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
    public partial class frmCatClases : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private int opcion;

        public string  idxG;
        public string[] dv = new string[2];

        private int AcCOPEdit;
        private int AcCOPSelec;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        public String KeyCampo = null;

        public frmCatClases()
        {
            InitializeComponent();
        }


        public frmCatClases(MsSql Odat, DatCfgParamSystem ParamS, string perfil, int opc =0 )
        {
            InitializeComponent();
            db = Odat;
            Perfil = perfil;
            opcion = opc;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatClases_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            /*

            Minv	Clases	Formulario	1Inv009	1Inv00
Minv	Agregar Clases	Operacion		1Inv009
Minv	Editar Clases	Operacion		1Inv009
Minv	Eliminar Clases	Operacion		1Inv009
Minv	Consultar Clases	Operacion		1Inv009
Minv	Seleccionar Clases	Operacion		1Inv009
Minv	Buscar Clases	Operacion		1Inv009

    */
            clsUsPerfil up = uT.BuscarIdNodo("1Inv009A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv009B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv009C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv009D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv009E");
            AcCOPSelec = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOPSelec == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv009F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            cmdSeleccionar.Visible = false;


            this.Size = this.MinimumSize;
            LlenaGridView();
            cboEstatus.SelectedText = "Activo";

            if (opcion >3)
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
        


        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatClases pui = new PuiCatClases(db);
                    pui.keyCveClase = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaClase();
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
            PuiCatClases pui = new PuiCatClases(db);
            DatosTbl = pui.BuscaClase(txtBuscar.Text);
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

        private void frmCatClases_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatClases pui = new PuiCatClases(db);
            DatosTbl = pui.ListarClases();
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
                PuiCatClases pui = new PuiCatClases(db);
                                
                pui.keyCveClase = txtClaveClase.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";
            

                if (pui.AgregarClase() >= 1)
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
                        PuiCatClases pui = new PuiCatClases(db);

                        pui.keyCveClase = txtClaveClase.Text;
                        pui.cmpDescripcion = txtDescripcion.Text;
                        pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";

                        if (pui.ActualizaClase() >= 0)
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
            if (String.IsNullOrEmpty(txtClaveClase.Text))
            {                
                MessageBoxAdv.Show("Código: No puede ir vacío.", "CatClasees", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveClase.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "CatClases", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatClases", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "CatClases", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtClaveClase.Enabled = Op;
            txtDescripcion.Enabled = Op;
            cboEstatus.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveClase.Text = "";
            txtDescripcion.Text = "";
            cboEstatus.Text = "";
        }

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmdEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            if (opcion > 3)
                cmdSeleccionar_Click(sender, e);
            else
                cmdEditar_Click(sender, e);
        }

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClaveClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            //idxG = grdView.CurrentRow.Index;

            PuiCatClases pui = new PuiCatClases(db);

            pui.keyCveClase = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarClase();
            txtClaveClase.Text = pui.keyCveClase;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboEstatus.SelectedText = (pui.cmpEstatus == "1") ? "Activo" : "Baja";

            OpcionControles(false);
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

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            if (AcCOPEdit == 1)
            {
                LimpiarControles();
                OpcionControles(true);

                this.Size = this.MaximumSize;
                opcion = 2;

                //idxG = grdView.CurrentRow.Index;

                PuiCatClases pui = new PuiCatClases(db);

                pui.keyCveClase = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarClase();
                txtClaveClase.Text = pui.keyCveClase;
                txtDescripcion.Text = pui.cmpDescripcion;
                cboEstatus.SelectedText = (pui.cmpEstatus == "1") ? "Activo" : "Baja";

                txtClaveClase.Enabled = false;
            }
            else
            {
                MessageBoxAdv.Show("No cuenta con permisos suficientes" , "Error al editar registro", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }
    }
}
