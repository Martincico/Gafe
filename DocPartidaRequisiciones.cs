/*
 * VALIDACIONES
DOCUMENTO COMPRA No vender mas de lo que se tiene en existencia

Buscar en la lista de precio de costo si es un documento de proveedores, 
si es un documento de venta, buscar en la lista de precio del almacen correspondiente

*/
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
        public DocPartidasReq partida;
        private MsSql db = null;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        ClsUtilerias Util = new ClsUtilerias();
        private String IdArt = "";
        private String CveImp = "";
        private String CveUmed = "";
        Boolean ErrCalc = true;

        private int Opcion;
        
        public DocPartidaRequisiciones()
        {
            InitializeComponent();
        }

        public DocPartidaRequisiciones(MsSql oDat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op, DocPartidasReq part = null)
        {
            InitializeComponent();
            StiloColor = NewColor;
            db = oDat;
            txtDescuento.Text = "0";
            txtCantidad.Text = "0";
            user = DatUsr;
            Opcion = op;
            partida = part;
        }


        private void DocPartidaRequisiciones_Load(object sender, EventArgs e)
        {
            if (Opcion == 2)
            {
                AbrirPArtidas(partida);
            }
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

                    partida.CveArticulo = txtClaveArticulo.Text;
                    partida.Descripcion = txtDescripcion.Text;
                    partida.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    partida.CveUmedida1 = CveUmed;
                    partida.CveImpuesto = CveImp;
                    partida.ImpuestoValor = Convert.ToDouble(txtIva.Text);
                    partida.Precio = Convert.ToDouble(txtPrecio.Text);
                    partida.Descuento = Convert.ToDouble(txtDescuento.Text);
                    partida.PrecioNeto = Convert.ToDouble(txtPrecioNeto.Text);
                    partida.Impuesto = Convert.ToDouble(txtImpuesto.Text);
                    partida.SubTotal = Convert.ToDouble(txtSubtotal.Text);
                    partida.Total = Convert.ToDouble(txtTotal.Text);
            }
           
            return partida;
        }

        private void AbrirPArtidas(DocPartidasReq part)
        {
            txtClaveArticulo.Text = part.CveArticulo;
            IdArt = part.CveArticulo;
            CveImp = part.CveImpuesto;
            CveUmed = part.CveUmedida1;
            txtDescripcion.Text = part.Descripcion;
            txtPrecio.Text = part.Precio.ToString();
            txtDescuento.Text = (part.Descuento > 0) ? part.Descuento.ToString():"0.00";
            txtPrecioNeto.Text = part.PrecioNeto.ToString();
            txtCantidad.Text = part.Cantidad.ToString();
            txtImpuesto.Text = part.Impuesto.ToString();
            txtSubtotal.Text = part.SubTotal.ToString();
            txtTotal.Text = part.Total.ToString();
            txtIva.Text = part.ImpuestoValor.ToString();
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
            String err = "";
            double Precio = 0;
            double Descuento = 0;
            double PNeto = 0;
            double Cantidad = 0;
            double SubTotal = 0;
            double TotalIva = 0;
            double TotalPartida = 0;

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
                PNeto = Precio - (Precio* Descuento);
                txtPrecioNeto.Text = Convert.ToString(PNeto);
                double iva = Convert.ToDouble(txtIva.Text);

                SubTotal = PNeto * Cantidad;
                TotalIva = SubTotal * (iva / 100);
                TotalPartida = SubTotal + TotalIva;


                txtImpuesto.Text = TotalIva.ToString();
                txtSubtotal.Text = SubTotal.ToString();
                txtTotal.Text = TotalPartida.ToString();
                
            }
            else
            {
                MessageBoxAdv.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
         }

        private Boolean validacion()
        {
            String err = "";
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

                if (!ErrCalc)
                {
                    MessageBoxAdv.Show("Contiene error(es):\n" + err, "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ErrCalc;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos ar = new frmLstArticulos(db, user.CodPerfil, 3);
            ar.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            ar.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            ar.ShowDialog();
            IdArt = ar.dv[0];
            txtClaveArticulo.Text = ar.dv[0];
            txtDescripcion.Text = ar.dv[1];
            CveImp = ar.dv[10];
            txtIva.Text = ar.dv[12];
            CveUmed = ar.dv[8];

        }

        private void txtClaveArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PuiCatArticulos Art = new PuiCatArticulos(db);
                PuiCatImpuestos Impu = new PuiCatImpuestos(db);
                Art.keyCveArticulo = txtClaveArticulo.Text;
                if (Art.EditarArticulo() > 0)
                {
                    IdArt = Art.keyCveArticulo;
                    txtClaveArticulo.Text = Art.keyCveArticulo;
                    txtDescripcion.Text = Art.cmpDescripcion;
                    
                    CveImp = Art.Impuesto.keyCveImpuesto;
                    Impu.keyCveImpuesto = CveImp;
                    Impu.EditarImpuesto();
                    txtIva.Text = Convert.ToString(Impu.cmpValor);
                    CveUmed = Art.UMedida1.keyCveUMedida;
                }
                else
                {
                    LimpiaVar();
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiaVar()
        {
            IdArt = "";
            txtDescripcion.Text = "";
            txtIva.Text = "";
            CveImp = "";
            CveUmed = "";
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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }
    }
}
