using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currentAssembly = typeof(AppDbContext).Assembly;
            var efMappingTypes = currentAssembly.GetTypes().Where(t =>
                t.FullName.StartsWith("BookLibrary.Infra.Data.Mapping.") &&
                t.FullName.EndsWith("Map"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}
