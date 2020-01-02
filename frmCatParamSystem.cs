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
    public partial class frmCatParamSystem : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private int opcion;
        private int idxG;
        private int AcCOPEdit;
        public String KeyCampo = null;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;


        public frmCatParamSystem()
        {
            InitializeComponent();
        }


        public frmCatParamSystem(MsSql Odat, DatCfgParamSystem ParamS, string perfil, int op=1)
        {
            InitializeComponent();
            db = Odat;
            opcion = op;
            Perfil = perfil;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatParamSystem_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv003A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv003B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOPEdit == 1) ? true : false;

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


            this.Size = this.MinimumSize;
            LlenaGridView();
            LleCboModuloSys();

            cmdSeleccionar.Visible = false;
            if (opcion>3)
            {
                
                cmdAceptar.Visible = false;
                cmdEliminar.Visible = false;
                cmdEliminar.Visible = false;
                cmdConsultar.Visible = true;
                cmdSeleccionar.Visible = true;
            }
            
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 1;
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            if(AcCOPEdit==1)
            {
                LimpiarControles();
                OpcionControles(true);
                this.Size = this.MaximumSize;
                opcion = 2;

                idxG = grdView.CurrentRow.Index;

                PuiCatParamSystem pui = new PuiCatParamSystem(db);

                pui.keyCodParametro = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarParamSystem();
                txtCodParametro.Text = pui.keyCodParametro;
                txtDescripcion.Text = pui.cmpDescripcion;
                cboCfgModuloSys.SelectedValue = pui.cmpModUsa;
                txtValor.Text = pui.cmpValor;

                txtCodParametro.Enabled = false;
            }
            else
            {
                MessageBoxAdv.Show("No tienes privilegios suficientes",
                 "Error al editar registro", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
            

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;

            PuiCatParamSystem pui = new PuiCatParamSystem(db);

            pui.keyCodParametro = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarParamSystem();
            txtCodParametro.Text = pui.keyCodParametro;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboCfgModuloSys.SelectedValue = pui.cmpModUsa;
            txtValor.Text = pui.cmpValor;

            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatParamSystem pui = new PuiCatParamSystem(db);
                    pui.keyCodParametro = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaParamSystem();
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
            PuiCatParamSystem pui = new PuiCatParamSystem(db);
            DatosTbl = pui.BuscaParamSystem(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);

            grdView.Rows.Clear();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
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

        private void frmCatParamSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatParamSystem pui = new PuiCatParamSystem(db);
            DatosTbl = pui.ListarParamSystems();
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Rows.Clear();

                for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                {
                    object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                    grdView.Rows.Add(tmp);
                }
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
                PuiCatParamSystem pui = new PuiCatParamSystem(db);

                pui.keyCodParametro = txtCodParametro.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpModUsa = Convert.ToString(cboCfgModuloSys.SelectedValue);
                pui.cmpValor = txtValor.Text;

                if (pui.AgregarParamSystem() >= 1)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiCatParamSystem pui = new PuiCatParamSystem(db);

                    pui.keyCodParametro = txtCodParametro.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpModUsa = Convert.ToString(cboCfgModuloSys.SelectedValue);
                    pui.cmpValor = txtValor.Text;

                    if (pui.ActualizaParamSystem() >= 0)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    LlenaGridView();
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
            if (String.IsNullOrEmpty(txtCodParametro.Text))
            {
                MessageBoxAdv.Show("Código: No puede ir vacío.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtCodParametro.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtValor.Text))
            {
                MessageBoxAdv.Show("Valor: No puede ir vacío.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtValor.Text))
                {
                    MessageBoxAdv.Show("Valor: Contiene caracteres no validos.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }
            String val = Convert.ToString(cboCfgModuloSys.SelectedValue);
            if (val.Equals(""))
            {
                MessageBoxAdv.Show("Módulo: No puede ir vacío.", "Parámetros del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }

                return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtCodParametro.Enabled = Op;
            txtDescripcion.Enabled = Op;
            cboCfgModuloSys.Enabled = Op;
            txtValor.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtCodParametro.Text = "";
            txtDescripcion.Text = "";
            txtValor.Text = "";
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


        private void frmCatParamSystem_CaptionBarPaint(object sender, PaintEventArgs e)
        {
//            e.Graphics.FillRectangle(new LinearGradientBrush(e.ClipRectangle, Color.AliceBlue, Color.Blue, LinearGradientMode.BackwardDiagonal), e.ClipRectangle);
        }

        private void LleCboModuloSys()
        {
            PuiCatCfgCatFoliadores lin = new PuiCatCfgCatFoliadores(db);
            cboCfgModuloSys.DataSource = lin.CboCfgModuloSys();
            cboCfgModuloSys.ValueMember = "CveModulo";
            cboCfgModuloSys.DisplayMember = "Descripcion";

        }

        private void txtCodParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }
    }
}