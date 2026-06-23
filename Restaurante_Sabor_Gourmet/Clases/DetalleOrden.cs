using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class DetalleOrden
    {
        public int IdDetalle { get; set; }                  // id_detalle (PK)
        public int IdOrdenDetalle { get; set; }              // id_orden_detalle (FK -> tbl_ordenes)
        public int IdProductoDetalle { get; set; }           // id_producto_detalle (FK -> tbl_productos)
        public int CantidadDetalle { get; set; }             // cantidad_detalle
        public decimal PrecioUnitarioDetalle { get; set; }   // precio_unitario_detalle
        public string Observaciones { get; set; }            // observaciones

        // Solo para mostrar en pantalla (viene de JOIN con tbl_productos)
        public string NombreProducto { get; set; }

        /// <summary>Cantidad * precio unitario. No es columna en BD, se calcula en memoria.</summary>
        public decimal Subtotal => CantidadDetalle * PrecioUnitarioDetalle;
    }
}
