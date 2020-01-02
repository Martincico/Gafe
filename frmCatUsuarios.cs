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
    public partial class frmCatUsuarios : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;
        private int opcion;
        private int idxG;
        public string KeyCampo;
        private MsSql db = null;
        private string sPerfil;
        private clsUtil uT;

        private int AcCOPEdit, AcCOPSelec;

        public frmCatUsuarios()
        {
            InitializeComponent();
            
        }
        public frmCatUsuarios(MsSql Odat, DatCfgParamSystem ParamS, string perfil)
        {
            InitializeComponent();
            db = Odat;
            sPerfil = perfil;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmCatUsuarios_Load(object sender, EventArgs e)
        {

            uT = new clsUtil(db, sPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv004A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv004F");
            AcCOPSelec = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            this.Size = this.MinimumSize;
            LlenaGridView();

            LleCboPerfiles();


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

        private void cbVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVerPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
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

                idxG = grdView.CurrentRow.Index;

                PuiSegUsuarios pui = new PuiSegUsuarios(db);

                pui.keySusuario = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarUsuario();

                txtUsuario.Text = pui.keySusuario;
                txtNombre.Text = pui.cmpNombre;
                txtPassword.Text = pui.cmpPassword;
                cboPerfil.SelectedValue = pui.cmpCodPerfil;
                txtUsuario.Enabled = false;
                txtNombre.Focus();
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

            PuiSegUsuarios pui = new PuiSegUsuarios(db);

            pui.keySusuario = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarUsuario();
            txtUsuario.Text = pui.keySusuario;
            txtNombre.Text = pui.cmpNombre;
            txtPassword.Text = pui.cmpPassword;
            cboPerfil.SelectedValue = pui.cmpCodPerfil;

            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiSegUsuarios pui = new PuiSegUsuarios(db);
                    pui.keySusuario = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaUsuario();
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
            PuiSegUsuarios pui = new PuiSegUsuarios(db);
            DatosTbl = pui.BuscaUsuario(txtBuscar.Text);
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

        private void frmCatUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiSegUsuarios pui = new PuiSegUsuarios(db);
            DatosTbl = pui.ListarUsuarios();
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
                PuiSegUsuarios pui = new PuiSegUsuarios(db);

                pui.keySusuario= txtUsuario.Text;
                pui.cmpNombre = txtNombre.Text;
                pui.cmpPassword = txtPassword.Text;
                if (cboPerfil.SelectedValue != null)
                    pui.cmpCodPerfil = cboPerfil.SelectedValue.ToString();
                

                if (pui.AgregarUsuario() >= 1)
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
                    PuiSegUsuarios pui = new PuiSegUsuarios(db);

                    pui.keySusuario = txtUsuario.Text;
                    pui.cmpNombre = txtNombre.Text;
                    pui.cmpPassword = txtPassword.Text;
                    if (cboPerfil.SelectedValue != null)
                        pui.cmpCodPerfil = cboPerfil.SelectedValue.ToString();

                    if (pui.ActualizaUsuario() >= 0)
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
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBoxAdv.Show("Usuario: No puede ir vacío.", "CatUsuarioes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtUsuario.Text))
                {
                    MessageBoxAdv.Show("Usuario: Contiene caracteres no validos.", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBoxAdv.Show("Nombre: No puede ir vacío.", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtNombre.Text))
                {
                    MessageBoxAdv.Show("Nombre: Contiene caracteres no validos.", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBoxAdv.Show("Password: No puede ir vacío.", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtPassword.Text))
                {
                    MessageBoxAdv.Show("Password: Contiene caracteres no validos.", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }
            if (cboPerfil.SelectedValue == null)
            {  
               MessageBoxAdv.Show("Perfil: Seleccione un perfil", "CatUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            
            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtUsuario.Enabled = Op;
            txtNombre.Enabled = Op;
            txtPassword.Enabled = Op;
            cboPerfil.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtPassword.Text = "";
            //cboPerfil.Text = "";
            LleCboPerfiles();
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
                if (AcCOPSelec == 1)
                {
                    KeyCampo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
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


        private void LleCboPerfiles()
        {
            PuiSegPerfiles puiPerf = new PuiSegPerfiles(db);
            cboPerfil.DataSource = puiPerf.CboPerfiles();

            cboPerfil.ValueMember = "Clave";
            cboPerfil.DisplayMember = "Descripcion";
        }
    }
}
