using LogRegister.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Serilog;

namespace LogRegister.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();
            var datadogOptions = serviceProvider.GetRequiredService<IOptions<DatadogOptions>>().Value;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.DatadogLogs(
                apiKey: datadogOptions.ApiKey,
                source: "LogRegister",
                service: "LogRegister",
                host: "dockerfile-local",
                tags: new[] { "env:local" },
                logLevel: Serilog.Events.LogEventLevel.Debug)
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


            return builder.Host.UseSerilog();
        }

        public static IHostBuilder ConfigureServiceProvider(this IHostBuilder builder)
            => builder.UseDefaultServiceProvider((context, provider)
                => provider.ValidateScopes =
                    provider.ValidateOnBuild =
                        context.HostingEnvironment.IsDevelopment());

        public static IHostBuilder ConfigureAppConfiguration(this IHostBuilder builder)
            => builder.ConfigureAppConfiguration(configuration
                => configuration
                    .AddUserSecrets<Program>()
                    .AddEnvironmentVariables());
    }
}
