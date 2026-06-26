using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class DetalleOrden
    {
        public int IdDetalle { get; set; }                  
        public int IdOrdenDetalle { get; set; }              
        public int IdProductoDetalle { get; set; }           
        public int CantidadDetalle { get; set; }             
        public decimal PrecioUnitarioDetalle { get; set; }   
        public string Observaciones { get; set; }            

        public string NombreProducto { get; set; }

        public decimal Subtotal => CantidadDetalle * PrecioUnitarioDetalle;
    }
}
