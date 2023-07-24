using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARKET_PLACE.Entities
{
    public class Producto_Descripcion
    {
        
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
