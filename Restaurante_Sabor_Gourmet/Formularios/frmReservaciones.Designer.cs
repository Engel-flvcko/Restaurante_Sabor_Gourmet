namespace Restaurante_Sabor_Gourmet.Formularios
{
    partial class frmReservaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.picIcono = new System.Windows.Forms.PictureBox();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblRolUsuario = new System.Windows.Forms.Label();

            this.pnlFormulario = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloNueva = new System.Windows.Forms.Label();

            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new Guna.UI2.WinForms.Guna2TextBox();

            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();

            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();

            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.cmbHoraInicio = new Guna.UI2.WinForms.Guna2ComboBox();

            this.lblNumPersonas = new System.Windows.Forms.Label();
            this.nudNumPersonas = new System.Windows.Forms.NumericUpDown();

            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new Guna.UI2.WinForms.Guna2ComboBox();

            this.lblNombreEvento = new System.Windows.Forms.Label();
            this.txtNombreEvento = new Guna.UI2.WinForms.Guna2TextBox();

            this.lblMesasAsignadas = new System.Windows.Forms.Label();
            this.pnlMesas = new System.Windows.Forms.Panel();

            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new Guna.UI2.WinForms.Guna2ComboBox();

            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnLimpiar = new Guna.UI2.WinForms.Guna2Button();

            this.pnlLista = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFiltBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFiltFecha = new System.Windows.Forms.Label();
            this.dtpFiltroFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFiltEstado = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblFiltTipo = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();

            this.dgvReservaciones = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMesas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistradoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlBotonesAccion = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelarRes = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmar = new Guna.UI2.WinForms.Guna2Button();

            this.pnlKpis = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlKpiTotal = new Guna.UI2.WinForms.Guna2Panel();
            this.picKpiTotal = new System.Windows.Forms.PictureBox();
            this.lblKpiTotalLabel = new System.Windows.Forms.Label();
            this.lblKpiTotalValor = new System.Windows.Forms.Label();

            this.pnlKpiPendientes = new Guna.UI2.WinForms.Guna2Panel();
            this.picKpiPendientes = new System.Windows.Forms.PictureBox();
            this.lblKpiPendientesLabel = new System.Windows.Forms.Label();
            this.lblKpiPendientesValor = new System.Windows.Forms.Label();

            this.pnlKpiConfirmadas = new Guna.UI2.WinForms.Guna2Panel();
            this.picKpiConfirmadas = new System.Windows.Forms.PictureBox();
            this.lblKpiConfirmadasLabel = new System.Windows.Forms.Label();
            this.lblKpiConfirmadasValor = new System.Windows.Forms.Label();

            this.pnlKpiCanceladas = new Guna.UI2.WinForms.Guna2Panel();
            this.picKpiCanceladas = new System.Windows.Forms.PictureBox();
            this.lblKpiCanceladasLabel = new System.Windows.Forms.Label();
            this.lblKpiCanceladasValor = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiConfirmadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiCanceladas)).BeginInit();
            this.pnlTopBar.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotonesAccion.SuspendLayout();
            this.pnlKpis.SuspendLayout();
            this.pnlKpiTotal.SuspendLayout();
            this.pnlKpiPendientes.SuspendLayout();
            this.pnlKpiConfirmadas.SuspendLayout();
            this.pnlKpiCanceladas.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTopBar ──────────────────────────────────────────────
            this.pnlTopBar.FillColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1536, 65);
            this.pnlTopBar.TabIndex = 0;
            this.pnlTopBar.Controls.Add(this.picIcono);
            this.pnlTopBar.Controls.Add(this.lblTituloForm);
            this.pnlTopBar.Controls.Add(this.picUsuario);
            this.pnlTopBar.Controls.Add(this.lblNombreUsuario);
            this.pnlTopBar.Controls.Add(this.lblRolUsuario);

            this.picIcono.Image = null;
            this.picIcono.Location = new System.Drawing.Point(15, 12);
            this.picIcono.Name = "picIcono";
            this.picIcono.Size = new System.Drawing.Size(40, 40);
            this.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcono.TabIndex = 0;
            this.picIcono.TabStop = false;

            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(62, 17);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Text = "Gestión de Reservaciones";

            this.picUsuario.Image = null;
            this.picUsuario.Location = new System.Drawing.Point(1410, 12);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(40, 40);
            this.picUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuario.TabIndex = 1;
            this.picUsuario.TabStop = false;

            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(1458, 14);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Text = "Usuario";

            this.lblRolUsuario.AutoSize = true;
            this.lblRolUsuario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRolUsuario.ForeColor = System.Drawing.Color.FromArgb(180, 180, 200);
            this.lblRolUsuario.Location = new System.Drawing.Point(1458, 34);
            this.lblRolUsuario.Name = "lblRolUsuario";
            this.lblRolUsuario.Text = "Rol";

            // ── pnlFormulario (panel izquierdo — Nueva Reservación) ────
            this.pnlFormulario.BorderRadius = 12;
            this.pnlFormulario.FillColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(15, 80);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.ShadowDecoration.Enabled = true;
            this.pnlFormulario.Size = new System.Drawing.Size(390, 880);
            this.pnlFormulario.TabIndex = 1;
            this.pnlFormulario.Controls.Add(this.lblTituloNueva);
            this.pnlFormulario.Controls.Add(this.lblNombreCliente);
            this.pnlFormulario.Controls.Add(this.txtNombreCliente);
            this.pnlFormulario.Controls.Add(this.lblTelefono);
            this.pnlFormulario.Controls.Add(this.txtTelefono);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.dtpFecha);
            this.pnlFormulario.Controls.Add(this.lblHoraInicio);
            this.pnlFormulario.Controls.Add(this.cmbHoraInicio);
            this.pnlFormulario.Controls.Add(this.lblNumPersonas);
            this.pnlFormulario.Controls.Add(this.nudNumPersonas);
            this.pnlFormulario.Controls.Add(this.lblTipo);
            this.pnlFormulario.Controls.Add(this.cmbTipo);
            this.pnlFormulario.Controls.Add(this.lblNombreEvento);
            this.pnlFormulario.Controls.Add(this.txtNombreEvento);
            this.pnlFormulario.Controls.Add(this.lblMesasAsignadas);
            this.pnlFormulario.Controls.Add(this.pnlMesas);
            this.pnlFormulario.Controls.Add(this.lblEstado);
            this.pnlFormulario.Controls.Add(this.cmbEstado);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.btnLimpiar);

            this.lblTituloNueva.AutoSize = true;
            this.lblTituloNueva.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloNueva.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTituloNueva.Location = new System.Drawing.Point(18, 18);
            this.lblTituloNueva.Name = "lblTituloNueva";
            this.lblTituloNueva.Text = "Nueva Reservación";

            // Nombre del Cliente
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreCliente.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblNombreCliente.Location = new System.Drawing.Point(18, 60);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Text = "Nombre del Cliente";

            this.txtNombreCliente.BorderRadius = 8;
            this.txtNombreCliente.DefaultText = "";
            this.txtNombreCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreCliente.Location = new System.Drawing.Point(18, 83);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.PlaceholderText = "Ingrese nombre del cliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(352, 38);
            this.txtNombreCliente.TabIndex = 1;

            // Teléfono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblTelefono.Location = new System.Drawing.Point(18, 132);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Text = "Teléfono";

            this.txtTelefono.BorderRadius = 8;
            this.txtTelefono.DefaultText = "";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.Location = new System.Drawing.Point(18, 155);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PlaceholderText = "Ingrese teléfono";
            this.txtTelefono.Size = new System.Drawing.Size(352, 38);
            this.txtTelefono.TabIndex = 2;

            // Fecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFecha.Location = new System.Drawing.Point(18, 204);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha";

            this.dtpFecha.BorderRadius = 8;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(18, 227);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(352, 38);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.Value = System.DateTime.Now.AddDays(1);

            // Hora de Inicio
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHoraInicio.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblHoraInicio.Location = new System.Drawing.Point(18, 276);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Text = "Hora de Inicio";

            this.cmbHoraInicio.BorderRadius = 8;
            this.cmbHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHoraInicio.Location = new System.Drawing.Point(18, 299);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(352, 38);
            this.cmbHoraInicio.TabIndex = 4;

            // Número de Personas
            this.lblNumPersonas.AutoSize = true;
            this.lblNumPersonas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNumPersonas.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblNumPersonas.Location = new System.Drawing.Point(18, 348);
            this.lblNumPersonas.Name = "lblNumPersonas";
            this.lblNumPersonas.Text = "Número de Personas";

            this.nudNumPersonas.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.nudNumPersonas.Location = new System.Drawing.Point(18, 371);
            this.nudNumPersonas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudNumPersonas.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudNumPersonas.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudNumPersonas.Name = "nudNumPersonas";
            this.nudNumPersonas.Size = new System.Drawing.Size(352, 34);
            this.nudNumPersonas.TabIndex = 5;

            // Tipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblTipo.Location = new System.Drawing.Point(18, 416);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo";

            this.cmbTipo.BorderRadius = 8;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.Location = new System.Drawing.Point(18, 439);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(352, 38);
            this.cmbTipo.TabIndex = 6;

            // Nombre del Evento
            this.lblNombreEvento.AutoSize = true;
            this.lblNombreEvento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombreEvento.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblNombreEvento.Location = new System.Drawing.Point(18, 488);
            this.lblNombreEvento.Name = "lblNombreEvento";
            this.lblNombreEvento.Text = "Nombre del Evento";

            this.txtNombreEvento.BorderRadius = 8;
            this.txtNombreEvento.DefaultText = "";
            this.txtNombreEvento.Enabled = false;
            this.txtNombreEvento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreEvento.Location = new System.Drawing.Point(18, 511);
            this.txtNombreEvento.Name = "txtNombreEvento";
            this.txtNombreEvento.PlaceholderText = "Solo para eventos";
            this.txtNombreEvento.Size = new System.Drawing.Size(352, 38);
            this.txtNombreEvento.TabIndex = 7;

            // Mesas Asignadas
            this.lblMesasAsignadas.AutoSize = true;
            this.lblMesasAsignadas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMesasAsignadas.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblMesasAsignadas.Location = new System.Drawing.Point(18, 560);
            this.lblMesasAsignadas.Name = "lblMesasAsignadas";
            this.lblMesasAsignadas.Text = "Mesas Asignadas";

            this.pnlMesas.AutoScroll = true;
            this.pnlMesas.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.pnlMesas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMesas.Location = new System.Drawing.Point(18, 583);
            this.pnlMesas.Name = "pnlMesas";
            this.pnlMesas.Size = new System.Drawing.Size(352, 120);
            this.pnlMesas.TabIndex = 8;

            // Estado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblEstado.Location = new System.Drawing.Point(18, 714);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado";

            this.cmbEstado.BorderRadius = 8;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.Location = new System.Drawing.Point(18, 737);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(352, 38);
            this.cmbEstado.TabIndex = 9;

            // Botón Guardar
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(18, 792);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(352, 48);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar Reservación";

            // Botón Limpiar
            this.btnLimpiar.BorderRadius = 10;
            this.btnLimpiar.FillColor = System.Drawing.Color.FromArgb(120, 120, 130);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(18, 848);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(352, 18);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar Formulario";

            // ── pnlLista (panel derecho) ───────────────────────────────
            this.pnlLista.BorderRadius = 12;
            this.pnlLista.FillColor = System.Drawing.Color.White;
            this.pnlLista.Location = new System.Drawing.Point(420, 80);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.ShadowDecoration.Enabled = true;
            this.pnlLista.Size = new System.Drawing.Size(1100, 760);
            this.pnlLista.TabIndex = 2;
            this.pnlLista.Controls.Add(this.pnlFiltros);
            this.pnlLista.Controls.Add(this.dgvReservaciones);

            // ── pnlFiltros ─────────────────────────────────────────────
            this.pnlFiltros.FillColor = System.Drawing.Color.Transparent;
            this.pnlFiltros.Location = new System.Drawing.Point(15, 12);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1070, 58);
            this.pnlFiltros.TabIndex = 0;
            this.pnlFiltros.Controls.Add(this.lblFiltBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblFiltFecha);
            this.pnlFiltros.Controls.Add(this.dtpFiltroFecha);
            this.pnlFiltros.Controls.Add(this.lblFiltEstado);
            this.pnlFiltros.Controls.Add(this.cmbFiltroEstado);
            this.pnlFiltros.Controls.Add(this.lblFiltTipo);
            this.pnlFiltros.Controls.Add(this.cmbFiltroTipo);
            this.pnlFiltros.Controls.Add(this.btnBuscar);

            this.lblFiltBuscar.AutoSize = true;
            this.lblFiltBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltBuscar.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFiltBuscar.Location = new System.Drawing.Point(0, 0);
            this.lblFiltBuscar.Name = "lblFiltBuscar";
            this.lblFiltBuscar.Text = "Buscar (nombre o teléfono)";

            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(0, 18);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar...";
            this.txtBuscar.Size = new System.Drawing.Size(220, 36);
            this.txtBuscar.TabIndex = 0;

            this.lblFiltFecha.AutoSize = true;
            this.lblFiltFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltFecha.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFiltFecha.Location = new System.Drawing.Point(234, 0);
            this.lblFiltFecha.Name = "lblFiltFecha";
            this.lblFiltFecha.Text = "Fecha";

            this.dtpFiltroFecha.BorderRadius = 8;
            this.dtpFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(234, 18);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(180, 36);
            this.dtpFiltroFecha.TabIndex = 1;
            this.dtpFiltroFecha.Value = System.DateTime.Now;

            this.lblFiltEstado.AutoSize = true;
            this.lblFiltEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltEstado.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFiltEstado.Location = new System.Drawing.Point(428, 0);
            this.lblFiltEstado.Name = "lblFiltEstado";
            this.lblFiltEstado.Text = "Estado";

            this.cmbFiltroEstado.BorderRadius = 8;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltroEstado.Location = new System.Drawing.Point(428, 18);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(160, 36);
            this.cmbFiltroEstado.TabIndex = 2;

            this.lblFiltTipo.AutoSize = true;
            this.lblFiltTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltTipo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblFiltTipo.Location = new System.Drawing.Point(602, 0);
            this.lblFiltTipo.Name = "lblFiltTipo";
            this.lblFiltTipo.Text = "Tipo";

            this.cmbFiltroTipo.BorderRadius = 8;
            this.cmbFiltroTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFiltroTipo.Location = new System.Drawing.Point(602, 18);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(160, 36);
            this.cmbFiltroTipo.TabIndex = 3;

            this.btnBuscar.BorderRadius = 8;
            this.btnBuscar.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(780, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 36);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";

            // ── dgvReservaciones ───────────────────────────────────────
            this.dgvReservaciones.AllowUserToAddRows = false;
            this.dgvReservaciones.AllowUserToResizeRows = false;
            this.dgvReservaciones.AutoGenerateColumns = false;
            this.dgvReservaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservaciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvReservaciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservaciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvReservaciones.ColumnHeadersHeight = 38;
            this.dgvReservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservaciones.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvReservaciones.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(229, 240, 255);
            this.dgvReservaciones.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.dgvReservaciones.GridColor = System.Drawing.Color.FromArgb(230, 230, 235);
            this.dgvReservaciones.Location = new System.Drawing.Point(15, 80);
            this.dgvReservaciones.MultiSelect = false;
            this.dgvReservaciones.Name = "dgvReservaciones";
            this.dgvReservaciones.ReadOnly = true;
            this.dgvReservaciones.RowHeadersVisible = false;
            this.dgvReservaciones.RowTemplate.Height = 42;
            this.dgvReservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservaciones.Size = new System.Drawing.Size(1070, 665);
            this.dgvReservaciones.TabIndex = 1;
            this.dgvReservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNombreCliente, this.colTelefono, this.colFecha,
                this.colHora, this.colPersonas, this.colTipoRes, this.colNombreEvento,
                this.colMesas, this.colEstado, this.colRegistradoPor });

            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.DataPropertyName = "id_reservacion";
            this.colId.FillWeight = 5F;
            this.colId.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colNombreCliente.HeaderText = "Nombre Cliente";
            this.colNombreCliente.Name = "colNombreCliente";
            this.colNombreCliente.DataPropertyName = "nombre_cliente";
            this.colNombreCliente.FillWeight = 14F;

            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.DataPropertyName = "telefono_cliente";
            this.colTelefono.FillWeight = 11F;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.DataPropertyName = "fecha";
            this.colFecha.FillWeight = 9F;
            this.colFecha.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.DataPropertyName = "hora_inicio";
            this.colHora.FillWeight = 7F;
            this.colHora.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colPersonas.HeaderText = "Personas";
            this.colPersonas.Name = "colPersonas";
            this.colPersonas.DataPropertyName = "num_personas";
            this.colPersonas.FillWeight = 7F;
            this.colPersonas.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colTipoRes.HeaderText = "Tipo";
            this.colTipoRes.Name = "colTipoRes";
            this.colTipoRes.DataPropertyName = "tipo";
            this.colTipoRes.FillWeight = 7F;
            this.colTipoRes.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colNombreEvento.HeaderText = "Nombre Evento";
            this.colNombreEvento.Name = "colNombreEvento";
            this.colNombreEvento.DataPropertyName = "nombre_evento";
            this.colNombreEvento.FillWeight = 12F;

            this.colMesas.HeaderText = "Mesas";
            this.colMesas.Name = "colMesas";
            this.colMesas.DataPropertyName = "mesas_asignadas";
            this.colMesas.FillWeight = 12F;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.DataPropertyName = "estado";
            this.colEstado.FillWeight = 9F;
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.colRegistradoPor.HeaderText = "Registrada por";
            this.colRegistradoPor.Name = "colRegistradoPor";
            this.colRegistradoPor.DataPropertyName = "nombre_usuario";
            this.colRegistradoPor.FillWeight = 12F;

            // ── pnlBotonesAccion ───────────────────────────────────────
            this.pnlBotonesAccion.BorderRadius = 12;
            this.pnlBotonesAccion.FillColor = System.Drawing.Color.White;
            this.pnlBotonesAccion.Location = new System.Drawing.Point(420, 850);
            this.pnlBotonesAccion.Name = "pnlBotonesAccion";
            this.pnlBotonesAccion.ShadowDecoration.Enabled = true;
            this.pnlBotonesAccion.Size = new System.Drawing.Size(1100, 62);
            this.pnlBotonesAccion.TabIndex = 3;
            this.pnlBotonesAccion.Controls.Add(this.btnEditar);
            this.pnlBotonesAccion.Controls.Add(this.btnCancelarRes);
            this.pnlBotonesAccion.Controls.Add(this.btnConfirmar);

            this.btnEditar.BorderRadius = 10;
            this.btnEditar.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(260, 8);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(180, 46);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";

            this.btnCancelarRes.BorderRadius = 10;
            this.btnCancelarRes.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnCancelarRes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelarRes.ForeColor = System.Drawing.Color.White;
            this.btnCancelarRes.Location = new System.Drawing.Point(460, 8);
            this.btnCancelarRes.Name = "btnCancelarRes";
            this.btnCancelarRes.Size = new System.Drawing.Size(220, 46);
            this.btnCancelarRes.TabIndex = 1;
            this.btnCancelarRes.Text = "Cancelar Reservación";

            this.btnConfirmar.BorderRadius = 10;
            this.btnConfirmar.FillColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(700, 8);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 46);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";

            // ── pnlKpis ────────────────────────────────────────────────
            this.pnlKpis.BorderRadius = 12;
            this.pnlKpis.FillColor = System.Drawing.Color.White;
            this.pnlKpis.Location = new System.Drawing.Point(420, 922);
            this.pnlKpis.Name = "pnlKpis";
            this.pnlKpis.ShadowDecoration.Enabled = true;
            this.pnlKpis.Size = new System.Drawing.Size(1100, 100);
            this.pnlKpis.TabIndex = 4;
            this.pnlKpis.Controls.Add(this.pnlKpiTotal);
            this.pnlKpis.Controls.Add(this.pnlKpiPendientes);
            this.pnlKpis.Controls.Add(this.pnlKpiConfirmadas);
            this.pnlKpis.Controls.Add(this.pnlKpiCanceladas);

            // KPI Total
            this.pnlKpiTotal.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpiTotal.BorderThickness = 1;
            this.pnlKpiTotal.BorderRadius = 10;
            this.pnlKpiTotal.FillColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlKpiTotal.Location = new System.Drawing.Point(20, 12);
            this.pnlKpiTotal.Name = "pnlKpiTotal";
            this.pnlKpiTotal.Size = new System.Drawing.Size(240, 76);
            this.pnlKpiTotal.TabIndex = 0;
            this.pnlKpiTotal.Controls.Add(this.picKpiTotal);
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalLabel);
            this.pnlKpiTotal.Controls.Add(this.lblKpiTotalValor);

            this.picKpiTotal.Image = null;
            this.picKpiTotal.Location = new System.Drawing.Point(14, 16);
            this.picKpiTotal.Name = "picKpiTotal";
            this.picKpiTotal.Size = new System.Drawing.Size(36, 44);
            this.picKpiTotal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpiTotal.TabStop = false;

            this.lblKpiTotalLabel.AutoSize = true;
            this.lblKpiTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiTotalLabel.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiTotalLabel.Location = new System.Drawing.Point(58, 12);
            this.lblKpiTotalLabel.Name = "lblKpiTotalLabel";
            this.lblKpiTotalLabel.Text = "Total hoy:";

            this.lblKpiTotalValor.AutoSize = true;
            this.lblKpiTotalValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalValor.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiTotalValor.Location = new System.Drawing.Point(58, 30);
            this.lblKpiTotalValor.Name = "lblKpiTotalValor";
            this.lblKpiTotalValor.Text = "0";

            // KPI Pendientes
            this.pnlKpiPendientes.BorderColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.pnlKpiPendientes.BorderThickness = 1;
            this.pnlKpiPendientes.BorderRadius = 10;
            this.pnlKpiPendientes.FillColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.pnlKpiPendientes.Location = new System.Drawing.Point(280, 12);
            this.pnlKpiPendientes.Name = "pnlKpiPendientes";
            this.pnlKpiPendientes.Size = new System.Drawing.Size(240, 76);
            this.pnlKpiPendientes.TabIndex = 1;
            this.pnlKpiPendientes.Controls.Add(this.picKpiPendientes);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesLabel);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesValor);

            this.picKpiPendientes.Image = null;
            this.picKpiPendientes.Location = new System.Drawing.Point(14, 16);
            this.picKpiPendientes.Name = "picKpiPendientes";
            this.picKpiPendientes.Size = new System.Drawing.Size(36, 44);
            this.picKpiPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpiPendientes.TabStop = false;

            this.lblKpiPendientesLabel.AutoSize = true;
            this.lblKpiPendientesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiPendientesLabel.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.lblKpiPendientesLabel.Location = new System.Drawing.Point(58, 12);
            this.lblKpiPendientesLabel.Name = "lblKpiPendientesLabel";
            this.lblKpiPendientesLabel.Text = "Pendientes:";

            this.lblKpiPendientesValor.AutoSize = true;
            this.lblKpiPendientesValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendientesValor.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.lblKpiPendientesValor.Location = new System.Drawing.Point(58, 30);
            this.lblKpiPendientesValor.Name = "lblKpiPendientesValor";
            this.lblKpiPendientesValor.Text = "0";

            // KPI Confirmadas
            this.pnlKpiConfirmadas.BorderColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.pnlKpiConfirmadas.BorderThickness = 1;
            this.pnlKpiConfirmadas.BorderRadius = 10;
            this.pnlKpiConfirmadas.FillColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.pnlKpiConfirmadas.Location = new System.Drawing.Point(540, 12);
            this.pnlKpiConfirmadas.Name = "pnlKpiConfirmadas";
            this.pnlKpiConfirmadas.Size = new System.Drawing.Size(240, 76);
            this.pnlKpiConfirmadas.TabIndex = 2;
            this.pnlKpiConfirmadas.Controls.Add(this.picKpiConfirmadas);
            this.pnlKpiConfirmadas.Controls.Add(this.lblKpiConfirmadasLabel);
            this.pnlKpiConfirmadas.Controls.Add(this.lblKpiConfirmadasValor);

            this.picKpiConfirmadas.Image = null;
            this.picKpiConfirmadas.Location = new System.Drawing.Point(14, 16);
            this.picKpiConfirmadas.Name = "picKpiConfirmadas";
            this.picKpiConfirmadas.Size = new System.Drawing.Size(36, 44);
            this.picKpiConfirmadas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpiConfirmadas.TabStop = false;

            this.lblKpiConfirmadasLabel.AutoSize = true;
            this.lblKpiConfirmadasLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiConfirmadasLabel.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblKpiConfirmadasLabel.Location = new System.Drawing.Point(58, 12);
            this.lblKpiConfirmadasLabel.Name = "lblKpiConfirmadasLabel";
            this.lblKpiConfirmadasLabel.Text = "Confirmadas:";

            this.lblKpiConfirmadasValor.AutoSize = true;
            this.lblKpiConfirmadasValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiConfirmadasValor.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblKpiConfirmadasValor.Location = new System.Drawing.Point(58, 30);
            this.lblKpiConfirmadasValor.Name = "lblKpiConfirmadasValor";
            this.lblKpiConfirmadasValor.Text = "0";

            // KPI Canceladas
            this.pnlKpiCanceladas.BorderColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlKpiCanceladas.BorderThickness = 1;
            this.pnlKpiCanceladas.BorderRadius = 10;
            this.pnlKpiCanceladas.FillColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.pnlKpiCanceladas.Location = new System.Drawing.Point(800, 12);
            this.pnlKpiCanceladas.Name = "pnlKpiCanceladas";
            this.pnlKpiCanceladas.Size = new System.Drawing.Size(240, 76);
            this.pnlKpiCanceladas.TabIndex = 3;
            this.pnlKpiCanceladas.Controls.Add(this.picKpiCanceladas);
            this.pnlKpiCanceladas.Controls.Add(this.lblKpiCanceladasLabel);
            this.pnlKpiCanceladas.Controls.Add(this.lblKpiCanceladasValor);

            this.picKpiCanceladas.Image = null;
            this.picKpiCanceladas.Location = new System.Drawing.Point(14, 16);
            this.picKpiCanceladas.Name = "picKpiCanceladas";
            this.picKpiCanceladas.Size = new System.Drawing.Size(36, 44);
            this.picKpiCanceladas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpiCanceladas.TabStop = false;

            this.lblKpiCanceladasLabel.AutoSize = true;
            this.lblKpiCanceladasLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiCanceladasLabel.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblKpiCanceladasLabel.Location = new System.Drawing.Point(58, 12);
            this.lblKpiCanceladasLabel.Name = "lblKpiCanceladasLabel";
            this.lblKpiCanceladasLabel.Text = "Canceladas:";

            this.lblKpiCanceladasValor.AutoSize = true;
            this.lblKpiCanceladasValor.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiCanceladasValor.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblKpiCanceladasValor.Location = new System.Drawing.Point(58, 30);
            this.lblKpiCanceladasValor.Name = "lblKpiCanceladasValor";
            this.lblKpiCanceladasValor.Text = "0";

            // ── frmReservaciones ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1536, 1040);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlLista);
            this.Controls.Add(this.pnlBotonesAccion);
            this.Controls.Add(this.pnlKpis);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReservaciones";
            this.Text = "Gestión de Reservaciones";

            ((System.ComponentModel.ISupportInitialize)(this.dgvReservaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiConfirmadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKpiCanceladas)).EndInit();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlLista.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotonesAccion.ResumeLayout(false);
            this.pnlKpis.ResumeLayout(false);
            this.pnlKpiTotal.ResumeLayout(false);
            this.pnlKpiTotal.PerformLayout();
            this.pnlKpiPendientes.ResumeLayout(false);
            this.pnlKpiPendientes.PerformLayout();
            this.pnlKpiConfirmadas.ResumeLayout(false);
            this.pnlKpiConfirmadas.PerformLayout();
            this.pnlKpiCanceladas.ResumeLayout(false);
            this.pnlKpiCanceladas.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Top Bar ────────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlTopBar;
        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblRolUsuario;

        // ── Panel Formulario (izquierdo) ───────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlFormulario;
        private System.Windows.Forms.Label lblTituloNueva;
        private System.Windows.Forms.Label lblNombreCliente;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private System.Windows.Forms.Label lblFecha;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHoraInicio;
        private Guna.UI2.WinForms.Guna2ComboBox cmbHoraInicio;
        private System.Windows.Forms.Label lblNumPersonas;
        private System.Windows.Forms.NumericUpDown nudNumPersonas;
        private System.Windows.Forms.Label lblTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNombreEvento;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreEvento;
        private System.Windows.Forms.Label lblMesasAsignadas;
        private System.Windows.Forms.Panel pnlMesas;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEstado;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;

        // ── Panel Lista (derecho) ──────────────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlLista;
        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltFecha;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Label lblFiltEstado;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblFiltTipo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltroTipo;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvReservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMesas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistradoPor;

        // ── Panel Botones Acción ───────────────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlBotonesAccion;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnCancelarRes;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;

        // ── Panel KPIs ─────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2Panel pnlKpis;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiTotal;
        private System.Windows.Forms.PictureBox picKpiTotal;
        private System.Windows.Forms.Label lblKpiTotalLabel;
        private System.Windows.Forms.Label lblKpiTotalValor;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiPendientes;
        private System.Windows.Forms.PictureBox picKpiPendientes;
        private System.Windows.Forms.Label lblKpiPendientesLabel;
        private System.Windows.Forms.Label lblKpiPendientesValor;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiConfirmadas;
        private System.Windows.Forms.PictureBox picKpiConfirmadas;
        private System.Windows.Forms.Label lblKpiConfirmadasLabel;
        private System.Windows.Forms.Label lblKpiConfirmadasValor;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiCanceladas;
        private System.Windows.Forms.PictureBox picKpiCanceladas;
        private System.Windows.Forms.Label lblKpiCanceladasLabel;
        private System.Windows.Forms.Label lblKpiCanceladasValor;
    }
}