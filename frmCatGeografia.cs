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
    public partial class frmCatGeografia : MetroForm
    {
        private int opcion;
        private int _padre;
        private int idxG = -1;
        private int AcCOPB = 0;
        private string combo;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        public frmCatGeografia()
        {
            InitializeComponent();
        }
        public frmCatGeografia(MsSql Odat, DatCfgParamSystem ParamS, string perfil,int op= 1)
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

        private void frmCatGeografia_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            if (opcion==1)
            {
                cmdAgregarPais.Visible = true;
                cmdAgregarEstado.Visible = true;
                cmdAgregarMunicipio.Visible = true;
                cmdAgregarLocalidad.Visible = true;
                cmdEliminarPais.Visible = true;
                cmdEliminarEstado.Visible = true;
                cmdEliminarMunicipio.Visible = true;
                cmdEliminarLocalidad.Visible = true;
                cmdEditarPais.Visible = true;
                cmdEditarEstado.Visible = true;
                cmdEditarMunicipio.Visible = true;
                cmdEditarLocalidad.Visible = true;
                cmdSeleccionar.Visible = false;
            }
            else
                cmdSeleccionar.Visible = true;

            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();
            
            clsUsPerfil up = uT.BuscarIdNodo("1Inv006A");
            AcCOPB = (up != null) ? up.Acceso : 0;
            if(AcCOPB==1)
            {
                cmdAgregarPais.Enabled = true;
                cmdAgregarEstado.Enabled = true;
                cmdAgregarMunicipio.Enabled = true;
                cmdAgregarLocalidad.Enabled = true;
                cmdEliminarPais.Enabled = true;
                cmdEliminarEstado.Enabled = true;
                cmdEliminarMunicipio.Enabled = true;
                cmdEliminarLocalidad.Enabled = true;
                cmdEditarPais.Enabled = true;
                cmdEditarEstado.Enabled = true;
                cmdEditarMunicipio.Enabled = true;
                cmdEditarLocalidad.Enabled = true;
                cmdSeleccionar.Enabled = false;
            }
            

            up = uT.BuscarIdNodo("1Inv006B");
            int AcCOPS = (up != null) ? up.Acceso : 0;

            cmdSeleccionar.Enabled = (AcCOPS == 1) ? true : false;
            
            PuiCatGeografia pais = new PuiCatGeografia(db);
            cboPaises.DataSource = pais.ListPaises();
            cboSyncPaises.DataSource = pais.ListPaises();
            cboSyncPaises.DisplayMember = "Descripcion";
            cboSyncPaises.ValueMember = "Clave";

            
            cboEstatus.SelectedText = "Activo";
        }
      

        private void OpcionControles(Boolean Op)
        {
            txtDescripcion.Enabled = Op;
            cboEstatus.Enabled = Op;
        }



        private void LimpiarControles()
        {
            txtDescripcion.Text = "";
            cboEstatus.Text = "";
            lblAgregar.Text = "";
        }

        private void cmdAgregarPais_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.Size = this.MaximumSize;
            lblAgregar.Text = "Agregando Pais";
            _padre = 0;
            combo = "cboPaises";
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            LimpiarControles();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "CatGeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no válidos.", "CatGeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int resp = -1;

            PuiCatGeografia pui = new PuiCatGeografia(db);
            pui.keyCveGeografia = idxG;
            pui.cmpDescripcion = txtDescripcion.Text;
            pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "1" : "0";
            
            if (idxG < 0)
            {
                pui.cmpPadre = _padre;
                resp = pui.AgregarGeografia();
            }
            else
                resp = pui.ActualizaGeografia();

            idxG = -1;
            if (resp >= 0)
            {
                MessageBoxAdv.Show("Operación realizada con éxito", "Confirmacion", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                switch (combo)
                {
                    case "cboPaises":
                        cboPaises.DataSource = pui.ListPaises();
                        break;
                    case "cboEstados":
                        cboEstados.DataSource = pui.ListGeografia(_padre);
                        break;
                    case "cboMunicipios":
                        cboMunicipios.DataSource = pui.ListGeografia(_padre);
                        break;
                    case "cboLocalidad":
                        cboLocalidad.DataSource = pui.ListGeografia(_padre);
                        break;
                }
            }
            this.Size = this.MinimumSize;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aux;
            ComboBox cbo = (ComboBox)sender;
            if (!int.TryParse(cbo.SelectedValue.ToString(), out aux))
                aux = 0;
            if (aux > 0)
            {
                PuiCatGeografia pui = new PuiCatGeografia(db);
                switch (cbo.Name)
                {
                    case "cboPaises":
                        cboEstados.DataSource = pui.ListGeografia(aux);
                        cboEstados.Text = "";
                        cboEstados.Enabled = true;
                        if (AcCOPB == 1)
                        {
                            cmdAgregarEstado.Enabled = true;
                            cmdEliminarPais.Enabled = true;
                            cmdEditarPais.Enabled = true;
                        }
                        break;
                    case "cboEstados":
                        cboMunicipios.DataSource = pui.ListGeografia(aux);
                        cboMunicipios.Enabled = true;
                        cboMunicipios.Text = "";
                        if (AcCOPB == 1)
                        {
                            cmdEliminarEstado.Enabled = true;
                            cmdAgregarMunicipio.Enabled = true;
                            cmdEditarEstado.Enabled = true;
                        }
                        break;
                    case "cboMunicipios":
                        cboLocalidad.DataSource = pui.ListGeografia(aux);
                        cboLocalidad.Enabled = true;
                        cboLocalidad.Text = "";
                        if (AcCOPB == 1)
                        {
                            cmdEliminarMunicipio.Enabled = true;
                            cmdAgregarLocalidad.Enabled = true;
                            cmdEditarMunicipio.Enabled = true;
                        }
                        break;
                    case "cboLocalidad":
                        if (AcCOPB == 1)
                        {
                            cmdEliminarLocalidad.Enabled = true;
                            cmdEditarLocalidad.Enabled = true;
                        }
                        break;
                }
            }
            else
                cbo.Text = "";
        }

        private void cmdAgregarEstado_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (!int.TryParse(cboPaises.SelectedValue.ToString(), out aux))
            {
                MessageBoxAdv.Show("Pais: Seleccione un Pais.", "CatGeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPaises.Focus();
                return;
            }
                
            LimpiarControles();
            this.Size = this.MaximumSize;
            lblAgregar.Text = "Agregando Estado del Pais - "+cboPaises.Text;
            _padre = aux;
            combo = "cboEstados";
            

        }

        private void cmdAgregarMunicipio_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (!int.TryParse(cboEstados.SelectedValue.ToString(), out aux))
            {
                MessageBoxAdv.Show("Estado: Seleccione un Estado.", "CatGeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstados.Focus();
                return;
            }

            LimpiarControles();
            this.Size = this.MaximumSize;
            lblAgregar.Text = "Agregando Municipio del Estado - " + cboEstados.Text;
            _padre = aux;
            combo = "cboMunicipios";
            
        }

        private void cmdAgregarLocalidad_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (!int.TryParse(cboMunicipios.SelectedValue.ToString(), out aux))
            {
                MessageBoxAdv.Show("Municipio: Seleccione un Municipio.", "CatGeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMunicipios.Focus();
                return;
            }

            LimpiarControles();
            this.Size = this.MaximumSize;
            lblAgregar.Text = "Agregando Localidad del Municipio - " + cboMunicipios.Text;
            _padre = aux;
            combo = "cboLocalidad";
            
        }

        private void cmdEliminarPais_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboPaises.SelectedValue.ToString());

                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + cboPaises.Text,
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatGeografia pui = new PuiCatGeografia(db);
                    pui.keyCveGeografia = aux;
                    pui.EliminaGeografia();
                    cboPaises.DataSource = pui.ListPaises();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Pais: Seleccione un Pais. \n " +ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboPaises.Focus();
            }
        }

        private void cmdEliminarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboEstados.SelectedValue.ToString());

                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + cboEstados.Text,
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatGeografia pui = new PuiCatGeografia(db);
                    pui.keyCveGeografia = aux;
                    pui.EliminaGeografia();
                    cboEstados.DataSource = pui.ListGeografia(int.Parse(cboPaises.SelectedValue.ToString()));
                    cboEstados.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Estado: Seleccione un Estado. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboEstados.Focus();
            }
        }

        private void cmdEliminarMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboMunicipios.SelectedValue.ToString());

                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + cboMunicipios.Text,
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatGeografia pui = new PuiCatGeografia(db);
                    pui.keyCveGeografia = aux;
                    pui.EliminaGeografia();
                    cboMunicipios.DataSource = pui.ListGeografia(int.Parse(cboEstados.SelectedValue.ToString()));
                    cboMunicipios.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Pais: Seleccione un Pais. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboMunicipios.Focus();
            }
        }

        private void cmdEliminarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboLocalidad.SelectedValue.ToString());

                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + cboLocalidad.Text,
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatGeografia pui = new PuiCatGeografia(db);
                    pui.keyCveGeografia = aux;
                    pui.EliminaGeografia();
                    cboLocalidad.DataSource = pui.ListGeografia(int.Parse(cboMunicipios.SelectedValue.ToString()));
                    cboLocalidad.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Pais: Seleccione un Pais. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboLocalidad.Focus();
            }
        }

        private void cmdEditarPais_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboPaises.SelectedValue.ToString());
                combo = "cboPaises";
                Editar(aux);

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Pais: Seleccione un Pais. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboPaises.Focus();
            }
        }
        

        private void cmdEditarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboEstados.SelectedValue.ToString());
                combo = "cboEstados";
                Editar(aux);

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Estado: Seleccione un Estado. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboEstados.Focus();
            }
        }

        private void cmdEditarMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboMunicipios.SelectedValue.ToString());
                combo = "cboMunicipios";
                Editar(aux);

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Municipio: Seleccione un Municipio. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboMunicipios.Focus();
            }

        }

        private void cmdEditarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(cboLocalidad.SelectedValue.ToString());
                combo = "cboLocalidad";
                Editar(aux);

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Localidad: Seleccione un Localidad. \n " + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                cboMunicipios.Focus();
            }
        }

        private void Editar(int id)
        {
            LimpiarControles();
            this.Size = this.MaximumSize;
            PuiCatGeografia pui = new PuiCatGeografia(db);
            pui.keyCveGeografia = id;
            pui.EditarGeografia();
            lblAgregar.Text = "Modificando a: " + pui.cmpDescripcion;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboEstatus.SelectedText = (pui.cmpEstatus == "1") ? "Activo" : "Baja";
            idxG = pui.keyCveGeografia;
        }

        private void frmCatGeografia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
