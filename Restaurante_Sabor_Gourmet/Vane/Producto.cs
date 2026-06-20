using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int TiempoPreparacionMin { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Disponible { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } 
    }

}
