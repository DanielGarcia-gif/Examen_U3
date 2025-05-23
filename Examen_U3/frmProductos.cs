using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_U3
{
    public partial class frmProductos : Form
    {

        Datos dt = new Datos();
        public frmProductos()
        {
            InitializeComponent();
        }
        private void actualizaGrid()
        {
            DataSet ds;
            ds = dt.consulta("Select id_Prod as [ID Producto], " +
                                      "Stock as [Existencias], " +
                                      "Nombre as [Nombre], " +
                                      "Precio as [Precio], " +
                                      "Descripcion as [Descripcion] " +
                                      "FROM Productos");

            if (ds != null)
            {
                dgvProductos.DataSource = ds.Tables[0];
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            actualizaGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmInsertarProducto insertar = new frmInsertarProducto();
            insertar.Show();
        }

        private void frmProductos_Activated(object sender, EventArgs e)
        {
            actualizaGrid();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            int i = dgvProductos.CurrentRow.Index;
            DialogResult f = MessageBox.Show("¿Eliminar Producto '" + dgvProductos.Rows[i].Cells[2].Value + "'?");

            if (f == DialogResult.OK)
            {
                string sql = "DELETE FROM Productos WHERE id_Prod = " + dgvProductos.Rows[i].Cells[0].Value;
                bool v = dt.ejecutarMando(sql);
                if (v)
                {
                    MessageBox.Show("Producto Eliminado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizaGrid();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            int i = dgvProductos.CurrentRow.Index;
            frmActualizarProducto actualiza = new frmActualizarProducto(dgvProductos.Rows[i].Cells[0].Value.ToString(),
                                                                        dgvProductos.Rows[i].Cells[1].Value.ToString(),
                                                                        dgvProductos.Rows[i].Cells[2].Value.ToString(),
                                                                        dgvProductos.Rows[i].Cells[3].Value.ToString(),
                                                                        dgvProductos.Rows[i].Cells[4].Value.ToString());

            actualiza.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmsControl_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds;
            ds = dt.consulta("Select id_Prod as [ID Producto], " +
                                      "Stock as [Existencias], " +
                                      "Nombre as [Nombre], " +
                                      "Precio as [Precio], " +
                                      "Descripcion as [Descripcion] " +
                                      "FROM Productos WHERE nombre LIKE '" + txtBuscar.Text + "%'");

            if (ds != null)
            {
                dgvProductos.DataSource = ds.Tables[0];
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir imprimir = new frmImprimir();
            imprimir.Show();
        }
    }
}
