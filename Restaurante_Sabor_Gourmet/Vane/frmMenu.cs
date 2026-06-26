using Restaurante_Sabor_Gourmet.Clases;
using Restaurante_Sabor_Gourmet.ConsultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Vane
{
    public partial class frmMenu : Form
    {

        // ─────────────────────────────────────────
        // VARIABLES DE ESTADO
        // ─────────────────────────────────────────
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        private int idProductoSeleccionado = 0;
        private bool modoEdicion = false;

        private int idCategoriaSeleccionada = 0;

        private List<ProductoCatalogo> todosLosProductos = new List<ProductoCatalogo>();
        private Dictionary<string, int> mapaCategorias = new Dictionary<string, int>();

        private readonly SQLMenu sqlMenu = new SQLMenu();

        // ─────────────────────────────────────────
        // CONSTRUCTOR
        // ─────────────────────────────────────────
        public frmMenu(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────
        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────
        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = nombreUsuarioSesion;

            CargarCategoriasEnCombos();
            CargarProductos();
            CargarGrillaCategorias();

            EstadoInicial();

            btnEliminarCategoria.Enabled = false;
            txtNombreCategoria.Text = "";
        }

        private void EstadoInicial()
        {
            idProductoSeleccionado = 0;
            modoEdicion = false;

            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtTiempoPrep.Text = "";
            tglDisponible.Checked = true;
            lblDisponibleTexto.Text = "Sí";
            lblFormTitulo.Text = "Datos del Producto";

            BloquearCampos(true);

            btnNuevoProducto.Text = "Nuevo";
            btnNuevoProducto.Enabled = true;   // ← siempre visible y activo
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void EstadoSeleccionado(ProductoCatalogo p)
        {
            idProductoSeleccionado = p.IdProducto;
            modoEdicion = false;

            txtCodigo.Text = p.CodigoProducto;
            txtNombreProducto.Text = p.NombreProducto;
            txtDescripcion.Text = p.Descripcion;
            txtPrecio.Text = p.PrecioVenta.ToString("F2");
            txtTiempoPrep.Text = p.TiempoPreparacionMin.ToString();
            tglDisponible.Checked = p.Disponible;
            lblDisponibleTexto.Text = p.Disponible ? "Sí" : "No";
            lblDisponibleTexto.ForeColor = p.Disponible
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);

            if (mapaCategorias.ContainsValue(p.IdCategoria))
                cmbCategoria.SelectedItem = p.NombreCategoria;

            lblFormTitulo.Text = $"Producto: {p.NombreProducto}";

            BloquearCampos(true);

            btnNuevoProducto.Text = "Nuevo";
            btnNuevoProducto.Enabled = true;   // ← activo para poder crear uno nuevo
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void EstadoEditando(bool esNuevo)
        {
            BloquearCampos(false);

            lblFormTitulo.Text = esNuevo ? "Nuevo Producto" : "Editando producto...";

            btnNuevoProducto.Text = "Guardar";
            btnNuevoProducto.Enabled = true;   // ← ESTE es el fix principal
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        // ─────────────────────────────────────────
        // ESTADOS DEL FORMULARIO
        // ─────────────────────────────────────────



        private void BloquearCampos(bool bloqueado)
        {
            txtNombreProducto.ReadOnly = bloqueado;
            txtDescripcion.ReadOnly = bloqueado;
            txtPrecio.ReadOnly = bloqueado;
            txtTiempoPrep.ReadOnly = bloqueado;
            cmbCategoria.Enabled = !bloqueado;
            tglDisponible.Enabled = !bloqueado;
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA
        // ─────────────────────────────────────────
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            int id = Convert.ToInt32(fila.Tag);
            ProductoCatalogo prod = todosLosProductos.Find(p => p.IdProducto == id);
            if (prod == null) return;

            EstadoSeleccionado(prod);
        }

        // ─────────────────────────────────────────
        // BOTÓN NUEVO / GUARDAR (doble función)
        // ─────────────────────────────────────────
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            // Si el botón dice "Guardar", ejecutar guardado
            if (btnNuevoProducto.Text == "Guardar")
            {
                Guardar();
                return;
            }

            // Si dice "Nuevo", preparar formulario vacío
            idProductoSeleccionado = 0;
            modoEdicion = false;

            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtTiempoPrep.Text = "";
            tglDisponible.Checked = true;
            lblDisponibleTexto.Text = "Sí";
            lblDisponibleTexto.ForeColor = Color.FromArgb(34, 197, 94);

            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;

            GenerarCodigoAutomatico();
            txtCodigo.ReadOnly = true;

            EstadoEditando(esNuevo: true);
            txtNombreProducto.Focus();
        }

        // ─────────────────────────────────────────
        // BOTÓN EDITAR
        // ─────────────────────────────────────────
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoEdicion = true;
            txtCodigo.ReadOnly = true;

            EstadoEditando(esNuevo: false);
            txtNombreProducto.Focus();
        }

        // ─────────────────────────────────────────
        // LÓGICA DE GUARDADO (usado por btnNuevoProducto en modo Guardar)
        // ─────────────────────────────────────────
        private void Guardar()
        {
            if (!ValidarFormularioProducto()) return;

            string nombreCat = cmbCategoria.SelectedItem?.ToString();
            int idCat = mapaCategorias.ContainsKey(nombreCat) ? mapaCategorias[nombreCat] : 0;

            if (idCat == 0)
            {
                MessageBox.Show("Selecciona una categoría válida.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar código duplicado
            if (sqlMenu.CodigoExiste(txtCodigo.Text.Trim(), idProductoSeleccionado))
            {
                MessageBox.Show("Ya existe un producto con ese código.",
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductoCatalogo p = new ProductoCatalogo
            {
                IdProducto = idProductoSeleccionado,
                CodigoProducto = txtCodigo.Text.Trim(),
                NombreProducto = txtNombreProducto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                PrecioVenta = decimal.Parse(txtPrecio.Text.Trim()),
                TiempoPreparacionMin = int.Parse(txtTiempoPrep.Text.Trim()),
                Disponible = tglDisponible.Checked,
                IdCategoria = idCat,
                NombreCategoria = nombreCat
            };

            bool resultado = modoEdicion
                ? sqlMenu.ActualizarProducto(p)
                : sqlMenu.InsertarProducto(p);

            if (resultado)
            {
                MessageBox.Show(modoEdicion
                    ? "Producto actualizado correctamente."
                    : "Producto agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProductos();
                CargarGrillaCategorias();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR
        // ─────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0) return;

            DialogResult confirm = MessageBox.Show(
                "¿Desactivar este producto del menú?\nNo se eliminará permanentemente.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = sqlMenu.CambiarDisponibilidad(idProductoSeleccionado, false);

            if (ok)
            {
                MessageBox.Show("Producto desactivado del menú.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
                EstadoInicial();
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el producto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ACTUALIZAR
        // ─────────────────────────────────────────
        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarCategoriasEnCombos();
            CargarProductos();
            CargarGrillaCategorias();
            EstadoInicial();
        }




        // ════════════════════════════════════════════════════
        // SECCIÓN PRODUCTOS
        // ════════════════════════════════════════════════════

        private void CargarCategoriasEnCombos()
        {
            cmbFiltroCategoria.Items.Clear();
            cmbCategoria.Items.Clear();
            mapaCategorias.Clear();

            cmbFiltroCategoria.Items.Add("Todas");

            var conConteo = sqlMenu.ObtenerCategoriasConConteo();
            foreach (var c in conConteo)
            {
                cmbFiltroCategoria.Items.Add(c.Nombre);
                cmbCategoria.Items.Add(c.Nombre);
                mapaCategorias[c.Nombre] = c.Id;
            }

            cmbFiltroCategoria.SelectedIndex = 0;
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            todosLosProductos = sqlMenu.ObtenerTodosLosProductos();
            ActualizarKpiCards();
            AplicarFiltrosYMostrar();
        }

        private void ActualizarKpiCards()
        {
            int total = todosLosProductos.Count;
            int disp = 0, noDisp = 0;

            foreach (ProductoCatalogo p in todosLosProductos)
            {
                if (p.Disponible) disp++;
                else noDisp++;
            }

            lblCardTotalValor.Text = total.ToString();
            lblCardDispValor.Text = disp.ToString();
            lblCardNoDispValor.Text = noDisp.ToString();
        }

        private void AplicarFiltrosYMostrar()
        {
            string texto = txtBuscarProducto.Text.Trim().ToLower();
            string cat = cmbFiltroCategoria.SelectedItem?.ToString() ?? "Todas";
            bool soloDisp = tglSoloDisponibles.Checked;

            List<ProductoCatalogo> filtrados = new List<ProductoCatalogo>();

            foreach (ProductoCatalogo p in todosLosProductos)
            {
                bool coincideTexto = string.IsNullOrEmpty(texto)
                    || p.NombreProducto.ToLower().Contains(texto)
                    || p.CodigoProducto.ToLower().Contains(texto);

                bool coincideCategoria = cat == "Todas" || p.NombreCategoria == cat;
                bool coincideDisponible = !soloDisp || p.Disponible;

                if (coincideTexto && coincideCategoria && coincideDisponible)
                    filtrados.Add(p);
            }

            MostrarProductosEnGrilla(filtrados);
        }

        private void MostrarProductosEnGrilla(List<ProductoCatalogo> lista)
        {
            dgvProductos.Rows.Clear();

            foreach (ProductoCatalogo p in lista)
            {
                int idx = dgvProductos.Rows.Add(
                    p.CodigoProducto,
                    p.NombreProducto,
                    p.NombreCategoria,
                    p.PrecioVenta,
                    $"{p.TiempoPreparacionMin} min",
                    p.Disponible ? "✔ Sí" : "✗ No"
                );

                dgvProductos.Rows[idx].Tag = p.IdProducto;

                if (!p.Disponible)
                    dgvProductos.Rows[idx].DefaultCellStyle.ForeColor =
                        Color.FromArgb(180, 180, 180);
            }
        }

        // ─────────────────────────────────────────
        // AUTOGENERAR CÓDIGO AL SELECCIONAR CATEGORÍA
        // ─────────────────────────────────────────
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoEdicion || idProductoSeleccionado > 0) return;
            GenerarCodigoAutomatico();
        }

        private void GenerarCodigoAutomatico()
        {
            if (cmbCategoria.SelectedItem == null) return;

            string nombreCat = cmbCategoria.SelectedItem.ToString();
            if (!mapaCategorias.ContainsKey(nombreCat)) return;

            int idCat = mapaCategorias[nombreCat];

            string prefijo = nombreCat.Length >= 3
                ? nombreCat.Substring(0, 3).ToUpper()
                : nombreCat.ToUpper().PadRight(3, 'X');

            int conteo = sqlMenu.ContarProductosPorCategoria(idCat);
            txtCodigo.Text = $"{prefijo}-{(conteo + 1):D3}";
        }

        // ─────────────────────────────────────────
        // EVENTOS FILTROS
        // ─────────────────────────────────────────
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        private void tglSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        private void tglDisponible_CheckedChanged(object sender, EventArgs e)
        {
            lblDisponibleTexto.Text = tglDisponible.Checked ? "Sí" : "No";
            lblDisponibleTexto.ForeColor = tglDisponible.Checked
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA PRODUCTOS
        // ─────────────────────────────────────────
        private void CargarProductoEnFormulario(ProductoCatalogo p)
        {
            idProductoSeleccionado = p.IdProducto;
            modoEdicion = false;

            txtCodigo.Text = p.CodigoProducto;
            txtNombreProducto.Text = p.NombreProducto;
            txtDescripcion.Text = p.Descripcion;
            txtPrecio.Text = p.PrecioVenta.ToString("F2");
            txtTiempoPrep.Text = p.TiempoPreparacionMin.ToString();
            tglDisponible.Checked = p.Disponible;
            lblDisponibleTexto.Text = p.Disponible ? "Sí" : "No";

            if (mapaCategorias.ContainsValue(p.IdCategoria))
                cmbCategoria.SelectedItem = p.NombreCategoria;

            lblFormTitulo.Text = $"Producto: {p.NombreProducto}";

            BloquearFormulario(true);       // bloquear campos
                                            // BloquearFormulario ya activa btnEditar y btnEliminar cuando hay selección
        }






        private void CargarGrillaCategorias()
        {
            dgvCategorias.Rows.Clear();

            var lista = sqlMenu.ObtenerCategoriasConConteo();
            foreach (var c in lista)
            {
                int idx = dgvCategorias.Rows.Add(c.Id, c.Nombre, c.TotalProductos);
                dgvCategorias.Rows[idx].Tag = c.Id;
            }
        }

        // ─────────────────────────────────────────
        // SELECCIÓN EN GRILLA CATEGORÍAS
        // Al seleccionar → activa eliminar, limpia textbox para no confundir
        // ─────────────────────────────────────────
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            idCategoriaSeleccionada = Convert.ToInt32(fila.Tag);
            string nombreCat = fila.Cells[1].Value?.ToString();
            // Mostrar nombre en textbox para referencia visual
            txtNombreCategoria.Text = nombreCat;

            // Activar eliminar solo si la categoría no tiene productos
            bool tieneProductos = sqlMenu.TieneProductos(idCategoriaSeleccionada);
            btnEliminarCategoria.Enabled = !tieneProductos;

            if (tieneProductos)
                lblCatFormTitulo.Text = $"'{nombreCat}' tiene productos — no se puede eliminar";
            else
                lblCatFormTitulo.Text = $"Seleccionada: {nombreCat}";
        }

        // ─────────────────────────────────────────
        // BOTÓN NUEVA CATEGORÍA
        // Lee el textbox y guarda directo — solo si NO hay categoría seleccionada
        // ─────────────────────────────────────────
        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Escribe el nombre de la nueva categoría en el campo de texto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            // Si hay una categoría seleccionada en la grilla, limpiar primero
            if (idCategoriaSeleccionada > 0)
            {
                // Desseleccionar grilla y limpiar para modo nuevo
                dgvCategorias.ClearSelection();
                idCategoriaSeleccionada = 0;
                btnEliminarCategoria.Enabled = false;
                lblCatFormTitulo.Text = "Datos de Categoría";

                // Avisar al usuario
                MessageBox.Show(
                    "Se deseleccionó la categoría anterior.\n" +
                    "Presiona 'Nueva Categoría' de nuevo para guardar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar duplicado sin distinción de mayúsculas
            if (sqlMenu.CategoriaExiste(nombre))
            {
                MessageBox.Show(
                    $"Ya existe una categoría llamada '{nombre}'.\nLos nombres no pueden repetirse.",
                    "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            bool ok = sqlMenu.InsertarCategoria(nombre);

            if (ok)
            {
                MessageBox.Show($"Categoría '{nombre}' creada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreCategoria.Text = "";
                idCategoriaSeleccionada = 0;
                btnEliminarCategoria.Enabled = false;
                lblCatFormTitulo.Text = "Datos de Categoría";

                CargarGrillaCategorias();
                CargarCategoriasEnCombos();
            }
            else
            {
                MessageBox.Show("No se pudo crear la categoría.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTÓN ELIMINAR CATEGORÍA
        // Solo se activa cuando hay una categoría seleccionada sin productos
        // ─────────────────────────────────────────
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0) return;

            string nombreCat = txtNombreCategoria.Text;

            if (sqlMenu.TieneProductos(idCategoriaSeleccionada))
            {
                MessageBox.Show("No se puede eliminar: tiene productos asociados.",
                    "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEliminarCategoria.Enabled = false;
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar la categoría '{nombreCat}'?\nEsta acción no se puede deshacer.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            bool ok = sqlMenu.EliminarCategoria(idCategoriaSeleccionada);

            if (ok)
            {
                MessageBox.Show($"Categoría '{nombreCat}' eliminada.",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreCategoria.Text = "";
                idCategoriaSeleccionada = 0;
                btnEliminarCategoria.Enabled = false;
                lblCatFormTitulo.Text = "Datos de Categoría";

                CargarGrillaCategorias();
                CargarCategoriasEnCombos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la categoría.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════

        private void ConfigurarFormProducto(bool haySeleccion)
        {
            btnEliminar.Enabled = haySeleccion && !modoEdicion;
            btnEditar.Enabled = haySeleccion && !modoEdicion;
        }

        private void BloquearFormulario(bool bloqueado)
        {
            txtNombreProducto.ReadOnly = bloqueado;
            txtDescripcion.ReadOnly = bloqueado;
            txtPrecio.ReadOnly = bloqueado;
            txtTiempoPrep.ReadOnly = bloqueado;
            cmbCategoria.Enabled = !bloqueado;
            tglDisponible.Enabled = !bloqueado;
            btnNuevoProducto.Enabled = !bloqueado;

            // Cuando se desbloquea para editar, ocultar editar/eliminar
            // Cuando se bloquea (solo ver), mostrarlos si hay producto seleccionado
            if (bloqueado && idProductoSeleccionado > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (!bloqueado)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
        private bool ValidarFormularioProducto()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProducto.Focus(); return false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido mayor a 0.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus(); return false;
            }
            if (!int.TryParse(txtTiempoPrep.Text.Trim(), out int tiempo) || tiempo < 0)
            {
                MessageBox.Show("Ingresa un tiempo de preparación válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiempoPrep.Focus(); return false;
            }
            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona una categoría.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus(); return false;
            }
            return true;
        }

       
    }
}