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
    public partial class frmInsertarProducto : Form
    {
        public frmInsertarProducto()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            bool f = datos.comando("INSERT INTO Productos  (Stock, Nombre, Precio, Descripcion) values " +
                                   "(" + txtStock.Text +
                                   ",'" + txtNombre.Text.Replace("'", "''") +
                                   "'," + txtPrecio.Text +
                                   ",'" + txtDescripcion.Text +
                                   "')");

            if (f == true)
            {
                MessageBox.Show("Datos insertados", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al insertar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
