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

using System.Globalization;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class MovtosInvPart : MetroForm
    {
        private int opcion;
        private MsSql db = null;
        private int CodPart;

        Boolean ErrCalc = true;

        private String PModLlama;
        private String PNoMovimiento;

        private double Cantidad;
        private double Precio;
        private double Descuento;
        private double PNeto;
        private double TotalIva;
        private double TotalIEPS;
        private double SubTotal;
        private double TotalPartida;

        clsCfgTipoMovInv CfgMovInv;

        clsCfgAlmacen CfgAlma;
        //clsCfgAlmacen CfgAlmaDest;

        private int ExisNegativa;
        private String PAlmacen;

        private double CantInv;

        private String CveImp = "", CveImpIEPS ="";
        private String CveUmed = "";
        private String IdArt = "", CodBa = "";
        public clsStiloTemas StiloColor;

        public DatCfgUsuario user;

        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        private ToolTip ttPrecio = new ToolTip();
        private ToolTip ttDescuento = new ToolTip();
        private ToolTip ttCantidad = new ToolTip();
        
        public MovtosInvPart()
        {
            InitializeComponent();
        }

        public MovtosInvPart(MsSql Odat, DatCfgParamSystem ParamS, clsStiloTemas NewColor, DatCfgUsuario DatUsr, String P_modulo, 
                 String P_folio, int P_operacion,
                 clsCfgTipoMovInv PCfgMovInv, clsCfgAlmacen PCfgAlma, int P_CodPart, String Almacen )
        {
            InitializeComponent();
            opcion = P_operacion;
            db = Odat;
            user = DatUsr;
            ParamSystem = ParamS;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            CodPart = P_CodPart;
            StiloColor = NewColor;
            PModLlama = P_modulo; //dependiendo del modulo que llama esta ventana extrae el precio
            PNoMovimiento = P_folio;

            CfgMovInv = PCfgMovInv;
            CfgAlma = PCfgAlma;
            PAlmacen = Almacen;

            if (CfgMovInv.EditaCosto == 0)
                txtPrecio.Enabled = false;
            
            if (CfgMovInv.MuestraCosto == 1)
            {
                lblMuesCosto.Visible = true;
                txtMuesCosto.Visible = true;
            }
            else
            {
                lblMuesCosto.Visible = false;
                txtMuesCosto.Visible = false;
            }

            if (opcion >= 2)
            {
                GetRegistro();
            }

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void GetRegistro()
        {
            PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
            pui.keyNoMovimiento = PNoMovimiento;
            pui.keyNoPartida = CodPart;
            pui.EditarPartida();
            //txtCodigo.Text = pui.cmpCveArticulo;
            txtCodigo.Text = (ParamSystem.HideCveArt == 1) ? pui.cmpCodigoBarra : pui.cmpCveArticulo;

            IdArt = pui.cmpCveArticulo;
            CodBa = pui.cmpCodigoBarra;


            txtDescripcion.Text = pui.cmpDescripcion;
            txtUmedida.Text = pui.cmpCveUMedida;
            BuscarPrecio(pui.cmpCveArticulo);
            txtCantidad.Text = Convert.ToString(pui.cmpCantidad);
            txtDescuento.Text = Convert.ToString(pui.cmpDescuento);
            txtTotalDescuento.Text = Convert.ToString(pui.cmpTotalDscto);
            chkCalculaPorcentaje.Checked = pui.cmpTotalDscto == 1 ? true : false;
            txtPrecioNeto.Text =Util.FormtDouDec(pui.cmpTotalDscto); //Convert.ToString(pui.cmpTotalDscto);
            txtSubTotal.Text = Util.FormtDouDec(pui.cmpSubTotal); //Convert.ToString(pui.cmpSubTotal);
            txtImpuesto.Text = Util.FormtDouDec(pui.cmpTotalIva);// Convert.ToString(pui.cmpTotalIva);
            txtValorIVA.Text = Convert.ToString(pui.cmpImpuestoValor);
            txtTotal.Text = Util.FormtDouDec(pui.cmpTotalPartida);  //Convert.ToString(pui.cmpTotalPartida);

            CveImpIEPS = pui.cmpCveImpIEPS;
            txtValorIEPS.Text = Convert.ToString(pui.cmpImpIEPSValor);
            TotalIEPS = pui.cmpTotalIEPS;
            

        }

        private void AddPartidaInvMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case 1: AltaPartida();   break;
                case 2: EditarPartida(); break;
                case 3: this.Close(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
        }

        private void AltaPartida()
        {
            SetValues(1);
        }

        private void EditarPartida()
        {
            SetValues(0);
        }
 
        private void SetValues(int NewReg = 1)
        {
            try
            {
                if (validacion())
                {
                    PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                    pui.keyNoMovimiento = PNoMovimiento;
                    pui.keyNoPartida = NewReg == 1 ? pui.GetFolioPart(PNoMovimiento) : CodPart;
                    pui.cmpCveAlmacenMov = "";
                    pui.cmpCveTipoMov = CfgMovInv.CveTipoMov;
                    pui.cmpEntSal = CfgMovInv.EntSal;
                    pui.cmpNoDoc = "";
                    pui.cmpDocumento = "";
                    pui.cmpCveArticulo = IdArt;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpCveUMedida = CveUmed;
                    pui.cmpCantidad = Cantidad;
                    pui.cmpCantidadPkt = Cantidad;
                    pui.cmpPrecio = Precio;
                    pui.cmpDescuento = Descuento;
                    pui.cmpTotalDscto = PNeto;
                    pui.cmpDsctoEsPorcentaje = chkCalculaPorcentaje.Checked ? 1 : 0;
                    pui.cmpCveImpuesto = CveImp;
                    pui.cmpImpuestoValor = Convert.ToDouble(txtValorIVA.Text);
                    pui.cmpTotalIva = TotalIva;
                    pui.cmpSubTotal = SubTotal;
                    pui.cmpTotalPartida = TotalPartida;
                    pui.cmpFolioDocOrigen = "";
                    pui.cmpFechaMovimiento = user.FecServer;
                    pui.cmpNoMovtoTra = "";
                    pui.cmpDocTra = "";
                    pui.cmpPartTra = "";

                    pui.cmpCveImpIEPS = CveImpIEPS;
                    pui.cmpImpIEPSValor = Convert.ToDouble(txtValorIEPS.Text);
                    pui.cmpTotalIEPS = TotalIEPS;
                    pui.cmpCveImpRetIVA = "";
                    pui.cmpImpRetIVAValor = 0;
                    pui.cmpTotalRetIVA = 0;
                    pui.cmpCveImpRetISR = "";
                    pui.cmpImpRetISRValor = 0;
                    pui.cmpTotalRetISR = 0;
                    pui.cmpCveImpOtro = "";
                    pui.cmpImpValorOtro = 0;
                    pui.cmpTotalImpOtro = 0;


                    if (NewReg == 1)
                    {
                        if (pui.AgregarPartida() >= 1)
                        {
                            MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        if (pui.ActualizaPartida() >= 1)
                        {
                            MessageBoxAdv.Show("Registro actualizado", "Confirmacion", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        

        private void cboCveClsMov_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        

        private void BuscarPrecio(String CveArt)
        {
            PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
            pui.cmpCveArticulo = CveArt;
            pui.cmpinv_ClaveAlmacen = PAlmacen;
            pui.BuscaPrecio(PModLlama);
            CantInv = pui.cmpinv_Cantidad;


            if (PModLlama.Equals("Minv"))
            {
                //FALTA sugiere costo
                //String sugiere = winpadre.parametros.metcosto;
                if (CfgMovInv.SugiereCosto == 1)
                {
                    /*
                    switch(Convert.ToInt32(sugiere))
                    {
                        Asignar el costo según sea su parametro
                    }

                    */

                    txtPrecio.Text = Convert.ToString(pui.cmpinv_CostoUltimo);
                }
                else
                    txtPrecio.Text = "0.0";

                if(CfgMovInv.MuestraCosto == 1)
                {
                    /*
                    switch(Convert.ToInt32(sugiere))
                    {
                        Asignar el costo según sea su parametro
                    }

                    */
                    txtMuesCosto.Text = Convert.ToString(pui.cmpinv_CostoUltimo);
                }

            }
            
        }


        private Boolean validacion()
        {
            String err = "";
            ValidaCalculos(1);
            String txtTo = Util.LimpiarTxt(txtTotal.Text);
            if (ErrCalc)
            {
                if (String.IsNullOrEmpty(txtCodigo.Text))
                {
                    err = "Código: No puede ir vacío. \n";
                    ErrCalc = false;
                }
                else
                {
                    if (!Util.LetrasNum(txtCodigo.Text))
                    {
                        err = "Código: Contiene caracteres no validos. \n";
                        ErrCalc = false;
                    }
                }

                if (ExisNegativa == 1)
                {
                    err = err + "La cantidad solicitada es mayor a la exitencia del articulo \n";
                    ErrCalc = false;
                }


                if (CfgMovInv.SolicitaCosto == 1)
                {
                    if (String.IsNullOrEmpty(txtPrecio.Text))
                    {
                        err = err + "Precio: No puede ir vacío\n";
                        ErrCalc = false;
                    }
                    else
                    {
                        if (!Util.Decimal(txtPrecio.Text))
                        {
                            err = err + "Precio: Contiene caracteres no validos. Sugiere: 0,000 0.0 0000\n";
                            ErrCalc = false;
                        }

                    }

                    if (String.IsNullOrEmpty(txtTo))
                    {
                        err = err + "Total: Existe un error calculo.\n";
                        ErrCalc = false;
                    }
                    else
                    {
                        if (!Util.Decimal(txtTo))
                        {
                            err = err + "Total: Contiene caracteres no validos. Sugiere: 0,000 0.0 0000\n";
                            ErrCalc = false;
                        }
                        else
                        {
                            double tt = Double.Parse(txtTo);
                            if (tt <= 0)
                            {
                                err = err + "Total: Existe un error calculo.\n";
                                ErrCalc = false;
                            }
                        }
                    }


                }

                if (!ErrCalc)
                {
                    MessageBoxAdv.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ErrCalc;
        }

        private void ValidaCalculos(int Op)
        {
            
            //String err = "";
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                if (Op == 1)
                {
                    Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                    //err = err + "Cantidad: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                {
                    Cantidad = 0;
                    ttCantidad.Hide(txtCantidad);
                }
            }
            else
            {
                if (txtCantidad.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtCantidad.Text))
                    {
                        Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        //err = err + "Cantidad: Contiene caracteres no validos. Sugiere: 0)\n";
                        ErrCalc = false;
                    }
                    else
                    {
                        Cantidad = Convert.ToDouble(txtCantidad.Text);
                        ttCantidad.Hide(txtCantidad);
                    }
                }
            }

            if (String.IsNullOrEmpty(txtPrecio.Text))
            {
                if (Op == 1)
                {
                    Util.MsjBox(ttPrecio, txtPrecio, "Precio", "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000", ToolTipIcon.Error);
                    //err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                {
                    Precio = 0;
                    ttPrecio.Hide(txtPrecio);
                }
            }
            else
            {
                if (txtPrecio.Text.Length >= 1)
                {
                    
                    if (!Util.Decimal(txtPrecio.Text))
                    {
                        new BalloonTip("Error de captura", "Contiene caracteres no validos. Sugiere: 0.0 0000", txtPrecio, BalloonTip.ICON.INFO, 5000);
                        //err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;

                    }
                    else
                    {
                        Precio = Convert.ToDouble(txtPrecio.Text);
                        ttPrecio.Hide(txtPrecio);
                    }
                }
            }

            if (String.IsNullOrEmpty(txtDescuento.Text))
            {
                if (Op == 1)
                {
                    Util.MsjBox(ttDescuento, txtDescuento, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                    //err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                {
                    Descuento = 0;
                    ttDescuento.Hide(txtDescuento);
                }
            }
            else
            {
                if (txtDescuento.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtDescuento.Text))
                    {
                        Util.MsjBox(ttDescuento, txtDescuento, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        //err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                    {
                        Descuento = (Convert.ToDouble(txtDescuento.Text));
                        ttDescuento.Hide(txtDescuento);
                    }
                }
            }
                
            if (ErrCalc)
            {
                ttCantidad.Hide(txtCantidad);
                if (PModLlama.Equals("Minv"))
                {
                    if (CfgMovInv.EsTraspaso == 1 || CfgMovInv.EntSal.Equals("S"))
                    {
                        if ((CantInv - Cantidad) < 0)
                        {
                            if (CfgAlma.NumRojo == 1)
                            {
                                if (MessageBoxAdv.Show("Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                        " Existencia: " + CantInv + "\n" +
                                        " ¿Desea continuar?",
                                        "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    ExisNegativa = 0;
                                }
                                else
                                    ExisNegativa = 1;
                            }
                            else
                            {
                                ExisNegativa = 1;
                                Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                                                   " Existencia: " + CantInv + "\n", ToolTipIcon.Error);
                            }
                        }
                        else
                            ExisNegativa = 0;
                    }
                    else
                    {
                        ExisNegativa = 0;
                        //ValidaCalculos(Op);
                    }
                }
                else
                    ExisNegativa = 0;

                SubTotal = 0; txtSubTotal.Text = "0.0";
                PNeto = 0; txtPrecioNeto.Text = "0.0";
                TotalIva = 0; TotalIEPS = 0;
                TotalPartida = 0; txtTotal.Text = "0.0";


                //002 eNTRADA - 501 - SALIDA por ajuste de inventario
                if (!CfgMovInv.CveTipoMov.Equals("002") || !CfgMovInv.CveTipoMov.Equals("501"))
                {

                    SubTotal = Precio * Cantidad;
                    if (chkCalculaPorcentaje.Checked)
                        PNeto = (SubTotal * Descuento / 100);
                    else
                        PNeto = Descuento;

                    SubTotal = SubTotal - PNeto;

                    //PENDIENTE: Valida una matrz y dentro de un else va lo siguiente
                    if (CfgMovInv.CalculaIva == 1)
                    {
                        double iva = Convert.ToDouble(txtValorIVA.Text);
                        double _iEPS = Convert.ToDouble(txtValorIEPS.Text);

                        TotalIEPS = _iEPS > 0 ? SubTotal * (_iEPS / 100) : 0;
                        SubTotal = SubTotal + TotalIEPS;
                        TotalIva = iva > 0 ? SubTotal * (iva / 100) : 0;
                    }

                    TotalPartida = SubTotal + TotalIva;
                    SubTotal = SubTotal - TotalIEPS;

                }
                else
                {
                    CveImp = "";
                }

                txtTotalDescuento.Text = Util.FormtDouDec(PNeto);//Convert.ToString(SubTotal);
                txtSubTotal.Text = Util.FormtDouDec(SubTotal); //Convert.ToString(SubTotal);
                txtImpuesto.Text = Util.FormtDouDec(TotalIva);  //Convert.ToString(TotalIva);
                txtImpIEPS.Text = Util.FormtDouDec(TotalIEPS);  //Convert.ToString(TotalIva);
                txtTotal.Text = Util.FormtDouDec(TotalPartida); //Convert.ToString(TotalPartida);

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
            {
                if (ch == 13)
                    txtDescuento.Focus();

                ErrCalc = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46 && ch != 13)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
            {
                if (ch == 13)
                    txtPrecio.Focus();

                ErrCalc = true;
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46 && ch != 13)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
            {
                if (ch == 13)
                    cmdAceptar.Focus();

                ErrCalc = true;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            ValidaCalculos(0);
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            ValidaCalculos(0);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            ValidaCalculos(0);
        }

        private void btnBuscarArt_Click(object sender, EventArgs e)
        {

            frmLstArticulos art = new frmLstArticulos(db, ParamSystem, user, StiloColor, 3);
            art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            art.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            art.ShowDialog();
            if (!string.IsNullOrEmpty(art.KeyCampo))
            {
                LimpiaVar();
                PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                pui.keyNoMovimiento = art.KeyCampo;
                pui.keyNoPartida = Convert.ToInt32(PNoMovimiento);
                if (pui.GetDuplicado() >= 1)
                {
                    if (MessageBoxAdv.Show("¿Desea agregar mas cantidad? ",
                        "El Articulo se encuentra en la lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        opcion = 2;
                        CodPart = pui.keyNoPartida;
                        GetRegistro();
                        txtPrecio.Focus();
                    }

                }
                else
                {
                    if (ParamSystem.HideCveArt == 1)
                        txtCodigo.Text = art.dv[16];
                    else
                        txtCodigo.Text = art.dv[0];

                    IdArt = art.dv[0];
                    CodBa = art.dv[16];
                    
                    txtDescripcion.Text = art.dv[1];

                    CveImp = art.dv[10];
                    txtValorIVA.Text = GetImpuesto(CveImp);
                    CveUmed = art.dv[8];
                    txtUmedida.Text = GetUMed();
                    CveImpIEPS = art.dv[13];
                    if (!string.IsNullOrEmpty(CveImpIEPS))
                        txtValorIEPS.Text = GetImpuesto(CveImpIEPS);


                    BuscarPrecio(art.KeyCampo);
                    txtPrecio.Focus();
                }
            }
        }

        private string GetImpuesto(string CveIm)
        {
            PuiCatImpuestos Impu = new PuiCatImpuestos(db);
            Impu.keyCveImpuesto = CveIm;
            Impu.EditarImpuesto();
            return Convert.ToString(Impu.cmpValor);
        }

        private string GetUMed()
        {
            PuiCatUMedidas UM = new PuiCatUMedidas(db);
            UM.keyCveUMedida = CveUmed;
            UM.EditarUMedida();
            return UM.cmpDescripcion;
        }


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LimpiaVar();
                PuiCatArticulos Art = new PuiCatArticulos(db);
                PuiCatImpuestos Impu = new PuiCatImpuestos(db);
                Art.keyCveArticulo = txtCodigo.Text;
                if (Art.EditarArticulo(ParamSystem.HideCveArt) > 0)
                {
                    PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                    pui.keyNoMovimiento = Art.keyCveArticulo;
                    pui.keyNoPartida = Convert.ToInt32(PNoMovimiento);
                    txtPrecio.Focus();
                    if (pui.GetDuplicado() >= 1)
                    {
                        if (MessageBoxAdv.Show("¿Desea agregar mas cantidad? ",
                            "El Articulo se encuentra en la lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            opcion = 2;
                            CodPart = pui.keyNoPartida;
                            GetRegistro();
                        }

                    }
                    else
                    {
                        //txtCodigo.Text = Art.keyCveArticulo;
                        IdArt = Art.keyCveArticulo;
                        txtDescripcion.Text = Art.cmpDescripcion;
                        CodBa = Art.cmpCodigoBarra;

                        if (ParamSystem.HideCveArt == 1)
                            txtCodigo.Text = Art.cmpCodigoBarra;
                        else
                            txtCodigo.Text = Art.keyCveArticulo;



                        CveImp = Art.cmpCveImpuesto;
                        txtValorIVA.Text = GetImpuesto(CveImp);
                        CveUmed = Art.cmpCveUMedida1;
                        txtUmedida.Text = GetUMed();
                        CveImpIEPS = Art.CveImpIEPS;

                        if (!string.IsNullOrEmpty(CveImpIEPS))
                            txtValorIEPS.Text = GetImpuesto(CveImpIEPS);

                        BuscarPrecio(Art.keyCveArticulo);
                    }

                }
                else
                {
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUmedida_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void txtPrecioNeto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMuesCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMuesCosto_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtCveIESP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCveIVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkCalculaPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            ValidaCalculos(0);
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void txtImpuesto_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LimpiaVar()
        {
            IdArt = "";
            CodBa = "";
            txtDescripcion.Text = "";
            txtValorIVA.Text = "0";
            CveImp = "";
            txtImpuesto.Text = "";
            txtValorIEPS.Text = "0";
            CveImpIEPS = "";
            txtImpIEPS.Text = "";
            txtUmedida.Text = "";
            CveUmed = "";
        }
    }
}
