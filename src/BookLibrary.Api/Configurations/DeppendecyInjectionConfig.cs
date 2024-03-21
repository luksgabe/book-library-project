using CrossCutting.IoT;

namespace BookLibrary.Api.Configurations
{
    public static class DeppendecyInjectionConfig
    {

        public static void AddDeppendecyInjectionConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}
