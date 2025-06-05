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
        Datos datos = new Datos();
        int id = 0;
        public frmInsertarProducto()
        {
            InitializeComponent();
        }

        private void agregarProd()
        {
            string sql = "Insert into Productos (Nombre,Precio,Descripcion,Stock) Values ('" + txtNombre.Text + "'," +
                "" + txtPrecio.Text + ",'" + txtDescripcion.Text + "'," + txtStock.Text + ")";
            bool v = datos.ejecutarComando(sql);
            if (v)
            {
                MessageBox.Show("Producto Agregado");
                bool v1 = datos.ejecutarMensaje("AGREGAR", txtNombre.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar producto");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            agregarProd();
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
