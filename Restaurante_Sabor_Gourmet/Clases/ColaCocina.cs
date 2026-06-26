using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class ColaCocina
    {
        public int IdCocina { get; set; }                 
        public int IdOrden { get; set; }                    
        public string EstadoCocina { get; set; }            
        public DateTime HoraRecepcion { get; set; }         
        public DateTime? HoraInicio { get; set; }           
        public DateTime? HoraFinalizacion { get; set; }    

        public int NumeroMesa { get; set; }
        public List<DetalleOrden> Productos { get; set; } = new List<DetalleOrden>();

        public double MinutosTranscurridos
        {
            get
            {
                DateTime referencia = HoraFinalizacion ?? DateTime.Now;
                return (referencia - HoraRecepcion).TotalMinutes;
            }
        }
    }
}
