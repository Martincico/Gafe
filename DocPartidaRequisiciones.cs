
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

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class DocPartidaRequisiciones : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        public DocPartidasReq partida;
        private MsSql db = null;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        ClsUtilerias Util ;
        private ToolTip ttPrecio = new ToolTip();
        private ToolTip ttDescuento = new ToolTip();
        private ToolTip ttCantidad = new ToolTip();
        private clsCfgDocumento ConfigDoc;

        private String IdArt = "", CodBa = "";
        private String CveImp = "", CveImpIEPS = "";
        private String CveUmed = "";
        private String Linea = "", Marca = "";
        Boolean ErrCalc = true;
        clsCfgAlmacen CfgAlma;

        private double CantInv = 0;

        private int Opcion;
        private int ExisNegativa;//0 Esta bien -- 1 Es Negativo

        public DocPartidaRequisiciones()
        {
            InitializeComponent();
        }

        public DocPartidaRequisiciones(MsSql oDat, DatCfgParamSystem ParamS,  DatCfgUsuario DatUsr, clsCfgDocumento CfgDoc,
            clsCfgAlmacen PCfgAlma, clsStiloTemas NewColor, int op, DocPartidasReq part = null)
        {
            InitializeComponent();
            StiloColor = NewColor;
            ParamSystem = ParamS;
            db = oDat;
            Util = new ClsUtilerias(ParamSystem.NumDec);
            user = DatUsr;
            Opcion = op;
            partida = part;
            ConfigDoc = CfgDoc;
            CfgAlma = PCfgAlma;
        }


        private void DocPartidaRequisiciones_Load(object sender, EventArgs e)
        {
            txtDescuento.Text = Util.FormtStrDec("0");
            txtCantidad.Text = Util.FormtStrDec("0"); 

            if (Opcion == 2)
            {
                AbrirPArtidas(partida);
            }

            txtPrecio.Enabled = (ConfigDoc.EditaPrecio == 1) ? true : false;
        }

        private DocPartidasReq AbrirPArtidas()
        {
            if (partida != null)
            {
                if (Opcion == 1)
                {
                    partida.idMov = "0";
                    partida.Documento = "";
                    partida.Serie = "";
                    partida.Numdoc = 0;
                    partida.ClaveAlmacen = "";
                    partida.Partida = 0;
                }


                    partida.CveArticulo = IdArt;
                    partida.CodigoBarra = CodBa;
                    partida.Descripcion = txtDescripcion.Text;
                    partida.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    partida.CveUmedida1 = CveUmed;
                    partida.CveImpuesto = CveImp;
                    partida.ImpuestoValor = Convert.ToDouble(Util.LimpiarTxt(txtCveIVA.Text));
                    partida.CveImpIEPS = CveImpIEPS;
                    partida.ImpIEPSValor = Convert.ToDouble(Util.LimpiarTxt(txtImpIEPS.Text));
                    partida.CveImpRetISR = "";
                    partida.ImpRetISRValor = 0;
                    partida.CveImpRetIVA = "";
                    partida.ImpRetIVAValor = 0;
                    partida.CveImpOtro = "";
                    partida.ImpValorOtro = 0;
                    partida.Linea = Linea;
                    partida.Marca = Marca;

                    partida.Precio = Convert.ToDouble(txtPrecio.Text);
                    partida.Descuento = Convert.ToDouble(txtDescuento.Text);
                    partida.PrecioNeto = Convert.ToDouble(Util.LimpiarTxt(txtPrecioNeto.Text));//Convert.ToDouble(txtPrecioNeto.Text);
                    partida.Impuesto = Convert.ToDouble(Util.LimpiarTxt(txtImpuesto.Text));  //Convert.ToDouble(txtImpuesto.Text);
                    partida.TotalIEPS = Convert.ToDouble(Util.LimpiarTxt(txtImpIEPS.Text));  //Convert.ToDouble(txtImpuesto.Text);
                    partida.TotalRetISR = 0;
                    partida.TotalRetIVA = 0;
                    partida.TotalImpOtro= 0;
                    partida.SubTotal = Convert.ToDouble(Util.LimpiarTxt(txtSubtotal.Text));//Convert.ToDouble(txtSubtotal.Text);
                    partida.Total = Convert.ToDouble(Util.LimpiarTxt(txtTotal.Text)); //Convert.ToDouble(txtTotal.Text);
            }
           
            return partida;
        }

        private void AbrirPArtidas(DocPartidasReq part)
        {
            //txtClaveArticulo.Text = part.CveArticulo;
            txtClaveArticulo.Text = (ParamSystem.HideCveArt == 1) ? part.CodigoBarra : part.CveArticulo;

            IdArt = part.CveArticulo;
            CodBa = part.CodigoBarra;
            CveImp = part.CveImpuesto;
            CveUmed = part.CveUmedida1;
            txtDescripcion.Text = part.Descripcion;
            txtPrecio.Text = part.Precio.ToString();
            txtDescuento.Text = (part.Descuento > 0) ? part.Descuento.ToString() : "0.00";
            txtPrecioNeto.Text = Util.FormtDouDec(part.PrecioNeto);//part.PrecioNeto.ToString();
            txtCantidad.Text = part.Cantidad.ToString();
            txtImpuesto.Text = Util.FormtDouDec(part.Impuesto); //part.Impuesto.ToString();
            txtSubtotal.Text = Util.FormtDouDec(part.SubTotal);//part.SubTotal.ToString();
            txtTotal.Text = Util.FormtDouDec(part.Total); //part.Total.ToString();
            txtCveIVA.Text = part.ImpuestoValor.ToString();

            CveImpIEPS = part.CveImpIEPS;
            txtImpIEPS.Text = Util.FormtDouDec(part.TotalIEPS); //part.Impuesto.ToString();
            txtCveIESP.Text = part.ImpIEPSValor.ToString();

            Linea = part.Linea;
            Marca = part.Marca;

        }




        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            partida = null;
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (validacion())
            {
                AbrirPArtidas();
                this.Close();
            }

        }

        private void Calculos(int Op)
        {
            //String err = "";
            double Precio = 0;
            double Descuento = 0;
            double PNeto = 0;
            double Cantidad = 0;
            double SubTotal = 0;
            double TotalIva = 0;
            double TotalIEPS = 0;
            double TotalPartida = 0;

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                if (Op == 1)
                {
                    Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
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
                    //err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    Util.MsjBox(ttPrecio, txtPrecio, "Precio", "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000", ToolTipIcon.Error);
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
                        //err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        Util.MsjBox(ttPrecio, txtPrecio, "Precio", "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000", ToolTipIcon.Error);
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
                    //err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    Util.MsjBox(ttDescuento, txtDescuento, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
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
                        //err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        Util.MsjBox(ttDescuento, txtDescuento, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        ErrCalc = false;
                    }
                    else
                    {
                        //Descuento = (Convert.ToDouble(txtDescuento.Text) / 100);
                        Descuento = (Convert.ToDouble(txtDescuento.Text) );
                        ttDescuento.Hide(txtDescuento);
                    }
                }

            }

            if (ErrCalc)
            {
                if (ConfigDoc.UsaAlmTmp == 1)
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
                }

                if(ExisNegativa == 0)
                {

                    double iva = Convert.ToDouble(txtCveIVA.Text);
                    double _iEPS = Convert.ToDouble(txtCveIESP.Text);

                    SubTotal = Precio * Cantidad;

                    if (chkCalculaPorcentaje.Checked)
                        PNeto = (SubTotal * Descuento / 100);
                    else
                        PNeto = Descuento;

                    SubTotal = SubTotal - PNeto;


                    TotalIEPS = _iEPS > 0 ? SubTotal * (_iEPS / 100) : 0;
                    SubTotal = SubTotal + TotalIEPS;
                    TotalIva = iva > 0 ? SubTotal * (iva / 100) : 0;

                    TotalPartida = SubTotal + TotalIva;
                    SubTotal = SubTotal - TotalIEPS;

                    txtImpIEPS.Text = Util.FormtDouDec(TotalIEPS);  //Convert.ToString(TotalIva);
                    txtImpuesto.Text = Util.FormtDouDec(TotalIva);//TotalIva.ToString();
                    txtSubtotal.Text = Util.FormtDouDec(SubTotal); //SubTotal.ToString();
                    txtTotal.Text = Util.FormtDouDec(TotalPartida);//TotalPartida.ToString();


                }

            }
         }

        private Boolean validacion()
        {
            String err = "";
            String txtTo = Util.LimpiarTxt(txtTotal.Text);
            Calculos(1);
            if (ErrCalc)
            {
                if (String.IsNullOrEmpty(IdArt))
                {
                    err = "Artículo: Error en busqueda. \n";
                    ErrCalc = false;
                }
                else
                {
                    if (IdArt.Equals(""))
                    {
                        err = "Artículo: No se ha seleccionado correctamente. \n";
                        ErrCalc = false;
                    }
                }


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

                if (ExisNegativa == 1)
                {
                    err = err + "La cantidad solicitada es mayor a la exitencia del articulo \n";
                    ErrCalc = false;
                }


                if (!ErrCalc)
                {
                    MessageBoxAdv.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ErrCalc;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos ar = new frmLstArticulos(db, ParamSystem, user, StiloColor, 4)
            {
                CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado),
                CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor)
            };
            ar.ShowDialog();
            if (!string.IsNullOrEmpty(ar.KeyCampo))
            {
                IdArt = ar.dv[0];
                if (ParamSystem.HideCveArt == 1)
                    txtClaveArticulo.Text = ar.dv[16];
                else
                    txtClaveArticulo.Text = ar.dv[0];

                CodBa = ar.dv[16];
                txtDescripcion.Text = ar.dv[1];

                CveImp = ar.dv[10];
                txtCveIVA.Text = GetImpuesto(CveImp);
                CveUmed = ar.dv[8];
                txtUmedida.Text = GetUMed();
                CveImpIEPS = ar.dv[13];
                if (!string.IsNullOrEmpty(CveImpIEPS))
                    txtCveIESP.Text = GetImpuesto(CveImpIEPS);

                Linea = ar.dv[3];
                Marca = ar.dv[5];

                BuscarPrecio(ar.KeyCampo);
                Calculos(0);
                txtPrecio.Focus();

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

        private void txtClaveArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PuiCatArticulos Art = new PuiCatArticulos(db);
                Art.keyCveArticulo = txtClaveArticulo.Text;
                if (Art.EditarArticulo(ParamSystem.HideCveArt) > 0)
                {
                    IdArt = Art.keyCveArticulo;
                    //txtClaveArticulo.Text = Art.keyCveArticulo;
                    if (ParamSystem.HideCveArt == 1)
                        txtClaveArticulo.Text = Art.cmpCodigoBarra;
                    else
                        txtClaveArticulo.Text = Art.keyCveArticulo;


                    CodBa = Art.cmpCodigoBarra;

                    txtDescripcion.Text = Art.cmpDescripcion;
                    
                    CveImp = Art.cmpCveImpuesto;
                    txtCveIVA.Text = GetImpuesto(CveImp);
                    CveUmed = Art.cmpCveUMedida1;
                    txtUmedida.Text = GetUMed();
                    CveImpIEPS = Art.cmpCveImpIEPS;
                    if (!string.IsNullOrEmpty(CveImpIEPS))
                        txtCveIESP.Text = GetImpuesto(CveImpIEPS);


                    Linea = getLinea(Art.cmpCveLinea);
                    Marca = GetMarca(Art.cmpCveMarca);

                    BuscarPrecio(Art.keyCveArticulo);

                    Calculos(0);
                    txtPrecio.Focus();

                    
                }
                else
                {
                    LimpiaVar();
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscarPrecio(String CveArt)
        {
            PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
            pui.cmpCveArticulo = CveArt;
            pui.cmpinv_ClaveAlmacen = user.AlmacenUsa;
            pui.BuscaPrecio("MProv");
            CantInv = pui.cmpinv_Cantidad;
            
            if (ConfigDoc.MuestraPrecio == 1)
            {
                txtPrecio.Text = Convert.ToString(pui.cmpinv_CostoUltimo);
            }
            else
                txtPrecio.Text = "0.0";
            
        }



        private String GetMarca(String Mcc)
        {
            PuiCatMarcas Mc = new PuiCatMarcas(db);
            Mc.keyCveMarca = Mcc;
            Mc.EditarMarcas();
            return Mc.cmpDescripcion;
        }

        private string getLinea(String Lnn)
        {
            PuiCatLineas Ln = new PuiCatLineas(db);
            Ln.keyCveLinea = Lnn;
            Ln.EditarLinea();
            return Ln.cmpDescripcion;
        }

        private void LimpiaVar()
        {
            IdArt = "";
            CodBa = "";
            txtDescripcion.Text = "";
            txtCveIVA.Text = "";
            CveImp = "";
            CveUmed = "";
            txtUmedida.Text = "";
            txtImpuesto.Text = "";
            txtCveIESP.Text = "";
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
                    txtCantidad.Focus();

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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void chkCalculaPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtCveIVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void DocPartidaRequisiciones_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
