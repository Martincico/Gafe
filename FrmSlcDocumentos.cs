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

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class FrmSlcDocumentos : MetroForm
    {
        private MsSql db = null;
        private clsUtil uT;

        public String KeyCampo = null;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;

        public FrmSlcDocumentos()
        {
            InitializeComponent();
        }


        public FrmSlcDocumentos(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;

            user = DatUsr;
            StiloColor = NewColor;

            LleCboDocumentos();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void SlcDocumentos_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboDocumentos.SelectedValue);
            if (cboDocumentos.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    String cmp = cboDocumentos.Text;
                    DocLstRequisiciones Lst = new DocLstRequisiciones(db, user, StiloColor, val, cmp);
                    Lst.ShowDialog();
                    //this.Close();
                }
            }
        }

        private void LleCboDocumentos()
        {
            PuiCatCfgTipoMovProv lin = new PuiCatCfgTipoMovProv(db);
            cboDocumentos.DataSource = lin.cboTipoMovProvee(); ;
            cboDocumentos.ValueMember = "Clave";
            cboDocumentos.DisplayMember = "Descripcion";

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
        }

        private void SlcDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



    }
}
