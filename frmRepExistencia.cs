using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAFE
{
    public partial class frmRepExistencia : Form
    {
        public frmRepExistencia()
        {
            InitializeComponent();
        }

        private void frmRepExistencia_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
