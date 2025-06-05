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
        Datos dt = new Datos();
        int id = 0;
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

        private void editarProd()
        {

            // Verificar si el producto todavía existe
            string checkSql = $"SELECT COUNT(*) FROM Productos WHERE IdProducto = {id}";
            DataSet ds = dt.consulta(checkSql);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Este producto ya no existe. Otro usuario pudo haberlo eliminado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cierra el formulario 
                return;
            }

            string sql = "Update Productos set Nombre='" + txtNombre.Text + "',Precio=" + txtPrecio.Text +
                ",Descripcion='" + txtDescripcion.Text + "',Stock=" + txtStock.Text + " where IdProducto=" + id;
            bool v = dt.ejecutarComando(sql);
            if (v)
            {
                MessageBox.Show("Producto Editado");
                bool v1 = dt.ejecutarMensaje("EDITAR", txtNombre.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al editar producto");
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            editarProd();
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
