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
    public partial class frmImprimir : Form
    {
        public frmImprimir()
        {
            InitializeComponent();
        }

        private void frmImprimir_Load(object sender, EventArgs e)
        {
            CrystalReportProductos2.Refresh();
        }
    }
}
