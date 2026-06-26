using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.clases
{
    internal class Pago
    {
        public int IdPago { get; set; }
        public int IdOrden { get; set; }
        public int IdCajero { get; set; }
        public int IdArqueo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Propina { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
