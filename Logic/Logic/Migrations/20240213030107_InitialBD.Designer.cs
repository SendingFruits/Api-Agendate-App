﻿// <auto-generated />
using System;
using Logic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Logic.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240213030107_InitialBD")]
    partial class InitialBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Logic.Entities.Favoritos", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("recibirNotificaciones")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Logic.Entities.Notificaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("asunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correoDestinatario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cuerpo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaEnvio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("Logic.Entities.Promociones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AsuntoMensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuerpoMensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destinatarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimoEnvio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Promociones", (string)null);
                });

            modelBuilder.Entity("Logic.Entities.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHoraTurno")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("FechaRealizada")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Logic.Entities.Servicios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuracionTurno")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("JSONDiasHorariosDisponibilidadServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Servicios", (string)null);
                });

            modelBuilder.Entity("Logic.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(4);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(3);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(2);

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Logic.Entities.Clientes", b =>
                {
                    b.HasBaseType("Logic.Entities.Usuarios");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("Documento")
                        .IsUnique()
                        .HasFilter("[Documento] IS NOT NULL");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Logic.Entities.Empresas", b =>
                {
                    b.HasBaseType("Logic.Entities.Usuarios");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("NombrePropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rubro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RutDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("RutDocumento")
                        .IsUnique()
                        .HasFilter("[RutDocumento] IS NOT NULL");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("Logic.Entities.Favoritos", b =>
                {
                    b.HasOne("Logic.Entities.Clientes", "Cliente")
                        .WithMany("Favoritos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Logic.Entities.Servicios", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Logic.Entities.Promociones", b =>
                {
                    b.HasOne("Logic.Entities.Empresas", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Logic.Entities.Reservas", b =>
                {
                    b.HasOne("Logic.Entities.Clientes", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Logic.Entities.Servicios", "Servicio")
                        .WithMany("Reservas")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Logic.Entities.Servicios", b =>
                {
                    b.HasOne("Logic.Entities.Empresas", "Empresa")
                        .WithMany("Servicios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Logic.Entities.Clientes", b =>
                {
                    b.HasOne("Logic.Entities.Usuarios", null)
                        .WithOne()
                        .HasForeignKey("Logic.Entities.Clientes", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logic.Entities.Empresas", b =>
                {
                    b.HasOne("Logic.Entities.Usuarios", null)
                        .WithOne()
                        .HasForeignKey("Logic.Entities.Empresas", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logic.Entities.Servicios", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Logic.Entities.Clientes", b =>
                {
                    b.Navigation("Favoritos");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Logic.Entities.Empresas", b =>
                {
                    b.Navigation("Servicios");
                });
#pragma warning restore 612, 618
        }
    }
}