using MARKET_PLACE.Context;
using MARKET_PLACE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_PLACE.Services
{
    public class ProductosServis
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public Producto? GetProductoById(int id)
        {
            return this.db.Productos
                .Include(p => p.Generos)
                .FirstOrDefault(p => p.PkProducto == id);
        }

        public Genero? GetGenero(int id)
        {
            return this.db.Generos
                .FirstOrDefault(p => p.PkGenero == id);
        }
        public List<Producto> GetAllProductos()
        {
            return this.db.Productos
                .Include(p => p.Generos)
                .ToList();
        }

        public Producto? AddProducto(Producto producto)
        {
            try
            {
                this.db.Productos.Add(producto);
                this.db.SaveChanges();
                return producto;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool UpdateProducto(Producto producto)
        {
            try
            {
                Producto? existe = this.db.Productos.FirstOrDefault(p => p.PkProducto == producto.PkProducto);

                if (existe == null)
                {
                    return false;
                }

                this.db.Productos.Update(producto);

                this.db.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteProducto(int id)
        {
            try
            {
                Producto? producto = this.db.Productos.FirstOrDefault(p => p.PkProducto == id);

                if (producto == null)
                    return false;

                this.db.Productos.Remove(producto);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}

