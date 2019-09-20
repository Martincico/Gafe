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
    public partial class frmLstArticulos : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;
        public string KeyCampo = null;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        public string[] dv = new string[13];

        public frmLstArticulos()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKey);
        }


        public frmLstArticulos(MsSql Odat, string perfil, int op = 1)
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            Perfil = perfil;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            this.KeyDown += new KeyEventHandler(PressKey);
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmLstArticulos_Load(object sender, EventArgs e)
        {

            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv001A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            cmdSeleccionar.Visible = false;

            LlenaGridView();
            if (opcion>=3)
            {
                cmdAgregar.Visible = false;
                cmdEliminar.Visible = false;
                cmdEditar.Visible = false;
                cmdSeleccionar.Visible = true;
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmCatArticulos art = new frmCatArticulos(db, Perfil);
            art.ShowDialog();
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatArticulos art = new frmCatArticulos(db, Perfil, 2, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                art.ShowDialog();
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatArticulos art = new frmCatArticulos(db, Perfil, 3, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                art.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al Consultar", MessageBoxButtons.OK,
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
                    PuiCatArticulos pui = new PuiCatArticulos(db);
                    pui.keyCveArticulo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaArticulo();
                    LlenaGridView();                    
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
            PuiCatArticulos pui = new PuiCatArticulos(db);
            DatosTbl = pui.BuscaArticulo(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);
            //grdView.Rows.Clear();
            grdView.DataSource = ds.Tables[0];
            //grdViewPart.Columns["NoPartida"].Frozen = true;//Inmovilizar columna
            grdView.Columns["CveLinea"].Visible = false;// 6
            grdView.Columns["CveMarca"].Visible = false;// 8
            grdView.Columns["CveClase"].Visible = false;//10
            grdView.Columns["CveUMedida"].Visible = false;//12
            grdView.Columns["CveImpuesto"].Visible = false;//14
            grdView.Columns["Tipo"].Visible = false;//14
            grdView.Columns["Valor"].Visible = false;//16
        }





        private void LlenaGridView()
        {
            PuiCatArticulos pui = new PuiCatArticulos(db);
            DatosTbl = pui.ListarArticulos();
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                //grdView.Rows.Clear();
                grdView.DataSource = Ds.Tables[0];
                //grdViewPart.Columns["NoPartida"].Frozen = true;//Inmovilizar columna
                grdView.Columns["CveLinea"].Visible = false;// 6
                grdView.Columns["CveMarca"].Visible = false;// 8
                grdView.Columns["CveClase"].Visible = false;//10
                grdView.Columns["CveUMedida"].Visible = false;//12
                grdView.Columns["CveImpuesto"].Visible = false;//14
                grdView.Columns["Tipo"].Visible = false;//14
                grdView.Columns["Valor"].Visible = false;//16
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      

        
        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (opcion >= 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            if (opcion >= 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmEditar_Click(sender, e);
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {

            try
            {
                KeyCampo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                dv[0] = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                dv[1] = grdView[2, grdView.CurrentRow.Index].Value.ToString();

                dv[2] = grdView[6, grdView.CurrentRow.Index].Value.ToString();//CveLinea
                dv[3] = grdView[7, grdView.CurrentRow.Index].Value.ToString();//DesLinea

                dv[4] = grdView[8, grdView.CurrentRow.Index].Value.ToString();//CveMarca
                dv[5] = grdView[9, grdView.CurrentRow.Index].Value.ToString();//Desc CveMarca

                dv[6] = grdView[10, grdView.CurrentRow.Index].Value.ToString();//CveClase
                dv[7] = grdView[11, grdView.CurrentRow.Index].Value.ToString();//Desc CveClase

                dv[8] = grdView[12, grdView.CurrentRow.Index].Value.ToString();//CveUMedida
                dv[9] = grdView[13, grdView.CurrentRow.Index].Value.ToString();//Desc CveUMedida

                dv[10] = grdView[14, grdView.CurrentRow.Index].Value.ToString();//CveImpuesto
                dv[11] = grdView[15, grdView.CurrentRow.Index].Value.ToString();//Desc Tipo
                dv[12] = grdView[16, grdView.CurrentRow.Index].Value.ToString();//Valor


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdBuscar_Click(sender,e);
            }
        }

        private void grdView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSeleccionar_Click(sender, e);
            }
        }
    }
}
