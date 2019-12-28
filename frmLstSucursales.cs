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
    public partial class frmLstSucursales : MetroForm
    {

        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        private int opcion;
        public string KeyCampo = null;
        private int AcCOPEdit;

        private MsSql db = null;
        private clsUtil uT;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;

        public string[] dv = new string[3];

        public frmLstSucursales()
        {
            InitializeComponent();
        }

        public frmLstSucursales(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op = 1)
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            user = DatUsr;
            StiloColor = NewColor;
            ParamSystem = ParamS;
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }


    private void frmLstSucursales_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv014A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv014B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv014C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv014D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv014E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv014F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            cmdSeleccionar.Visible = false;

            LlenaGridView();
            if (opcion >= 3)
            {
                cmdAgregar.Visible = false;
                cmdEliminar.Visible = false;
                cmdEditar.Visible = false;
                cmdSeleccionar.Visible = true;
            }

        }


        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmCatSucursales art = new frmCatSucursales(db,ParamSystem, StiloColor, user.CodPerfil);
            art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            art.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            art.ShowDialog();
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AcCOPEdit == 1)
                {
                    frmCatSucursales art = new frmCatSucursales(db, ParamSystem, StiloColor, user.CodPerfil, 2, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                    art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                    art.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                    art.ShowDialog();
                    LlenaGridView();
                }
                else
                {
                    MessageBoxAdv.Show("No tienes privilegios suficientes",
                    "Error al editar registro", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
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
                frmCatSucursales art = new frmCatSucursales(db, ParamSystem, StiloColor,user.CodPerfil, 3, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                art.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
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
                    PuiCatSucursales pui = new PuiCatSucursales(db);
                    pui.keyCveSucursales = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaSucursales();
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
            PuiCatSucursales pui = new PuiCatSucursales(db);
            DatosTbl = pui.BuscaSucursal(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);
            //grdView.Rows.Clear();
            grdView.DataSource = ds.Tables[0];
            /*
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
            */
        }




        private void frmLstSucursales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void LlenaGridView()
        {
            try
            {
                PuiCatSucursales pui = new PuiCatSucursales(db);
                //grdView.Rows.Clear();
                grdView.DataSource = pui.ListSucursales(); ;
                /*
                for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                {
                    object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                    grdView.Rows.Add(tmp);
                }
                */
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
    }
}
