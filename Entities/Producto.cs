using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_PLACE.Entities
{
    public class Producto
    {
        public Producto()
        {
            ProductosGenero = new List<Producto_Descripcion>();
        }


        [Key]
        public int PkProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public List<Genero> Generos { get; set; }
        public ICollection<Producto_Descripcion> ProductosGenero { get; set; }
    }
}
