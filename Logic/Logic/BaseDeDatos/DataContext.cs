using Microsoft.EntityFrameworkCore;
using Logic.Entities;

namespace Logic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
