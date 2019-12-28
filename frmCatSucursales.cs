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
    public partial class frmCatSucursales : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private int _Opcion;
        private String _KeyCampo;

        private MsSql db = null;

        PuiCatSucursales Prov;
        private string Perfil;
        private clsUtil uT;
        public clsStiloTemas StiloColor;

        public frmCatSucursales(MsSql Odat, DatCfgParamSystem ParamS, clsStiloTemas NewColor, string perfil, int op = 1, String Key = "")
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
                    this.Text = "Agregando nueva sucursal...";
                    cmdAceptar.Text = "Guardar";
                    break;
                case 2:
                    this.Text = "Modificando sucursal con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Actualizar";
                    break;
                default:
                    this.Text = "Datos sucursal con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Aceptar";
                    break;

            }
        }

        private void frmCatSucursales_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            Prov = new PuiCatSucursales(db);

            // Combos
            PuiCatGeografia pui = new PuiCatGeografia(db);
            cboPais.DataSource = pui.ListPaises();
            //cboPais.SelectedText = "MEXICO";


            //Combos
            if (_Opcion >= 2)
            {

                Prov.keyCveSucursales = _KeyCampo;
                Prov.EditarSucursales();
                LlenarDatos();
                txtClaveSucursal.Enabled = false;
                if (_Opcion == 3)
                   OpcionControles(false);
            }
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void LlenarDatos()
        {
            txtClaveSucursal.Text = Prov.keyCveSucursales;
            txtNombre.Text = Prov.cmpNombre;
            txtCalle.Text = Prov.cmpCalle;
            txtCP.Text = Prov.cmpCP;
            txtTel1.Text = Prov.cmpTel;
            txtMail1.Text = Prov.cmpMail;
            txtContacto.Text = Prov.cmpContacto;
            txtCargo.Text = Prov.cmpCargo;

            chkEstatus.Checked = (Prov.cmpEstatus == 1) ? true : false;

            int Municipio, Estado, Pais;
            //String NomLocal;
            PuiCatGeografia geo = new PuiCatGeografia(db);
            geo.keyCveGeografia = Prov.cmpCveLocalidad;
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

            cboLocalidad.SelectedValue = Prov.cmpCveLocalidad;
           
        }
        private void LlenarSucursal()
        {
            Prov = new PuiCatSucursales(db);
            Prov.keyCveSucursales = txtClaveSucursal.Text;
            Prov.cmpNombre = txtNombre.Text;
            Prov.cmpCalle = txtCalle.Text;
            Prov.cmpCP = txtCP.Text;
            if (cboLocalidad.SelectedValue != null)
                Prov.cmpCveLocalidad = int.Parse(cboLocalidad.SelectedValue.ToString());
            Prov.cmpEstatus = (chkEstatus.Checked == true) ? 1 : 0;
            Prov.cmpContacto = txtContacto.Text;
            Prov.cmpCargo = txtCargo.Text;
            Prov.cmpTel = txtTel1.Text;
            Prov.cmpMail = txtMail1.Text;
        }



        private void OpcionControles(Boolean Op)
        {
            txtNombre.Enabled = Op;
            txtClaveSucursal.Enabled = Op;
            cboPais.Enabled = Op;
            txtCalle.Enabled = Op;
            cboEstado.Enabled = Op;
            cboMunicipio.Enabled = Op;
            cboLocalidad.Enabled = Op;
            txtCP.Enabled = Op;
            txtTel1.Enabled = Op;
            txtMail1.Enabled = Op;
            txtContacto.Enabled = Op;
            txtCargo.Enabled = Op;
            chkEstatus.Enabled = Op;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarSucursal();
                if (_Opcion == 1)
                {
                    if (Prov.AgregarSucursales() >= 1)
                    {
                        MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }
                else if (_Opcion == 2)
                    if (Prov.ActualizaSucursales() >= 1)
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

            if (String.IsNullOrEmpty(txtClaveSucursal.Text))
                mensaje += "Código: No puede ir vacío. \n";
            else
                if (!Util.LetrasNum(txtClaveSucursal.Text))
                    mensaje += "Código: Contiene caracteres no validos.\n";

            if (String.IsNullOrEmpty(txtNombre.Text))
                mensaje += "Nombre: No puede ir vacío. \n";
            

            if (String.IsNullOrEmpty(txtCalle.Text))
                mensaje += "Direccion: No puede ir vacío. \n";


            if (String.IsNullOrEmpty(txtTel1.Text))
                mensaje += "Teléfono 1: No puede ir vacío. \n";

            if (String.IsNullOrEmpty(txtMail1.Text))
                mensaje += "Correo 1: No puede ir vacío. \n";
            if (cboLocalidad.SelectedValue == null)
                mensaje += "Localidad: Seleccione una localidad. \n";
            
            if (mensaje != "")
            {
                MessageBoxAdv.Show("Se encontraron los siguientes errores: \n" + mensaje, "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

        private void txtClaveSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

    }
}
