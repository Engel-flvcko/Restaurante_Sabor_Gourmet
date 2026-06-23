using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class ColaCocina
    {
        public int IdCocina { get; set; }                  // id_cocina (PK)
        public int IdOrden { get; set; }                    // id_orden (FK -> tbl_ordenes)
        public string EstadoCocina { get; set; }            // estado_cocina: pendiente, en_preparacion, lista, entregada, cancelada
        public DateTime HoraRecepcion { get; set; }         // hora_recepcion
        public DateTime? HoraInicio { get; set; }           // hora_inicio
        public DateTime? HoraFinalizacion { get; set; }     // hora_finalizacion

        // Campos solo para mostrar en pantalla (vienen de JOIN con tbl_ordenes/tbl_mesas/tbl_detalle_orden)
        public int NumeroMesa { get; set; }
        public List<DetalleOrden> Productos { get; set; } = new List<DetalleOrden>();

        /// <summary>Minutos transcurridos desde la recepción hasta ahora (o hasta que finalizó).</summary>
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
