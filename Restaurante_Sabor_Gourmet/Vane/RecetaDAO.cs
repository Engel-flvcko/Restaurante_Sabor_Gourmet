using System.Collections.Generic;

namespace Restaurante_Sabor_Gourmet.Vane
{
    internal class RecetaDAO
    {
        public List<Receta> ObtenerRecetaPorProducto(int idProducto)
        {
            return new List<Receta>();
        }

        public bool AgregarIngredienteAReceta(Receta r)
        {
            return true;
        }

        public bool EliminarIngredienteDeReceta(int idReceta)
        {
            return true;
        }
    }
}