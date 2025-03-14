using Microsoft.Extensions.DependencyInjection;

namespace Optimizely.Aspire.Example.AppHost;

public static class SqlServerBuilderExtensions
{
    public static IResourceBuilder<SqlServerServerResource> AddSqlServerWithCustomImage(this IDistributedApplicationBuilder builder, [ResourceName] string name, IResourceBuilder<ParameterResource>? password = null, int? port = null, string? dbName = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrEmpty(name);

        dbName ??= "Optimizely.CMS";

        // The password must be at least 8 characters long and contain characters from three of the following four sets: Uppercase letters, Lowercase letters, Base 10 digits, and Symbols
        var passwordParameter = password?.Resource ?? ParameterResourceBuilderExtensions.CreateDefaultPasswordParameter(builder, $"{name}-password", minLower: 1, minUpper: 1, minNumeric: 1);

        var sqlServer = new SqlServerServerResource(name, passwordParameter);

        string? connectionString = null;

        builder.Eventing.Subscribe<ConnectionStringAvailableEvent>(sqlServer, async (@event, ct) =>
        {
            connectionString = await sqlServer.GetConnectionStringAsync(ct).ConfigureAwait(false);

            if (connectionString == null)
            {
                throw new DistributedApplicationException($"ConnectionStringAvailableEvent was published for the '{sqlServer.Name}' resource but the connection string was null.");
            }
        });

        var healthCheckKey = $"{name}_check";
        builder.Services.AddHealthChecks().AddSqlServer(sp => connectionString ?? throw new InvalidOperationException("Connection string is unavailable"), name: healthCheckKey);

        return builder.AddResource(sqlServer)
                      .WithEndpoint(port: port, targetPort: 1433, name: "tcp")
                      .WithImage("mssql/server", "2022-latest")
                      .WithImageRegistry("mcr.microsoft.com")
                      .WithDockerfile("./Docker/Database", "Dockerfile")
                      .WithBuildSecret("db-password", sqlServer.PasswordParameter)
                      .WithBuildArg("DB_NAME", dbName)
                      .WithBuildArg("DB_DIRECTORY", dbName)
                      .WithEnvironment(context =>
                      {
                          context.EnvironmentVariables["MSSQL_SA_PASSWORD"] = sqlServer.PasswordParameter;
                          context.EnvironmentVariables["SA_PASSWORD"] = sqlServer.PasswordParameter;
                          context.EnvironmentVariables["DB_NAME"] = dbName;
                          context.EnvironmentVariables["DB_DIRECTORY"] = dbName;
                      })
                      .WithHealthCheck(healthCheckKey);
    }
}