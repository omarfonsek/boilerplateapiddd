using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class MiggrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();

            var sqlFilePath = Path.Combine(AppContext.BaseDirectory, "SeedData", "SeedDataSIGHU.sql");

            // Inicializa los datos
            DataSeeder.SeedData(dbContext, sqlFilePath);
        }
    }
}
