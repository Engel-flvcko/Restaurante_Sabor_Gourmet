using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.clases
{
    internal class DescuentoAutorizado
    {
        public int IdDescuento { get; set; }
        public int IdOrden { get; set; }
        public int IdSupervisor { get; set; }
        public int IdCajero { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public string MotivoDescuento { get; set; }
        public DateTime FechaDescuento { get; set; }
    }
}
