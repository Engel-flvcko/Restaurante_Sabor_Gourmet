using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Existencia { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal CostoUnitario { get; set; }
    }

}
