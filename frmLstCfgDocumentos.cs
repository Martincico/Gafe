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
    public partial class frmLstCfgDocumentos : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        public String KeyCampo = null;

        private MsSql db = null;
        private clsUtil uT;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;


        public frmLstCfgDocumentos()
        {
            InitializeComponent();
        }


        public frmLstCfgDocumentos(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op=1)
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            user = DatUsr;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatCfgDocumentos_Load(object sender, EventArgs e)
        {
            /*
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv003A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;
            */

            LlenaGridView();

            cmdSeleccionar.Visible = false;
            if (opcion>3)
            {
                
                cmdEliminar.Visible = false;
                cmdEliminar.Visible = false;
                cmdConsultar.Visible = true;
                cmdSeleccionar.Visible = true;
            }
            
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmRegCfgDocumentos art = new frmRegCfgDocumentos(db, user.CodPerfil,1);
            art.ShowDialog();
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegCfgDocumentos Ventana = new frmRegCfgDocumentos(db, user.CodPerfil, 2, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                Ventana.ShowDialog();
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro ",
                    "Error al consultar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegCfgDocumentos Ventana = new frmRegCfgDocumentos(db, user.CodPerfil, 3, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                Ventana.ShowDialog();
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro ",
                    "Error al consultar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatLineas pui = new PuiCatLineas(db);
                    pui.keyCveLinea = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaLinea();
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            PuiCatCfgDocumentos pui = new PuiCatCfgDocumentos(db);
            DatosTbl = pui.BuscaCfgDocumentos(txtBuscar.Text);
            DataSet ds = new DataSet();
            try
            {
                DatosTbl.Fill(ds);
                LoadArcGrid(ds);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdAceptar_Click(object sender, EventArgs e)
        {

            switch (opcion)
            {
                case 1: break;
                case 2: break;
                case 3: this.Size = this.MinimumSize; break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCatCfgDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatCfgDocumentos pui = new PuiCatCfgDocumentos(db);
            DatosTbl = pui.ListarCfgDocumentos();
            DataSet Ds = new DataSet();
            try
            {
                DatosTbl.Fill(Ds);
                LoadArcGrid(Ds);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadArcGrid(DataSet Ds)
        {
            grdView.Columns.Clear();
            grdView.DataSource = Ds.Tables[0];
            //grdView.Columns["Documento"].Frozen = true;//Inmovilizar columna
            //grdView.Columns["NoMovimiento"].Visible = false;
        }
       

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {

            try
            {
                KeyCampo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void txtClaveLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void frmLstCfgDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}