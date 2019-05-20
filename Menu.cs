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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            frmCatAlmacenes falm = new frmCatAlmacenes();
            falm.ShowDialog();
        }
    }
}
