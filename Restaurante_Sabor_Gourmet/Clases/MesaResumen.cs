using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class MesaResumen
    {
        public int IdMesa { get; set; }                  // id_mesa
        public int NumeroMesa { get; set; }              // numero_mesa
        public string EstadoMesa { get; set; }           // estado_mesa
        public int? IdMeseroAsignado { get; set; }       // id_mesero_asignado (FK -> tbl_usuarios)

        // Solo para mostrar en pantalla (vienen de JOIN)
        public string NombreZona { get; set; }
        public string NombreMeseroAsignado { get; set; }
    }
}
