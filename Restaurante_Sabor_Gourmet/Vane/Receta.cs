using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public class Receta
    {
        public int IdReceta { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }      // JOIN para mostrar en grilla
        public int IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }   // JOIN para mostrar en grilla
        public string UnidadMedida { get; set; }        // JOIN para mostrar en grilla
        public decimal CantidadReceta { get; set; }
    }

}
