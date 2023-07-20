﻿using MARKET_PLACE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MySqlX.XDevAPI.Relational;
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
            options.UseMySQL("server =localhost; database= Marketplace23BM; user= root; password=");
        }
        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Rol> Roles { get; set; }
        
    }
}
