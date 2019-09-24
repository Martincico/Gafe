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
    public partial class AddPartidaInvMovtos : MetroForm
    {
        private int opcion;
        private MsSql db = null;
        private int CodPart;

        Boolean ErrCalc = true;

        private String PModLlama;
        private String PNoMovimiento;
        private String PCveTipoMov;


        private double Cantidad;
        private double Precio;
        private double Descuento;
        private double PNeto;
        private double TotalIva;
        private double SubTotal;
        private double TotalPartida;


        private int PSugiereCosto;
        private int PEditaCosto;
        private int PMuestraCosto;
        private int PSolicitaCosto;
        private int PEsTraspaso;
        private String PEntSal;
        private int PCalcIva;


        private int _AlmNumRojo;
        private int _AlmNumRojoDest;
        private int ExisNegativa;


        private double CantInv;

        // PENDIENTE
        //        private int PermiteExiNegativasOri;
        //        private int PermiteExiNegativasDest;
        //        private int ExisNegativa;


        private String CveImp = "";
        public clsStiloTemas StiloColor;

        public DatCfgUsuario user;

        ClsUtilerias Util = new ClsUtilerias();

        public AddPartidaInvMovtos()
        {
            InitializeComponent();
        }

        public AddPartidaInvMovtos(MsSql Odat, clsStiloTemas NewColor, DatCfgUsuario DatUsr, String P_modulo, String P_folio, int P_operacion,
                String P_CveTipoMov, int P_SugiereCosto, int P_EditaCosto, int P_MuestraCosto, 
                 int P_SolicitaCosto, int P_EsTraspaso, String P_EntSal, int P_CalcIva, 
                 int P_AlmNumRojo, int P_AlmNumRojoDest, int P_CodPart )
        {
            InitializeComponent();
            opcion = P_operacion;
            db = Odat;
            user = DatUsr;
            CodPart = P_CodPart;
            StiloColor = NewColor;
            PModLlama = P_modulo; //dependiendo del modulo que llama esta ventana extrae el precio
            PNoMovimiento = P_folio;

            PCveTipoMov = P_CveTipoMov;
            PSugiereCosto = P_SugiereCosto;
            PEditaCosto = P_EditaCosto;
            PMuestraCosto = P_MuestraCosto;
            PSolicitaCosto = P_SolicitaCosto;
            PEsTraspaso = P_EsTraspaso;
            PEntSal = P_EntSal;
            //PENDIENTE 
//            this.PermiteExiNegativasOri = P_PermiteExiNegativasOri;
//            this.PermiteExiNegativasDest = P_PermiteExiNegativasDest;
            PCalcIva = P_CalcIva;
            _AlmNumRojo = P_AlmNumRojo;
            _AlmNumRojoDest = P_AlmNumRojoDest;


            if (PEditaCosto == 0)
                txtPrecio.Enabled = false;
            
            if (PMuestraCosto == 1)
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
            txtCodigo.Text = pui.cmpCveArticulo;
            txtDescripcion.Text = pui.cmpDescripcion;
            txtUmedida.Text = pui.cmpCveUMedida;
            BuscarPrecio(pui.cmpCveArticulo);
            txtCantidad.Text = Convert.ToString(pui.cmpCantidad);
            txtDescuento.Text = Convert.ToString(pui.cmpDescuento);
            txtPrecioNeto.Text = Convert.ToString(pui.cmpTotalDscto);
            txtSubTotal.Text = Convert.ToString(pui.cmpSubTotal);
            txtImpuesto.Text = Convert.ToString(pui.cmpTotalIva);
            txtIva.Text = Convert.ToString(pui.cmpImpuestoValor);
            txtTotal.Text = Convert.ToString(pui.cmpTotalPartida);

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
            if (validacion())
            {
                PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
                pui.keyNoMovimiento = PNoMovimiento;
                pui.keyNoPartida = pui.GetFolioPart(PNoMovimiento);
                pui.cmpCveAlmacenMov = "";
                pui.cmpCveTipoMov = PCveTipoMov;
                pui.cmpEntSal = PEntSal;
                pui.cmpNoDoc = "";
                pui.cmpDocumento = "";
                pui.cmpCveArticulo = txtCodigo.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpCveUMedida = txtUmedida.Text;
                pui.cmpCantidad = Cantidad;
                pui.cmpCantidadPkt = Cantidad;
                pui.cmpPrecio = Precio;
                pui.cmpDescuento = Descuento;
                pui.cmpTotalDscto = PNeto;
                pui.cmpCveImpuesto = CveImp;
                pui.cmpImpuestoValor = Convert.ToDouble(txtIva.Text);
                pui.cmpTotalIva = TotalIva;
                pui.cmpSubTotal = SubTotal;
                pui.cmpTotalPartida = TotalPartida;
                pui.cmpFolioDocOrigen = "";
                pui.cmpFechaMovimiento = user.FecServer;
                pui.cmpNoMovtoTra = "";
                pui.cmpDocTra = "";
                pui.cmpPartTra = "";

                if (pui.AgregarPartida() >= 1)
                {
                    MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void EditarPartida()
        {
            try
            {
                if (validacion())
                {
                    PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);

                    pui.keyNoMovimiento = PNoMovimiento;
                    pui.keyNoPartida = CodPart;
                    pui.cmpCveAlmacenMov = "";
                    pui.cmpCveTipoMov = PCveTipoMov;
                    pui.cmpEntSal = PEntSal;
                    pui.cmpNoDoc = "";
                    pui.cmpDocumento = "";
                    pui.cmpCveArticulo = txtCodigo.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpCveUMedida = txtUmedida.Text;
                    pui.cmpCantidad = Cantidad;
                    pui.cmpCantidadPkt = Cantidad;
                    pui.cmpPrecio = Precio;
                    pui.cmpDescuento = Descuento;
                    pui.cmpTotalDscto = PNeto;
                    pui.cmpCveImpuesto = CveImp;
                    pui.cmpImpuestoValor = Convert.ToDouble(txtIva.Text);
                    pui.cmpTotalIva = TotalIva;
                    pui.cmpSubTotal = SubTotal;
                    pui.cmpTotalPartida = TotalPartida;
                    pui.cmpFolioDocOrigen = "";
                    pui.cmpFechaMovimiento = user.FecServer;
                    pui.cmpNoMovtoTra = "";
                    pui.cmpDocTra = "";
                    pui.cmpPartTra = "";

                    if (pui.ActualizaPartida() >= 1)
                    {
                        MessageBoxAdv.Show("Registro actualizado", "Confirmacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.Close();
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

        

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void cboCveClsMov_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        

        private void BuscarPrecio(String CveArt)
        {
            PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
            pui.cmpCveArticulo = CveArt;
            pui.cmpinv_ClaveAlmacen = user.AlmacenUsa;
            pui.BuscaPrecio(PModLlama);
            CantInv = pui.cmpinv_Cantidad;


            if (PModLlama.Equals("Minv"))
            {
                //FALTA sugiere costo
                //String sugiere = winpadre.parametros.metcosto;
                if (PSugiereCosto == 1)
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

                if(PMuestraCosto == 1)
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


                if (PSolicitaCosto == 1)
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

                    if (String.IsNullOrEmpty(txtTotal.Text))
                    {
                        err = err + "Total: Existe un error calculo.\n";
                        ErrCalc = false;
                    }
                    else
                    {
                        if (!Util.Decimal(txtTotal.Text))
                        {
                            err = err + "Total: Contiene caracteres no validos. Sugiere: 0,000 0.0 0000\n";
                            ErrCalc = false;
                        }
                        else
                        {
                            double tt = Double.Parse(txtTotal.Text);
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
            
            String err = "";
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                if (Op == 1)
                {
                    err = err + "Cantidad: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                    Cantidad = 0;
            }
            else
            {
                if (txtCantidad.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtCantidad.Text))
                    {
                        err = err + "Cantidad: Contiene caracteres no validos. Sugiere: 0)\n";
                        ErrCalc = false;
                    }
                    else
                        Cantidad = Convert.ToDouble(txtCantidad.Text);
                }
                /*
                else
                {
                    if (Op == 1)
                    {
                        err = err + "Cantidad: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                        Cantidad = 0;
                }
                */

            }

            if (String.IsNullOrEmpty(txtPrecio.Text))
            {
                if (Op == 1)
                {
                    err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                    Precio = 0;
            }
            else
            {
                if (txtPrecio.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtPrecio.Text))
                    {
                        err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                        Precio = Convert.ToDouble(txtPrecio.Text);
                }
                /*
                else
                {
                    if (!Util.Decimal(txtPrecio.Text))
                    {
                        err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                        Precio = 0;
                }
                */
            }

            if (String.IsNullOrEmpty(txtDescuento.Text))
            {
                if (Op == 1)
                {
                    err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                else
                    Descuento = 0;
            }
            else
            {
                if (txtDescuento.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtDescuento.Text))
                    {
                        err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                        Descuento = (Convert.ToDouble(txtDescuento.Text) / 100);
                }
                /*
                else
                {
                    if (!Util.Decimal(txtDescuento.Text))
                    {
                        err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                        ErrCalc = false;
                    }
                    else
                        Descuento = 0;
                }
                */

            }
                
            if (ErrCalc)
            {

                if (PModLlama.Equals("Minv"))
                {
                    if (PEsTraspaso == 1 || PEntSal.Equals("S"))
                    {
                        if ((CantInv - Cantidad) < 0)
                        {
                            if (_AlmNumRojo == 1)
                            {
                                Cantidad = Convert.ToDouble(txtCantidad.Text);
                                ExisNegativa = 0;
                            }
                            else
                            {
                                if (MessageBoxAdv.Show("Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                        " Existencia: " + CantInv + " ",
                                        "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    ExisNegativa = 1;
                                }
                                else
                                    ExisNegativa = 0;

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
                TotalIva = 0; 
                TotalPartida = 0; txtTotal.Text = "0.0";


                //002 eNTRADA - 501 - SALIDA por ajuste de inventario
                if (!PCveTipoMov.Equals("002") || !PCveTipoMov.Equals("501"))
                {
                    PNeto = Precio - (Precio * Descuento);
                    txtPrecioNeto.Text = Convert.ToString(PNeto);
                    double iva = Convert.ToDouble(txtIva.Text);

                    SubTotal = PNeto * Cantidad;
                    TotalIva = SubTotal * (iva / 100);
                    TotalPartida = SubTotal + TotalIva;


                    //PENDIENTE: Valida una matrz y dentro de un else va lo siguiente
                    if (PCalcIva == 1)
                        TotalIva = SubTotal * 16 / 100;

                    TotalPartida = SubTotal + TotalIva;


                }
                else
                {
                    CveImp = "";
                }

                txtSubTotal.Text = Convert.ToString(SubTotal);
                txtImpuesto.Text = Convert.ToString(TotalIva);
                txtTotal.Text = Convert.ToString(TotalPartida);

            }
            else
            {
                MessageBoxAdv.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmdAceptar.Focus();

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
                    txtDescuento.Focus();

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
                    txtCantidad.Focus();

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
            frmLstArticulos art = new frmLstArticulos(db, StiloColor, user.CodPerfil, 3);
            art.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            art.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            art.ShowDialog();
            if (!string.IsNullOrEmpty(art.KeyCampo))
            {
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
                    CveImp = art.dv[10];
                    txtIva.Text = art.dv[12];
                    txtCodigo.Text = art.dv[0];
                    txtDescripcion.Text = art.dv[1];
                    txtUmedida.Text = art.dv[8];
                    BuscarPrecio(art.KeyCampo);
                    txtPrecio.Focus();
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PuiCatArticulos Art = new PuiCatArticulos(db);
                PuiCatImpuestos Impu = new PuiCatImpuestos(db);
                Art.keyCveArticulo = txtCodigo.Text;
                if (Art.EditarArticulo() > 0)
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
                        txtCodigo.Text = Art.keyCveArticulo;
                        txtDescripcion.Text = Art.cmpDescripcion;

                        CveImp = Art.Impuesto.keyCveImpuesto;
                        Impu.keyCveImpuesto = CveImp;
                        Impu.EditarImpuesto();
                        txtIva.Text = Convert.ToString(Impu.cmpValor);
                        txtUmedida.Text = Art.UMedida1.keyCveUMedida;
                        BuscarPrecio(Art.keyCveArticulo);
                    }

                }
                else
                {
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiaVar();
                }
            }
        }


        private void LimpiaVar()
        {
            txtDescripcion.Text = "";
            txtImpuesto.Text = "";
            CveImp = "";
        }
    }
}
