using BookLibrary.WebApplication.ApiConnection;
using CrossCutting.IoT;

namespace BookLibrary.WebApplication.Configurations
{
    public static class DeppendecyInjectionConfig
    {
        public static void AddDeppendecyInjectionConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IWebApiService, WebApiService>();

            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}
