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
    public partial class frmReservaciones : Form
    {
        // Sesión
        private int idUsuarioSesion;
        private string nombreUsuarioSesion;

        //  Estado interno 
        private int idReservacionSeleccionada = 0;
        private bool modoEdicion = false;

        // Caché de checkboxes de mesas generados dinámicamente
        private List<CheckBox> checksMesas = new List<CheckBox>();

        // Constructor 
        public frmReservaciones(int idUsuarioSesion, string nombreUsuarioSesion)
        {
            InitializeComponent();
            this.idUsuarioSesion = idUsuarioSesion;
            this.nombreUsuarioSesion = nombreUsuarioSesion;
        }

        //  CARGA INICIAL
        private void frmReservaciones_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarMesasEnPanel();
            dtpFiltroFecha.Value = DateTime.Now.AddDays(1); 
            BuscarReservaciones();
            LimpiarFormulario();
        }
       

        //  Poblar combos 
        private void CargarCombos()
        {
            // Horas disponibles (de 7:00 a 22:00 cada 30 min)
            cmbHoraInicio.Items.Clear();
            for (int h = 7; h <= 22; h++)
            {
                cmbHoraInicio.Items.Add($"{h:D2}:00");
                if (h < 22) cmbHoraInicio.Items.Add($"{h:D2}:30");
            }
            cmbHoraInicio.SelectedIndex = 0;

            // Tipo
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Simple");
            cmbTipo.Items.Add("Evento");
            cmbTipo.SelectedIndex = 0;

            // Estado — minúsculas para coincidir con ENUM de la BD
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("pendiente");
            cmbEstado.Items.Add("confirmada");
            cmbEstado.Items.Add("cancelada");
            cmbEstado.SelectedIndex = 0;

            // Filtro estado
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("pendiente");
            cmbFiltroEstado.Items.Add("confirmada");
            cmbFiltroEstado.Items.Add("cancelada");
            cmbFiltroEstado.SelectedIndex = 0;

            // Filtro tipo
            cmbFiltroTipo.Items.Clear();
            cmbFiltroTipo.Items.Add("Todos");
            cmbFiltroTipo.Items.Add("Simple");
            cmbFiltroTipo.Items.Add("Evento");
            cmbFiltroTipo.SelectedIndex = 0;
        }

        // Generar checkboxes de mesas 
        private void CargarMesasEnPanel()
        {
            pnlMesas.Controls.Clear();
            checksMesas.Clear();

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                List<MesaResumen> mesas = sql.ObtenerMesasDisponiblesParaReserva();

                int col = 0, fila = 0;
                int anchoCheck = 165, altoCheck = 24, margenH = 8, margenV = 4;

                foreach (MesaResumen m in mesas)
                {
                    CheckBox chk = new CheckBox();
                    chk.Text = $"Mesa {m.NumeroMesa} — {m.NombreZona}";
                    chk.Tag = m.IdMesa;
                    chk.Font = new Font("Segoe UI", 8.8F);
                    chk.ForeColor = Color.FromArgb(30, 30, 47);
                    chk.Size = new Size(anchoCheck, altoCheck);
                    chk.Location = new Point(col * (anchoCheck + margenH) + 6,
                                             fila * (altoCheck + margenV) + 6);
                    chk.AutoSize = false;

                    pnlMesas.Controls.Add(chk);
                    checksMesas.Add(chk);

                    col++;
                    if (col >= 2) { col = 0; fila++; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar mesas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obtener IDs de mesas seleccionadas
        private List<int> ObtenerMesasSeleccionadas()
        {
            List<int> ids = new List<int>();
            foreach (CheckBox chk in checksMesas)
                if (chk.Checked) ids.Add((int)chk.Tag);
            return ids;
        }

        // ══════════════════════════════════════════════════════════════
        //  BÚSQUEDA Y CARGA DE LA GRILLA
        // ══════════════════════════════════════════════════════════════
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarReservaciones();
        }

        private void BuscarReservaciones()
        {
            try
            {
                SQLReservaciones sql = new SQLReservaciones();

                string buscar = txtBuscar.Text.Trim();
                DateTime fecha = dtpFiltroFecha.Value.Date;

                string estado = cmbFiltroEstado.SelectedItem?.ToString() == "Todos"
                                ? "" : cmbFiltroEstado.SelectedItem?.ToString() ?? "";

                string tipo = cmbFiltroTipo.SelectedItem?.ToString() == "Todos"
                                ? "" : cmbFiltroTipo.SelectedItem?.ToString() ?? "";

                DataTable dt = sql.ObtenerReservaciones(fecha, buscar, estado, tipo);

                dgvReservaciones.AutoGenerateColumns = false;
                dgvReservaciones.DataSource = dt;

                ActualizarKpis(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar reservaciones: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── KPIs ───────────────────────────────────────────────────────
        private void ActualizarKpis(DataTable dt)
        {
            int total = dt.Rows.Count;
            int pendientes = dt.AsEnumerable()
                               .Count(r => r["estado"].ToString()
                               .Equals("pendiente", StringComparison.OrdinalIgnoreCase));
            int confirmadas = dt.AsEnumerable()
                                .Count(r => r["estado"].ToString()
                                .Equals("confirmada", StringComparison.OrdinalIgnoreCase));
            int canceladas = dt.AsEnumerable()
                               .Count(r => r["estado"].ToString()
                               .Equals("cancelada", StringComparison.OrdinalIgnoreCase));

            lblKpiTotalValor.Text = total.ToString();
            lblKpiPendientesValor.Text = pendientes.ToString();
            lblKpiConfirmadasValor.Text = confirmadas.ToString();
            lblKpiCanceladasValor.Text = canceladas.ToString();
        }

        // ── Color de filas según estado ───────────────────────────────
        private void dgvReservaciones_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvReservaciones.Rows[e.RowIndex];
            string estado = row.Cells["colEstado"].Value?.ToString() ?? "";

            if (dgvReservaciones.Columns[e.ColumnIndex].Name == "colEstado")
            {
                switch (estado.ToLower())
                {
                    case "pendiente":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(249, 115, 22);
                        break;
                    case "confirmada":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(34, 197, 94);
                        break;
                    case "cancelada":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(239, 68, 68);
                        break;
                }
                e.FormattingApplied = true;
            }
        }
        //  SELECCIÓN EN GRILLA
        private void dgvReservaciones_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvReservaciones.Rows[e.RowIndex];
            idReservacionSeleccionada = Convert.ToInt32(row.Cells["colId"].Value);

            string estado = row.Cells["colEstado"].Value?.ToString() ?? "";

            btnEditar.Enabled = !estado.Equals("cancelada", StringComparison.OrdinalIgnoreCase);
            btnCancelarRes.Enabled = !estado.Equals("cancelada", StringComparison.OrdinalIgnoreCase);
            btnConfirmar.Enabled = estado.Equals("pendiente", StringComparison.OrdinalIgnoreCase);
        }

        //  TIPO , habilitar/deshabilitar campo Nombre Evento
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esEvento = cmbTipo.SelectedItem?.ToString() == "Evento";
            txtNombreEvento.Enabled = esEvento;
            txtNombreEvento.BackColor = esEvento
                ? Color.White
                : Color.FromArgb(240, 240, 248);
            if (!esEvento) txtNombreEvento.Text = "";
        }

        //  GUARDAR (nuevo o actualización)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                List<int> mesasSeleccionadas = ObtenerMesasSeleccionadas();

                Reservacion r = new Reservacion
                {
                    NombreCliente = txtNombreCliente.Text.Trim(),
                    TelefonoCliente = txtTelefono.Text.Trim(),
                    Fecha = dtpFecha.Value.Date,
                    HoraInicio = TimeSpan.Parse(cmbHoraInicio.SelectedItem.ToString()),
                    NumPersonas = (int)nudNumPersonas.Value,
                    Tipo = cmbTipo.SelectedItem.ToString(),
                    NombreEvento = cmbTipo.SelectedItem.ToString() == "Evento"
                                            ? txtNombreEvento.Text.Trim() : "",
                    Estado = cmbEstado.SelectedItem.ToString(),
                    IdEmpleadoRegistro = idUsuarioSesion
                };

                // Verificar conflicto de horario antes de guardar
                if (sql.VerificarConflictoHorario(r.Fecha, r.HoraInicio,
                    mesasSeleccionadas, modoEdicion ? idReservacionSeleccionada : 0))
                {
                    MessageBox.Show(
                        "Una o más mesas ya están reservadas en ese horario.",
                        "Conflicto de horario",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool exito;
                if (modoEdicion)
                {
                    r.IdReservacion = idReservacionSeleccionada;
                    exito = sql.ActualizarReservacion(r, mesasSeleccionadas);
                }
                else
                {
                    exito = sql.RegistrarReservacion(r, mesasSeleccionadas);
                }

                if (exito)
                {
                    MessageBox.Show(
                        modoEdicion
                            ? "Reservación actualizada correctamente."
                            : "Reservación registrada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    BuscarReservaciones();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo guardar la reservación. Intenta de nuevo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  EDITAR — cargar datos de la reservación seleccionada
        // ══════════════════════════════════════════════════════════════
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idReservacionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una reservación de la lista primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                Reservacion r = sql.ObtenerPorId(idReservacionSeleccionada);
                if (r == null) return;

                if (r.Estado.Equals("cancelada", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No se puede editar una reservación cancelada.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar datos en controles
                txtNombreCliente.Text = r.NombreCliente;
                txtTelefono.Text = r.TelefonoCliente;
                dtpFecha.Value = r.Fecha;
                cmbHoraInicio.Text = r.HoraInicio.ToString(@"hh\:mm");
                nudNumPersonas.Value = r.NumPersonas;
                cmbTipo.SelectedItem = r.Tipo;
                txtNombreEvento.Text = r.NombreEvento;
                cmbEstado.SelectedItem = r.Estado;

                // Marcar las mesas que tenía asignadas
                List<int> mesasActuales =
                    sql.ObtenerMesasPorReservacion(idReservacionSeleccionada);
                foreach (CheckBox chk in checksMesas)
                    chk.Checked = mesasActuales.Contains((int)chk.Tag);

                modoEdicion = true;
                btnGuardar.Text = "Actualizar Reservación";
                btnGuardar.FillColor = Color.FromArgb(37, 99, 235);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  CONFIRMAR RESERVACIÓN
        // ══════════════════════════════════════════════════════════════
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (idReservacionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una reservación de la lista primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Confirmar la reservación seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                bool exito = sql.CambiarEstado(idReservacionSeleccionada, "confirmada");

                if (exito)
                {
                    MessageBox.Show("Reservación confirmada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarReservaciones();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo confirmar la reservación.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  CANCELAR RESERVACIÓN
        // ══════════════════════════════════════════════════════════════
        private void btnCancelarRes_Click(object sender, EventArgs e)
        {
            if (idReservacionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una reservación de la lista primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show(
                "¿Cancelar la reservación seleccionada?\nEsta acción no se puede deshacer.",
                "Cancelar reservación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes) return;

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                bool exito = sql.CambiarEstado(idReservacionSeleccionada, "cancelada");

                if (exito)
                {
                    MessageBox.Show("Reservación cancelada.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarReservaciones();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo cancelar la reservación.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  LIMPIAR FORMULARIO
        // ══════════════════════════════════════════════════════════════
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idReservacionSeleccionada = 0;
            modoEdicion = false;

            txtNombreCliente.Text = "";
            txtTelefono.Text = "";
            dtpFecha.Value = DateTime.Now.AddDays(1);
            if (cmbHoraInicio.Items.Count > 0) cmbHoraInicio.SelectedIndex = 0;
            nudNumPersonas.Value = 1;
            cmbTipo.SelectedIndex = 0;
            txtNombreEvento.Text = "";
            txtNombreEvento.Enabled = false;
            txtNombreEvento.BackColor = Color.FromArgb(240, 240, 248);
            cmbEstado.SelectedIndex = 0;

            foreach (CheckBox chk in checksMesas)
                chk.Checked = false;

            btnGuardar.Text = "Guardar Reservación";
            btnGuardar.FillColor = Color.FromArgb(34, 197, 94);

            btnEditar.Enabled = false;
            btnCancelarRes.Enabled = false;
            btnConfirmar.Enabled = false;

            dgvReservaciones.ClearSelection();
            txtNombreCliente.Focus();
        }

        // ══════════════════════════════════════════════════════════════
        //  VALIDACIONES
        // ══════════════════════════════════════════════════════════════
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre del cliente es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (dtpFecha.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No se puede registrar una reservación en una fecha pasada.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!modoEdicion && dtpFecha.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show(
                    "La reservación debe registrarse con al menos 1 día de anticipación.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTipo.SelectedItem?.ToString() == "Evento" &&
                string.IsNullOrWhiteSpace(txtNombreEvento.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del evento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEvento.Focus();
                return false;
            }

            if (ObtenerMesasSeleccionadas().Count == 0)
            {
                MessageBox.Show("Debe asignar al menos una mesa a la reservación.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                SQLReservaciones sql = new SQLReservaciones();
                int capacidadTotal = sql.ObtenerCapacidadTotal(ObtenerMesasSeleccionadas());
                if ((int)nudNumPersonas.Value > capacidadTotal)
                {
                    MessageBox.Show(
                        $"El número de personas ({(int)nudNumPersonas.Value}) supera la " +
                        $"capacidad total de las mesas seleccionadas ({capacidadTotal} personas).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch { /* si falla la consulta de capacidad, el SP valida */ }

            return true;
        }
    }
}