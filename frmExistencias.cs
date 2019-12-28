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
    public partial class frmExistencias : MetroForm
    {

        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;

        private MsSql db = null;
        private clsUtil uT;

        //List<clsFillCbo> lp;
        //List<clsFillCbo> ln;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;

        public frmExistencias()
        {
            InitializeComponent();
        }


        public frmExistencias(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            ParamSystem = ParamS;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmExistencias_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv013A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAsignaStock.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv013B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

            /*
            up = uT.BuscarIdNodo("1Inv013C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;
            */

            LlecboAlmacen(user.AlmacenUsa);
            cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;
            
            LlecboLineas();
            LlenaGridView(0);
        }


        private void LlenaGridView(int tieneFiltro)
        {
            PuiExistencias pui = new PuiExistencias(db);
            int OmiteExis0 = chkOmitir0.Checked ? 1 : 0;
            DatosTbl =pui.BuscaExistencia(txtClaveArticulo.Text,cboAlmacen.SelectedValue.ToString(),
                                                                              cboLineas.SelectedValue.ToString(),txtBuscar.Text, OmiteExis0);
            DataSet Ds = new DataSet();
            try
            {
                DatosTbl.Fill(Ds);
                //grdView.Rows.Clear();
                grdView.DataSource = Ds.Tables[0];
                grdView.Columns["Cód. Barra"].Frozen = true;//Inmovilizar columna
                grdView.Columns["Artículo"].Frozen = true;//Inmovilizar columna

                if (ParamSystem.HideCveArt == 1)
                {
                    grdView.Columns["Clave"].Visible = false;
                }
                else
                {
                    grdView.Columns["Clave"].Frozen = true;//Inmovilizar columna
                    grdView.Columns["Clave"].Width = 100;
                }

                lblTotalRegistros.Text = "Total de registros: "+ Ds.Tables[0].Rows.Count;

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos la = new frmLstArticulos(db, ParamSystem, user, StiloColor,3);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            txtClaveArticulo.Text = la.dv[0];
            txtDscArticulo.Text = la.dv[1];
            LlenaGridView(1);
        }

        private void cboLineas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdAsignaStock_Click(object sender, EventArgs e)
        {
            string ClaveArticulo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            string ClaveAlmacen = grdView[3, grdView.CurrentRow.Index].Value.ToString();
            string Descripcion = grdView[1, grdView.CurrentRow.Index].Value.ToString();
            string Ubicacion = grdView[12, grdView.CurrentRow.Index].Value.ToString(); ;
            string stockMin = grdView[7, grdView.CurrentRow.Index].Value.ToString();
            string stockMax = grdView[8, grdView.CurrentRow.Index].Value.ToString();

            AsignaPorAlmacen fas = new AsignaPorAlmacen(ClaveArticulo,ClaveAlmacen,Descripcion,Ubicacion,stockMin,stockMax,db);
            fas.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            fas.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            fas.ShowDialog();
            LlenaGridView(1);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            string Almacen = (cboAlmacen.SelectedValue == null) ? "" : cboAlmacen.SelectedValue.ToString();
            string Linea = (cboLineas.SelectedValue == null) ? "" : cboLineas.SelectedValue.ToString();
            string Articulo = txtClaveArticulo.Text;
            string Buscar = txtBuscar.Text;
            int Omit0 = chkOmitir0.Checked?1:0;
            string NAlmacen = (cboAlmacen.SelectedValue == null) ? "" : cboAlmacen.Text;
            string NLinea = (cboLineas.SelectedValue == null) ? "" : cboLineas.Text;
            string NArticulo = txtDscArticulo.Text;


            frmRepExistencia Rep = new frmRepExistencia(Articulo, Almacen, Linea, Buscar, Omit0, "Farmacias Salinas G",
                                                       NArticulo, NAlmacen, NLinea, user.FecServer,  db);
            Rep.ShowDialog();



        }

        private void frmExistencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void LlecboAlmacen(String CveUser)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            DataTable dt = lin.CboCatAlmacenes(0);
            DataRow row = dt.NewRow();
            row["ClaveAlmacen"] = "";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboAlmacen.DataSource = dt;

            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";

            cboAlmacen.SelectedValue = CveUser;
        }

        private void LlecboLineas()
        {
            PuiCatLineas lin = new PuiCatLineas(db);
            DataTable dt = lin.CboLinea();
            DataRow row = dt.NewRow();
            row["Clave"] = "";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboLineas.DataSource = dt;

            cboLineas.ValueMember = "Clave";
            cboLineas.DisplayMember = "Descripcion";

            cboLineas.SelectedValue = "";
        }

        private void chkOmitir0_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
