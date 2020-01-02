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
    public partial class frmCatImpuestos : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private int opcion;
        public String idxG;
        public string[] dv = new string[2];
        private int AcCOPSelec;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;
        private int AcCOPEdit;

        public frmCatImpuestos()
        {
            InitializeComponent();
        }


        public frmCatImpuestos(MsSql Odat, DatCfgParamSystem ParamS, string perfil, int op = 0)
        {
            InitializeComponent();
            db = Odat;
            Perfil = perfil;
            opcion = op;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatImpuestos_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv010A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv010B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv010C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv010D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv010F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv010E");
            AcCOPSelec = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOPSelec == 1) ? true : false;


            this.Size = this.MinimumSize;
            LlenaGridView();
            cboEstatus.SelectedText = "Activo";

            cmdSeleccionar.Visible = false;
            if (opcion > 3)
            {
                //                cmdAgregar.Visible = false;
                cmdEliminar.Visible = false;
                //                cmdEditar.Visible = false;
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
            if (AcCOPEdit == 1)
            {
                LimpiarControles();
                OpcionControles(true);
                this.Size = this.MaximumSize;
                opcion = 2;

                //idxG = grdView.CurrentRow.Index;

                PuiCatImpuestos pui = new PuiCatImpuestos(db);

                pui.keyCveImpuesto = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarImpuesto();
                txtClaveImpuesto.Text = pui.keyCveImpuesto;
                txtTipo.Text = pui.cmpTipo;
                txtValor.Text = Convert.ToString(pui.cmpValor);
                cboEstatus.SelectedText = (pui.cmpEstatus == "1") ? "Activo" : "Baja";
            

                txtClaveImpuesto.Enabled = false;
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

            //idxG = grdView.CurrentRow.Index;

            PuiCatImpuestos pui = new PuiCatImpuestos(db);

            pui.keyCveImpuesto = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarImpuesto();
            txtClaveImpuesto.Text = pui.keyCveImpuesto;
            txtTipo.Text = pui.cmpTipo;
            txtValor.Text = Convert.ToString(pui.cmpValor);
            cboEstatus.SelectedText = (pui.cmpEstatus == "1") ? "Activo" : "Baja";


            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatImpuestos pui = new PuiCatImpuestos(db);
                    pui.keyCveImpuesto = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaImpuesto();
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
            PuiCatImpuestos pui = new PuiCatImpuestos(db);
            DatosTbl = pui.BuscaImpuesto(txtBuscar.Text);
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

        private void frmCatImpuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatImpuestos pui = new PuiCatImpuestos(db);
            DatosTbl = pui.ListarImpuestos();
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
                PuiCatImpuestos pui = new PuiCatImpuestos(db);
                                
                pui.keyCveImpuesto = txtClaveImpuesto.Text;
                pui.cmpTipo = txtTipo.Text;
                pui.cmpValor = Convert.ToDouble(txtValor.Text);
                pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";


                if (pui.AgregarImpuesto() >= 1)
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
                if (AcCOPEdit == 1)
                {
                    if (Validar())
                    {
                        PuiCatImpuestos pui = new PuiCatImpuestos(db);

                        pui.keyCveImpuesto = txtClaveImpuesto.Text;
                        pui.cmpTipo = txtTipo.Text;
                        pui.cmpValor = Convert.ToDouble(txtValor.Text);
                        pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";

                        if (pui.ActualizaImpuesto() >= 0)
                        {
                            MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information);
                            this.Size = this.MinimumSize;
                        }
                        LlenaGridView();
                        //grdView.CurrentRow.Index = idxG;  
                    }
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


        private Boolean Validar()
        {
            Boolean dv = true;
            if (String.IsNullOrEmpty(txtClaveImpuesto.Text))
            {                
                MessageBoxAdv.Show("Código: No puede ir vacío.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveImpuesto.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtTipo.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtTipo.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtValor.Text))
            {
                MessageBoxAdv.Show("Valor: No puede ir vacío.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.Decimal(txtValor.Text))
                {
                    MessageBoxAdv.Show("Valor: Contiene caracteres no validos.", "CatImpuestos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }



            return dv;
        }

        private void OpcionControles(Boolean Op)
        {
            txtClaveImpuesto.Enabled = Op;
            txtTipo.Enabled = Op;
            txtValor.Enabled = Op;
            cboEstatus.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveImpuesto.Text = "";
            txtTipo.Text = "";
            cboEstatus.Text = "";
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


        private void txtClaveImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (AcCOPSelec == 1)
                {
                    idxG = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[0] = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    dv[1] = grdView[1, grdView.CurrentRow.Index].Value.ToString();

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
    }
}
