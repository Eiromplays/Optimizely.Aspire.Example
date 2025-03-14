namespace Optimizely.CMS;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder => loggingBuilder.AddOpenTelemetry(logging =>
            {
                logging.IncludeFormattedMessage = true;
                logging.IncludeScopes = true;
            }))
            .ConfigureCmsDefaults()
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
