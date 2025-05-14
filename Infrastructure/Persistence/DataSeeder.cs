using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context, string sqlFilePath)
        {
            // Verifica si los datos ya están inicializados
            if (context.Employees.Any())
            {
                return; // Salir si ya hay datos
            }

            if (File.Exists(sqlFilePath))
            {
                // Lee el archivo SQL
                var sqlScript = File.ReadAllText(sqlFilePath);

                // Ejecuta el script SQL en la base de datos
                context.Database.ExecuteSqlRaw(sqlScript);
            }
        }
    }
}
