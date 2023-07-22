using Microsoft.EntityFrameworkCore;
using Logic.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Empresa>()
                .ToTable("Empresas");

            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");
            
            
            for (int i =1; i < 10; i++)
            {

                modelBuilder.Entity<Empresa>().HasData(new Empresa
                {
                    Id= i,
                    Nombre = "NombreEmpresa" + i,
                    Apellido = "ApellidoEmpresa" + i,
                    Celular = "099" + i + "2332" + i,
                    Contrasenia = "Contrasenia" + i,
                    NombrePropietario = "Propietario de la empresa" + i,
                    Correo = "Nombre" + i + "@gmail.com",
                    NombreUsuario = "NombreUsu" + i + "Emp",
                    Calle = "calle  " + i ,
                    NumeroPuerta = " 2" + i + "3" + i,
                    RazonSocial = "Empresa " + i,
                    Ciudad = "Montevideo",
                    Descripcion = "desripcion empresa " + i,
                    RutDocumento = "23456789" + i,
                    
                    Rubro = "Rubro " + i,
                    Latitud = -34.9047715683992 + i,
                    Longitud = -56.18086220696568 + (i + 2)
                }); ;

              

            }


            for (int i=10; i> 20; i++)
            {
                modelBuilder.Entity<Cliente>().HasData(new Cliente
                {
                    Id= i,
                    Nombre = "NombreCliente" + i,
                    Apellido = "ApellidoCliente" + i,
                    Documento = "123456" + i,
                    Celular = "099" + i + "2332" + i,
                    Contrasenia = "NombreCliente" + i,
                    Correo = "NombreCliente" + i + "@gmail.com",
                    NombreUsuario = "NombreCliente" + i + "Cli"

                });

            }

        }
    }
}
