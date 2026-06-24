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

namespace Restaurante_Sabor_Gourmet.Formularios
{
    public partial class frmOrdenes : Form
    {
        // Sesión del mesero logueado , la recibe del frmPrincipal de Persona 1
        private int idMeseroSesion;
        private string nombreMeseroSesion;

        // Mesa y orden actualmente seleccionadas
        private int idMesaSeleccionada = 0;
        private int idOrdenActual = 0;
        private int idCategoriaActual = 0;
        private bool ordenEnviadaACocina = false;

        // Caché de mesas ocupadas para consultar datos sin volver a la BD
        private List<MesaResumen> mesasOcupadas = new List<MesaResumen>();

        public frmOrdenes(int idMeseroSesion, string nombreMeseroSesion)
        {
            InitializeComponent();
            this.idMeseroSesion = idMeseroSesion;
            this.nombreMeseroSesion = nombreMeseroSesion;
        }

        private void frmOrdenes_Load(object sender, EventArgs e)
        {
            CargarMesasOcupadas();
            CargarCategoriasDinamicas();
        }

        //  carga de mesas
        private void CargarMesasOcupadas()
        {
            try
            {
                SQLMesaResumen sql = new SQLMesaResumen();
                mesasOcupadas = sql.ObtenerMesasOcupadas();

                // Construir DataTable para el ComboBox
                DataTable dt = new DataTable();
                dt.Columns.Add("id_mesa", typeof(int));
                dt.Columns.Add("texto_mesa", typeof(string));

                foreach (MesaResumen m in mesasOcupadas)
                    dt.Rows.Add(m.IdMesa,
                        string.Format("Mesa {0:00} - {1}", m.NumeroMesa, m.NombreZona));

                cbxMesa.DataSource = dt;
                cbxMesa.DisplayMember = "texto_mesa";
                cbxMesa.ValueMember = "id_mesa";

                // Limpiar info mientras no haya selección real
                LimpiarInfoMesa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mesas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMesa.SelectedValue == null) return;

            idMesaSeleccionada = Convert.ToInt32(cbxMesa.SelectedValue);

            // Buscar la mesa en el caché (evita otra consulta a la BD)
            MesaResumen mesa = mesasOcupadas.Find(m => m.IdMesa == idMesaSeleccionada);
            if (mesa == null) return;

            lblNumeroMesa.Text = "Mesa " + mesa.NumeroMesa.ToString("00");
            lblZona.Text = mesa.NombreZona;
            lblMeseroAsignado.Text = mesa.NombreMeseroAsignado;

            CargarOActualizarOrdenAbierta();
        }

        private void LimpiarInfoMesa()
        {
            lblNumeroMesa.Text = "Mesa --";
            lblZona.Text = "--";
            lblMeseroAsignado.Text = "--";
        }
        //  orden abierta
        //  Si la mesa ya tiene una orden 'abierta', se carga la orden 
        //  Si no, deja todo limpio para una orden nueva.
        private void CargarOActualizarOrdenAbierta()
        {
            try
            {
                SQLOrden sql = new SQLOrden();
                Orden ordenExistente = sql.ObtenerOrdenAbiertaPorMesa(idMesaSeleccionada);

                dgvDetalleOrden.Rows.Clear();
                RecalcularTotalOrden();
                txtObservacionesGenerales.Clear();

                if (ordenExistente != null)
                {
                    // Orden ya existente: cargar su detalle
                    idOrdenActual = ordenExistente.IdOrden;
                    ordenEnviadaACocina = false; // sigue abierta, se puede agregar
                    ActualizarEstadoOrden(ordenExistente.EstadoOrden);
                    txtObservacionesGenerales.Text = ordenExistente.Observaciones;

                    foreach (DetalleOrden d in ordenExistente.Detalles)
                    {
                        int fila = dgvDetalleOrden.Rows.Add(
                            d.NombreProducto,
                            d.CantidadDetalle,
                            d.PrecioUnitarioDetalle.ToString("0.00"),
                            d.Subtotal.ToString("0.00"),
                            d.Observaciones);

                        dgvDetalleOrden.Rows[fila].Tag = d.IdProductoDetalle;
                    }

                    RecalcularTotalOrden();
                }
                else
                {
                    // Mesa sin orden: resetear
                    idOrdenActual = 0;
                    ordenEnviadaACocina = false;
                    ActualizarEstadoOrden("abierta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar orden: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoOrden(string estado)
        {
            switch (estado)
            {
                case "abierta":
                    lblEstadoOrden.FillColor = Color.FromArgb(37, 99, 235);
                    lblEstadoOrdenTexto.Text = "● ABIERTA";
                    break;
                case "pendiente_pago":
                    lblEstadoOrden.FillColor = Color.FromArgb(249, 115, 22);
                    lblEstadoOrdenTexto.Text = "● PENDIENTE DE PAGO";
                    ordenEnviadaACocina = true; // bloquear edición
                    break;
                case "pagada":
                    lblEstadoOrden.FillColor = Color.FromArgb(34, 197, 94);
                    lblEstadoOrdenTexto.Text = "● PAGADA";
                    ordenEnviadaACocina = true;
                    break;
                case "cancelada":
                    lblEstadoOrden.FillColor = Color.FromArgb(239, 68, 68);
                    lblEstadoOrdenTexto.Text = "● CANCELADA";
                    ordenEnviadaACocina = true;
                    break;
            }
        }
        //  categorias finamicas
        //  Se cargan desde tbl_categorias; si la BD no responde,
        //  se usan las categorías fijas del Designer como fallback.
        private void CargarCategoriasDinamicas()
        {
            try
            {
                SQLProductoCatalogo sql = new SQLProductoCatalogo();
                List<(int Id, string Nombre)> categorias = sql.ObtenerCategorias();

                if (categorias.Count == 0) return;

                // Limpiar los botones fijos del Designer y reemplazarlos
                pnlCategorias.Controls.Clear();

                bool primero = true;
                foreach ((int id, string nombre) in categorias)
                {
                    Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button
                    {
                        Text = nombre,
                        Tag = id,
                        BorderRadius = 8,
                        Font = new Font("Segoe UI", 10F),
                        Size = new Size(140, 40),
                        Margin = new Padding(0, 0, 0, 8),
                        FillColor = primero
                            ? Color.FromArgb(37, 99, 235)
                            : Color.FromArgb(240, 240, 248),
                        ForeColor = primero
                            ? Color.White
                            : Color.FromArgb(30, 30, 47)
                    };
                    btn.Click += btnCategoria_Click;
                    pnlCategorias.Controls.Add(btn);

                    if (primero)
                    {
                        idCategoriaActual = id;
                        primero = false;
                    }
                }

                CargarProductosPorCategoria(idCategoriaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  Categorias y productos 
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            MarcarCategoriaActiva(btn);
            idCategoriaActual = Convert.ToInt32(btn.Tag);
            CargarProductosPorCategoria(idCategoriaActual);
        }

        private void MarcarCategoriaActiva(Guna.UI2.WinForms.Guna2Button btnActivo)
        {
            foreach (Control c in pnlCategorias.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.FillColor = Color.FromArgb(240, 240, 248);
                    btn.ForeColor = Color.FromArgb(30, 30, 47);
                }
            }
            btnActivo.FillColor = Color.FromArgb(37, 99, 235);
            btnActivo.ForeColor = Color.White;
        }

        private void CargarProductosPorCategoria(int idCategoria)
        {
            pnlProductosContainer.Controls.Clear();

            try
            {
                SQLProductoCatalogo sql = new SQLProductoCatalogo();
                List<ProductoCatalogo> productos = sql.ObtenerPorCategoria(idCategoria);

                foreach (ProductoCatalogo p in productos)
                    CrearTarjetaProducto(p.IdProducto, p.NombreProducto, p.PrecioVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearTarjetaProducto(int idProducto, string nombre, decimal precio)
        {
            Guna.UI2.WinForms.Guna2Panel tarjeta = new Guna.UI2.WinForms.Guna2Panel
            {
                Width = pnlProductosContainer.Width - 20,
                Height = 60,
                FillColor = Color.FromArgb(248, 248, 252),
                BorderRadius = 8,
                Margin = new Padding(0, 0, 0, 8)
            };

            Label lblNombre = new Label
            {
                Text = nombre,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(30, 30, 47),
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblPrecio = new Label
            {
                Text = "$" + precio.ToString("0.00"),
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                Location = new Point(15, 34),
                AutoSize = true
            };

            Guna.UI2.WinForms.Guna2Button btnAgregar = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                FillColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                BorderRadius = 8,
                Size = new Size(40, 40),
                Location = new Point(tarjeta.Width - 55, 10),
                Tag = new object[] { idProducto, nombre, precio }
            };
            btnAgregar.Click += btnAgregarProducto_Click;

            tarjeta.Controls.Add(lblNombre);
            tarjeta.Controls.Add(lblPrecio);
            tarjeta.Controls.Add(btnAgregar);
            pnlProductosContainer.Controls.Add(tarjeta);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (idMesaSeleccionada == 0)
            {
                MessageBox.Show("Primero selecciona una mesa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ordenEnviadaACocina)
            {
                MessageBox.Show("Esta orden ya fue enviada a cocina y no se puede modificar.",
                    "Orden bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            object[] datos = (object[])btn.Tag;
            int idProd = (int)datos[0];
            string nombre = (string)datos[1];
            decimal precio = (decimal)datos[2];

            AgregarProductoAOrden(idProd, nombre, precio);
        }
        //  Detalle de la orden (DataGridView)
        private void AgregarProductoAOrden(int idProducto, string nombre, decimal precioUnitario)
        {
            // Si el producto ya está en la grilla, solo suma 1
            foreach (DataGridViewRow fila in dgvDetalleOrden.Rows)
            {
                if (fila.Tag != null && (int)fila.Tag == idProducto)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["colCantidad"].Value);
                    fila.Cells["colCantidad"].Value = cantidadActual + 1;
                    RecalcularFila(fila);
                    RecalcularTotalOrden();
                    return;
                }
            }

            int indice = dgvDetalleOrden.Rows.Add();
            DataGridViewRow row = dgvDetalleOrden.Rows[indice];
            row.Tag = idProducto;
            row.Cells["colProducto"].Value = nombre;
            row.Cells["colCantidad"].Value = 1;
            row.Cells["colPrecioUnitario"].Value = precioUnitario.ToString("0.00");
            row.Cells["colSubtotal"].Value = precioUnitario.ToString("0.00");
            row.Cells["colObservaciones"].Value = "";

            RecalcularTotalOrden();
        }

        private void dgvDetalleOrden_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (ordenEnviadaACocina)
            {
                MessageBox.Show("Esta orden ya fue enviada a cocina y no se puede modificar.",
                    "Orden bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreCol = dgvDetalleOrden.Columns[e.ColumnIndex].Name;
            DataGridViewRow fila = dgvDetalleOrden.Rows[e.RowIndex];

            if (nombreCol == "colEliminar")
            {
                DialogResult resp = MessageBox.Show(
                    "¿Eliminar este producto de la orden?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    dgvDetalleOrden.Rows.RemoveAt(e.RowIndex);
                    RecalcularTotalOrden();
                }
            }
            else if (nombreCol == "colEditar")
            {
                string obsActual = fila.Cells["colObservaciones"].Value?.ToString() ?? "";
                string nuevaObs = Microsoft.VisualBasic.Interaction.InputBox(
                    "Observación para este producto:", "Editar observación", obsActual);
                fila.Cells["colObservaciones"].Value = nuevaObs;
            }
        }

        private void dgvDetalleOrden_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetalleOrden.Columns[e.ColumnIndex].Name != "colCantidad") return;

            DataGridViewRow fila = dgvDetalleOrden.Rows[e.RowIndex];

            if (!int.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out int cantidad)
                || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero mayor a 0.",
                    "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fila.Cells["colCantidad"].Value = 1;
            }

            RecalcularFila(fila);
            RecalcularTotalOrden();
        }

        private void RecalcularFila(DataGridViewRow fila)
        {
            int cantidad = Convert.ToInt32(fila.Cells["colCantidad"].Value);
            decimal precio = Convert.ToDecimal(fila.Cells["colPrecioUnitario"].Value);
            fila.Cells["colSubtotal"].Value = (cantidad * precio).ToString("0.00");
        }

        private void RecalcularTotalOrden()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvDetalleOrden.Rows)
            {
                if (fila.Cells["colSubtotal"].Value != null)
                    total += Convert.ToDecimal(fila.Cells["colSubtotal"].Value);
            }
            lblTotalOrden.Text = "$" + total.ToString("0.00");
        }

        //  HELPER: Construir List<DetalleOrden> desde el DataGridView
        private List<DetalleOrden> ObtenerDetalleParaGuardar()
        {
            List<DetalleOrden> lista = new List<DetalleOrden>();

            foreach (DataGridViewRow fila in dgvDetalleOrden.Rows)
            {
                if (fila.Tag == null) continue;

                lista.Add(new DetalleOrden
                {
                    IdProductoDetalle = (int)fila.Tag,
                    NombreProducto = fila.Cells["colProducto"].Value?.ToString() ?? "",
                    CantidadDetalle = Convert.ToInt32(fila.Cells["colCantidad"].Value),
                    PrecioUnitarioDetalle = Convert.ToDecimal(fila.Cells["colPrecioUnitario"].Value),
                    Observaciones = fila.Cells["colObservaciones"].Value?.ToString() ?? ""
                });
            }

            return lista;
        }

        //  Observaciones generales 

        private void txtObservacionesGenerales_TextChanged(object sender, EventArgs e)
        {
            lblContadorObs.Text = txtObservacionesGenerales.Text.Length + "/300";
        }

        //  Enviar a cocina
        private void btnEnviarCocina_Click(object sender, EventArgs e)
        {
            // Obtener estado de la mesa para validar
            MesaResumen mesa = mesasOcupadas.Find(m => m.IdMesa == idMesaSeleccionada);
            string estadoMesa = mesa?.EstadoMesa ?? "";

            ValidacionesOrdenes.ResultadoValidacion validacion =
                ValidacionesOrdenes.ValidarEnvioOrden(
                    idMesaSeleccionada,
                    dgvDetalleOrden.Rows.Count,
                    estadoMesa);

            if (!validacion.EsValido)
            {
                MessageBox.Show(validacion.Mensaje, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Enviar esta orden a cocina? Ya no podrás modificarla después.",
                "Confirmar envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLOrden sql = new SQLOrden();
                List<DetalleOrden> det = ObtenerDetalleParaGuardar();

                int idGenerado = sql.RegistrarOrden(
                    idMesaSeleccionada,
                    idMeseroSesion,
                    txtObservacionesGenerales.Text.Trim(),
                    det);

                if (idGenerado > 0)
                {
                    idOrdenActual = idGenerado;
                    ordenEnviadaACocina = true;
                    ActualizarEstadoOrden("abierta"); // sigue abierta hasta CerrarCuenta

                    MessageBox.Show("Orden #" + idGenerado + " enviada a cocina correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la orden. Intenta de nuevo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la orden: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  Solicitar de cierre de cuenta 
        private void btnSolicitarCierre_Click(object sender, EventArgs e)
        {
            if (idOrdenActual == 0)
            {
                MessageBox.Show("Esta mesa aún no tiene una orden enviada a cocina.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidacionesOrdenes.OrdenSePuedeCerrar("abierta"))
            {
                MessageBox.Show("Esta orden no se puede cerrar en su estado actual.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Solicitar el cierre de cuenta para la Orden #" + idOrdenActual + "?\n" +
                "La orden pasará a 'Pendiente de pago' y el cliente deberá ir a caja.",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLOrden sql = new SQLOrden();
                bool exito = sql.CerrarCuenta(idOrdenActual);

                if (exito)
                {
                    ActualizarEstadoOrden("pendiente_pago");
                    MessageBox.Show("Cuenta enviada a caja correctamente.\n" +
                        "La mesa quedará disponible al cobrar.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo cerrar la cuenta. Verifica que la orden esté abierta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la cuenta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}