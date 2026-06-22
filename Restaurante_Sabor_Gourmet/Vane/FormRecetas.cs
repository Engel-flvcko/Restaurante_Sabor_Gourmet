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
    public partial class FormRecetas : Form
    {
        private ProductoDAO productoDAO = new ProductoDAO();
        private IngredienteDAO ingredienteDAO = new IngredienteDAO();
        private RecetaDAO recetaDAO = new RecetaDAO();
        public FormRecetas()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (gdgvIngredientes.Columns[e.ColumnIndex].Name == "Accion")
            {
                int idReceta =
                    Convert.ToInt32(gdgvIngredientes.Rows[e.RowIndex].Tag);

                recetaDAO.EliminarIngredienteDeReceta(idReceta);

                int idProducto =
                    Convert.ToInt32(gcmbProducto.SelectedValue);

                CargarReceta(idProducto);
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        private void CargarReceta(int idProducto)
        {
            gdgvIngredientes.Rows.Clear();

            List<Receta> receta = recetaDAO.ObtenerRecetaPorProducto(idProducto);

            foreach (var item in receta)
            {
                gdgvIngredientes.Rows.Add(
                    item.NombreIngrediente,
                    item.CantidadReceta,
                    "",
                    "Eliminar"
                );
            }
        }


        private void FormRecetas_Load(object sender, EventArgs e)
        {
            gcmbProducto.DataSource = productoDAO.ObtenerTodosLosProductos();
            gcmbProducto.DisplayMember = "NombreProducto";
            gcmbProducto.ValueMember = "IdProducto";

            guna2ComboBox1.DataSource = ingredienteDAO.ObtenerTodosLosIngredientes();
            guna2ComboBox1.DisplayMember = "NombreIngrediente";
            guna2ComboBox1.ValueMember = "IdIngrediente";
            this.Load += FormRecetas_Load;
        }

        private void gbtn_BuscarP_Click(object sender, EventArgs e)
        {
            if (gcmbProducto.SelectedItem == null)
                return;

            Producto p = (Producto)gcmbProducto.SelectedItem;

            lblCodigo.Text = p.CodigoProducto;
            lblNombre.Text = p.NombreProducto;
            gtxt_Categoria.Text = p.NombreCategoria;

            gtxt_Estado.Text = p.Disponible ? "Disponible" : "No disponible";

            CargarReceta(p.IdProducto);
        }
    }



}
