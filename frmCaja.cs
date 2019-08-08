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
using System.Collections;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmCaja : MetroForm
    {

        private MsSql db = null;
        public DatCfgUsuario user;
        Form Flg;
        private clsUtil uT;
        clsStiloTemas NewColor = new clsStiloTemas();

        public DocPartidasReq partida;

        private String IdArt = "";
        private String CveImp = "";
        private String CveUmed = "";


        private String LstPre_Clie = "";
        private String LstPre_Alm = "";

        private int Opcion;

        List<DocPartidasReq> PARTIDAS;
        clsCfgDocumento ConfigDoc;

        public frmCaja()
        {
            InitializeComponent();
            
        }


        public frmCaja(MsSql Odat, Form lg, DatCfgUsuario DatUsr)
        {
            InitializeComponent();
            
            db = Odat;
            user = DatUsr;
            Flg = lg;
            //SelectTemaUser(user.StiloTema);


            PuiSegUsuarioCfg team = new PuiSegUsuarioCfg(db);
            team.cmpStiloTema = user.StiloTema;
            Object[] reg = team.GetParamTema();
            NewColor.Encabezado = reg[0].ToString();
            NewColor.HoverEncabezado = reg[1].ToString();
            NewColor.FontColor = reg[2].ToString();

            //this.ribMenu.Office2016ColorTable.Add(NewColor.StiloTeam());

            
            LlecboCliente();

            GetDatoAlmacen();

            PARTIDAS = new List<DocPartidasReq>();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmCatInventarioMovtos_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);

            clsCfgDocumento cd = new clsCfgDocumento("M3001", db);
            ConfigDoc = cd.ConfigDoc();

            string movimiento = rq.AgregarDocEnBlanco(int.Parse(ConfigDoc.Foliador), user.FecServer);
        }

        private void frmCaja_KeyDown(object sender, KeyEventArgs e)
        {
        
        }

        private void AbrirPArtidas(DocPartidasReq part)
        {
            txtClaveArticulo.Text = part.CveArticulo;
            IdArt = part.CveArticulo;
            CveImp = part.CveImpuesto;
            CveUmed = part.CveUmedida1;
            txtDescripcion.Text = part.Descripcion;
            txtPrecio.Text = part.Precio.ToString();
            //txtDescuento.Text = (part.Descuento > 0) ? part.Descuento.ToString() : "0.00";
            //txtPrecioNeto.Text = part.PrecioNeto.ToString();
            txtCantidad.Text = part.Cantidad.ToString();
            //txtImpuesto.Text = part.Impuesto.ToString();
            //txtSubtotal.Text = part.SubTotal.ToString();
            //txtTotal.Text = part.Total.ToString();
            //txtIva.Text = part.ImpuestoValor.ToString();
        }
        private void AbrirPArtidas()
        {
            double subTotal = 0, total = 0;
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
                partida.ImpuestoValor = 0;//Convert.ToDouble(txtIva.Text);
                partida.Precio = Convert.ToDouble(txtPrecio.Text);
                subTotal = Convert.ToDouble(txtPrecio.Text) * Convert.ToDouble(txtCantidad.Text);
                partida.Descuento = 0;
                partida.PrecioNeto = Convert.ToDouble(txtPrecio.Text);
                partida.Impuesto = 0;;
                partida.SubTotal = subTotal;
                partida.Total = subTotal;

        }

        private void LLenaGrid()
        {
            grdViewD.DataSource = null;
            grdViewD.DataSource = PARTIDAS;

            grdViewD.Columns["idMov"].Visible = false;
            grdViewD.Columns["Documento"].Visible = false;
            grdViewD.Columns["Serie"].Visible = false;
            grdViewD.Columns["Numdoc"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["ClaveAlmacen"].Visible = false;
            grdViewD.Columns["Partida"].HeaderText = "Part";
            grdViewD.Columns["Partida"].Width = 40;
            grdViewD.Columns["Autorizado"].Visible = false;
            grdViewD.Columns["Descripcion"].Width = 150;
            grdViewD.Columns["CveUmedida1"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["Descuento"].Visible = false;

            grdViewD.Columns["Impuesto"].Visible = false;
            grdViewD.Columns["ImpuestoValor"].Visible = false;
            grdViewD.Columns["Precio"].Visible = false;
            grdViewD.Columns["SubTotal"].Visible = false;
            grdViewD.Columns["Cantidad"].Width = 40;
            grdViewD.Columns["Cantidad"].HeaderText = "Cant.";

            grdViewD.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
            

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            partida = new DocPartidasReq();
            if (e.KeyChar == (char)Keys.Enter)
            { 
                AbrirPArtidas();

                if (partida != null)
                {
                    if (partida.CveArticulo != null)
                    {
                        double subTotal = 0, total = 0;
                        PARTIDAS.Add(partida);
                        for (int i = 0; i < PARTIDAS.Count; i++)
                        {
                            PARTIDAS[i].idMov = "idmovimiento";
                            PARTIDAS[i].Serie = "";
                            PARTIDAS[i].Partida = i + 1;
                            PARTIDAS[i].ClaveAlmacen = user.AlmacenUsa;
                            PARTIDAS[i].Autorizado = false;
                            subTotal = subTotal + PARTIDAS[i].SubTotal;
                            total = total + PARTIDAS[i].Total;
                        }
                        txtSubTotal.Text = subTotal.ToString();
                        txtTotal.Text = total.ToString();

                        LLenaGrid();
                        LimpiaVar();
                    }
                }

            }
            
        }
        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos ar = new frmLstArticulos(db, user.CodPerfil, 3);
            ar.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Encabezado);
            ar.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            ar.ShowDialog();
            IdArt = ar.dv[0];
            txtClaveArticulo.Text = ar.dv[0];
            txtDescripcion.Text = ar.dv[1];
            CveImp = ar.dv[10];
            //txtIva.Text = ar.dv[12];
            CveUmed = ar.dv[8];

            PuiCatArticulos Art = new PuiCatArticulos(db);
            Art.keyCveArticulo = ar.dv[0];
            Art.EditarArticulo();

            if (Art.cmpFoto.Length > 0)
            {
                MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                pbArticulo.Image = Image.FromStream(Mf);
            }
            getPrecio();
            txtCantidad.Focus();
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
                    //txtIva.Text = Convert.ToString(Impu.cmpValor);
                    CveUmed = Art.UMedida1.keyCveUMedida;
                    if (Art.cmpFoto.Length > 0)
                    {
                        MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                        Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                        pbArticulo.Image = Image.FromStream(Mf);
                    }
                    getPrecio();
                    txtCantidad.Focus();
                }
                else
                {
                    LimpiaVar();
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getPrecio()
        {
            PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
            SqlDataAdapter Datos = null;
            DataSet Ds = new DataSet();
            object[] ObjA = null;

            pui.keyCveLstPrecio = LstPre_Clie;
            pui.cmpNombre = IdArt;

            Datos = pui.GetPrecioArticulo();

            Datos.Fill(Ds);

            if(Ds.Tables[0].Rows.Count>0)
            {
                ObjA = Ds.Tables[0].Rows[0].ItemArray;
            }
            else
            {
                pui.keyCveLstPrecio = LstPre_Alm;
                pui.cmpNombre = IdArt;

                Datos = pui.GetPrecioArticulo();
                Datos.Fill(Ds);

                ObjA = Ds.Tables[0].Rows[0].ItemArray;
            }


            txtPrecio.Text = ObjA[4].ToString();

        }

        private void LlecboCliente()
        {
            PuiCatClientes lin = new PuiCatClientes(db);
            cboCliente.DataSource = lin.LLenaCboClientes();
            cboCliente.ValueMember = "Clave";
            cboCliente.DisplayMember = "Descripcion";

            GetDatoCliente();
        }

        private void GetDatoCliente()
        {
            string val = Convert.ToString(cboCliente.SelectedValue);
            if (cboCliente.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    PuiCatClientes cli = new PuiCatClientes(db);
                    cli.keyCveClientes = val;

                    cli.EditarClientes();

                    LstPre_Clie = cli.cmpCveLstPrecio;
                }
            }
        }

        private void GetDatoAlmacen()
        {
            PuiCatAlmacenes alm = new PuiCatAlmacenes(db);
            alm.keyClaveAlmacen = user.AlmacenUsa;

            alm.EditarAlmacen();

            LstPre_Alm = alm.cmpCveLstPrecio;
        }

        private void LimpiaVar()
        {
            IdArt = "";
            txtDescripcion.Text = "";
            txtClaveArticulo.Text = "";
            CveImp = "";
            CveUmed = "";
            txtCantidad.Text = "1";
            txtClaveArticulo.Focus();
        }


        private void frmCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
        }

        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboCliente.SelectedValue);
            if (cboCliente.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    GetDatoCliente();
                }
            }
        }
    }
}
