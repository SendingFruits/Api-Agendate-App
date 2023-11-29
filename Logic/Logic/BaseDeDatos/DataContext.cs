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

        public DbSet<HorariosServicios> HorariosServicios { get; set; }

        public DbSet<Horarios> Horarios { get; set; }

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

            modelBuilder.Entity<HorariosServicios>()
                .ToTable("HorariosServicios");

            modelBuilder.Entity<Horarios>()
                .ToTable("Horarios");


            #region Seeds de Horarios
            // Datos para horarios por hora
            for (int i = 1; i <= 24; i++)
            {
                modelBuilder.Entity<Horarios>().HasData(
                    new Horarios { Id = i, FechaHora = DateTime.Now.Date.AddHours(i - 1), Categoria = "Hora" }
                );
            }

            // Datos para horarios cada media hora
            for (int i = 25; i <= 72; i++)
            {
                int hour = (i - 24) / 2;
                int minute = (i - 24) % 2 * 30;
                modelBuilder.Entity<Horarios>().HasData(
                    new Horarios { Id = i, FechaHora = DateTime.Now.Date.AddHours(hour).AddMinutes(minute), Categoria = "Media" }
                );
            }

            // Datos para horarios cada 15 minutos
            for (int i = 73; i <= 144; i++)
            {
                int hour = (i - 72) / 4;
                int minute = (i - 72) % 4 * 15;
                modelBuilder.Entity<Horarios>().HasData(
                    new Horarios { Id = i, FechaHora = DateTime.Now.Date.AddHours(hour).AddMinutes(minute), Categoria = "Cuarto" }
                );
            }
            #endregion
        }

    }
}
