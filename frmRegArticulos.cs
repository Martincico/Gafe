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
    public partial class frmRegArticulos : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;
        private int _Opcion;
        private String _KeyCampo;

        private SqlDataAdapter DatosTbl;
        private MsSql db = null;

        PuiCatArticulos Art;
        private clsUtil uT;
        public clsStiloTemas StiloColor;
        public DatCfgUsuario user;

        //Variables para los select
        private string _CveMarc ="",  _CveClas1 = "", _CveClas2 = "", _CveClas3 = "", _CveLin = "", 
            _CveUMed1 = "", _CveUMed2 = "", _CveUMed3 = "", _CveImp = "", _CveImpIESP = "", _CveRetImp = "", _CveRetImpISR = "";

        public frmRegArticulos(MsSql Odat, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op=1, String Key="" )
        {
            InitializeComponent();
            _Opcion = op;
            _KeyCampo = Key;
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            switch (op)
            {
                case 1:
                    this.Text = "Agregando nuevo Articulo...";
                    cmdAceptar.Text = "Guardar";
                    break;
                case 2:
                    this.Text = "Modificando el Articulo con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Actualizar";
                    cmdLstPrecio.Visible = true;
                    break;
                default:
                    this.Text = "Datos del Articulo con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Aceptar";
                    //LleGridLstPrecio();
                    break;

            }
            dtFechaAlta.Value = user.FecServer;
            
        }

        private void frmCatArticulos_Load(object sender, EventArgs e)
        {

            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            Art = new PuiCatArticulos(db);

            //Combos
            if (_Opcion>=2)
            {
                
                Art.keyCveArticulo = _KeyCampo;
                Art.EditarArticulo(0);
                LlenarDatos();
                txtClaveArticulo.Enabled = false;
                if (_Opcion == 3)
                    OpcionControles(false);
            }

        }



        private Boolean Validar()
        {
            lblDescArt.ForeColor = Color.Black;
            lblMarca.ForeColor = Color.Black;
            lblClase.ForeColor = Color.Black;
            lblLinea.ForeColor = Color.Black;
            lblUMed.ForeColor = Color.Black;
            lblImp.ForeColor = Color.Black;
            lblCodB.ForeColor = Color.Black;
            lblCveInterna.ForeColor = Color.Black;
            lblRetISR.ForeColor = Color.Black;
            lblRetIVA.ForeColor = Color.Black;

            Boolean dv = true;
            String MsgErr = "";

            if (String.IsNullOrEmpty(txtClaveArticulo.Text))
            {
                MsgErr += "Clave interna: No puede ir vacío. \n";
                dv = false;
                lblCveInterna.ForeColor = Color.Red;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveArticulo.Text))
                {
                    MsgErr += "Clave interna: Contiene caracteres no validos. \n";
                    dv = false;
                    lblCveInterna.ForeColor = Color.Red;
                }
            }
            
            if (String.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                MsgErr += "Código de barra: No puede ir vacío. \n";
                dv = false;
                lblCodB.ForeColor = Color.Red;
            }
            else
            {
                if (!Util.LetrasNum(txtCodigoBarras.Text))
                {
                    MsgErr += "Código de barra: Contiene caracteres no validos. \n";
                    dv = false;
                    lblCodB.ForeColor = Color.Red;
                }
            }
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MsgErr += "Descripción: No puede ir vacío. \n";
                dv = false;
                lblDescArt.ForeColor = Color.Red;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MsgErr += "Descripción: Contiene caracteres no validos. \n";
                    dv = false;
                    lblDescArt.ForeColor = Color.Red;
                }
            }

            if (String.IsNullOrEmpty(_CveClas1))
            {
                MsgErr += "Clase: No puede ir vacío. \n";
                dv = false;
                lblClase.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(_CveMarc))
            {
                MsgErr += "Marca: No puede ir vacío. \n";
                dv = false;
                lblMarca.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(_CveLin))
            {
                MsgErr += "Línea: No puede ir vacío. \n";
                dv = false;
                lblLinea.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(_CveUMed1))
            {
                MsgErr += "Unidad de medida: No puede ir vacío. \n";
                dv = false;
                lblUMed.ForeColor = Color.Red;
            }

            if (String.IsNullOrEmpty(_CveImp))
            {
                MsgErr += "Impuesto: No puede ir vacío. \n";
                dv = false;
                lblImp.ForeColor = Color.Red;
            }
            
            if(chkEsServicio.Checked)
            {
                Boolean rp = String.IsNullOrEmpty(_CveRetImp) ? (String.IsNullOrEmpty(_CveRetImpISR) ? true : false) : false;
                if (rp)
                {
                    MsgErr += "Debe seleccionar un tipo de retención. \n";
                    dv = false;
                    lblRetISR.ForeColor = Color.Red;
                    lblRetIVA.ForeColor = Color.Red;
                }
            }

            if (!dv)
            {
                MessageBoxAdv.Show(MsgErr, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return dv;
        }

        private void LlenarDatos()
        {
            txtClaveArticulo.Text = Art.keyCveArticulo;
            txtDescripcion.Text = Art.cmpDescripcion;
            txtCodigoBarras.Text = Art.cmpCodigoBarra;
            txtCodigoAlterno.Text = Art.cmpCodigoAlterno;
            txtCodigoSAT.Text = Art.cmpCodigoSat;
            dtFechaAlta.Value = Art.cmpFecha_Alta;


            
            if (!string.IsNullOrEmpty(Art.cmpCveLinea))
            {
                _CveLin = Art.cmpCveLinea;
                PuiCatLineas Ln = new PuiCatLineas(db);
                Ln.keyCveLinea = Art.cmpCveLinea;
                Ln.EditarLinea();
                txtLinea.Text = Ln.cmpDescripcion;
            }

            PuiCatClases cl = new PuiCatClases(db);

            if (!string.IsNullOrEmpty(Art.cmpCveClase1))
            {
                _CveClas1 = Art.cmpCveClase1;
                cl.keyCveClase = Art.cmpCveClase1;
                cl.EditarClase();
                txtClase1.Text = cl.cmpDescripcion;
            }

            if (!string.IsNullOrEmpty(Art.cmpCveClase2))
            {
                _CveClas2 = Art.cmpCveClase1;
                cl.keyCveClase = Art.cmpCveClase2;
                cl.EditarClase();
                txtClase2.Text = cl.cmpDescripcion;
            }

            if (!string.IsNullOrEmpty(Art.cmpCveClase3))
            {
                _CveClas3 = Art.cmpCveClase3;
                cl.keyCveClase = Art.cmpCveClase3;
                cl.EditarClase();
                txtClase3.Text = cl.cmpDescripcion;
            }

            PuiCatImpuestos Im = new PuiCatImpuestos(db);

            if (!string.IsNullOrEmpty(Art.cmpCveImpuesto))
            {
                _CveImp = Art.cmpCveImpuesto;
                Im.keyCveImpuesto = Art.cmpCveImpuesto;
                Im.EditarImpuesto();
                txtImpuesto.Text = Im.cmpTipo;
            }

            if (!string.IsNullOrEmpty(Art.cmpCveImpIEPS))
            {
                _CveImpIESP = Art.cmpCveImpuesto;
                Im.keyCveImpuesto = Art.cmpCveImpuesto;
                Im.EditarImpuesto();
                txtImpIESP.Text = Im.cmpTipo;
            }

            if (!string.IsNullOrEmpty(Art.cmpCveMarca))
            {
                _CveMarc = Art.cmpCveMarca;
                PuiCatMarcas Mc = new PuiCatMarcas(db);
                Mc.keyCveMarca = Art.cmpCveMarca;
                Mc.EditarMarcas();
                txtMarca.Text = Mc.cmpDescripcion;
            }


            PuiCatUMedidas Um = new PuiCatUMedidas(db);

            if (!string.IsNullOrEmpty(Art.cmpCveUMedida1))
            {
                _CveUMed1 = Art.cmpCveUMedida1;
                Um.keyCveUMedida= Art.cmpCveUMedida1;
                Um.EditarUMedida();
                txtUMed1.Text = Um.cmpDescripcion;
            }

            if (!string.IsNullOrEmpty(Art.cmpCveUMedida2))
            {
                _CveUMed2 = Art.cmpCveUMedida2;
                Um.keyCveUMedida = Art.cmpCveUMedida2;
                Um.EditarUMedida();
                txtUMed2.Text = Um.cmpDescripcion;
            }
            if (!string.IsNullOrEmpty(Art.cmpCveUMedidaEquiv))
            {
                _CveUMed3 = Art.cmpCveUMedidaEquiv;
                Um.keyCveUMedida = Art.cmpCveUMedidaEquiv;
                Um.EditarUMedida();
                txtUMed3.Text = Um.cmpDescripcion;
            }


            if (Art.cmpEsServicio)
            {
                chkEsServicio.Checked = Art.cmpEsServicio;
                if (!string.IsNullOrEmpty(Art.cmpCveImpRetISR))
                {
                    _CveRetImpISR = Art.cmpCveImpRetISR;
                    Im.keyCveImpuesto = Art.cmpCveImpRetISR;
                    Im.EditarImpuesto();
                    txtRetISR.Text = Im.cmpTipo;
                }
                if (!string.IsNullOrEmpty(Art.cmpCveImpRetIVA))
                {
                    _CveRetImp = Art.cmpCveImpRetIVA;
                    Im.keyCveImpuesto = Art.cmpCveImpRetIVA;
                    Im.EditarImpuesto();
                    txtRetIVA.Text = Im.cmpTipo;
                }
            }
            else
            {
                chkEsServicio.Checked = false;
            }
             
            //Art.= cmdModelo.SelectedValue.ToString();

            chkEsInventa.Checked = Art.cmpEsInventa;
            chkEsKit.Checked = Art.cmpEsKit;
            chkDispKit.Checked = Art.cmpDispKit;
            
            chkDispVenta.Checked = Art.cmpDispVenta;
            txtObservaciones.Text = Art.cmpObservacion;
            chkEstatus.Checked = Art.cmpEstatus;
            txtUltimaCompra.Text = Art.cmpFecUltCompra;

            chkRequiereReceta.Checked = Art.cmpRequiereReceta == 1 ? true : false;
            if (Art.cmpFoto != null)
            {
                MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                pbArticulo.Image = Image.FromStream(Mf);
            }
        }


        private void LlenarArticulo()
        {
            Art = new PuiCatArticulos(db);
            Art.keyCveArticulo = txtClaveArticulo.Text;
            Art.cmpDescripcion= txtDescripcion.Text;            
            Art.cmpCodigoBarra= txtCodigoBarras.Text;
            Art.cmpCodigoAlterno= txtCodigoAlterno.Text;
            Art.cmpCodigoSat= txtCodigoSAT.Text;
            Art.cmpFecha_Alta = dtFechaAlta.Value;// Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", dtFechaAlta.Value));

            Art.cmpCveLinea = _CveLin;
            Art.cmpCveClase1 = _CveClas1;
            Art.cmpCveClase2 = _CveClas2;
            Art.cmpCveClase3 = _CveClas3;
            Art.cmpCveImpuesto = _CveImp;
            Art.cmpCveImpIEPS = _CveImpIESP;
            Art.cmpCveMarca = _CveMarc;
            Art.cmpCveImpOtro = "";
            Art.cmpCveUMedida1 = _CveUMed1;
            Art.cmpCveUMedida2 = _CveUMed2 ;
            Art.cmpCveUMedidaEquiv = _CveUMed3;

            //Art.= cmdModelo.SelectedValue.ToString();


            Art.cmpEsInventa= chkEsInventa.Checked;
            Art.cmpEsKit= chkEsKit.Checked;
            Art.cmpDispKit= chkDispKit.Checked;
            //Art.cmpEsServicio= chkEsServicio.Checked;
            Art.cmpDispVenta= chkDispVenta.Checked;
            Art.cmpObservacion= txtObservaciones.Text;
            Art.cmpEstatus= chkEstatus.Checked;
            Art.cmpCveAlmacen = user.AlmacenUsa;
            Art.cmpRequiereReceta = chkRequiereReceta.Checked ? 1 : 0;

            if (chkEsServicio.Checked)
            {
                Art.cmpEsServicio = chkEsServicio.Checked;
                Art.cmpCveImpRetISR = _CveRetImpISR;
                Art.cmpCveImpRetIVA = _CveRetImp;
            }
            else
            {
                Art.cmpEsServicio = false;
                Art.cmpCveImpRetISR = "";
                Art.cmpCveImpRetIVA = "";
            }


            if (pbArticulo.Image != null)
            {
                MemoryStream ms1 = new MemoryStream();
                // Se guarda la imagen en el buffer            
                pbArticulo.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
                Art.cmpFoto = ms1.GetBuffer();
            }
        }




        private void OpcionControles(Boolean Op)
        {
            txtDescripcion.Enabled = Op;
            txtCodigoBarras.Enabled = Op;
            txtCodigoAlterno.Enabled = Op;
            txtCodigoSAT.Enabled = Op;
            dtFechaAlta.Enabled = Op;
            cmdLinea.Enabled = Op;
            cmdClase3.Enabled = Op;
            cmdClase2.Enabled = Op;
            cmdClase1.Enabled = Op;
            cmdImpuesto.Enabled = Op;
            cmdImpIESP.Enabled = Op;
            cmdMarca.Enabled = Op;
            //cboModelo.Enabled = Op;
            cmdUMed1.Enabled = Op;
            cmdUMed2.Enabled = Op;
            cmdUMed3.Enabled = Op;
            chkEsInventa.Enabled = Op;
            chkEsKit.Enabled = Op;
            chkDispKit.Enabled = Op;
            chkEsServicio.Enabled = Op;
            chkDispVenta.Enabled = Op;
            txtObservaciones.Enabled = Op;
            chkEstatus.Enabled = Op;
            cmdFoto.Enabled = Op;
            //grdLstPrecio.Enabled = Op;
            chkRequiereReceta.Enabled = Op;

            HabRetImp(Op);

            cmdLinea.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdClase3.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdClase2.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdClase1.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdImpuesto.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdImpIESP.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);

            cmdMarca.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdUMed1.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdUMed2.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdUMed3.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);

        }


        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                LlenarArticulo();
                if (_Opcion == 1)
                {
                    db.IniciaTrans();
                    if (Art.AgregarArticulo() >= 1)
                    {
                        if (Art.AddArticulo_LstPrecio() >= 1)
                        {
                            db.TerminaTrans();
                            MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            db.CancelaTrans();
                            MessageBoxAdv.Show("Existe un problema al registrar en listas.", "Artículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        db.CancelaTrans();
                        MessageBoxAdv.Show("Existe un problema al guardar.", "Artículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (_Opcion == 2)
                    if (Art.ActualizaArticulo() >= 1)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                        this.Close();
                    }
                
            }
        }

        private void cmdFoto_Click(object sender, EventArgs e)
        {
            
            if (opfFoto.ShowDialog() == DialogResult.OK)
            {
                pbArticulo.Image= Image.FromFile(opfFoto.FileName);

              
            }
        }

        private void txtClaveArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
            
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e,1);
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoAlterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void txtCodigoSAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void dtFechaAlta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void chkEsInventa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdMarca_Click(object sender, EventArgs e)
        {
            frmCatMarcas la = new frmCatMarcas(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveMarc = la.dv[0];
                txtMarca.Text = la.dv[1];
            }
        }

        private void cmdRetIVA_Click(object sender, EventArgs e)
        {
            frmCatImpuestos la = new frmCatImpuestos(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveRetImp = la.dv[0];
                txtRetIVA.Text = la.dv[1];
            }
        }

        private void cmdRetISR_Click(object sender, EventArgs e)
        {
            frmCatImpuestos la = new frmCatImpuestos(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveRetImpISR = la.dv[0];
                txtRetISR.Text = la.dv[1];
            }
        }

        private void cmdLstPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatLstPreciosDet LPv = new frmCatLstPreciosDet(db, ParamSystem, user, StiloColor, "", txtClaveArticulo.Text);
                LPv.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                LPv.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                LPv.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void cmdBorrarIEPS_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show("Confirme eliminar impuesto IESP seleccionado " + txtImpIESP.Text,
                     "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _CveImpIESP = "";
                txtImpIESP.Text = "";
            }
        }

        private void cmdLimpiarRetIVA_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show("Confirme eliminar impuesto Ret. IVA seleccionado " + txtRetIVA.Text,
                     "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _CveRetImp = "";
                txtRetIVA.Text = "";
            }
        }

        private void cmdLimpiarRetISR_Click(object sender, EventArgs e)
        {
            if (MessageBoxAdv.Show("Confirme eliminar impuesto Ret. ISR seleccionado " + txtRetISR.Text,
                     "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _CveRetImpISR = "";
                txtRetISR.Text = "";
            }
        }

        private void chkEsServicio_CheckedChanged(object sender, EventArgs e)
        {
            HabRetImp(chkEsServicio.Checked);
        }
        private void HabRetImp(Boolean Op)
        {
            cmdRetISR.Enabled = Op;
            cmdRetIVA.Enabled = Op;

            cmdRetISR.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);
            cmdRetIVA.BackColor = (Op) ? Color.White : Color.FromArgb(234, 234, 234);

        }

        private void cmdImpuesto_Click(object sender, EventArgs e)
        {
            frmCatImpuestos la = new frmCatImpuestos(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveImp = la.dv[0];
                txtImpuesto.Text = la.dv[1];
            }
        }

        private void cmdImpIESP_Click(object sender, EventArgs e)
        {
            frmCatImpuestos la = new frmCatImpuestos(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveImpIESP = la.dv[0];
                txtImpIESP.Text = la.dv[1];
            }
        }

        private void cmdUMed1_Click(object sender, EventArgs e)
        {
            frmCatUMedidas la = new frmCatUMedidas(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveUMed1 = la.dv[0];
                txtUMed1.Text = la.dv[1];
            }
        }

        private void cmdUMed3_Click(object sender, EventArgs e)
        {
            frmCatUMedidas la = new frmCatUMedidas(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveUMed3 = la.dv[0];
                txtUMed3.Text = la.dv[1];
            }
        }

        private void cmdUMed2_Click(object sender, EventArgs e)
        {
            frmCatUMedidas la = new frmCatUMedidas(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveUMed2 = la.dv[0];
                txtUMed2.Text = la.dv[1];
            }
        }

        private void cmdLinea_Click(object sender, EventArgs e)
        {
            frmCatLineas la = new frmCatLineas(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveLin = la.dv[0];
                txtLinea.Text = la.dv[1];
            }
        }

        private void cmdClase1_Click(object sender, EventArgs e)
        {
            frmCatClases la = new frmCatClases(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveClas1 = la.dv[0];
                txtClase1.Text = la.dv[1];
            }
        }

        private void cmdClase2_Click(object sender, EventArgs e)
        {
            frmCatClases la = new frmCatClases(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveClas2 = la.dv[0];
                txtClase2.Text = la.dv[1];
            }
        }

        private void cmdClase3_Click(object sender, EventArgs e)
        {
            frmCatClases la = new frmCatClases(db, ParamSystem, user.CodPerfil, 4);
            la.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            la.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            la.ShowDialog();
            if (!string.IsNullOrEmpty(la.idxG))
            {
                _CveClas3 = la.dv[0];
                txtClase3.Text = la.dv[1];
            }
        }
    }
}
