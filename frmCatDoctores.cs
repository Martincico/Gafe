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
    public partial class frmCatDoctores : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private int _Opcion;
        private String _KeyCampo;

        private MsSql db = null;

        PuiCatDoctores Prov;
        private string Perfil;
        private clsUtil uT;
        public clsStiloTemas StiloColor;

        public frmCatDoctores(MsSql Odat, DatCfgParamSystem ParamS, clsStiloTemas NewColor, string perfil, int op = 1, String Key = "")
        {
            InitializeComponent();
            _Opcion = op;
            _KeyCampo = Key;
            db = Odat;
            Perfil = perfil;
            StiloColor = NewColor;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            switch (op)
            {
                case 1:
                    this.Text = "Agregando nuevo Doctor...";
                    cmdAceptar.Text = "Guardar";
                    break;
                case 2:
                    this.Text = "Modificando el Doctor con Cedula: " + _KeyCampo;
                    cmdAceptar.Text = "Actualizar";
                    break;
                default:
                    this.Text = "Datos del Doctor con Cedula: " + _KeyCampo;
                    cmdAceptar.Text = "Aceptar";
                    break;

            }
        }

        private void frmCatDoctores_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            Prov = new PuiCatDoctores(db);

            // Combos
            PuiCatGeografia pui = new PuiCatGeografia(db);
            cboPais.DataSource = pui.ListPaises();
            //cboPais.SelectedText = "MEXICO";


            //Combos
            if (_Opcion >= 2)
            {

                Prov.keyCveDoctor = _KeyCampo;
                Prov.EditarDoctores();
                LlenarDatos();
                txtCedula.Enabled = false;
                if (_Opcion == 3)
                   OpcionControles(false);
            }
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void LlenarDatos()
        {
            txtCedula.Text = Prov.keyCveDoctor;
            txtNombre.Text = Prov.cmpNombre;
            txtCalle.Text = Prov.cmpCalle;
            txtCP.Text = Prov.cmpCP;
            txtTelefono.Text = Prov.cmpTelefono;
            txtCorreo.Text = Prov.cmpCorreo;
            int Municipio, Estado, Pais;
            //String NomLocal;
            PuiCatGeografia geo = new PuiCatGeografia(db);
            geo.keyCveGeografia = Prov.cmpLocalidad;
            geo.EditarGeografia();
            Municipio = geo.cmpPadre;
            //NomLocal = geo.cmpDescripcion;

            geo.keyCveGeografia = Municipio;
            geo.EditarGeografia();
            Estado = geo.cmpPadre;

            geo.keyCveGeografia = Estado;
            geo.EditarGeografia();
            Pais = geo.cmpPadre;

            cboPais.DataSource = geo.ListPaises();
            cboPais.SelectedValue = Pais;

            cboEstado.SelectedValue = Estado;

            cboMunicipio.SelectedValue = Municipio;

            cboLocalidad.SelectedValue = Prov.cmpLocalidad;
           
        }
        private void LlenarDoctor()
        {
            Prov = new PuiCatDoctores(db);
            Prov.keyCveDoctor = txtCedula.Text;
            Prov.cmpNombre = txtNombre.Text;
            Prov.cmpCalle = txtCalle.Text;
            Prov.cmpCP = txtCP.Text;
            Prov.cmpTelefono = txtTelefono.Text;
            Prov.cmpCorreo = txtCorreo.Text;
            if (cboLocalidad.SelectedValue != null)
                Prov.cmpLocalidad = int.Parse(cboLocalidad.SelectedValue.ToString());
        }



        private void OpcionControles(Boolean Op)
        {
            txtNombre.Enabled = Op;
            txtCedula.Enabled = Op;
            cboPais.Enabled = Op;
            txtCalle.Enabled = Op;
            cboEstado.Enabled = Op;
            cboMunicipio.Enabled = Op;
            cboLocalidad.Enabled = Op;
            txtCP.Enabled = Op;
            txtTelefono.Enabled = Op;
            txtCorreo.Enabled = Op;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarDoctor();
                if (_Opcion == 1)
                {
                    if (Prov.AgregarDoctor() >= 1)
                    {
                        MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }
                else if (_Opcion == 2)
                    if (Prov.ActualizaDoctores() >= 1)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                this.Close();
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
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
                    case "cboPais":
                        cboEstado.DataSource = pui.ListGeografia(aux);
                        cboEstado.Enabled = true;
                        cboEstado.Text = "";
                        break;
                    case "cboEstado":
                        cboMunicipio.DataSource = pui.ListGeografia(aux);
                        cboMunicipio.Enabled = true;
                        cboMunicipio.Text = "";
                        break;
                    case "cboMunicipio":
                        cboLocalidad.DataSource = pui.ListGeografia(aux);
                        cboLocalidad.Enabled = true;
                        cboLocalidad.Text = "";
                        break;
                }
            }
            else
                cbo.Text = "";
        }

        private Boolean Validar()
        {
            Boolean result = true;
            string mensaje = "";

            if (String.IsNullOrEmpty(txtCedula.Text))
                mensaje += "Cedula: No puede ir vacío. \n";
            else
                if (!Util.LetrasNum(txtCedula.Text))
                    mensaje += "Cedula: Contiene caracteres no validos.\n";

            if (String.IsNullOrEmpty(txtNombre.Text))
                mensaje += "Nombre: No puede ir vacío. \n";
            

            if (String.IsNullOrEmpty(txtCalle.Text))
                mensaje += "Calle: No puede ir vacío. \n";


            if (String.IsNullOrEmpty(txtTelefono.Text))
                mensaje += "Teléfono: No puede ir vacío. \n";

            if (String.IsNullOrEmpty(txtCorreo.Text))
                mensaje += "Correo: No puede ir vacío. \n";
            if (cboLocalidad.SelectedValue == null)
                mensaje += "Localidad: Seleccione una localidad. \n";
            
            if (mensaje != "")
            {
                MessageBoxAdv.Show("Se encontraron los siguientes errores: \n" + mensaje, "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

        private void txtClaveDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void txtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }
    }
}
