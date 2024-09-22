using Microsoft.EntityFrameworkCore;
using SegundoModulo.Models;

namespace SegundoModulo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define tus DbSets aquí
        public DbSet<Prueba> Pruebas { get; set; }
    }
}
