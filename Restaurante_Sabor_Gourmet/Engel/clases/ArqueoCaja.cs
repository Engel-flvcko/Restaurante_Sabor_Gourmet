using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Engel.clases
{
    internal class ArqueoCaja
    {
        public int IdArqueo { get; set; }
        public int IdCajero { get; set; }
        public DateTime FechaApertura { get; set; }
        public decimal FondoInicial { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal TotalEsperado { get; set; }
        public decimal TotalContado { get; set; }
        public decimal Diferencia { get; set; }
        public string Estado { get; set; }
    }
}
