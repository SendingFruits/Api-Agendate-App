using Microsoft.EntityFrameworkCore;
using Logic.Entities;

namespace Logic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Empresas> Empresas { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Notificaciones> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Empresas>()
                .ToTable("Empresas");

            modelBuilder.Entity<Clientes>()
                .ToTable("Clientes");

            modelBuilder.Entity<Servicios>()
                .ToTable("Servicios");

        }

    }
}
