using System.Collections.Generic;

namespace Restaurante_Sabor_Gourmet.Vane
{
    internal class IngredienteDAO
    {
        public List<Ingrediente> ObtenerTodosLosIngredientes()
        {
            return new List<Ingrediente>();
        }

        public bool InsertarIngrediente(Ingrediente i)
        {
            return true;
        }

        public bool ActualizarExistencia(int idIngrediente, decimal nuevaExistencia)
        {
            return true;
        }

        public List<Ingrediente> ObtenerIngredientesBajoStock()
        {
            return new List<Ingrediente>();
        }
    }
}