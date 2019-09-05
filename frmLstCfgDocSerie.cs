
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
    public partial class frmLstCfgDocSerie : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        public String KeyCampo = null;

        private MsSql db = null;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;


        public frmLstCfgDocSerie()
        {
            InitializeComponent();
        }


        public frmLstCfgDocSerie(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op =1 )
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            user = DatUsr;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmRegCfgDocSerie art = new frmRegCfgDocSerie(db, user, 1);
            art.ShowDialog();
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            {
                String Alm = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                String CodMP = grdView[2, grdView.CurrentRow.Index].Value.ToString();
                String Ser = grdView[4, grdView.CurrentRow.Index].Value.ToString();
                frmRegCfgDocSerie Ventana = new frmRegCfgDocSerie(db, user, 2, Alm, CodMP, Ser);
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
                String Alm = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                String CodMP = grdView[2, grdView.CurrentRow.Index].Value.ToString();
                String Ser = grdView[4, grdView.CurrentRow.Index].Value.ToString();
                frmRegCfgDocSerie Ventana = new frmRegCfgDocSerie(db, user, 3, Alm, CodMP, Ser);
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
                    PuiCatCfgDocSerie pui = new PuiCatCfgDocSerie(db);
                    /*
                    pui.keyCveLinea = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaLinea();
                    */
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
            PuiCatCfgDocSerie pui = new PuiCatCfgDocSerie(db);
            DatosTbl = pui.BuscaCfgDocSerie(txtBuscar.Text);
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
            
            grdView.Columns["CveAlmacen"].Visible = false;
            grdView.Columns["CveDoc"].Visible = false;
            grdView.Columns["CodFoliador"].Visible = false;
            /*
            grdView.Columns["Almacén"].Frozen = true;//Inmovilizar columna
            grdView.Columns["Mov_Inv"].Frozen = true;//Inmovilizar columna
            grdView.Columns["Serie"].Frozen = true;//Inmovilizar columna
            */
        }





        private void cmdAceptar_Click(object sender, EventArgs e)
        {

            switch (opcion)
            {
                case 1: Agregar(); break;
                case 2: Editar(); break;
                case 3: this.Size = this.MinimumSize; break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            LimpiarControles();
            OpcionControles(true);
        }

        private void LlenaGridView()
        {
            PuiCatCfgDocSerie pui = new PuiCatCfgDocSerie(db);
            DatosTbl = pui.ListarCfgDocSeries();
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

        private void Agregar()
        {
            if (Validar())
            {
                PuiCatCfgDocSerie pui = new PuiCatCfgDocSerie(db);
                /*
                pui.keyCveLinea = txtClaveLinea.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";
                

                    if (pui.AgregarLinea() >= 1)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }
                    */
            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiCatCfgDocSerie pui = new PuiCatCfgDocSerie(db);
                    /*
                    pui.keyCveLinea = txtClaveLinea.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";
                    
                    if (pui.ActualizaLinea() >= 0)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    LlenaGridView();
                    */
                    //grdView.CurrentRow.Index = idxG;  
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            /*
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveLinea.Text))
            {
                MessageBoxAdv.Show("Código: No puede ir vacío.", "CatLineaes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveLinea.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "CatLineas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }
            */

            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            /*
            txtClaveLinea.Enabled = Op;
            txtDescripcion.Enabled = Op;
            cboEstatus.Enabled = Op;
            */
        }

        private void LimpiarControles()
        {
            /*
            txtClaveLinea.Text = "";
            txtDescripcion.Text = "";
            cboEstatus.Text = "";
            */
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

        private void frmLstCfgDocSerie_Load(object sender, EventArgs e)
        {
            /*
            uT = new clsUtil(db, user.CodPerfil);
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
            if (opcion > 3)
            {
                cmdEliminar.Visible = false;
                cmdEliminar.Visible = false;
                cmdConsultar.Visible = true;
                cmdSeleccionar.Visible = true;
            }
        }

        private void frmLstCfgDocSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}