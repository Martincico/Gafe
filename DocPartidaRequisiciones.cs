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
            Descuento.Text = "00.00";
            Cantidad.Text = "0";
            user = DatUsr;
            Opcion = op;
            partida = part;
        }


        private void DocPartidaRequisiciones2222_Load(object sender, EventArgs e)
        {
            if (Opcion == 2)
            {
                AbrirPArtidas(partida);
            }
        }

        private DocPartidasReq AbrirPArtidas()
        {
            partida = new DocPartidasReq();
            //this.ShowDialog();
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
                    partida.Cantidad = Convert.ToDouble(Cantidad.Text);
                    partida.CveUmedida1 = "";
                    partida.CveImpuesto = "";
                    partida.ImpuestoValor = Convert.ToDouble(Iva.Text);
                    partida.Precio = Convert.ToDouble(txtPrecio.Text);
                    partida.Descuento = Convert.ToDouble(Descuento.Text);
                    partida.PrecioNeto = Convert.ToDouble(PrecioNeto.Text);
                    partida.Impuesto = Convert.ToDouble(Impuesto.Text);
                    partida.SubTotal = Convert.ToDouble(Subtotal.Text);
                    partida.Total = Convert.ToDouble(txtTotal.Text);
            }
           
            return partida;
        }

        private void AbrirPArtidas(DocPartidasReq part)
        {
            partida = part;
            txtClaveArticulo.Text = part.CveArticulo;
            txtDescripcion.Text = part.Descripcion;
            txtPrecio.Text = part.Precio.ToString();
            Descuento.Text = (part.Descuento > 0) ? part.Descuento.ToString():"0.00";
            PrecioNeto.Text = part.PrecioNeto.ToString();
            Cantidad.Text = part.Cantidad.ToString();
            Impuesto.Text = part.Impuesto.ToString();
            Subtotal.Text = part.SubTotal.ToString();
            txtTotal.Text = part.Total.ToString();
            Iva.Text = part.ImpuestoValor.ToString();
            //this.ShowDialog();
            
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

   

        private void Descuento_Leave(object sender, EventArgs e)
        {
            Calculos();
        }

        private void Cantidad_Leave(object sender, EventArgs e)
        {
            Calculos();
        }

        private void Precio_Leave(object sender, EventArgs e)
        {
            Calculos();
        }


        private void Calculos()
        {
            double pre = Convert.ToDouble(txtPrecio.Text);
            double des = (Convert.ToDouble(Descuento.Text) / 100);
            double prenet = 0;
            prenet = pre - (pre * des);
            PrecioNeto.Text = Convert.ToString(prenet);

            double preN = Convert.ToDouble(PrecioNeto.Text);
            double cant = Convert.ToDouble(Cantidad.Text);
            double iva = Convert.ToDouble(Iva.Text);
            double SubTot = preN * cant;
            double Imp = SubTot * (iva / 100);
            double Tot = SubTot + Imp;
            Impuesto.Text = Imp.ToString();
            Subtotal.Text = SubTot.ToString();
            txtTotal.Text = Tot.ToString();
        }

        private Boolean validacion()
        {
            String err = "";
            Boolean ErrCalc = true;
                if (String.IsNullOrEmpty(txtClaveArticulo.Text))
                {
                    err = "Código: No puede ir vacío. \n";
                    ErrCalc = false;
                }
                else
                {
                    if (!Util.LetrasNum(txtClaveArticulo.Text))
                    {
                        err = "Código: Contiene caracteres no validos. \n";
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
            

            return ErrCalc;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos ar = new frmLstArticulos(db, user.CodPerfil, 3);
            ar.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            ar.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            ar.ShowDialog();
            txtClaveArticulo.Text = ar.dv[0];
            txtDescripcion.Text = ar.dv[1];
            //falta que al seleccionar el articulo me retorne el valor del impuesto y la  unidad de medida
            Iva.Text = "16";

            //Buscar en la lista de precio de costo si es un documento de proveedores, si es un documento de venta, buscar en la lista de precio
            //del almacen correspondiente
        }

    }
}
