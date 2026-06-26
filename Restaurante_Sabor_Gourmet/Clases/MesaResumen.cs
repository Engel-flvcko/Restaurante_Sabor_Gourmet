using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class MesaResumen
    {
        public int IdMesa { get; set; }                  
        public int NumeroMesa { get; set; }            
        public string EstadoMesa { get; set; }          
        public int? IdMeseroAsignado { get; set; }      
        public string TextoComboBox { get; set; }
        public int Capacidad { get; set; }   
        public string NombreZona { get; set; }
        public string NombreMeseroAsignado { get; set; }
    }
}
