using DrogueriaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DrogueriaWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();
    }
}
