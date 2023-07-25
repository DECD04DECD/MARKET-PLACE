﻿// <auto-generated />
using System;
using MARKET_PLACE.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MARKET_PLACE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230725124418_Example")]
    partial class Example
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GeneroProducto", b =>
                {
                    b.Property<int>("GenerosPkGenero")
                        .HasColumnType("int");

                    b.Property<int>("ProductosPkProducto")
                        .HasColumnType("int");

                    b.HasKey("GenerosPkGenero", "ProductosPkProducto");

                    b.HasIndex("ProductosPkProducto");

                    b.ToTable("GeneroProducto");
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Genero", b =>
                {
                    b.Property<int>("PkGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreG")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkGenero");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            PkGenero = 1,
                            NombreG = "Electrónicos"
                        },
                        new
                        {
                            PkGenero = 2,
                            NombreG = "Moda"
                        },
                        new
                        {
                            PkGenero = 3,
                            NombreG = "Belleza y cuidado personal"
                        },
                        new
                        {
                            PkGenero = 4,
                            NombreG = "Deportes"
                        });
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Producto", b =>
                {
                    b.Property<int>("PkProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkProducto");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            PkProducto = 3,
                            Nombre = "Maquillaje"
                        },
                        new
                        {
                            PkProducto = 2,
                            Nombre = "Playera"
                        },
                        new
                        {
                            PkProducto = 1,
                            Nombre = "Telefono"
                        },
                        new
                        {
                            PkProducto = 4,
                            Nombre = "Balon"
                        });
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Producto_Descripcion", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("ProductoId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Producto_Descripcion");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            GeneroId = 1
                        },
                        new
                        {
                            ProductoId = 2,
                            GeneroId = 2
                        },
                        new
                        {
                            ProductoId = 3,
                            GeneroId = 3
                        },
                        new
                        {
                            ProductoId = 4,
                            GeneroId = 4
                        });
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            PkRol = 2,
                            Nombre = "Vendedor"
                        },
                        new
                        {
                            PkRol = 3,
                            Nombre = "Comprador"
                        });
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1,
                            FkRol = 1,
                            Nombre = "Diego",
                            Password = "1234",
                            UserName = "Admin1"
                        },
                        new
                        {
                            PkUsuario = 2,
                            FkRol = 2,
                            Nombre = "Maximiliano",
                            Password = "1212",
                            UserName = "User1"
                        },
                        new
                        {
                            PkUsuario = 3,
                            FkRol = 3,
                            Nombre = "Adamaris",
                            Password = "pato",
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("GeneroProducto", b =>
                {
                    b.HasOne("MARKET_PLACE.Entities.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosPkGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MARKET_PLACE.Entities.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductosPkProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Producto_Descripcion", b =>
                {
                    b.HasOne("MARKET_PLACE.Entities.Genero", "NomGenero")
                        .WithMany("ProductosGenero")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MARKET_PLACE.Entities.Producto", "NomProducto")
                        .WithMany("ProductosGenero")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NomGenero");

                    b.Navigation("NomProducto");
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Usuario", b =>
                {
                    b.HasOne("MARKET_PLACE.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Genero", b =>
                {
                    b.Navigation("ProductosGenero");
                });

            modelBuilder.Entity("MARKET_PLACE.Entities.Producto", b =>
                {
                    b.Navigation("ProductosGenero");
                });
#pragma warning restore 612, 618
        }
    }
}
