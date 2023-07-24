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
            options.UseMySQL("server= localhost; database= MarketZone; user= root; password=");
        }

        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Rol> Roles { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        

    }
}
