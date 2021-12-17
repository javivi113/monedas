using Microsoft.EntityFrameworkCore;

namespace monedas.Models
{
    public class MonedaContext : DbContext
    {
        public MonedaContext(DbContextOptions<MonedaContext> options)
            : base(options)
        {
        }

        public DbSet<Monedas> Monedas { get; set; }
    }
}