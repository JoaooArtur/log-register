using LogRegister.Infrastructure.Options;

namespace LogRegister.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigureOptions(this IServiceCollection services)
           => services
            .ConfigureOptions<DatadogOptions>();

        private static IServiceCollection ConfigureOptions<TOptions>(this IServiceCollection services)
            where TOptions : class
           => services
            .AddOptions<TOptions>()
            .BindConfiguration(typeof(TOptions).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
    }

}
