using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public class MovimientoInventario
    {
        public int IdMovimiento { get; set; }
        public int IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }   // JOIN para mostrar en grilla
        public int IdUsuario { get; set; }
        public string TipoMovimiento { get; set; }      // 'Compra','Consumo','Ajuste','Desperdicio'
        public decimal Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Observacion { get; set; }
        public string NombreUsuario { get; set; }
    }

}
