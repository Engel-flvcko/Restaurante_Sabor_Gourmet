using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.clases
{
    internal class Promocion
    {
        public int IdPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public decimal PorcentajePromocion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
