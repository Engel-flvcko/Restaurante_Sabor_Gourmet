namespace Restaurante_Sabor_Gourmet.Engel
{
    partial class frmDashboard
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
            // Barra superior
            this.pnlSuperior = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();

            // Panel de KPIs (4 tarjetas)
            this.pnlKpis = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlVentas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblVentasLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblVentasHoy = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.pnlMesas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMesasLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMesasOcupadas = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.pnlCocina = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCoocinaLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblOrdenesEnCocina = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.pnlPropinas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPropinasLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPropinasHoy = new Guna.UI2.WinForms.Guna2HtmlLabel();

            this.btnRefrescar = new Guna.UI2.WinForms.Guna2Button();

            // Panel rango de fechas
            this.pnlRango = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesde = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarFechas = new Guna.UI2.WinForms.Guna2Button();
            this.lblVentasRangoLbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblVentasRango = new Guna.UI2.WinForms.Guna2HtmlLabel();

            // Tab de reportes
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tabMeseros = new System.Windows.Forms.TabPage();
            this.dgvVentasMesero = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.dgvTopProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabCategorias = new System.Windows.Forms.TabPage();
            this.dgvCategorias = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPropinas = new System.Windows.Forms.TabPage();
            this.dgvPropinas = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabCostos = new System.Windows.Forms.TabPage();
            this.dgvCostos = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlSuperior.SuspendLayout();
            this.pnlKpis.SuspendLayout();
            this.pnlVentas.SuspendLayout();
            this.pnlMesas.SuspendLayout();
            this.pnlCocina.SuspendLayout();
            this.pnlPropinas.SuspendLayout();
            this.pnlRango.SuspendLayout();
            this.tabReportes.SuspendLayout();
            this.tabMeseros.SuspendLayout();
            this.tabProductos.SuspendLayout();
            this.tabCategorias.SuspendLayout();
            this.tabPropinas.SuspendLayout();
            this.tabCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasMesero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.SuspendLayout();

            // ── pnlSuperior ──────────────────────────────────────────────────
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1280, 60);
            this.pnlSuperior.TabIndex = 0;
            this.pnlSuperior.Controls.Add(this.lblTitulo);

            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊  Dashboard Gerencial";

            // ── pnlKpis ──────────────────────────────────────────────────────
            this.pnlKpis.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.pnlKpis.Location = new System.Drawing.Point(0, 60);
            this.pnlKpis.Name = "pnlKpis";
            this.pnlKpis.Size = new System.Drawing.Size(1280, 130);
            this.pnlKpis.TabIndex = 1;
            this.pnlKpis.Controls.Add(this.pnlVentas);
            this.pnlKpis.Controls.Add(this.pnlMesas);
            this.pnlKpis.Controls.Add(this.pnlCocina);
            this.pnlKpis.Controls.Add(this.pnlPropinas);
            this.pnlKpis.Controls.Add(this.btnRefrescar);

            // Tarjeta 1: Ventas hoy
            ConstruirTarjeta(this.pnlVentas, 10, 10, 270,
                System.Drawing.Color.FromArgb(30, 30, 47),
                this.lblVentasLbl, "Ventas hoy",
                this.lblVentasHoy, "$0.00");

            // Tarjeta 2: Mesas ocupadas
            ConstruirTarjeta(this.pnlMesas, 290, 10, 270,
                System.Drawing.Color.FromArgb(59, 130, 246),
                this.lblMesasLbl, "Mesas ocupadas",
                this.lblMesasOcupadas, "0");

            // Tarjeta 3: Órdenes en cocina
            ConstruirTarjeta(this.pnlCocina, 570, 10, 270,
                System.Drawing.Color.FromArgb(234, 179, 8),
                this.lblCoocinaLbl, "Órdenes en cocina",
                this.lblOrdenesEnCocina, "0");

            // Tarjeta 4: Propinas hoy
            ConstruirTarjeta(this.pnlPropinas, 850, 10, 270,
                System.Drawing.Color.FromArgb(34, 197, 94),
                this.lblPropinasLbl, "Propinas hoy",
                this.lblPropinasHoy, "$0.00");

            this.btnRefrescar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefrescar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefrescar.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnRefrescar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnRefrescar.FillColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.BorderRadius = 8;
            this.btnRefrescar.Location = new System.Drawing.Point(1140, 45);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(130, 36);
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Text = "🔄 Actualizar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // ── pnlRango ─────────────────────────────────────────────────────
            this.pnlRango.BackColor = System.Drawing.Color.White;
            this.pnlRango.Location = new System.Drawing.Point(0, 200);
            this.pnlRango.Name = "pnlRango";
            this.pnlRango.Size = new System.Drawing.Size(1280, 60);
            this.pnlRango.TabIndex = 2;
            this.pnlRango.Controls.Add(this.lblDesde);
            this.pnlRango.Controls.Add(this.dtpDesde);
            this.pnlRango.Controls.Add(this.lblHasta);
            this.pnlRango.Controls.Add(this.dtpHasta);
            this.pnlRango.Controls.Add(this.btnFiltrarFechas);
            this.pnlRango.Controls.Add(this.lblVentasRangoLbl);
            this.pnlRango.Controls.Add(this.lblVentasRango);

            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblDesde.Location = new System.Drawing.Point(10, 10);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(50, 18);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 23);
            this.dtpDesde.TabIndex = 1;

            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblHasta.Location = new System.Drawing.Point(205, 10);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(50, 18);
            this.lblHasta.TabIndex = 0;
            this.lblHasta.Text = "Hasta";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(265, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 23);
            this.dtpHasta.TabIndex = 2;

            this.btnFiltrarFechas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrarFechas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFiltrarFechas.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnFiltrarFechas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnFiltrarFechas.FillColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnFiltrarFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltrarFechas.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarFechas.BorderRadius = 6;
            this.btnFiltrarFechas.Location = new System.Drawing.Point(400, 5);
            this.btnFiltrarFechas.Name = "btnFiltrarFechas";
            this.btnFiltrarFechas.Size = new System.Drawing.Size(120, 34);
            this.btnFiltrarFechas.TabIndex = 3;
            this.btnFiltrarFechas.Text = "🔍 Filtrar";
            this.btnFiltrarFechas.Click += new System.EventHandler(this.btnFiltrarFechas_Click);

            this.lblVentasRangoLbl.BackColor = System.Drawing.Color.Transparent;
            this.lblVentasRangoLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVentasRangoLbl.ForeColor = System.Drawing.Color.FromArgb(80, 80, 110);
            this.lblVentasRangoLbl.Location = new System.Drawing.Point(540, 10);
            this.lblVentasRangoLbl.Name = "lblVentasRangoLbl";
            this.lblVentasRangoLbl.Size = new System.Drawing.Size(120, 18);
            this.lblVentasRangoLbl.TabIndex = 0;
            this.lblVentasRangoLbl.Text = "Total en rango:";

            this.lblVentasRango.BackColor = System.Drawing.Color.Transparent;
            this.lblVentasRango.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblVentasRango.ForeColor = System.Drawing.Color.FromArgb(30, 30, 47);
            this.lblVentasRango.Location = new System.Drawing.Point(670, 5);
            this.lblVentasRango.Name = "lblVentasRango";
            this.lblVentasRango.Size = new System.Drawing.Size(200, 30);
            this.lblVentasRango.TabIndex = 0;
            this.lblVentasRango.Text = "$0.00";

            // ── tabReportes ──────────────────────────────────────────────────
            this.tabReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabReportes.Location = new System.Drawing.Point(0, 270);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(1280, 580);
            this.tabReportes.TabIndex = 3;
            this.tabReportes.Controls.Add(this.tabMeseros);
            this.tabReportes.Controls.Add(this.tabProductos);
            this.tabReportes.Controls.Add(this.tabCategorias);
            this.tabReportes.Controls.Add(this.tabPropinas);
            this.tabReportes.Controls.Add(this.tabCostos);
            this.tabReportes.SelectedIndexChanged += new System.EventHandler(this.tabReportes_SelectedIndexChanged);

            // Tabs y grids
            ConfigurarTab(this.tabMeseros, "  Ventas por mesero  ", this.dgvVentasMesero, "dgvVentasMesero");
            ConfigurarTab(this.tabProductos, "  Top productos  ", this.dgvTopProductos, "dgvTopProductos");
            ConfigurarTab(this.tabCategorias, "  Ventas por categoría  ", this.dgvCategorias, "dgvCategorias");
            ConfigurarTab(this.tabPropinas, "  Propinas  ", this.dgvPropinas, "dgvPropinas");
            ConfigurarTab(this.tabCostos, "  Costos de producción  ", this.dgvCostos, "dgvCostos");

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 248);
            this.ClientSize = new System.Drawing.Size(1280, 860);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlKpis);
            this.Controls.Add(this.pnlRango);
            this.Controls.Add(this.tabReportes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmDashboard";
            this.Text = "Dashboard Gerencial — Sabor Gourmet FMO";
            this.Load += new System.EventHandler(this.frmDashboard_Load);

            this.pnlSuperior.ResumeLayout(false);
            this.pnlKpis.ResumeLayout(false);
            this.pnlVentas.ResumeLayout(false);
            this.pnlMesas.ResumeLayout(false);
            this.pnlCocina.ResumeLayout(false);
            this.pnlPropinas.ResumeLayout(false);
            this.pnlRango.ResumeLayout(false);
            this.tabMeseros.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            this.tabCategorias.ResumeLayout(false);
            this.tabPropinas.ResumeLayout(false);
            this.tabCostos.ResumeLayout(false);
            this.tabReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasMesero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private void ConstruirTarjeta(Guna.UI2.WinForms.Guna2Panel pnl,
            int x, int y, int ancho,
            System.Drawing.Color color,
            Guna.UI2.WinForms.Guna2HtmlLabel lbl1, string texto1,
            Guna.UI2.WinForms.Guna2HtmlLabel lbl2, string texto2)
        {
            pnl.BackColor = color;
            pnl.BorderRadius = 12;
            pnl.Location = new System.Drawing.Point(x, y);
            pnl.Size = new System.Drawing.Size(ancho, 110);

            lbl1.BackColor = System.Drawing.Color.Transparent;
            lbl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl1.ForeColor = System.Drawing.Color.FromArgb(200, 200, 220);
            lbl1.Location = new System.Drawing.Point(15, 15);
            lbl1.Size = new System.Drawing.Size(240, 18);
            lbl1.TabIndex = 0;
            lbl1.Text = texto1;

            lbl2.BackColor = System.Drawing.Color.Transparent;
            lbl2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lbl2.ForeColor = System.Drawing.Color.White;
            lbl2.Location = new System.Drawing.Point(15, 40);
            lbl2.Size = new System.Drawing.Size(240, 50);
            lbl2.TabIndex = 0;
            lbl2.Text = texto2;

            pnl.Controls.Add(lbl1);
            pnl.Controls.Add(lbl2);
            this.pnlKpis.Controls.Add(pnl);
        }

        private void ConfigurarTab(System.Windows.Forms.TabPage tab, string titulo,
            Guna.UI2.WinForms.Guna2DataGridView dgv, string nombreDgv)
        {
            tab.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            tab.Text = titulo;
            tab.Padding = new System.Windows.Forms.Padding(5);

            var hdr = new System.Windows.Forms.DataGridViewCellStyle();
            hdr.BackColor = System.Drawing.Color.FromArgb(30, 30, 47);
            hdr.Font = new System.Drawing.Font("Segoe UI", 10F);
            hdr.ForeColor = System.Drawing.Color.White;
            hdr.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            hdr.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

            var row = new System.Windows.Forms.DataGridViewCellStyle();
            row.BackColor = System.Drawing.Color.White;
            row.Font = new System.Drawing.Font("Segoe UI", 10F);
            row.ForeColor = System.Drawing.Color.FromArgb(50, 50, 80);
            row.SelectionBackColor = System.Drawing.Color.FromArgb(200, 210, 255);
            row.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 47);

            dgv.ColumnHeadersDefaultCellStyle = hdr;
            dgv.DefaultCellStyle = row;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.GridColor = System.Drawing.Color.FromArgb(220, 220, 235);
            dgv.Name = nombreDgv;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.TabIndex = 0;
            dgv.ThemeStyle.ReadOnly = true;

            tab.Controls.Add(dgv);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlSuperior;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;

        private Guna.UI2.WinForms.Guna2Panel pnlKpis;
        private Guna.UI2.WinForms.Guna2Panel pnlVentas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVentasLbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVentasHoy;
        private Guna.UI2.WinForms.Guna2Panel pnlMesas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMesasLbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMesasOcupadas;
        private Guna.UI2.WinForms.Guna2Panel pnlCocina;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCoocinaLbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOrdenesEnCocina;
        private Guna.UI2.WinForms.Guna2Panel pnlPropinas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPropinasLbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPropinasHoy;
        private Guna.UI2.WinForms.Guna2Button btnRefrescar;

        private Guna.UI2.WinForms.Guna2Panel pnlRango;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2Button btnFiltrarFechas;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVentasRangoLbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVentasRango;

        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabMeseros;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVentasMesero;
        private System.Windows.Forms.TabPage tabProductos;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopProductos;
        private System.Windows.Forms.TabPage tabCategorias;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCategorias;
        private System.Windows.Forms.TabPage tabPropinas;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPropinas;
        private System.Windows.Forms.TabPage tabCostos;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCostos;
    }
}
