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
    public partial class frmActualizarProducto : Form
    {
        public frmActualizarProducto(string id, string stock, string nombre, 
                                     string precio, string descripcion)
        {
            InitializeComponent();
            txtID.Text = id;
            txtStock.Text = stock;
            txtNombre.Text = nombre;
            txtPrecio.Text = precio;
            txtDescripcion.Text = descripcion;
        }

        private void frmActualizarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            bool f = datos.comando("UPDATE Productos " +
                                    "SET Stock = " + txtStock.Text +
                                    ", Nombre = '" + txtNombre.Text +
                                    "', Precio = " + txtPrecio.Text +
                                    ", Descripcion = '" + txtDescripcion.Text +
                                    "' WHERE id_Prod = " + txtID.Text);

            if (f == true)
            {
                MessageBox.Show("Datos actualizados", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
