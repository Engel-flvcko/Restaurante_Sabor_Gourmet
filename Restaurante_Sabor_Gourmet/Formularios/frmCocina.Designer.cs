namespace Restaurante_Sabor_Gourmet.Formularios
{
    partial class frmCocina
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
            // ---------- KPI: Tiempo Promedio ----------
            this.pnlKpiTiempoProm = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconTiempoProm = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconTiempoProm = new System.Windows.Forms.Label();
            this.lblKpiTiempoPromTitulo = new System.Windows.Forms.Label();
            this.lblKpiTiempoPromValor = new System.Windows.Forms.Label();
            this.lblKpiTiempoPromPeriodo = new System.Windows.Forms.Label();

            // ---------- KPI: Órdenes Pendientes ----------
            this.pnlKpiPendientes = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconPendientes = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconPendientes = new System.Windows.Forms.Label();
            this.lblKpiPendientesTitulo = new System.Windows.Forms.Label();
            this.lblKpiPendientesValor = new System.Windows.Forms.Label();
            this.lblKpiPendientesPeriodo = new System.Windows.Forms.Label();

            // ---------- KPI: Órdenes Retrasadas ----------
            this.pnlKpiRetrasadas = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconRetrasadas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconRetrasadas = new System.Windows.Forms.Label();
            this.lblKpiRetrasadasTitulo = new System.Windows.Forms.Label();
            this.lblKpiRetrasadasValor = new System.Windows.Forms.Label();
            this.lblKpiRetrasadasPeriodo = new System.Windows.Forms.Label();

            // ---------- KPI: Productos Más Solicitados ----------
            this.pnlKpiTopProductos = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlIconTopProductos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIconTopProductos = new System.Windows.Forms.Label();
            this.lblKpiTopProductosTitulo = new System.Windows.Forms.Label();
            this.lblTop1Nombre = new System.Windows.Forms.Label();
            this.lblTop1Cantidad = new System.Windows.Forms.Label();
            this.lblTop2Nombre = new System.Windows.Forms.Label();
            this.lblTop2Cantidad = new System.Windows.Forms.Label();
            this.lblTop3Nombre = new System.Windows.Forms.Label();
            this.lblTop3Cantidad = new System.Windows.Forms.Label();

            // ---------- Barra de filtros ----------
            this.pnlFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFiltroTodas = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroPendientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroPreparacion = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroListas = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroEntregadas = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltroCanceladas = new Guna.UI2.WinForms.Guna2Button();

            // ---------- Contenedor de la cola de producción (tarjetas dinámicas) ----------
            this.pnlColaProduccion = new System.Windows.Forms.Panel();

            this.pnlKpiTiempoProm.SuspendLayout();
            this.pnlIconTiempoProm.SuspendLayout();
            this.pnlKpiPendientes.SuspendLayout();
            this.pnlIconPendientes.SuspendLayout();
            this.pnlKpiRetrasadas.SuspendLayout();
            this.pnlIconRetrasadas.SuspendLayout();
            this.pnlKpiTopProductos.SuspendLayout();
            this.pnlIconTopProductos.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();

            // ============================================================
            // pnlKpiTiempoProm
            // ============================================================
            this.pnlKpiTiempoProm.BorderRadius = 12;
            this.pnlKpiTiempoProm.FillColor = System.Drawing.Color.White;
            this.pnlKpiTiempoProm.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiTiempoProm.Name = "pnlKpiTiempoProm";
            this.pnlKpiTiempoProm.ShadowDecoration.Enabled = true;
            this.pnlKpiTiempoProm.Size = new System.Drawing.Size(360, 140);
            this.pnlKpiTiempoProm.TabIndex = 0;
            this.pnlKpiTiempoProm.Controls.Add(this.pnlIconTiempoProm);
            this.pnlKpiTiempoProm.Controls.Add(this.lblKpiTiempoPromTitulo);
            this.pnlKpiTiempoProm.Controls.Add(this.lblKpiTiempoPromValor);
            this.pnlKpiTiempoProm.Controls.Add(this.lblKpiTiempoPromPeriodo);

            this.pnlIconTiempoProm.BorderRadius = 25;
            this.pnlIconTiempoProm.FillColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.pnlIconTiempoProm.Location = new System.Drawing.Point(20, 20);
            this.pnlIconTiempoProm.Name = "pnlIconTiempoProm";
            this.pnlIconTiempoProm.Size = new System.Drawing.Size(50, 50);
            this.pnlIconTiempoProm.TabIndex = 0;
            this.pnlIconTiempoProm.Controls.Add(this.lblIconTiempoProm);

            this.lblIconTiempoProm.AutoSize = false;
            this.lblIconTiempoProm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconTiempoProm.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblIconTiempoProm.Name = "lblIconTiempoProm";
            this.lblIconTiempoProm.Text = "⏱";
            this.lblIconTiempoProm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTiempoPromTitulo.AutoSize = true;
            this.lblKpiTiempoPromTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiTiempoPromTitulo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblKpiTiempoPromTitulo.Location = new System.Drawing.Point(85, 30);
            this.lblKpiTiempoPromTitulo.Name = "lblKpiTiempoPromTitulo";
            this.lblKpiTiempoPromTitulo.Size = new System.Drawing.Size(240, 19);
            this.lblKpiTiempoPromTitulo.TabIndex = 1;
            this.lblKpiTiempoPromTitulo.Text = "Tiempo Promedio de Preparación";

            this.lblKpiTiempoPromValor.AutoSize = true;
            this.lblKpiTiempoPromValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiTiempoPromValor.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.lblKpiTiempoPromValor.Location = new System.Drawing.Point(20, 78);
            this.lblKpiTiempoPromValor.Name = "lblKpiTiempoPromValor";
            this.lblKpiTiempoPromValor.Size = new System.Drawing.Size(120, 45);
            this.lblKpiTiempoPromValor.TabIndex = 2;
            this.lblKpiTiempoPromValor.Text = "0 min";

            this.lblKpiTiempoPromPeriodo.AutoSize = true;
            this.lblKpiTiempoPromPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiTiempoPromPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiTiempoPromPeriodo.Location = new System.Drawing.Point(22, 118);
            this.lblKpiTiempoPromPeriodo.Name = "lblKpiTiempoPromPeriodo";
            this.lblKpiTiempoPromPeriodo.Size = new System.Drawing.Size(110, 17);
            this.lblKpiTiempoPromPeriodo.TabIndex = 3;
            this.lblKpiTiempoPromPeriodo.Text = "Últimos 30 minutos";

            // ============================================================
            // pnlKpiPendientes
            // ============================================================
            this.pnlKpiPendientes.BorderRadius = 12;
            this.pnlKpiPendientes.FillColor = System.Drawing.Color.White;
            this.pnlKpiPendientes.Location = new System.Drawing.Point(395, 20);
            this.pnlKpiPendientes.Name = "pnlKpiPendientes";
            this.pnlKpiPendientes.ShadowDecoration.Enabled = true;
            this.pnlKpiPendientes.Size = new System.Drawing.Size(360, 140);
            this.pnlKpiPendientes.TabIndex = 1;
            this.pnlKpiPendientes.Controls.Add(this.pnlIconPendientes);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesTitulo);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesValor);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesPeriodo);

            this.pnlIconPendientes.BorderRadius = 25;
            this.pnlIconPendientes.FillColor = System.Drawing.Color.FromArgb(255, 237, 213);
            this.pnlIconPendientes.Location = new System.Drawing.Point(20, 20);
            this.pnlIconPendientes.Name = "pnlIconPendientes";
            this.pnlIconPendientes.Size = new System.Drawing.Size(50, 50);
            this.pnlIconPendientes.TabIndex = 0;
            this.pnlIconPendientes.Controls.Add(this.lblIconPendientes);

            this.lblIconPendientes.AutoSize = false;
            this.lblIconPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconPendientes.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblIconPendientes.Name = "lblIconPendientes";
            this.lblIconPendientes.Text = "🕐";
            this.lblIconPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiPendientesTitulo.AutoSize = true;
            this.lblKpiPendientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiPendientesTitulo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblKpiPendientesTitulo.Location = new System.Drawing.Point(85, 30);
            this.lblKpiPendientesTitulo.Name = "lblKpiPendientesTitulo";
            this.lblKpiPendientesTitulo.Size = new System.Drawing.Size(140, 19);
            this.lblKpiPendientesTitulo.TabIndex = 1;
            this.lblKpiPendientesTitulo.Text = "Órdenes Pendientes";

            this.lblKpiPendientesValor.AutoSize = true;
            this.lblKpiPendientesValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendientesValor.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.lblKpiPendientesValor.Location = new System.Drawing.Point(20, 78);
            this.lblKpiPendientesValor.Name = "lblKpiPendientesValor";
            this.lblKpiPendientesValor.Size = new System.Drawing.Size(60, 45);
            this.lblKpiPendientesValor.TabIndex = 2;
            this.lblKpiPendientesValor.Text = "0";

            this.lblKpiPendientesPeriodo.AutoSize = true;
            this.lblKpiPendientesPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiPendientesPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiPendientesPeriodo.Location = new System.Drawing.Point(22, 118);
            this.lblKpiPendientesPeriodo.Name = "lblKpiPendientesPeriodo";
            this.lblKpiPendientesPeriodo.Size = new System.Drawing.Size(75, 17);
            this.lblKpiPendientesPeriodo.TabIndex = 3;
            this.lblKpiPendientesPeriodo.Text = "Por preparar";

            // ============================================================
            // pnlKpiRetrasadas
            // ============================================================
            this.pnlKpiRetrasadas.BorderRadius = 12;
            this.pnlKpiRetrasadas.FillColor = System.Drawing.Color.White;
            this.pnlKpiRetrasadas.Location = new System.Drawing.Point(770, 20);
            this.pnlKpiRetrasadas.Name = "pnlKpiRetrasadas";
            this.pnlKpiRetrasadas.ShadowDecoration.Enabled = true;
            this.pnlKpiRetrasadas.Size = new System.Drawing.Size(360, 140);
            this.pnlKpiRetrasadas.TabIndex = 2;
            this.pnlKpiRetrasadas.Controls.Add(this.pnlIconRetrasadas);
            this.pnlKpiRetrasadas.Controls.Add(this.lblKpiRetrasadasTitulo);
            this.pnlKpiRetrasadas.Controls.Add(this.lblKpiRetrasadasValor);
            this.pnlKpiRetrasadas.Controls.Add(this.lblKpiRetrasadasPeriodo);

            this.pnlIconRetrasadas.BorderRadius = 25;
            this.pnlIconRetrasadas.FillColor = System.Drawing.Color.FromArgb(254, 226, 226);
            this.pnlIconRetrasadas.Location = new System.Drawing.Point(20, 20);
            this.pnlIconRetrasadas.Name = "pnlIconRetrasadas";
            this.pnlIconRetrasadas.Size = new System.Drawing.Size(50, 50);
            this.pnlIconRetrasadas.TabIndex = 0;
            this.pnlIconRetrasadas.Controls.Add(this.lblIconRetrasadas);

            this.lblIconRetrasadas.AutoSize = false;
            this.lblIconRetrasadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconRetrasadas.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblIconRetrasadas.Name = "lblIconRetrasadas";
            this.lblIconRetrasadas.Text = "⚠";
            this.lblIconRetrasadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiRetrasadasTitulo.AutoSize = true;
            this.lblKpiRetrasadasTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiRetrasadasTitulo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblKpiRetrasadasTitulo.Location = new System.Drawing.Point(85, 30);
            this.lblKpiRetrasadasTitulo.Name = "lblKpiRetrasadasTitulo";
            this.lblKpiRetrasadasTitulo.Size = new System.Drawing.Size(140, 19);
            this.lblKpiRetrasadasTitulo.TabIndex = 1;
            this.lblKpiRetrasadasTitulo.Text = "Órdenes Retrasadas";

            this.lblKpiRetrasadasValor.AutoSize = true;
            this.lblKpiRetrasadasValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiRetrasadasValor.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblKpiRetrasadasValor.Location = new System.Drawing.Point(20, 78);
            this.lblKpiRetrasadasValor.Name = "lblKpiRetrasadasValor";
            this.lblKpiRetrasadasValor.Size = new System.Drawing.Size(60, 45);
            this.lblKpiRetrasadasValor.TabIndex = 2;
            this.lblKpiRetrasadasValor.Text = "0";

            this.lblKpiRetrasadasPeriodo.AutoSize = true;
            this.lblKpiRetrasadasPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiRetrasadasPeriodo.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiRetrasadasPeriodo.Location = new System.Drawing.Point(22, 118);
            this.lblKpiRetrasadasPeriodo.Name = "lblKpiRetrasadasPeriodo";
            this.lblKpiRetrasadasPeriodo.Size = new System.Drawing.Size(50, 17);
            this.lblKpiRetrasadasPeriodo.TabIndex = 3;
            this.lblKpiRetrasadasPeriodo.Text = "+30 min";

            // ============================================================
            // pnlKpiTopProductos
            // ============================================================
            this.pnlKpiTopProductos.BorderRadius = 12;
            this.pnlKpiTopProductos.FillColor = System.Drawing.Color.White;
            this.pnlKpiTopProductos.Location = new System.Drawing.Point(1145, 20);
            this.pnlKpiTopProductos.Name = "pnlKpiTopProductos";
            this.pnlKpiTopProductos.ShadowDecoration.Enabled = true;
            this.pnlKpiTopProductos.Size = new System.Drawing.Size(371, 140);
            this.pnlKpiTopProductos.TabIndex = 3;
            this.pnlKpiTopProductos.Controls.Add(this.pnlIconTopProductos);
            this.pnlKpiTopProductos.Controls.Add(this.lblKpiTopProductosTitulo);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop1Nombre);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop1Cantidad);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop2Nombre);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop2Cantidad);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop3Nombre);
            this.pnlKpiTopProductos.Controls.Add(this.lblTop3Cantidad);

            this.pnlIconTopProductos.BorderRadius = 21;
            this.pnlIconTopProductos.FillColor = System.Drawing.Color.FromArgb(243, 232, 255);
            this.pnlIconTopProductos.Location = new System.Drawing.Point(20, 18);
            this.pnlIconTopProductos.Name = "pnlIconTopProductos";
            this.pnlIconTopProductos.Size = new System.Drawing.Size(42, 42);
            this.pnlIconTopProductos.TabIndex = 0;
            this.pnlIconTopProductos.Controls.Add(this.lblIconTopProductos);

            this.lblIconTopProductos.AutoSize = false;
            this.lblIconTopProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconTopProductos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblIconTopProductos.Name = "lblIconTopProductos";
            this.lblIconTopProductos.Text = "📊";
            this.lblIconTopProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTopProductosTitulo.AutoSize = true;
            this.lblKpiTopProductosTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiTopProductosTitulo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.lblKpiTopProductosTitulo.Location = new System.Drawing.Point(72, 28);
            this.lblKpiTopProductosTitulo.Name = "lblKpiTopProductosTitulo";
            this.lblKpiTopProductosTitulo.Size = new System.Drawing.Size(190, 19);
            this.lblKpiTopProductosTitulo.TabIndex = 1;
            this.lblKpiTopProductosTitulo.Text = "Productos Más Solicitados";

            this.lblTop1Nombre.AutoSize = true;
            this.lblTop1Nombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTop1Nombre.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTop1Nombre.Location = new System.Drawing.Point(20, 65);
            this.lblTop1Nombre.Name = "lblTop1Nombre";
            this.lblTop1Nombre.Size = new System.Drawing.Size(150, 19);
            this.lblTop1Nombre.TabIndex = 2;
            this.lblTop1Nombre.Text = "1.  ---";

            this.lblTop1Cantidad.AutoSize = true;
            this.lblTop1Cantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTop1Cantidad.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblTop1Cantidad.Location = new System.Drawing.Point(335, 65);
            this.lblTop1Cantidad.Name = "lblTop1Cantidad";
            this.lblTop1Cantidad.Size = new System.Drawing.Size(20, 19);
            this.lblTop1Cantidad.TabIndex = 3;
            this.lblTop1Cantidad.Text = "0";

            this.lblTop2Nombre.AutoSize = true;
            this.lblTop2Nombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTop2Nombre.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTop2Nombre.Location = new System.Drawing.Point(20, 90);
            this.lblTop2Nombre.Name = "lblTop2Nombre";
            this.lblTop2Nombre.Size = new System.Drawing.Size(150, 19);
            this.lblTop2Nombre.TabIndex = 4;
            this.lblTop2Nombre.Text = "2.  ---";

            this.lblTop2Cantidad.AutoSize = true;
            this.lblTop2Cantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTop2Cantidad.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblTop2Cantidad.Location = new System.Drawing.Point(335, 90);
            this.lblTop2Cantidad.Name = "lblTop2Cantidad";
            this.lblTop2Cantidad.Size = new System.Drawing.Size(20, 19);
            this.lblTop2Cantidad.TabIndex = 5;
            this.lblTop2Cantidad.Text = "0";

            this.lblTop3Nombre.AutoSize = true;
            this.lblTop3Nombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTop3Nombre.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblTop3Nombre.Location = new System.Drawing.Point(20, 115);
            this.lblTop3Nombre.Name = "lblTop3Nombre";
            this.lblTop3Nombre.Size = new System.Drawing.Size(150, 19);
            this.lblTop3Nombre.TabIndex = 6;
            this.lblTop3Nombre.Text = "3.  ---";

            this.lblTop3Cantidad.AutoSize = true;
            this.lblTop3Cantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTop3Cantidad.ForeColor = System.Drawing.Color.FromArgb(168, 85, 247);
            this.lblTop3Cantidad.Location = new System.Drawing.Point(335, 115);
            this.lblTop3Cantidad.Name = "lblTop3Cantidad";
            this.lblTop3Cantidad.Size = new System.Drawing.Size(20, 19);
            this.lblTop3Cantidad.TabIndex = 7;
            this.lblTop3Cantidad.Text = "0";

            // ============================================================
            // pnlFiltros
            // ============================================================
            this.pnlFiltros.BorderRadius = 12;
            this.pnlFiltros.FillColor = System.Drawing.Color.White;
            this.pnlFiltros.Location = new System.Drawing.Point(20, 175);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.ShadowDecoration.Enabled = true;
            this.pnlFiltros.Size = new System.Drawing.Size(1496, 65);
            this.pnlFiltros.TabIndex = 4;
            this.pnlFiltros.Controls.Add(this.btnFiltroTodas);
            this.pnlFiltros.Controls.Add(this.btnFiltroPendientes);
            this.pnlFiltros.Controls.Add(this.btnFiltroPreparacion);
            this.pnlFiltros.Controls.Add(this.btnFiltroListas);
            this.pnlFiltros.Controls.Add(this.btnFiltroEntregadas);
            this.pnlFiltros.Controls.Add(this.btnFiltroCanceladas);

            this.btnFiltroTodas.BorderRadius = 8;
            this.btnFiltroTodas.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroTodas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFiltroTodas.ForeColor = System.Drawing.Color.White;
            this.btnFiltroTodas.Location = new System.Drawing.Point(20, 12);
            this.btnFiltroTodas.Name = "btnFiltroTodas";
            this.btnFiltroTodas.Size = new System.Drawing.Size(110, 40);
            this.btnFiltroTodas.TabIndex = 0;
            this.btnFiltroTodas.Text = "Todas";
            this.btnFiltroTodas.Tag = "todas";
            this.btnFiltroTodas.Click += new System.EventHandler(this.btnFiltro_Click);

            this.btnFiltroPendientes.BorderRadius = 8;
            this.btnFiltroPendientes.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnFiltroPendientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltroPendientes.ForeColor = System.Drawing.Color.FromArgb(249, 115, 22);
            this.btnFiltroPendientes.Location = new System.Drawing.Point(150, 12);
            this.btnFiltroPendientes.Name = "btnFiltroPendientes";
            this.btnFiltroPendientes.Size = new System.Drawing.Size(150, 40);
            this.btnFiltroPendientes.TabIndex = 1;
            this.btnFiltroPendientes.Text = "🕐  Pendientes";
            this.btnFiltroPendientes.Tag = "pendiente";
            this.btnFiltroPendientes.Click += new System.EventHandler(this.btnFiltro_Click);

            this.btnFiltroPreparacion.BorderRadius = 8;
            this.btnFiltroPreparacion.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnFiltroPreparacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltroPreparacion.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroPreparacion.Location = new System.Drawing.Point(320, 12);
            this.btnFiltroPreparacion.Name = "btnFiltroPreparacion";
            this.btnFiltroPreparacion.Size = new System.Drawing.Size(170, 40);
            this.btnFiltroPreparacion.TabIndex = 2;
            this.btnFiltroPreparacion.Text = "🍳  En Preparación";
            this.btnFiltroPreparacion.Tag = "en_preparacion";
            this.btnFiltroPreparacion.Click += new System.EventHandler(this.btnFiltro_Click);

            this.btnFiltroListas.BorderRadius = 8;
            this.btnFiltroListas.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnFiltroListas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltroListas.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnFiltroListas.Location = new System.Drawing.Point(510, 12);
            this.btnFiltroListas.Name = "btnFiltroListas";
            this.btnFiltroListas.Size = new System.Drawing.Size(120, 40);
            this.btnFiltroListas.TabIndex = 3;
            this.btnFiltroListas.Text = "✓  Listas";
            this.btnFiltroListas.Tag = "lista";
            this.btnFiltroListas.Click += new System.EventHandler(this.btnFiltro_Click);

            this.btnFiltroEntregadas.BorderRadius = 8;
            this.btnFiltroEntregadas.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnFiltroEntregadas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltroEntregadas.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnFiltroEntregadas.Location = new System.Drawing.Point(650, 12);
            this.btnFiltroEntregadas.Name = "btnFiltroEntregadas";
            this.btnFiltroEntregadas.Size = new System.Drawing.Size(150, 40);
            this.btnFiltroEntregadas.TabIndex = 4;
            this.btnFiltroEntregadas.Text = "✓  Entregadas";
            this.btnFiltroEntregadas.Tag = "entregada";
            this.btnFiltroEntregadas.Click += new System.EventHandler(this.btnFiltro_Click);

            this.btnFiltroCanceladas.BorderRadius = 8;
            this.btnFiltroCanceladas.FillColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.btnFiltroCanceladas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFiltroCanceladas.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnFiltroCanceladas.Location = new System.Drawing.Point(820, 12);
            this.btnFiltroCanceladas.Name = "btnFiltroCanceladas";
            this.btnFiltroCanceladas.Size = new System.Drawing.Size(150, 40);
            this.btnFiltroCanceladas.TabIndex = 5;
            this.btnFiltroCanceladas.Text = "✕  Canceladas";
            this.btnFiltroCanceladas.Tag = "cancelada";
            this.btnFiltroCanceladas.Click += new System.EventHandler(this.btnFiltro_Click);

            // ============================================================
            // pnlColaProduccion
            // (panel vacío: las tarjetas de cada orden se generan dinámicamente
            //  por código, en orden estricto de hora_recepcion ascendente,
            //  en una cuadrícula de 3 columnas)
            // ============================================================
            this.pnlColaProduccion.AutoScroll = true;
            this.pnlColaProduccion.BackColor = System.Drawing.Color.Transparent;
            this.pnlColaProduccion.Location = new System.Drawing.Point(20, 255);
            this.pnlColaProduccion.Name = "pnlColaProduccion";
            this.pnlColaProduccion.Size = new System.Drawing.Size(1496, 670);
            this.pnlColaProduccion.TabIndex = 5;

            // 
            // frmCocina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1536, 945);
            this.Controls.Add(this.pnlKpiTiempoProm);
            this.Controls.Add(this.pnlKpiPendientes);
            this.Controls.Add(this.pnlKpiRetrasadas);
            this.Controls.Add(this.pnlKpiTopProductos);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlColaProduccion);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCocina";
            this.Text = "Cola de Producción - Cocina";
            this.Load += new System.EventHandler(this.frmCocina_Load);

            this.pnlKpiTiempoProm.ResumeLayout(false);
            this.pnlKpiTiempoProm.PerformLayout();
            this.pnlIconTiempoProm.ResumeLayout(false);
            this.pnlKpiPendientes.ResumeLayout(false);
            this.pnlKpiPendientes.PerformLayout();
            this.pnlIconPendientes.ResumeLayout(false);
            this.pnlKpiRetrasadas.ResumeLayout(false);
            this.pnlKpiRetrasadas.PerformLayout();
            this.pnlIconRetrasadas.ResumeLayout(false);
            this.pnlKpiTopProductos.ResumeLayout(false);
            this.pnlKpiTopProductos.PerformLayout();
            this.pnlIconTopProductos.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlKpiTiempoProm;
        private Guna.UI2.WinForms.Guna2Panel pnlIconTiempoProm;
        private System.Windows.Forms.Label lblIconTiempoProm;
        private System.Windows.Forms.Label lblKpiTiempoPromTitulo;
        private System.Windows.Forms.Label lblKpiTiempoPromValor;
        private System.Windows.Forms.Label lblKpiTiempoPromPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiPendientes;
        private Guna.UI2.WinForms.Guna2Panel pnlIconPendientes;
        private System.Windows.Forms.Label lblIconPendientes;
        private System.Windows.Forms.Label lblKpiPendientesTitulo;
        private System.Windows.Forms.Label lblKpiPendientesValor;
        private System.Windows.Forms.Label lblKpiPendientesPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiRetrasadas;
        private Guna.UI2.WinForms.Guna2Panel pnlIconRetrasadas;
        private System.Windows.Forms.Label lblIconRetrasadas;
        private System.Windows.Forms.Label lblKpiRetrasadasTitulo;
        private System.Windows.Forms.Label lblKpiRetrasadasValor;
        private System.Windows.Forms.Label lblKpiRetrasadasPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpiTopProductos;
        private Guna.UI2.WinForms.Guna2Panel pnlIconTopProductos;
        private System.Windows.Forms.Label lblIconTopProductos;
        private System.Windows.Forms.Label lblKpiTopProductosTitulo;
        private System.Windows.Forms.Label lblTop1Nombre;
        private System.Windows.Forms.Label lblTop1Cantidad;
        private System.Windows.Forms.Label lblTop2Nombre;
        private System.Windows.Forms.Label lblTop2Cantidad;
        private System.Windows.Forms.Label lblTop3Nombre;
        private System.Windows.Forms.Label lblTop3Cantidad;

        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;
        private Guna.UI2.WinForms.Guna2Button btnFiltroTodas;
        private Guna.UI2.WinForms.Guna2Button btnFiltroPendientes;
        private Guna.UI2.WinForms.Guna2Button btnFiltroPreparacion;
        private Guna.UI2.WinForms.Guna2Button btnFiltroListas;
        private Guna.UI2.WinForms.Guna2Button btnFiltroEntregadas;
        private Guna.UI2.WinForms.Guna2Button btnFiltroCanceladas;

        private System.Windows.Forms.Panel pnlColaProduccion;
    }
}