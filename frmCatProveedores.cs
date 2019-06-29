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
    public partial class frmCatProveedores : MetroForm
    {
        private int _Opcion;
        private String _KeyCampo;

        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;

        PuiCatProveedores Prov;
        private string Perfil;
        private clsUtil uT;

        public frmCatProveedores(MsSql Odat, string perfil, int op = 1, String Key = "")
        {
            InitializeComponent();
            _Opcion = op;
            _KeyCampo = Key;
            db = Odat;
            Perfil = perfil;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            switch (op)
            {
                case 1:
                    this.Text = "Agregando nuevo Proveedor...";
                    cmdAceptar.Text = "Guardar";
                    break;
                case 2:
                    this.Text = "Modificando el Proveedor con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Actualizar";
                    break;
                default:
                    this.Text = "Datos del Proveedor con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Aceptar";
                    break;

            }
        }

        private void frmCatProveedores_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            Prov = new PuiCatProveedores(db);

            // Combos
            PuiCatGeografia pui = new PuiCatGeografia(db);
            cboPais.DataSource = pui.ListPaises();
            //cboPais.SelectedText = "MEXICO";


            //Combos
            if (_Opcion >= 2)
            {

                Prov.keyCveProveedores = _KeyCampo;
                Prov.EditarProveedores();
                LlenarDatos();
                txtClaveProveedor.Enabled = false;
                if (_Opcion == 3)
                   OpcionControles(false);
            }
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void LlenarDatos()
        {
            txtClaveProveedor.Text = Prov.keyCveProveedores;
            txtNombre.Text = Prov.cmpNombre;
            txtRFC.Text = Prov.cmpRFC;
            txtCalle.Text = Prov.cmpCalle;
            txtCP.Text = Prov.cmpCP;
            txtTel1.Text = Prov.cmpTel1;
            txtMail1.Text = Prov.cmpMail1;
            cboTipoPersona.SelectedText = Prov.cmpTipoPersona;
            txtContacto.Text = Prov.cmpContacto;
            txtTel2.Text = Prov.cmpTel2;
            txtMail2.Text = Prov.cmpMail2;
            txtCargo.Text = Prov.cmpCargo;
            txtCelular.Text = Prov.cmpCelular;
            cboEstatus.SelectedText = (Prov.cmpEstatus == 1) ? "ACTIVO" : "BAJA";

            int Municipio, Estado, Pais;
            String NomLocal;
            PuiCatGeografia geo = new PuiCatGeografia(db);

            geo.keyCveGeografia = Prov.cmpCveLocalidad;
            geo.EditarGeografia();
            Municipio = geo.cmpPadre;
            NomLocal = geo.cmpDescripcion;

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

            cboLocalidad.SelectedText = NomLocal;
           
        }
        private void LlenarProveedor()
        {
            Prov = new PuiCatProveedores(db);
            Prov.keyCveProveedores = txtClaveProveedor.Text;
            Prov.cmpNombre = txtNombre.Text;
            Prov.cmpRFC = txtRFC.Text;
            Prov.cmpCalle = txtCalle.Text;
            Prov.cmpCP = txtCP.Text;
            Prov.cmpTel1 = txtTel1.Text;
            Prov.cmpMail1 = txtMail1.Text;
            if (cboLocalidad.SelectedValue != null)
                Prov.cmpCveLocalidad = int.Parse(cboLocalidad.SelectedValue.ToString());
            Prov.cmpTipoPersona = cboTipoPersona.Text;
            Prov.cmpEstatus = (cboEstatus.Text == "ACTIVO") ? 1 : 0;
            Prov.cmpContacto = txtContacto.Text;
            Prov.cmpTel2 = txtTel2.Text;
            Prov.cmpMail2 = txtMail2.Text;
            Prov.cmpCargo = txtCargo.Text;
            Prov.cmpCelular = txtCelular.Text;
        }



        private void OpcionControles(Boolean Op)
        {
            txtNombre.Enabled = Op;
            txtClaveProveedor.Enabled = Op;
            cboPais.Enabled = Op;
            txtRFC.Enabled = Op;
            txtCalle.Enabled = Op;
            cboEstado.Enabled = Op;
            cboTipoPersona.Enabled = Op;
            cboMunicipio.Enabled = Op;
            cboLocalidad.Enabled = Op;
            txtCP.Enabled = Op;
            txtTel1.Enabled = Op;
            txtTel2.Enabled = Op;
            txtMail2.Enabled = Op;
            txtMail1.Enabled = Op;
            txtContacto.Enabled = Op;
            txtCelular.Enabled = Op;
            txtCargo.Enabled = Op;
            cboEstatus.Enabled = Op;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarProveedor();
                if (_Opcion == 1)
                {
                    if (Prov.AgregarProveedores() >= 1)
                    {
                        MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }
                else if (_Opcion == 2)
                    if (Prov.ActualizaProveedores() >= 1)
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
            ClsUtilerias Util = new ClsUtilerias();

            if (String.IsNullOrEmpty(txtClaveProveedor.Text))
                mensaje += "Código: No puede ir vacío. \n";
            else
                if (!Util.LetrasNum(txtClaveProveedor.Text))
                    mensaje += "Código: Contiene caracteres no validos.\n";

            if (String.IsNullOrEmpty(txtRFC.Text))
                mensaje += "RFC: No puede ir vacío. \n";
            else
                if (!Util.LetrasNum(txtRFC.Text))
                    mensaje += "RFC: Contiene caracteres no validos.\n";

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
            if (cboTipoPersona.SelectedValue == null)
                mensaje += "Tipo de Persona: Seleccione un Tipo de persona. \n";
            if (cboEstatus.SelectedValue == null)
                mensaje += "Estatus: Seleccione un Estatus. \n";
            


            if (mensaje != "")
            {
                MessageBoxAdv.Show("Se encontraron los siguientes errores: \n" + mensaje, "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

    }
}
