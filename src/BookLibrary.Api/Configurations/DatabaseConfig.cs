using BookLibrary.Data.Context;
using BookLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EventStoreSqlContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void CreateDatabaseIfNotExists(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
