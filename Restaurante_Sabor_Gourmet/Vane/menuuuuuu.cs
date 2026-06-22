using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.ConsultasSQL;
using Restaurante_Sabor_Gourmet.Vane;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public partial class menuuuuuu : Form
    {
        // ─────────────────────────────────────────
        // VARIABLES DE ESTADO
        // ─────────────────────────────────────────
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;
        private int idProductoSeleccionado = 0;
        private bool modoEdicion = false;

        // ─────────────────────────────────────────
        // DAOs
        // ─────────────────────────────────────────
        private readonly SQLMenu sqlMenu = new SQLMenu();

        // ─────────────────────────────────────────
        // CONSTRUCTOR
        // ─────────────────────────────────────────
        public menuuuuuu(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion      = idUsuarioSesion;
            this.nombreUsuarioSesion  = nombreUsuarioSesion;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────
        private void FormMenu_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
            ConfigurarBotones(false);

            // Conectar eventos no definidos en el Designer
            gbtn_Agregar.Click += gbtn_Agregar_Click;
            gbtnLimpiar.Click  += gbtnLimpiar_Click;
            gbtn_Ver.Click     += gbtn_Ver_Click;
        }

        // ─────────────────────────────────────────
        // CARGAR DATOS
        // ─────────────────────────────────────────
        private void CargarCategorias()
        {
            // Combo de filtro (gcmbCategoria)
            gcmbCategoria.Items.Clear();
            gcmbCategoria.Items.Add("Todas");

            // Combo del formulario de datos (gcmbCategoria2)
            gcmbCategoria2.Items.Clear();

            List<string> categorias = sqlMenu.ObtenerCategorias();
            foreach (string cat in categorias)
            {
                gcmbCategoria.Items.Add(cat);
                gcmbCategoria2.Items.Add(cat);
            }

            gcmbCategoria.SelectedIndex  = 0;
            gcmbCategoria2.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            List<ProductoCatalogo> lista = sqlMenu.ObtenerTodosLosProductos();
            MostrarEnGrilla(lista);
        }

        private void MostrarEnGrilla(List<ProductoCatalogo> lista)
        {
            dgv_Lista.Rows.Clear();

            foreach (ProductoCatalogo p in lista)
            {
                dgv_Lista.Rows.Add(
                    p.CodigoProducto,
                    p.NombreProducto,
                    p.NombreCategoria,
                    p.PrecioVenta.ToString("C2"),
                    p.Descripcion,
                    p.Disponible ? "Sí" : "No"
                );

                // Colorear fila si no está disponible
                if (!p.Disponible)
                    dgv_Lista.Rows[dgv_Lista.Rows.Count - 1]
                             .DefaultCellStyle.ForeColor = Color.Gray;
            }

            label12.Text = $"Total: {lista.Count} producto(s)";
        }

        // ─────────────────────────────────────────
        // BOTÓN BUSCAR
        // ─────────────────────────────────────────
        private void gbtnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscar = gtxtBuscar.Text.Trim().ToLower();
            string catSeleccion = gcmbCategoria.SelectedItem?.ToString() ?? "Todas";

            List<ProductoCatalogo> todos = sqlMenu.ObtenerTodosLosProductos();
            List<ProductoCatalogo> filtrados = new List<ProductoCatalogo>();

            foreach (ProductoCatalogo p in todos)
            {
                bool coincideTexto = string.IsNullOrEmpty(textoBuscar)
                    || p.NombreProducto.ToLower().Contains(textoBuscar)
                    || p.CodigoProducto.ToLower().Contains(textoBuscar);

                bool coincideCategoria = catSeleccion == "Todas"
                    || p.NombreCategoria == catSeleccion;

                if (coincideTexto && coincideCategoria)
                    filtrados.Add(p);
            }

            MostrarEnGrilla(filtrados);
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA
        // ─────────────────────────────────────────
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgv_Lista.Rows[e.RowIndex];
            string codigo = fila.Cells["Codigo"].Value?.ToString();

            if (string.IsNullOrEmpty(codigo)) return;

            // Buscar el producto completo para llenar el panel
            List<ProductoCatalogo> todos = sqlMenu.ObtenerTodosLosProductos();
            ProductoCatalogo seleccionado = todos.Find(p => p.CodigoProducto == codigo);

            if (seleccionado != null)
            {
                idProductoSeleccionado = seleccionado.IdProducto;
                gtxtCodigo.Text        = seleccionado.CodigoProducto;
                gtxtNombre.Text        = seleccionado.NombreProducto;
                gtxtPrecio.Text        = seleccionado.PrecioVenta.ToString("F2");
                gtxtDescripcion.Text   = seleccionado.Descripcion;
                gTs_Disponible.Checked = seleccionado.Disponible;
                lblDisponible.Text     = seleccionado.Disponible ? "Activo" : "Inactivo";

                // Seleccionar categoría correspondiente en el combo
                gcmbCategoria2.SelectedItem = seleccionado.NombreCategoria;

                ConfigurarBotones(true);
            }
        }

        // ─────────────────────────────────────────
        // TOGGLE DISPONIBLE — actualizar label al cambiar
        // ─────────────────────────────────────────
        private void gTs_Disponible_CheckedChanged(object sender, EventArgs e)
        {
            lblDisponible.Text = gTs_Disponible.Checked ? "Activo" : "Inactivo";
        }

        // ─────────────────────────────────────────
        // BOTÓN AGREGAR — activa modo nuevo registro
        // ─────────────────────────────────────────
        private void gbtn_Agregar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            modoEdicion            = false;
            idProductoSeleccionado = 0;
            gtxtCodigo.ReadOnly    = false;
            gtxtCodigo.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN EDITAR — activa modo edición
        // ─────────────────────────────────────────
        private void gbtn_Editar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoEdicion         = true;
            gtxtCodigo.ReadOnly = true; // El código no se cambia al editar
            gtxtNombre.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN GUARDAR — inserta o actualiza
        // ─────────────────────────────────────────
        private void gbtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // Obtener id de la categoría seleccionada
            string nombreCat = gcmbCategoria2.SelectedItem?.ToString();
            List<string> cats = sqlMenu.ObtenerCategorias();
            int idCat = cats.IndexOf(nombreCat) + 1; // Aproximación — usar ObtenerIdCategoria si se agrega

            ProductoCatalogo p = new ProductoCatalogo
            {
                IdProducto           = idProductoSeleccionado,
                CodigoProducto       = gtxtCodigo.Text.Trim(),
                NombreProducto       = gtxtNombre.Text.Trim(),
                Descripcion          = gtxtDescripcion.Text.Trim(),
                TiempoPreparacionMin = 0, // Sin campo en el form — valor neutro
                PrecioVenta          = decimal.Parse(gtxtPrecio.Text.Trim()),
                Disponible           = gTs_Disponible.Checked,
                IdCategoria          = idCat,
                NombreCategoria      = nombreCat
            };

            bool resultado;

            if (!modoEdicion)
            {
                // Validar código duplicado
                if (sqlMenu.CodigoExiste(p.CodigoProducto))
                {
                    MessageBox.Show("Ya existe un producto con ese código.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                resultado = sqlMenu.InsertarProducto(p);
            }
            else
            {
                resultado = sqlMenu.ActualizarProducto(p);
            }

            if (resultado)
            {
                MessageBox.Show(modoEdicion ? "Producto actualizado correctamente."
                                            : "Producto agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarProductos();
                ConfigurarBotones(false);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto. Intenta de nuevo.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR — cambia disponible a false (soft-disable)
        // Los productos no se eliminan físicamente si tienen historial
        // ─────────────────────────────────────────
        private void gbtn_Eliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Deseas desactivar este producto del menú?\n" +
                "No se eliminará permanentemente.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool resultado = sqlMenu.CambiarDisponibilidad(idProductoSeleccionado, false);

            if (resultado)
            {
                MessageBox.Show("Producto desactivado del menú.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarProductos();
                ConfigurarBotones(false);
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN VER RECETA — abre frmRecetas filtrando por producto
        // ─────────────────────────────────────────
        private void gbtn_Ver_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto para ver su receta.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProducto = gtxtNombre.Text;
            frmRecetas frm = new frmRecetas(idProductoSeleccionado, nombreProducto,
                                            idUsuarioSesion, nombreUsuarioSesion);
            frm.ShowDialog();
        }

        // ─────────────────────────────────────────
        // BOTÓN LIMPIAR
        // ─────────────────────────────────────────
        private void gbtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            ConfigurarBotones(false);
        }

        // ─────────────────────────────────────────
        // LABEL2 CLICK (filtro rápido por categoría)
        // ─────────────────────────────────────────
        private void label2_Click(object sender, EventArgs e)
        {
            // Sin acción específica — el filtro lo maneja gcmbCategoria + gbtnBuscar
        }

        // ─────────────────────────────────────────
        // HELPERS
        // ─────────────────────────────────────────
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(gtxtCodigo.Text))
            {
                MessageBox.Show("El código del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gtxtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(gtxtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gtxtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(gtxtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gtxtPrecio.Focus();
                return false;
            }

            if (gcmbCategoria2.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona una categoría.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gcmbCategoria2.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            idProductoSeleccionado = 0;
            modoEdicion            = false;
            gtxtCodigo.Text        = "";
            gtxtNombre.Text        = "";
            gtxtPrecio.Text        = "";
            gtxtDescripcion.Text   = "";
            gcmbCategoria2.SelectedIndex = 0;
            gTs_Disponible.Checked = true;
            lblDisponible.Text     = "Activo";
            gtxtCodigo.ReadOnly    = false;
        }

        private void ConfigurarBotones(bool haySeleccion)
        {
            gbtn_Editar.Enabled   = haySeleccion;
            gbtn_Eliminar.Enabled = haySeleccion;
            gbtn_Ver.Enabled      = haySeleccion;
        }
    }
}
