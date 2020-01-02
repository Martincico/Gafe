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
        private DatCfgParamSystem ParamSystem;
        private int opcion;
        private int AcCOPEdit;
        private int AcCOPSelec;
        public string KeyCampo = null;
        public DatCfgUsuario user;

        private MsSql db = null;
        private clsUtil uT;

        public string[] dv = new string[17];

        public clsStiloTemas StiloColor;

        public frmLstArticulos()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKey);
        }


        public frmLstArticulos(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op = 1)
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            user = DatUsr;
            ParamSystem = ParamS;
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            StiloColor = NewColor;

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

            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv001A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001E");
            AcCOPSelec = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOPSelec == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            cmdSeleccionar.Visible = false;

            LlenaGridView();
            if (opcion>=3)
            {
//                cmdAgregar.Visible = false;
                cmdEliminar.Visible = false;
//                cmdEditar.Visible = false;
                cmdSeleccionar.Visible = true;
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmRegArticulos art = new frmRegArticulos(db, ParamSystem, user,StiloColor);
            art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Pant2);
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
                    frmRegArticulos art = new frmRegArticulos(db, ParamSystem,user, StiloColor,  2, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                    art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Pant2);
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
                frmRegArticulos art = new frmRegArticulos(db, ParamSystem, user,StiloColor, 3, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Pant2);
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
                if (MessageBoxAdv.Show("¿Está seguro de eliminar el registro?" + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
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
            LlenaGridView();
        }

        private void LlenaGridView()
        {
            PuiCatArticulos pui = new PuiCatArticulos(db);
            DatosTbl = pui.BuscaArticulo(txtBuscar.Text.Trim());
            DataSet Ds = new DataSet();
            try
            {
                grdView.DataSource = null;
                DatosTbl.Fill(Ds);
                grdView.DataSource = Ds.Tables[0];
                MO_FilasGrid();

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      

        private void MO_FilasGrid()
        {
            /*
                        0 - A.CveArticulo, " +
                        1 - A.CodigoBarra'," +
                        2 - A.Descripción, " +
                        3 - A.CodigoSat," +
                        4 - UM.CveUMedida, " +
                        5 - UM.Descripcion AS UMedida, " +
                        6 - Imp.CveImpuesto, " +
                        7 - Imp.Tipo, 
                        8 - Imp.Valor, " +
                        9 - L.CveLinea, " +
                        10 - L.Descripcion AS Linea, " +
                        11 - M.CveMarca, " +
                        12 - M.Descripcion AS Marca, " +
                        13 - C.CveClase, " +
                        14 - C.Descripcion AS Clase, " +
                        15 - A.Modelo," +
                        16 - A.Observacion " +
                        17 - ImmpIep.CveImpuesto AS CveIEPS, " +
                        18 - ImmpIep.Tipo AS TipoIEPS, " +
                        19 - ImmpIep.Valor AS ValorIEPS" +
            */


            grdView.Columns["CodigoBarra"].Frozen = true;//Inmovilizar columna
            grdView.Columns["CodigoBarra"].Width = 100;
            grdView.Columns["CodigoBarra"].HeaderText = "Código B";

            grdView.Columns["Descripcion"].Frozen = true;//Inmovilizar columna
            grdView.Columns["Descripcion"].Width = 300;


            if (ParamSystem.HideCveArt == 1)
            {
                grdView.Columns["CveArticulo"].Visible = false;
            }
            else
            {
                grdView.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
                grdView.Columns["CveArticulo"].Width = 100;
                grdView.Columns["CveArticulo"].HeaderText = "Clave";
            }


            grdView.Columns["Modelo"].Visible = false;
            grdView.Columns["CveLinea"].Visible = false;
            grdView.Columns["CveMarca"].Visible = false;
            grdView.Columns["CveClase"].Visible = false;
            grdView.Columns["CveUMedida"].Visible = false;
            grdView.Columns["CveImpuesto"].Visible = false;
            grdView.Columns["Tipo"].Visible = false;
            grdView.Columns["Valor"].Visible = false;
            grdView.Columns["Observacion"].Visible = false;

            grdView.Columns["CveIEPS"].Visible = false;
            grdView.Columns["TipoIEPS"].Visible = false;
            grdView.Columns["ValorIEPS"].Visible = false;

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
                if (AcCOPSelec == 1)
                {
                    KeyCampo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[0] = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[16] = grdView[1, grdView.CurrentRow.Index].Value.ToString(); //Codigo BARRA
                    dv[1] = grdView[2, grdView.CurrentRow.Index].Value.ToString();//Descripcion

                    dv[2] = grdView[9, grdView.CurrentRow.Index].Value.ToString();//CveLinea
                    dv[3] = grdView[10, grdView.CurrentRow.Index].Value.ToString();//DesLinea

                    dv[4] = grdView[11, grdView.CurrentRow.Index].Value.ToString();//CveMarca
                    dv[5] = grdView[12, grdView.CurrentRow.Index].Value.ToString();//Desc CveMarca

                    dv[6] = grdView[13, grdView.CurrentRow.Index].Value.ToString();//CveClase
                    dv[7] = grdView[14, grdView.CurrentRow.Index].Value.ToString();//Desc CveClase

                    dv[8] = grdView[4, grdView.CurrentRow.Index].Value.ToString();//CveUMedida
                    dv[9] = grdView[5, grdView.CurrentRow.Index].Value.ToString();//Desc CveUMedida

                    dv[10] = grdView[6, grdView.CurrentRow.Index].Value.ToString();//CveImpuesto
                    dv[11] = grdView[7, grdView.CurrentRow.Index].Value.ToString();//Desc Tipo
                    dv[12] = grdView[8, grdView.CurrentRow.Index].Value.ToString();//Valor

                    dv[13] = grdView[17, grdView.CurrentRow.Index].Value.ToString();//CveImpuesto IEPS
                    dv[14] = grdView[18, grdView.CurrentRow.Index].Value.ToString();//Desc Tipo IEPS
                    dv[15] = grdView[19, grdView.CurrentRow.Index].Value.ToString();//Valor IEPS

                    this.Close();
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
