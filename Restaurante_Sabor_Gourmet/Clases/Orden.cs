using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Orden
    {
        public int IdOrden { get; set; }                  
        public int IdMesaOrden { get; set; }              
        public int IdMeseroOrden { get; set; }             
        public DateTime FechaHoraOrden { get; set; }      
        public string EstadoOrden { get; set; }           
        public string Observaciones { get; set; }          

        public int NumeroMesa { get; set; }
        public string NombreMesero { get; set; }

        public List<DetalleOrden> Detalles { get; set; } = new List<DetalleOrden>();

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (DetalleOrden d in Detalles)
                    total += d.Subtotal;
                return total;
            }
        }
    }
}
