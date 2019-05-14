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

namespace GAFE
{
    public partial class AddPartidaInvMovtos : Form
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
        private double TotalDesc;
        private double TotalIva;
        private double SubTotal;
        private double TotalPartida;
        private DateTime _FechaMov;



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

        ClsUtilerias Util = new ClsUtilerias();

        public AddPartidaInvMovtos()
        {
            InitializeComponent();
        }

        public AddPartidaInvMovtos(MsSql Odat, String P_modulo, String P_folio, int P_operacion,
                String P_CveTipoMov, int P_SugiereCosto, int P_EditaCosto, int P_MuestraCosto, 
                 int P_SolicitaCosto, int P_EsTraspaso, String P_EntSal, int P_CalcIva, DateTime P_FechaMovimiento,
                 int P_AlmNumRojo, int P_AlmNumRojoDest, int P_CodPart)
        {
            InitializeComponent();
            opcion = P_operacion;
            db = Odat;
            CodPart = P_CodPart;

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
            _FechaMov = P_FechaMovimiento;
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
            txtTotDesc.Text = Convert.ToString(pui.cmpTotalDscto);
            txtSubTotal.Text = Convert.ToString(pui.cmpSubTotal);
            txtIva.Text = Convert.ToString(pui.cmpTotalIva);
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
            ValidaCalculos();
            switch (opcion)
            {
                case 1: AltaPartida(); break;
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

                //pui.EditarPartida();

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
                pui.cmpTotalDscto = TotalDesc;
                pui.cmpCveImpuesto = "";
                pui.cmpTotalIva = TotalIva;
                pui.cmpSubTotal = SubTotal;
                pui.cmpTotalPartida = TotalPartida;
                pui.cmpFolioDocOrigen = "";
                pui.cmpFechaMovimiento = _FechaMov;
                pui.cmpNoMovtoTra = "";
                pui.cmpDocTra = "";
                pui.cmpPartTra = "";

                if (pui.AgregarPartida() >= 1)
                {
                    MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
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
                    pui.cmpTotalDscto = TotalDesc;
                    pui.cmpCveImpuesto = "";
                    pui.cmpTotalIva = TotalIva;
                    pui.cmpSubTotal = SubTotal;
                    pui.cmpTotalPartida = TotalPartida;
                    pui.cmpFolioDocOrigen = "";
                    pui.cmpFechaMovimiento = _FechaMov;
                    pui.cmpNoMovtoTra = "";
                    pui.cmpDocTra = "";
                    pui.cmpPartTra = "";

                    if (pui.ActualizaPartida() >= 1)
                    {
                        MessageBox.Show("Registro actualizado", "Confirmacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
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

        private void btnBuscarArt_Click(object sender, EventArgs e)
        {
            frmLstArticulos art = new frmLstArticulos(db, "perfil", 3);
            art.ShowDialog();
            if (!string.IsNullOrEmpty(art.KeyCampo))
            {
                PuiCatArticulos arti = new PuiCatArticulos(db);
                arti.keyCveArticulo = art.KeyCampo;
                arti.EditarArticulo();
                txtCodigo.Text = arti.keyCveArticulo;
                txtDescripcion.Text = arti.cmpDescripcion;
                txtUmedida.Text = arti.UMedida1.keyCveUMedida;
                BuscarPrecio(art.KeyCampo);
            }
        }

        private void BuscarPrecio(String CveArt)
        {
            PuiAddPartidasMovInv pui = new PuiAddPartidasMovInv(db);
            pui.cmpCveArticulo = CveArt;
            pui.cmpinv_ClaveAlmacen = "100";
            pui.BuscaPrecio(PModLlama);
            CantInv = pui.cmpinv_Cantidad;


            if (PModLlama.Equals("M01"))
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
            Boolean sig = true;
            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                err = "Código: No puede ir vacío. \n";
                sig = false;
            }
            else
            {
                if (!Util.LetrasNum(txtCodigo.Text))
                {
                    err = "Código: Contiene caracteres no validos. \n";
                    sig = false;
                }
            }
            
            if (ExisNegativa == 1)
            {
                err = err + "La cantidad solicitada es mayor a la exitencia del articulo \n";
                sig = false;
            }
            

            if (PSolicitaCosto == 1)
            {
                if (String.IsNullOrEmpty(txtPrecio.Text))
                {
                    err = err + "Precio: No puede ir vacío\n";
                    sig = false;
                }
                else
                {
                    if (!Util.Decimal(txtPrecio.Text))
                    {
                        err = err + "Precio: Contiene caracteres no validos. Sugiere: 0,000 0.0 0000\n";
                        sig = false;
                    }

                }

                if (String.IsNullOrEmpty(txtTotal.Text))
                {
                    err = err + "Total: Existe un error calculo.\n";
                    sig = false;
                }
                else
                {
                    if (!Util.Decimal(txtTotal.Text))
                    {
                        err = err + "Total: Contiene caracteres no validos. Sugiere: 0,000 0.0 0000\n";
                        sig = false;
                    }
                    else
                    {
                        double tt = Double.Parse(txtTotal.Text);
                        if (tt <= 0)
                        {
                            err = err + "Total: Existe un error calculo.\n";
                            sig = false;
                        }
                    }
                }


            }

            if (!sig)
            {
                MessageBox.Show("Contiene error(es):\n"+err,"Error de captura", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return sig;
        }

        private void ValidaCalculos()
        {
            if (ErrCalc)
            {
                String err = "";
                if (!Util.Decimal(txtPrecio.Text))
                {
                    err = err + "Precio: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }

                if (!Util.Decimal(txtDescuento.Text))
                {
                    err = err + "Descuento: Contiene caracteres no validos. Sugiere: 0.0 0000\n";
                    ErrCalc = false;
                }
                if (!Util.Numeros(txtCantidad.Text))
                {
                    if (txtCantidad.Text.Length >= 1)
                    {
                        err = err + "Precio: Contiene caracteres no validos. Sugiere: 0)\n";
                        ErrCalc = false;
                    }
                }

                if (ErrCalc)
                {
                    Cantidad =  Convert.ToDouble(txtCantidad.Text);
                    Precio =  Convert.ToDouble(txtPrecio.Text);
                    Descuento = Convert.ToDouble(txtDescuento.Text);

                    SubTotal = 0; txtSubTotal.Text = "0.0";
                    TotalDesc = 0; txtTotDesc.Text = "0.0";
                    TotalIva = 0; txtIva.Text = "0.0";
                    TotalPartida = 0; txtTotal.Text = "0.0";


                    //002 eNTRADA - 501 - SALIDA por ajuste de inventario
                    if (!PCveTipoMov.Equals("002") || !PCveTipoMov.Equals("501"))
                    {
                        SubTotal = Cantidad * Precio;
                        TotalDesc = SubTotal * (Descuento / 100);
                        txtTotDesc.Text = Convert.ToString(TotalDesc);
                        SubTotal = SubTotal - TotalDesc;

                        //PENDIENTE: Valida una matrz y dentro de un else va lo siguiente
                        if (PCalcIva == 1)
                            TotalIva = SubTotal * 16 / 100;

                        TotalPartida = SubTotal + TotalIva;


                    }


                    txtSubTotal.Text = Convert.ToString(SubTotal);
                    txtIva.Text = Convert.ToString(TotalIva);
                    txtTotal.Text = Convert.ToString(TotalPartida);

                }
                else
                {
                    MessageBox.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
                ErrCalc = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
                ErrCalc = true;
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                ErrCalc = false;
            }
            else
                ErrCalc = true;
        }

        private void txtCantidad_MouseLeave(object sender, EventArgs e)
        {
            CalcExist(0);
        }

        private void txtPrecio_MouseLeave(object sender, EventArgs e)
        {
            ValidaCalculos();
        }

        private void txtDescuento_MouseLeave(object sender, EventArgs e)
        {
            ValidaCalculos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcExist(0);
        }

        private int CalcExist(int Op)
        {
            int r = 1;
            double CantCapt = 0;
            String msj = "";
            /*
            try
            {
            */
                if (String.IsNullOrEmpty(txtCantidad.Text))
                {
                    if (Op == 1)
                    {
                        msj += "Cantidad: No debe estar vacío. \n";
                        r = 0;
                    }
                }
                else
                    CantCapt = Convert.ToDouble(txtCantidad.Text);


                if (PModLlama.Equals("M01"))
                {
                    if (PEsTraspaso == 1 || PEntSal.Equals("S"))
                    {
                        if ((CantInv - CantCapt) < 0)
                        {
                            if (_AlmNumRojo == 1)
                            {
                                Cantidad = Convert.ToDouble(txtCantidad.Text);
                                ExisNegativa = 0;
                            }
                            else
                            {
                                if (MessageBox.Show("Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                        " Existencia: " + CantInv + " ",
                                        "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    ExisNegativa = 1;
                                }

                            }
                        }
                        else
                            ExisNegativa = 0;
                    }
                    else
                    {
                        ExisNegativa = 0;
                        ValidaCalculos();
                    }
                }
                else
                    ExisNegativa = 0;

            /*
                        }
                        catch()
                        {

                        }
                        */
                        /*
            if (r==0)
            {
                MessageBox.Show("Contiene error(es):\n" + msj, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            return r;

        }

    }
}
