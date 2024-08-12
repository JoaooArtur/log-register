using Serilog;

namespace LogRegister.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
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
