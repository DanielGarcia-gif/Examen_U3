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
        string usuario;

        public frmProductos(string usuario)
        {
            InitializeComponent();

            rtbHistorial.ReadOnly = true;
            this.usuario = usuario;

            WebSocketClient.Inicializar("ws://10.19.204.167:8181/notify", usuario); // IP del servidor WebSocket

            WebSocketClient.ws.OnMessage += (sender, e) =>
            {

                this.Invoke(new Action(() =>
                {

                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        string[] partes = e.Data.Split(':');
                        if (partes.Length >= 3)
                        {
                            string accion = partes[0];
                            string nombreProducto = partes[1];
                            string usuario1 = partes[2];

                            string mensaje;

                            switch (accion.ToUpper())
                            {
                                case "AGREGAR":
                                    mensaje = $"[{usuario1}] ha agregado el producto '{nombreProducto}'.";
                                    break;
                                case "EDITAR":
                                    mensaje = $"[{usuario1}] ha editado el producto '{nombreProducto}'.";
                                    break;
                                case "ELIMINAR":
                                    mensaje = $"[{usuario1}] ha eliminado el producto '{nombreProducto}' del registro.";
                                    break;
                                default:
                                    mensaje = $"[{usuario1}] ha hecho un cambio en el producto '{nombreProducto}'.";
                                    break;
                            }

                            // Actualiza la tabla
                            cargarTabla();

                            //Enviamos notificacion al historial de cambios
                            rtbHistorial.AppendText(mensaje + Environment.NewLine + Environment.NewLine);
                        }
                    }
                }));

            };
        }

        private void cargarTabla()
        {
            DataSet ds = new DataSet();
            ds = dt.consulta("select * from Productos");
            if (ds != null)
            {
                dgvProductos.DataSource = ds.Tables[0];
                dgvProductos.Columns[0].HeaderText = "ID Producto";
                dgvProductos.Columns[1].HeaderText = "Nombre";
                dgvProductos.Columns[2].HeaderText = "Precio";
                dgvProductos.Columns[3].HeaderText = "Descripción";
                dgvProductos.Columns[4].HeaderText = "Inventario";
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmInsertarProducto insertar = new frmInsertarProducto();
            insertar.Show();
        }

        private void frmProductos_Activated(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            int i = dgvProductos.CurrentRow.Index;
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el producto '" + dgvProductos.Rows[i].Cells[1].Value + "'?", "Eliminar Producto", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string nombreProd = dgvProductos.Rows[i].Cells[1].Value.ToString();
                string sql = "Delete from Productos where Id_Prod=" + dgvProductos.Rows[i].Cells[0].Value;
                bool v = dt.ejecutarComando(sql);
                if (v)
                {
                    MessageBox.Show("Producto Eliminado");
                    bool v1 = dt.ejecutarMensaje("ELIMINAR", nombreProd);
                    cargarTabla();
                }
                else
                {
                    MessageBox.Show("Error al eliminar producto");
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Eliminación cancelada");
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
