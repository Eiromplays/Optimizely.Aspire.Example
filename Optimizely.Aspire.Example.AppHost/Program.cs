using Optimizely.Aspire.Example.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

const string dbName = "EPiServerDB";

var sql = builder.AddSqlServerWithCustomImage("sql", dbName: dbName)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var epiServerDb = sql.AddDatabase(dbName);

builder.AddProject<Projects.Optimizely_CMS>("cms")
    .WithReference(epiServerDb)
    .WaitFor(sql);

builder.Build().Run();
