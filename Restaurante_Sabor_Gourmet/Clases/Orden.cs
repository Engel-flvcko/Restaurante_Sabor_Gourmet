using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class Orden
    {
        public int IdOrden { get; set; }                  // id_orden (PK)
        public int IdMesaOrden { get; set; }               // id_mesa_orden (FK , tbl_mesas)
        public int IdMeseroOrden { get; set; }             // id_mesero_orden (FK . tbl_usuarios)
        public DateTime FechaHoraOrden { get; set; }       // fecha_hora_orden
        public string EstadoOrden { get; set; }            // estado_orden: abierta, pendiente_pago, pagada, cancelada
        public string Observaciones { get; set; }          // observaciones

        // Campos solo para mostrar en pantalla , vienen de JOIN, no son columnas de tbl_ordenes
        public int NumeroMesa { get; set; }
        public string NombreMesero { get; set; }

        public List<DetalleOrden> Detalles { get; set; } = new List<DetalleOrden>();

        /// <summary>Suma de los subtotales de todos los detalles de la orden.</summary>
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (DetalleOrden d in Detalles)
                    total += d.Subtotal;
                return total;
            }
        }
    }
}
