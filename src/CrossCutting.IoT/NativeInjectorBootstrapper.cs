using BookLibrary.Application.AppServices;
using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoT
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //AppsServices
            services.AddScoped<IBookAppService, BookAppService>();


            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();

        }
    }
}