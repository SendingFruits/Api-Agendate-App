using Microsoft.EntityFrameworkCore;
using Logic.Entities;

namespace Logic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Notificacion> Notificaciones { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Empresa>()
                .ToTable("Empresas");

            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

            modelBuilder.Entity<Servicio>()
                .ToTable("Servicios");

            modelBuilder.Entity<Location>()
                .ToTable("Locations");
        }
    }
}
