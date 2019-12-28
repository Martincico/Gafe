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
    public partial class frmCatPerfiles : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;
        private int opcion;
        private int idxG;
        public string KeyCampo;
        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        public frmCatPerfiles()
        {
            InitializeComponent();
        }

        public frmCatPerfiles(MsSql Odat, DatCfgParamSystem ParamS, string perfil)
        {
            InitializeComponent();
            db = Odat;
            Perfil = perfil;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmCatPerfiles_Load(object sender, EventArgs e)
        {
         

            this.Size = this.MinimumSize;
            LlenaGridView();
            cmdSeleccionar.Visible = false;
            if (opcion > 3)
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
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 2;

            idxG = grdView.CurrentRow.Index;

            PuiSegPerfiles pui = new PuiSegPerfiles(db);

            pui.keySperfil = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarPerfil();
            txtPerfil.Text = pui.keySperfil;
            txtDescripcion.Text = pui.cmpDescripcion;
            
            txtPerfil.Enabled = false;

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;

            PuiSegPerfiles pui = new PuiSegPerfiles(db);

            pui.keySperfil = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarPerfil();
            txtPerfil.Text = pui.keySperfil;
            txtDescripcion.Text = pui.cmpDescripcion;
            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiSegPerfiles pui = new PuiSegPerfiles(db);
                    pui.keySperfil = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaPerfil();
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
            PuiSegPerfiles pui = new PuiSegPerfiles(db);
            DatosTbl = pui.BuscaPerfil(txtBuscar.Text);
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

        private void frmSegPerfiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiSegPerfiles pui = new PuiSegPerfiles(db);
            DatosTbl = pui.ListarPerfiles();
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
                PuiSegPerfiles pui = new PuiSegPerfiles(db);

                pui.keySperfil = txtPerfil.Text;
                pui.cmpDescripcion = txtDescripcion.Text;

                if (pui.AgregarPerfil() >= 1)
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
                    PuiSegPerfiles pui = new PuiSegPerfiles(db);

                    pui.keySperfil = txtPerfil.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;

                    if (pui.ActualizaPerfil() >= 0)
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
            if (String.IsNullOrEmpty(txtPerfil.Text))
            {
                MessageBoxAdv.Show("Perfil: No puede ir vacío.", "CatUMedidaes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtPerfil.Text))
                {
                    MessageBoxAdv.Show("Perfil: Contiene caracteres no validos.", "SegPerfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "SegPerfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "SegPerfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtPerfil.Enabled = Op;
            txtDescripcion.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtPerfil.Text = "";
            txtDescripcion.Text = "";
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
    }
}
