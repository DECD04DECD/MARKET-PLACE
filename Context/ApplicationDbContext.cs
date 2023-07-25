using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MARKET_PLACE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_PLACE.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server= localhost; database= Market_Zone23BM; user= root; password=");
        }

        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Rol> Roles { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        #region aaaa
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto_Descripcion>()
                .HasKey(pd => new { pd.ProductoId, pd.GeneroId }); // Especificar la clave primaria compuesta de la tabla de asociación

            modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(pd => pd.NomProducto) // Indicar la propiedad de navegación que representa el Producto
                .WithMany(p => p.ProductosGenero) // Indicar la propiedad de navegación en Producto que representa las descripciones de productos
                .HasForeignKey(pd => pd.ProductoId);

            modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(pd => pd.NomGenero) // Indicar la propiedad de navegación que representa el Genero
                .WithMany(g => g.ProductosGenero) // Indicar la propiedad de navegación en Genero que representa las descripciones de productos
                .HasForeignKey(pd => pd.GeneroId);
        }
        */
        #endregion

        #region BBBB
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto_Descripcion>()
               .HasKey(ep => new { ep.NomProducto, ep.GeneroId });

            modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(ep => ep.NomGenero)
                .WithMany(e => e.ProductosGenero)
                .HasForeignKey(ep => ep.GeneroId);

           modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(ep => ep.NomProducto)
                .WithMany(p => p.ProductosGenero)
                .HasForeignKey(ep => ep.ProductoId);

            // Insert para la tabla de Usuarios
           modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Diego",
                    UserName = "Admin1",
                    Password = "1234",
                    FkRol = 1 // Aquí debes proporcionar el ID del rol correspondiente
                },
                new Usuario
                {
                    PkUsuario = 2,
                    Nombre = "Maximiliano",
                    UserName = "user1",
                   Password = "5678",
                    FkRol = 2 // Aquí debes proporcionar el ID del rol correspondiente
                }
            // Agrega más usuarios si es necesario
            );

            // Insert para la tabla de Roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Administrador"
                },
                new Rol
                {
                    PkRol = 2,
                    Nombre = "Vendedor"
                }
            // Agrega más roles si es necesario
            );

            // Insert para la tabla de Generos
            modelBuilder.Entity<Genero>().HasData(
                new Genero
                {
                    PkGenero = 1,
                    NombreG = "Electrónicos"
                },
                new Genero
                {
                    PkGenero = 2,
                    NombreG = "Moda"
                },
                new Genero
                {
                    PkGenero = 4,
                    NombreG = "Belleza y cuidado personal"
                },
                new Genero
                {
                    PkGenero = 5,
                   NombreG = "Deportes"
                },
                new Genero
                {
                    PkGenero = 6,
                    NombreG = "Juguetes"
                },
                new Genero
                {
                    PkGenero = 7,
                    NombreG = "Mascotas"
                }

            );

            // Insert para la tabla de Peliculas
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {

                    PkProducto = 3,
                    Nombre = "Maquillaje"

                },
                new Producto
                {
                    PkProducto = 4,
                    Nombre = "Playera"

                },
                new Producto
                {
                    PkProducto = 1,
                    Nombre = "Telefono"

                },
                new Producto
                {
                    PkProducto = 2,
                    Nombre = "Playera"
                }

            );
        }*/
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto_Descripcion>()
                .HasKey(ep => new { ep.ProductoId, ep.GeneroId }); // Especificar la clave primaria compuesta de la tabla de asociación

            modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(ep => ep.NomGenero)
                .WithMany(e => e.ProductosGenero)
                .HasForeignKey(ep => ep.GeneroId);

            modelBuilder.Entity<Producto_Descripcion>()
                .HasOne(ep => ep.NomProducto)
                .WithMany(p => p.ProductosGenero)
                .HasForeignKey(ep => ep.ProductoId);

            // Insert para la tabla de Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Diego",
                    UserName = "Admin1",
                    Password = "1234",
                    FkRol = 1
                },
                new Usuario
                {
                    PkUsuario = 2,
                    Nombre = "Maximiliano",
                    UserName = "User1",
                    Password = "1212",
                    FkRol = 2
                },
                new Usuario
                {
                    PkUsuario = 3,
                    Nombre = "Adamaris",
                    UserName = "User2",
                    Password = "pato",
                    FkRol = 3
                }
            // Agregar datos iniciales para usuarios
            );

            // Insert para la tabla de Roles
            modelBuilder.Entity<Rol>().HasData(
            // Agregar datos iniciales para roles
                new Rol
                {
                PkRol = 1,
                Nombre = "Administrador"
                },
                new Rol
                {
                    PkRol = 2,
                    Nombre = "Vendedor"
                },
                new Rol
                {
                    PkRol = 3,
                    Nombre = "Comprador"
                }
            );

            // Insert para la tabla de Generos
            modelBuilder.Entity<Genero>().HasData(
            // Agregar datos iniciales para géneros
            new Genero
            {
                PkGenero = 1,
                NombreG = "Electrónicos"
            },
                new Genero
                {
                    PkGenero = 2,
                    NombreG = "Moda"
                },
                new Genero
                {
                    PkGenero = 3,
                    NombreG = "Belleza y cuidado personal"
                },
                new Genero
                {
                    PkGenero = 4,
                    NombreG = "Deportes"
                }
            );

            // Insert para la tabla de Productos
            modelBuilder.Entity<Producto>().HasData(
            // Agregar datos iniciales para productos
                
                new Producto
                {

                 PkProducto = 3,
                 Nombre = "Maquillaje"

                },
                new Producto
                {
                    PkProducto = 2,
                    Nombre = "Playera"

                },
                new Producto
                {
                    PkProducto = 1,
                    Nombre = "Telefono"

                },
                new Producto
                {
                    PkProducto = 4,
                    Nombre = "Balon"
                }
            );

            // Insert para la tabla de Producto_Descripcion (asociaciones entre productos y géneros)
            modelBuilder.Entity<Producto_Descripcion>().HasData(
                // Agregar instancias de Producto_Descripcion para relacionar productos con sus géneros correspondientes
                new Producto_Descripcion { ProductoId = 1, GeneroId = 1 }, // Producto "Telefono" relacionado con Genero "Electrónicos"
                new Producto_Descripcion { ProductoId = 2, GeneroId = 2 }, // Producto "Playera" relacionado con Genero "Moda"
                new Producto_Descripcion { ProductoId = 3, GeneroId = 3 }, // Producto "Maquillaje" relacionado con Genero "Belleza y cuidado personal"
                new Producto_Descripcion { ProductoId = 4, GeneroId = 4 }  // Producto "Playera" relacionado con Genero "Moda"
                                                                           // Agrega más instancias de Producto_Descripcion para más asociaciones si es necesario
            );
        }

    }
}
//Hola Max