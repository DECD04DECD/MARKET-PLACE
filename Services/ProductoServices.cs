using MARKET_PLACE.Context;
using MARKET_PLACE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_PLACE.Services
{
    public class ProductoServices
    {
        #region Agregar Producto
        public void AddProducto(Producto request)
        {
            try
            {
                if (request != null)
                {
                    using (var _Context = new ApplicationDbContext())
                    {
                        Producto producto = new Producto();
                        producto.Nombre = request.Nombre;
                        producto.Precio = request.Precio;
                        producto.Cantidad = request.Cantidad;
                        producto.PkProducto = request.PkProducto;
                        producto.Generos = request.Generos;

                        _Context.Add(producto);
                        _Context.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
        #endregion
    }
}
