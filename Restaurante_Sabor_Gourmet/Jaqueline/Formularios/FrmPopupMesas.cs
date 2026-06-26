using Restaurante_Sabor_Gourmet.Jaqueline.ConsultasSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Sabor_Gourmet.Jaqueline.Formularios
{
    public partial class FrmPopupMesas : Form
    {
        // ── Tab inicial que abre el popup ─────────────────────────────
        public enum TabInicial { Unir, Transferir, Dividir }

        private int idMesaActual;
        private TabInicial tabActiva;
        private SQLMesas sqlMesas;

        // Selecciones del usuario
        private int idMesaSeleccionadaUnir = -1;
        private int idMesaSeleccionadaTransferir = -1;
        private int idMesaSeleccionadaDividir = -1;

        public FrmPopupMesas(int idMesa, TabInicial tab, SQLMesas sql)
        {
            InitializeComponent();
            this.idMesaActual = idMesa;
            this.tabActiva = tab;
            this.sqlMesas = sql;
        }


        //  Carga inicial
    
        private void FrmPopupMesas_Load(object sender, EventArgs e)
        {
            // Ocultar todos los tabs primero
            btnTabUnir.Visible = false;
            btnTabTransferir.Visible = false;
            btnTabDividir.Visible = false;

            // Mostrar solo el tab correspondiente
            switch (tabActiva)
            {
                case TabInicial.Unir:
                    btnTabUnir.Visible = true;
                    MostrarTabUnir();
                    break;
                case TabInicial.Transferir:
                    btnTabTransferir.Visible = true;
                    MostrarTabTransferir();
                    break;
                case TabInicial.Dividir:
                    btnTabDividir.Visible = true;
                    MostrarTabDividir();
                    break;
            }

            ActualizarEstiloTabs();
        }
        

        //  TABS

        private void btnTabUnir_Click(object sender, EventArgs e)
        {
            tabActiva = TabInicial.Unir;
            MostrarTabUnir();
            ActualizarEstiloTabs();
        }

        private void btnTabTransferir_Click(object sender, EventArgs e)
        {
            tabActiva = TabInicial.Transferir;
            MostrarTabTransferir();
            ActualizarEstiloTabs();
        }

        private void btnTabDividir_Click(object sender, EventArgs e)
        {
            tabActiva = TabInicial.Dividir;
            MostrarTabDividir();
            ActualizarEstiloTabs();
        }

        private void ActualizarEstiloTabs()
        {
            Color activo = Color.FromArgb(30, 30, 47);

            if (btnTabUnir.Visible)
            {
                btnTabUnir.ForeColor = activo;
                btnTabUnir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (btnTabTransferir.Visible)
            {
                btnTabTransferir.ForeColor = activo;
                btnTabTransferir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (btnTabDividir.Visible)
            {
                btnTabDividir.ForeColor = activo;
                btnTabDividir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }


        //  TAB 1 — unir esas
    
        private void MostrarTabUnir()
        {
            pnlContenido.Controls.Clear();
            idMesaSeleccionadaUnir = -1;

            // Título
            Label lblTitulo = new Label
            {
                Text = "Unir mesa M" + ObtenerNumeroMesa(idMesaActual),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            Label lblSub = new Label
            {
                Text = "Seleccione la(s) mesa(s) a unir",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 135),
                AutoSize = true,
                Location = new Point(0, 28)
            };

            // Lista de mesas adyacentes disponibles
            Panel pnlLista = new Panel
            {
                Location = new Point(0, 58),
                Size = new Size(440, 220),
                AutoScroll = true
            };

            DataTable dt = sqlMesas.ObtenerMesasAdyacentesDisponibles(idMesaActual);
            int y = 0;
            if (dt.Rows.Count == 0)
            {
                Label lblSinMesas = new Label
                {
                    Text = "No hay mesas adyacentes disponibles.",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(8, 10)
                };
                pnlLista.Controls.Add(lblSinMesas);
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    int idMesa = Convert.ToInt32(row["id_mesa"]);
                    int numMesa = Convert.ToInt32(row["numero_mesa"]);
                    string zona = row["nombre_zona"].ToString();
                    string estadoMesa = row["estado_mesa"].ToString();

                    Panel fila = CrearFilaMesa(idMesa, numMesa, zona, estadoMesa,
                        (idSelec) => idMesaSeleccionadaUnir = idSelec);
                    fila.Location = new Point(0, y);
                    pnlLista.Controls.Add(fila);
                    y += 58;
                }
            }

            // Nota informativa
            Panel pnlNota = CrearNota("ℹ  Solo se muestran mesas adyacentes y disponibles");

            pnlContenido.Controls.Add(lblTitulo);
            pnlContenido.Controls.Add(lblSub);
            pnlContenido.Controls.Add(pnlLista);
            pnlNota.Location = new Point(0, 288);
            pnlContenido.Controls.Add(pnlNota);
        }

        
        //  TAB 2 — trasnferiri orden
   
        private void MostrarTabTransferir()
        {
            pnlContenido.Controls.Clear();
            idMesaSeleccionadaTransferir = -1;

            DataTable dtActual = sqlMesas.ObtenerMesaPorId(idMesaActual);
            string numActual = dtActual.Rows.Count > 0 ? dtActual.Rows[0]["numero_mesa"].ToString() : "?";
            string zona = dtActual.Rows.Count > 0 ? dtActual.Rows[0]["nombre_zona"].ToString() : "";
            string mesero = dtActual.Rows.Count > 0 ? dtActual.Rows[0]["nombre_mesero"]?.ToString() ?? "-" : "-";
            string clientes = dtActual.Rows.Count > 0 ? dtActual.Rows[0]["num_clientes_mesa"].ToString() : "0";

            int? idOrden = sqlMesas.ObtenerOrdenActivaPorMesa(idMesaActual);

            Label lblTitulo = new Label
            {
                Text = "Transferir orden " + (idOrden.HasValue ? "#" + idOrden.Value : ""),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            Label lblSub = new Label
            {
                Text = $"Mesa actual: M{numActual} · {zona}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 135),
                AutoSize = true,
                Location = new Point(0, 28)
            };

            Label lblDestino = new Label
            {
                Text = "Mesa destino",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = true,
                Location = new Point(0, 60)
            };

            ComboBox cmbMesas = new ComboBox
            {
                Location = new Point(0, 82),
                Size = new Size(440, 34),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMesas.Items.Add("Seleccione una mesa");
            cmbMesas.SelectedIndex = 0;

            DataTable dtDisp = sqlMesas.ObtenerMesasDisponibles(idMesaActual);
            foreach (DataRow row in dtDisp.Rows)
            {
                int id = Convert.ToInt32(row["id_mesa"]);
                int num = Convert.ToInt32(row["numero_mesa"]);
                string z = row["nombre_zona"].ToString();
                cmbMesas.Items.Add(new MesaComboItem { IdMesa = id, Display = $"Mesa {num} — {z}" });
            }
            cmbMesas.SelectedIndexChanged += (s, e) =>
            {
                if (cmbMesas.SelectedItem is MesaComboItem item)
                    idMesaSeleccionadaTransferir = item.IdMesa;
                else
                    idMesaSeleccionadaTransferir = -1;
            };

            // Tarjeta info
            Panel pnlInfo = new Panel
            {
                Location = new Point(0, 130),
                Size = new Size(440, 80),
                BackColor = Color.FromArgb(245, 245, 248),
                Padding = new Padding(12)
            };
            pnlInfo.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(220, 220, 230), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, pnlInfo.Width - 1, pnlInfo.Height - 1);
            };

            Label lblC1 = new Label { Text = "Clientes", Font = new Font("Segoe UI", 9.5F), Location = new Point(12, 12), AutoSize = true };
            Label lblC2 = new Label { Text = clientes, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(360, 12), AutoSize = true };
            Label lblM1 = new Label { Text = "Mesero", Font = new Font("Segoe UI", 9.5F), Location = new Point(12, 40), AutoSize = true };
            Label lblM2 = new Label { Text = mesero, Font = new Font("Segoe UI", 9.5F), Location = new Point(300, 40), AutoSize = true };

            pnlInfo.Controls.AddRange(new Control[] { lblC1, lblC2, lblM1, lblM2 });

            pnlContenido.Controls.AddRange(new Control[]
                { lblTitulo, lblSub, lblDestino, cmbMesas, pnlInfo });
        }

        //  TAB 3 — Ddividir mesa 
 
        private void MostrarTabDividir()
        {
            pnlContenido.Controls.Clear();
            idMesaSeleccionadaDividir = -1;

            Label lblTitulo = new Label
            {
                Text = "Dividir mesa M" + ObtenerNumeroMesa(idMesaActual),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = true,
                Location = new Point(0, 0)
            };

            Label lblSub = new Label
            {
                Text = "Esta mesa está unida con:",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 135),
                AutoSize = true,
                Location = new Point(0, 28)
            };

            Panel pnlLista = new Panel
            {
                Location = new Point(0, 58),
                Size = new Size(440, 200),
                AutoScroll = true
            };

            DataTable dt = sqlMesas.ObtenerMesasUnidas(idMesaActual);
            int y = 0;

            if (dt.Rows.Count == 0)
            {
                Label lblSin = new Label
                {
                    Text = "Esta mesa no está unida con ninguna otra.",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(8, 10)
                };
                pnlLista.Controls.Add(lblSin);
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    int idMesa = Convert.ToInt32(row["id_mesa"]);
                    int numMesa = Convert.ToInt32(row["numero_mesa"]);
                    string zona = row["nombre_zona"].ToString();

                    Panel fila = CrearFilaMesaDividir(idMesa, numMesa, zona,
                        (idSel) => idMesaSeleccionadaDividir = idSel);
                    fila.Location = new Point(0, y);
                    pnlLista.Controls.Add(fila);
                    y += 58;
                }
            }

            // Alerta
            Panel pnlAlerta = new Panel
            {
                Location = new Point(0, 268),
                Size = new Size(440, 50),
                BackColor = Color.FromArgb(254, 249, 195)
            };
            pnlAlerta.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(234, 179, 8), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, pnlAlerta.Width - 1, pnlAlerta.Height - 1);
            };
            Label lblAlerta = new Label
            {
                Text = "⚠  Al confirmar, las mesas volverán a estar separadas",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 80, 0),
                AutoSize = false,
                Size = new Size(420, 40),
                Location = new Point(10, 8),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlAlerta.Controls.Add(lblAlerta);

            pnlContenido.Controls.AddRange(new Control[]
                { lblTitulo, lblSub, pnlLista, pnlAlerta });
        }

        //  CONFIRMAR

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool ok = false;

            switch (tabActiva)
            {
                case TabInicial.Unir:
                    if (idMesaSeleccionadaUnir == -1)
                    {
                        MessageBox.Show("Selecciona una mesa para unir.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ok = sqlMesas.UnirMesas(idMesaActual, idMesaSeleccionadaUnir);
                    break;

                case TabInicial.Transferir:
                    if (idMesaSeleccionadaTransferir == -1)
                    {
                        MessageBox.Show("Selecciona una mesa destino.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int? idOrden = sqlMesas.ObtenerOrdenActivaPorMesa(idMesaActual);
                    if (!idOrden.HasValue)
                    {
                        MessageBox.Show("No hay orden activa en esta mesa.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ok = sqlMesas.TransferirOrden(idOrden.Value, idMesaActual, idMesaSeleccionadaTransferir);
                    break;

                case TabInicial.Dividir:
                    if (idMesaSeleccionadaDividir == -1)
                    {
                        MessageBox.Show("Selecciona la mesa que deseas separar.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ok = sqlMesas.DividirMesas(idMesaActual, idMesaSeleccionadaDividir);
                    break;
            }

            if (ok)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No se pudo completar la operación.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //  HELPERS

        private int ObtenerNumeroMesa(int idMesa)
        {
            DataTable dt = sqlMesas.ObtenerMesaPorId(idMesa);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["numero_mesa"]) : idMesa;
        }

        // Fila de mesa seleccionable (para Unir)
        private Panel CrearFilaMesa(int idMesa, int numMesa, string zona, string estado,
                                    Action<int> alSeleccionar)
        {
            Panel fila = new Panel
            {
                Size = new Size(440, 50),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = idMesa
            };
            fila.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(220, 220, 230), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, fila.Width - 1, fila.Height - 1);
            };

            CheckBox chk = new CheckBox
            {
                Text = "M" + numMesa,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(10, 14),
                AutoSize = true,
                Tag = idMesa
            };
            chk.CheckedChanged += (s, e) => {
                if (chk.Checked) alSeleccionar(idMesa);
            };

            Label lblInfo = new Label
            {
                Text = zona + " · " + estado,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 135),
                AutoSize = true,
                Location = new Point(300, 16)
            };

            fila.Controls.AddRange(new Control[] { chk, lblInfo });
            fila.Click += (s, e) => chk.Checked = !chk.Checked;
            return fila;
        }

        // Fila de mesa (para Dividir — radio button)
        private Panel CrearFilaMesaDividir(int idMesa, int numMesa, string zona,
                                           Action<int> alSeleccionar)
        {
            Panel fila = new Panel
            {
                Size = new Size(440, 50),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };
            fila.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(220, 220, 230), 1))
                    e.Graphics.DrawRectangle(p, 0, 0, fila.Width - 1, fila.Height - 1);
            };

            Label lblNum = new Label
            {
                Text = "M" + numMesa,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 47),
                AutoSize = true,
                Location = new Point(14, 14)
            };

            Label lblGrupo = new Label
            {
                Text = zona,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 135),
                AutoSize = true,
                Location = new Point(300, 16)
            };

            fila.Controls.AddRange(new Control[] { lblNum, lblGrupo });
            fila.Click += (s, e) => {
                alSeleccionar(idMesa);
                // Marcar visualmente
                fila.BackColor = Color.FromArgb(235, 245, 255);
            };

            return fila;
        }

        private Panel CrearNota(string texto)
        {
            Panel p = new Panel
            {
                Size = new Size(440, 44),
                BackColor = Color.FromArgb(245, 245, 248)
            };
            p.Paint += (s, e) => {
                using (Pen pen = new Pen(Color.FromArgb(210, 210, 220), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            };
            Label lbl = new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", 8.8F),
                ForeColor = Color.FromArgb(90, 90, 105),
                AutoSize = false,
                Size = new Size(420, 34),
                Location = new Point(10, 5),
                TextAlign = ContentAlignment.MiddleLeft
            };
            p.Controls.Add(lbl);
            return p;
        }

        // Clase auxiliar para el ComboBox de mesas
        private class MesaComboItem
        {
            public int IdMesa { get; set; }
            public string Display { get; set; }
            public override string ToString() => Display;
        }
    }
}