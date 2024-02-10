﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Reservas> Reservas { get; set; }

        public DbSet<Promociones> Promociones { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }

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

            modelBuilder.Entity<Promociones>()
                .ToTable("promociones");

            modelBuilder.Entity<Servicios>()
            .HasOne(s => s.Empresa)
            .WithMany(c => c.Servicios)
            .HasForeignKey(s => s.EmpresaId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Cliente)
            .WithMany(c => (ICollection<Reservas>)c.Reservas)
            .HasForeignKey(r => r.ClienteId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservas>()
                .HasOne(r => r.Servicio)
                .WithMany(s => s.Reservas)
                .HasForeignKey(r => r.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favoritos>()
            .HasOne(s => s.Cliente)
            .WithMany(c => c.Favoritos)
            .HasForeignKey(s => s.ClienteId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
