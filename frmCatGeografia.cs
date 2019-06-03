using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatSql;
using System.Xml;
using System.IO;


namespace GAFE
{
    public partial class frmCatGeografia : Form
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        public frmCatGeografia()
        {
            InitializeComponent();
        }
        public frmCatGeografia(MsSql Odat, string perfil)
        {
            InitializeComponent();
            db = Odat;
            Perfil = perfil;
        }

        private void frmCatGeografia_Load(object sender, EventArgs e)
        {

            this.Size = this.MinimumSize;
            cboEstatus.SelectedText = "Activo";
        }






        private void OpcionControles(Boolean Op)
        {
            txtDescripcion.Enabled = Op;
            cboEstatus.Enabled = Op;
        }



        private void LimpiarControles()
        {
            txtDescripcion.Text = "";
            cboEstatus.Text = "";
        }

    }
}
