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
    public partial class frmMeseros : Form
    {
        // Sesión del usuario logueado (administrador/supervisor)
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        // Mesero seleccionado en la grilla (0 = ninguno → modo nuevo)
        private int idMeseroSeleccionado = 0;

        // Caché en memoria para filtrar sin volver a la BD
        private List<Mesero> listaMeseros = new List<Mesero>();

        // Id real del rol "Mesero" en tbl_roles
        // Verifica con: SELECT id_rol FROM tbl_roles WHERE nombre_rol = 'Mesero'
        private const int ID_ROL_MESERO = 2;

        private bool contrasenaVisible = false;

        public frmMeseros(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        // ============================================================
        //  CARGA INICIAL
        // ============================================================
        private void frmMeseros_Load(object sender, EventArgs e)
        {
            CargarMeseros();
            CargarMetricas();
            LimpiarFormulario();
        }

        private void CargarMeseros()
        {
            try
            {
                SQLMesero sql = new SQLMesero();
                listaMeseros = sql.ObtenerMeseros(ID_ROL_MESERO);
                RenderizarTabla(listaMeseros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar meseros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderizarTabla(List<Mesero> lista)
        {
            dgvMeseros.Rows.Clear();

            foreach (Mesero m in lista)
            {
                int fila = dgvMeseros.Rows.Add(
                    m.IdUsuario,
                    m.NombreUsuario,
                    m.Username,
                    m.Telefono,
                    m.FechaIngreso.ToString("dd/MM/yyyy"),
                    m.Activo ? "Sí" : "No");

                dgvMeseros.Rows[fila].Tag = m.IdUsuario;
            }
        }

        private void dgvMeseros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMeseros.Columns[e.ColumnIndex].Name != "colActivo" || e.Value == null) return;

            e.CellStyle.ForeColor = e.Value.ToString() == "Sí"
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);
        }

        // ============================================================
        //  BÚSQUEDA EN TIEMPO REAL
        // ============================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            List<Mesero> filtrados = string.IsNullOrEmpty(texto)
                ? listaMeseros
                : listaMeseros.Where(m =>
                    m.NombreUsuario.ToLower().Contains(texto) ||
                    m.Username.ToLower().Contains(texto) ||
                    (m.Telefono != null && m.Telefono.ToLower().Contains(texto))
                  ).ToList();

            RenderizarTabla(filtrados);
        }

        // ============================================================
        //  SELECCIÓN EN GRILLA → CARGAR EN FORMULARIO
        // ============================================================
        private void dgvMeseros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idMeseroSeleccionado = (int)dgvMeseros.Rows[e.RowIndex].Tag;
            Mesero m = listaMeseros.FirstOrDefault(x => x.IdUsuario == idMeseroSeleccionado);
            if (m == null) return;

            txtNombreCompleto.Text = m.NombreUsuario;
            txtUsername.Text = m.Username;
            txtTelefono.Text = m.Telefono;
            dtpFechaIngreso.Value = m.FechaIngreso;
            switchActivo.Checked = m.Activo;

            // La contraseña nunca se precarga por seguridad.
            // Si se deja vacía al actualizar, se conserva la actual en la BD.
            txtContrasena.Text = "";
            txtContrasena.PlaceholderText = "Dejar en blanco para no cambiar la contraseña";

            // Actualizar métricas del mesero seleccionado
            CargarMetricasPorMesero(idMeseroSeleccionado);
        }

        // ============================================================
        //  MOSTRAR / OCULTAR CONTRASEÑA
        // ============================================================
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            contrasenaVisible = !contrasenaVisible;
            txtContrasena.PasswordChar = contrasenaVisible ? '\0' : '●';
            btnTogglePassword.Text = contrasenaVisible ? "🙈" : "👁";
        }

        // ============================================================
        //  SWITCH ACTIVO
        // ============================================================
        private void switchActivo_CheckedChanged(object sender, EventArgs e)
        {
            lblActivoTexto.Text = switchActivo.Checked ? "Sí" : "No";
            lblActivoTexto.ForeColor = switchActivo.Checked
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);
        }

        // ============================================================
        //  GUARDAR (nuevo mesero)
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación centralizada con ValidacionesOrdenes
            IEnumerable<string> usernames = listaMeseros.Select(m => m.Username);
            ValidacionesOrdenes.ResultadoValidacion result = ValidacionesOrdenes.ValidarMesero(
                txtNombreCompleto.Text,
                txtUsername.Text,
                txtTelefono.Text,
                txtContrasena.Text,
                esNuevo: true,
                usernamesExistentes: usernames);

            if (!result.EsValido)
            {
                MessageBox.Show(result.Mensaje, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación extra a nivel de BD (username único global)
            try
            {
                SQLMesero sql = new SQLMesero();

                if (sql.UsernameExiste(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un usuario con ese username en el sistema.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Mesero nuevo = new Mesero
                {
                    NombreUsuario = txtNombreCompleto.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    ContrasenaUsuario = txtContrasena.Text,
                    Telefono = txtTelefono.Text.Trim(),
                    FechaIngreso = dtpFechaIngreso.Value.Date,
                    Activo = switchActivo.Checked,
                    IdRolUsuario = ID_ROL_MESERO
                };

                bool exito = sql.Insertar(nuevo);

                if (exito)
                {
                    MessageBox.Show("Mesero guardado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMeseros();
                    CargarMetricas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el mesero. Intenta de nuevo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  ACTUALIZAR
        // ============================================================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idMeseroSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un mesero de la lista antes de actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Excluir el username del mesero actual para no disparar falso duplicado
            IEnumerable<string> usernames = listaMeseros
                .Where(m => m.IdUsuario != idMeseroSeleccionado)
                .Select(m => m.Username);

            ValidacionesOrdenes.ResultadoValidacion result = ValidacionesOrdenes.ValidarMesero(
                txtNombreCompleto.Text,
                txtUsername.Text,
                txtTelefono.Text,
                txtContrasena.Text,
                esNuevo: false,
                usernamesExistentes: usernames);

            if (!result.EsValido)
            {
                MessageBox.Show(result.Mensaje, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SQLMesero sql = new SQLMesero();

                // Verificar si el nuevo username ya existe en otro usuario
                if (sql.UsernameExiste(txtUsername.Text.Trim(), idMeseroSeleccionado))
                {
                    MessageBox.Show("Ese username ya está en uso por otro usuario.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool cambiarContrasena = !string.IsNullOrWhiteSpace(txtContrasena.Text);

                Mesero actualizado = new Mesero
                {
                    IdUsuario = idMeseroSeleccionado,
                    NombreUsuario = txtNombreCompleto.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    ContrasenaUsuario = txtContrasena.Text,
                    Telefono = txtTelefono.Text.Trim(),
                    FechaIngreso = dtpFechaIngreso.Value.Date,
                    Activo = switchActivo.Checked,
                    IdRolUsuario = ID_ROL_MESERO
                };

                bool exito = sql.Actualizar(actualizado, cambiarContrasena);

                if (exito)
                {
                    MessageBox.Show("Mesero actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMeseros();
                    CargarMetricas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el mesero.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  ELIMINAR (soft-delete: activo = 0)
        //  No se borra físicamente para preservar historial de órdenes.
        // ============================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMeseroSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un mesero de la lista antes de eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Mesero m = listaMeseros.FirstOrDefault(x => x.IdUsuario == idMeseroSeleccionado);
            if (m == null) return;

            DialogResult resp = MessageBox.Show(
                "El mesero \"" + m.NombreUsuario + "\" tiene historial de órdenes,\n" +
                "por lo que no se eliminará físicamente: se marcará como Inactivo.\n\n" +
                "¿Continuar?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLMesero sql = new SQLMesero();
                bool exito = sql.Desactivar(idMeseroSeleccionado);

                if (exito)
                {
                    MessageBox.Show("Mesero marcado como inactivo correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMeseros();
                    CargarMetricas();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo desactivar el mesero.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desactivar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  LIMPIAR
        // ============================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idMeseroSeleccionado = 0;
            txtNombreCompleto.Clear();
            txtUsername.Clear();
            txtContrasena.Clear();
            txtContrasena.PlaceholderText = "";
            txtTelefono.Clear();
            dtpFechaIngreso.Value = DateTime.Now;
            switchActivo.Checked = true;
            lblActivoTexto.Text = "Sí";
            lblActivoTexto.ForeColor = Color.FromArgb(34, 197, 94);
            contrasenaVisible = false;
            txtContrasena.PasswordChar = '●';
            btnTogglePassword.Text = "👁";
            dgvMeseros.ClearSelection();
            txtNombreCompleto.Focus();

            // Volver a métricas generales al limpiar
            CargarMetricas();
        }

        // ============================================================
        //  MÉTRICAS GENERALES (todas al cargar / limpiar)
        // ============================================================
        private void CargarMetricas()
        {
            try
            {
                SQLMesero sql = new SQLMesero();
                (int ordenes, decimal ventas, decimal propinas) = sql.ObtenerMetricasGenerales();

                lblKpiOrdenesValor.Text = ordenes.ToString();
                lblKpiVentasValor.Text = "$" + ventas.ToString("0.00");
                lblKpiPropinasValor.Text = "$" + propinas.ToString("0.00");
                lblKpiTiempoValor.Text = ObtenerTiempoPromedioGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métricas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  MÉTRICAS DEL MESERO SELECCIONADO
        //  Se activan al hacer clic en una fila de la grilla
        // ============================================================
        private void CargarMetricasPorMesero(int idMesero)
        {
            try
            {
                SQLMesero sql = new SQLMesero();
                (int ordenes, decimal ventas, decimal propinas) = sql.ObtenerMetricasPorMesero(idMesero);

                lblKpiOrdenesValor.Text = ordenes.ToString();
                lblKpiVentasValor.Text = "$" + ventas.ToString("0.00");
                lblKpiPropinasValor.Text = "$" + propinas.ToString("0.00");
                lblKpiTiempoValor.Text = ObtenerTiempoPromedioPorMesero(idMesero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métricas del mesero: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  TIEMPO PROMEDIO
        //  Cálculo auxiliar: promedio de tiempo de preparación de las
        //  órdenes del mesero (hora_recepcion → hora_finalizacion en
        //  tbl_cola_cocina, cruzado con id_mesero_orden en tbl_ordenes).
        // ============================================================
        private string ObtenerTiempoPromedioGeneral()
        {
            try
            {
                SQLColaCocina sql = new SQLColaCocina();
                double minutos = sql.ObtenerTiempoPromedioMinutos();
                return minutos > 0 ? Math.Round(minutos) + " min" : "-- min";
            }
            catch
            {
                return "-- min";
            }
        }

        private string ObtenerTiempoPromedioPorMesero(int idMesero)
        {
            // El tiempo promedio de atención por mesero específico
            // usa la misma consulta general de cocina ya que las órdenes
            // de cocina están ligadas a tbl_ordenes que tiene id_mesero_orden.
            // Si en tu proyecto quieres filtrarlo por mesero, extiende
            // ColaCocinaDAO con un método ObtenerTiempoPromedioPorMesero(idMesero).
            return ObtenerTiempoPromedioGeneral();
        }
    }
}