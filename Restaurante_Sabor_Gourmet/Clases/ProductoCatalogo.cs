using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_Sabor_Gourmet.Clases
{
    internal class ProductoCatalogo
    {
        public int IdProducto { get; set; }           // id_producto
        public string CodigoProducto { get; set; }    // codigo_producto
        public string NombreProducto { get; set; }    // nombre_producto
        public string Descripcion { get; set; }       // descripcion  ← AGREGADO
        public int TiempoPreparacionMin { get; set; } // tiempo_preparacion_min  ← AGREGADO
        public decimal PrecioVenta { get; set; }      // precio_venta
        public bool Disponible { get; set; }          // disponible
        public int IdCategoria { get; set; }          // id_categoria (FK -> tbl_categorias)
        public string NombreCategoria { get; set; }   // JOIN con tbl_categorias
    }
}

