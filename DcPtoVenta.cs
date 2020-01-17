using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatSql;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class DcPtoVenta : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private MsSql db = null;
        public DatCfgUsuario user;
        Form Flg;
        private clsUtil uT;
        private DatCfgParamSystem ParamSystem;
        ClsUtilerias Util;

        public DocPartidasReq partida;
        private DocPartidasReq pr;

        private String IdArt = "";
        private String CveImp = "";
        private String CveIEPS = "";
        private String CveUmed = "";

        private double CantInv = 0;

        private String LstPre_Clie = "";
        private String LstPre_Alm = "";

        private int OptPartd = 1;

        private string idmovimiento = "";

        List<DocPartidasReq> PARTIDAS;
        clsCfgDocumento ConfigDoc;

        private String CveDoc;
        private Boolean isDataSaved = false;//Valida el cerrar el doc

        //Boolean ErrCalc = true;

       
        private ToolTip ttCantidad = new ToolTip();

        clsCfgAlmacen CfgAlma;

        clsCfgDocSeries CfgDocSerie;
        private String serieticket = "";
        clsStiloTemas NewColor = new clsStiloTemas();

        /*Resize*/
        private Rectangle lblTitleClienteOld;
        private Rectangle cboClienteOld;
        private Rectangle txtClaveArticuloOld;
        private Rectangle btnEditarOld;
        private Rectangle btnEliminarOld;
        private Rectangle grdViewArticuloOld;
        private Rectangle grdViewVentaOld;
        private Rectangle lblTitCantidadOld;
        private Rectangle txtCantidadOld;
        private Rectangle lblTitSubTotalOld;
        private Rectangle lblSubTotalOld;
        private Rectangle lblTitDescuentoOld;
        private Rectangle txtDescuentoOld;
        private Rectangle lblTitTotalOld;
        private Rectangle lblTotalOld;
        private Rectangle btnVerVentasOld;
        private Rectangle lblTotalArticulosOld;
        private Rectangle lblTitEfectivoOld;
        private Rectangle txtEfectivoOld;
        private Rectangle lblTitCambioOld;
        private Rectangle txtCambioOld;
        private Rectangle lblTitBusquedaOld;
        private Rectangle panelLineOld;
        private Size formOriginalSize;

        public DcPtoVenta()
        {
            InitializeComponent();

        }


        public DcPtoVenta(MsSql Odat, Form lg,  String PUsr, int Opc,
            String _CveDoc, string _namedoc, string _cveventa = "")
        {
            InitializeComponent();

            db = Odat;

            
            
            DatCfgParamSystem PSyst = new DatCfgParamSystem(db);
            ParamSystem = PSyst.ParaSystem();
            Util = new ClsUtilerias(ParamSystem.NumDec);
            DatCfgUsuario CUser = new DatCfgUsuario(PUsr, db);
            user = CUser.CfgUsario();

            Flg = lg;
            OptPartd = Opc;
            CveDoc = _CveDoc;
            idmovimiento = _cveventa;


            PuiSegUsuarioCfg team = new PuiSegUsuarioCfg(db);
            team.cmpStiloTema = user.StiloTema;
            Object[] reg = team.GetParamTema();
            NewColor.Encabezado = reg[0].ToString();
            NewColor.HoverEncabezado = reg[1].ToString();
            NewColor.FontColor = reg[2].ToString();
            NewColor.Pant1 = reg[3].ToString();
            NewColor.Pant2 = reg[4].ToString();
            NewColor.Pant3 = reg[5].ToString();
            NewColor.Pant4 = reg[6].ToString();
            NewColor.Pant5 = reg[7].ToString();

            this.MetroColor = ColorTranslator.FromHtml(NewColor.Pant5);
            this.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Pant5);
            this.CaptionButtonColor = ColorTranslator.FromHtml(NewColor.FontColor);
            this.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);

            this.BackColor = ColorTranslator.FromHtml(NewColor.Pant2);
            lblTitBusqueda.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitCambio.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitCantidad.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitDescuento.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitEfectivo.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitleCliente.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitSubTotal.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTitTotal.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            lblTotalArticulos.ForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            txtCantidad.ForeColor = ColorTranslator.FromHtml(NewColor.Pant1);
            txtDescuento.ForeColor = ColorTranslator.FromHtml(NewColor.Pant1);
            txtEfectivo.ForeColor = ColorTranslator.FromHtml(NewColor.Pant1);
            txtClaveArticulo.ForeColor = ColorTranslator.FromHtml(NewColor.Pant1);
            panelLine.BackColor = ColorTranslator.FromHtml(NewColor.Pant1);
        }

        private void DcPtoVenta_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;

            /* Resize*/

            lblTitleClienteOld = new Rectangle(lblTitleCliente.Location.X, lblTitleCliente.Location.Y, lblTitleCliente.Width, lblTitleCliente.Height);
            cboClienteOld = new Rectangle(cboCliente.Location.X, cboCliente.Location.Y, cboCliente.Width, cboCliente.Height);
            txtClaveArticuloOld = new Rectangle(txtClaveArticulo.Location.X, txtClaveArticulo.Location.Y, txtClaveArticulo.Width, txtClaveArticulo.Height);
            btnEditarOld = new Rectangle(btnEditar.Location.X, btnEditar.Location.Y, btnEditar.Width, btnEditar.Height);
            btnEliminarOld = new Rectangle(btnEliminar.Location.X, btnEliminar.Location.Y, btnEliminar.Width, btnEliminar.Height);
            grdViewArticuloOld = new Rectangle(grdViewArticulo.Location.X, grdViewArticulo.Location.Y, grdViewArticulo.Width, grdViewArticulo.Height);
            grdViewVentaOld= new Rectangle(grdViewVenta.Location.X, grdViewVenta.Location.Y, grdViewVenta.Width, grdViewVenta.Height);
            lblTitCantidadOld = new Rectangle(lblTitCantidad.Location.X, lblTitCantidad.Location.Y, lblTitCantidad.Width, lblTitCantidad.Height);
            txtCantidadOld = new Rectangle(txtCantidad.Location.X, txtCantidad.Location.Y, txtCantidad.Width, txtCantidad.Height);
            lblTitSubTotalOld = new Rectangle(lblTitSubTotal.Location.X, lblTitSubTotal.Location.Y, lblTitSubTotal.Width, lblTitSubTotal.Height);
            lblSubTotalOld = new Rectangle(txtSubTotal.Location.X, txtSubTotal.Location.Y, txtSubTotal.Width, txtSubTotal.Height);
            lblTitDescuentoOld = new Rectangle(lblTitDescuento.Location.X, lblTitDescuento.Location.Y, lblTitDescuento.Width, lblTitDescuento.Height);
            txtDescuentoOld = new Rectangle(txtDescuento.Location.X, txtDescuento.Location.Y, txtDescuento.Width, txtDescuento.Height);
            lblTitTotalOld = new Rectangle(lblTitTotal.Location.X, lblTitTotal.Location.Y, lblTitTotal.Width, lblTitTotal.Height);
            lblTotalOld = new Rectangle(txtTotal.Location.X, txtTotal.Location.Y, txtTotal.Width, txtTotal.Height);
            btnVerVentasOld = new Rectangle(btnVerVentas.Location.X, btnVerVentas.Location.Y, btnVerVentas.Width, btnVerVentas.Height);
            lblTotalArticulosOld = new Rectangle(lblTotalArticulos.Location.X, lblTotalArticulos.Location.Y, lblTotalArticulos.Width, lblTotalArticulos.Height);
            lblTitEfectivoOld = new Rectangle(lblTitEfectivo.Location.X, lblTitEfectivo.Location.Y, lblTitEfectivo.Width, lblTitEfectivo.Height);
            txtEfectivoOld = new Rectangle(txtEfectivo.Location.X, txtEfectivo.Location.Y, txtEfectivo.Width, txtEfectivo.Height);
            lblTitCambioOld = new Rectangle(lblTitCambio.Location.X, lblTitCambio.Location.Y, lblTitCambio.Width, lblTitCambio.Height);
            txtCambioOld = new Rectangle(txtCambio.Location.X, txtCambio.Location.Y, txtCambio.Width, txtCambio.Height);
            lblTitBusquedaOld = new Rectangle(lblTitBusqueda.Location.X, lblTitBusqueda.Location.Y, lblTitBusqueda.Width, lblTitBusqueda.Height);
            panelLineOld = new Rectangle(panelLine.Location.X, panelLine.Location.Y, panelLine.Width, panelLine.Height);


            
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();


            
            LlecboCliente();

            GetDatoAlmacen();

            PARTIDAS = new List<DocPartidasReq>();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            clsCfgDocumento cd = new clsCfgDocumento(CveDoc, db);
            ConfigDoc = cd.ConfigDoc();

            clsCfgAlmacen cslA = new clsCfgAlmacen(db, user.AlmacenUsa);
            CfgAlma = cslA.ConfigAlmacen();


            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            InhControles(true, 0);

            if (ConfigDoc.UsaSerie == 1)
            {

                PuiCatCfgDocSerie lin = new PuiCatCfgDocSerie(db);
                //cboSerie.DataSource = lin.CbollenaSeries(CveAlm, CveDoc);
                DataTable dt = lin.CbollenaSeries(user.AlmacenUsa, CveDoc);
                serieticket = dt.Rows[0]["Clave"].ToString();


                clsCfgDocSeries cds = new clsCfgDocSeries(user.AlmacenUsa, CveDoc, serieticket, db);
                CfgDocSerie = cds.ConfigDocSerie();
            }

            
            this.WindowState = FormWindowState.Maximized;
            
            

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            
            DialogResult rspw;

            switch (e.KeyCode)
            {
                
                case Keys.F2://Muestra Articulos
                    if (OptPartd == 1)
                        ShowLstArt();
                    else
                        MessageBoxAdv.Show("Busqueda de artículo deshabilitado para esta opción", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Keys.F3://Edita articulo
                    if (OptPartd == 1)
                        btnEditar_Click(sender, e);
                    else
                        MessageBoxAdv.Show("Editar de artículo deshabilitado para esta opción", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Keys.F4://Elimina partida
                    if (OptPartd == 1)
                    {
                        rspw = MessageBox.Show("¿Quieres eliminar el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rspw == DialogResult.Yes)
                        {
                            btnEliminar_Click(sender, e);
                        }
                    }
                    else
                        MessageBoxAdv.Show("Eliminar de artículo deshabilitado para esta opción", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
                case Keys.F5: //Muestra todas las ventas del día
                    VerVentas_Click();
                    break;
                case Keys.F6: //Limpiar todo
                    rspw = MessageBox.Show("¿Quieres cancelar el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rspw == DialogResult.Yes)
                    {
                        ResetControles(0);
                        InhControles(true, 0);
                    }
                    break;
                case Keys.Escape:
                    switch (OptPartd)
                    {
                        case 1:
                                if(txtClaveArticulo.Text.Equals(""))
                                    FrmClose();
                                else
                                {
                                    ResetControles(1); InhControles(true, 1);
                                }
                            break;
                        case 2: CancelEditPart(); break;
                        case 3: ResetControles(0); InhControles(true, 0); break;
                    }

                    break;
                default:
                    //MessageBox.Show(e.KeyCode.ToString() + " pressed.", "Key Down Event");
                    break;
            }
        }


        private void FrmClose()
        {
            if (!isDataSaved)
            {
                if (OptPartd != 3)
                {
                    switch (MessageBoxAdv.Show(this, "¿En realidad desea salir del modulo?", "Salir del modulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            isDataSaved = false;
                            break;
                        default:
                            if (grdViewVenta.RowCount > 0)
                            {
                                Aceptar_click(1);
                                if(isDataSaved)
                                    Flg.Close();
                            }
                            else
                            {
                                if (!idmovimiento.Equals(""))
                                {
                                    DocPuiRequisiciones InvMast = new DocPuiRequisiciones(db);
                                    InvMast.keyidMov = idmovimiento;
                                    InvMast.EliminaDocumento();
                                }

                                Flg.Close();
                            }
                            
                        break;
                    }
                }
            }
            else
            {
                Flg.Close();
            }



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

        private void ShowLstArt()
        {

            frmLstArticulos ar = new frmLstArticulos(db, ParamSystem, user, NewColor, 3);
            ar.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Encabezado);
            ar.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            ar.ShowDialog();
            IdArt = ar.dv[0];
            if (IdArt != null)
            {
                txtClaveArticulo.Text = ar.dv[0];
                CveImp = ar.dv[10];
                CveUmed = ar.dv[8];

                PuiCatArticulos Art = new PuiCatArticulos(db);
                Art.keyCveArticulo = ar.dv[0];
                Art.EditarArticulo(ParamSystem.HideCveArt);
                
                ExistArt();

                int RPpre = getPrecio();
                    if (RPpre == 1)
                    {
                        ResetControles(1);
                        String answ = "";
                        switch (RPpre)
                        {
                            case 1: answ = "No es posible su venta"; break;
                            case 2: answ = "No tiene asignado precio de venta"; break;
                        }
                        MessageBoxAdv.Show(answ, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtCantidad.Focus();
                        txtClaveArticulo.Enabled = false;
                    }
                
            }
        }

        private int getPrecio()
        {
            int Err = 0;
            PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
            SqlDataAdapter Datos = null;
            DataSet Ds = new DataSet();
            object[] ObjA = null;

            pui.keyCveLstPrecio = LstPre_Clie;
            pui.cmpCveArticulo = IdArt;

            Datos = pui.GetPrecioArticulo();

            Datos.Fill(Ds);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                ObjA = Ds.Tables[0].Rows[0].ItemArray;
            }
            else
            {
                pui.keyCveLstPrecio = LstPre_Alm;
                pui.cmpNombre = IdArt;

                Datos = pui.GetPrecioArticulo();
                Datos.Fill(Ds);
                if (Ds.Tables[0].Rows.Count > 0)
                    ObjA = Ds.Tables[0].Rows[0].ItemArray;
                else
                    Err = 1;

            }

            if (Err == 0)
            {
                double Ppre = Convert.ToDouble(ObjA[4]);
                int rPre = Ppre.CompareTo(0);
                if (rPre > 0)
                {
                    PuiCatImpuestos I = new PuiCatImpuestos(db);
                    if (!String.IsNullOrEmpty(CveIEPS))
                    {
                        I.keyCveImpuesto = CveIEPS;
                        I.EditarImpuesto();
                        if (I.cmpValor > 0)
                            Ppre += Ppre * (I.cmpValor / 100);
                    }
                    if (!String.IsNullOrEmpty(CveImp))
                    {
                        I.keyCveImpuesto = CveImp;
                        I.EditarImpuesto();
                        if (I.cmpValor > 0)
                            Ppre += Ppre * (I.cmpValor / 100);
                    }

                }
                else
                    Err = 1;

            }


            return Err;

        }

        private void ExistArt()
        {
            PuiAddPartidasMovInv puiExis = new PuiAddPartidasMovInv(db);
            puiExis.cmpCveArticulo = IdArt;
            puiExis.cmpinv_ClaveAlmacen = user.AlmacenUsa;
            puiExis.BuscaPrecio("Minv");
            CantInv = puiExis.cmpinv_Cantidad;
        }

        private void InhControles(Boolean Opt, int _all)
        {
            txtClaveArticulo.Enabled = Opt;
            txtCantidad.Enabled = Opt;
            txtDescuento.Enabled = Opt;
            txtEfectivo.Enabled = Opt;
            cboCliente.Enabled = Opt;
            if (_all == 0)
            {
                btnEditar.Enabled = Opt;
                btnEliminar.Enabled = Opt;
            }

        }

        private void ResetControles(int _All)
        {
            IdArt = "";
            txtClaveArticulo.Text = "";
            CveImp = "";
            CveUmed = "";
            txtCantidad.Text = "1";
            CantInv = 0;
            if (_All == 0)
            {
                //pbArticulo
                txtSubTotal.Text = "0";
                txtDescuento.Text = "0";
                txtTotal.Text = "0";
                grdViewVenta.DataSource = null;
                PARTIDAS = new List<DocPartidasReq>();
                lblTotalArticulos.Text = "Artículos: 0";
                txtCambio.Text = "0";
                txtEfectivo.Text = "";
                OptPartd = 1;

            }   

            txtClaveArticulo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewVenta[6, grdViewVenta.CurrentRow.Index].Value);
                pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);
                AbrirPArtidas(pr);
                ReasgIdPart();
                LLenaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewVenta[6, grdViewVenta.CurrentRow.Index].Value);
                pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);
                ReasgIdPart();
                LLenaGrid();
                OptPartd = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirPArtidas(DocPartidasReq part)
        {
            txtClaveArticulo.Text = part.CveArticulo;
            IdArt = part.CveArticulo;
            CveImp = part.CveImpuesto;
            CveUmed = part.CveUmedida1;
            txtCantidad.Text = part.Cantidad.ToString();

            InhControles(false, 1);
            txtCantidad.Enabled = true;
            ExistArt();


            OptPartd = 2;
        }

        private void AbrirPArtidas()
        {
            double subTotal = 0;
            if (OptPartd == 1)
            {
                partida.idMov = idmovimiento;
                partida.Documento = "";
                partida.Serie = "";
                partida.Numdoc = 0;
                partida.ClaveAlmacen = "";
                partida.Partida = 0;
            }

            partida.CveArticulo = txtClaveArticulo.Text;
            partida.Descripcion = "";
            partida.Cantidad = Convert.ToDouble(txtCantidad.Text);
            partida.CveUmedida1 = CveUmed;
            partida.CveImpuesto = CveImp;
            partida.ImpuestoValor = 0;//Convert.ToDouble(txtIva.Text);
            double PreA = Convert.ToDouble(Util.LimpiarTxt("0"));
            partida.Precio = PreA;
            subTotal = PreA * Convert.ToDouble(txtCantidad.Text);
            partida.Descuento = 0;
            partida.PrecioNeto = PreA;
            partida.Impuesto = 0; ;
            partida.SubTotal = subTotal;//subTotal.ToString("C2")
            partida.Total = subTotal;
            partida.FechaCaptura = user.FecServer;
            partida.FechaModificacion = user.FecServer;


        }

        private void LLenaGrid()
        {
            grdViewVenta.DataSource = null;
            grdViewVenta.DataSource = PARTIDAS;
            grdViewVenta.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
            grdViewVenta.Columns["Partida"].Visible = false;

            grdViewVenta.Columns["idMov"].Visible = false;
            grdViewVenta.Columns["Documento"].Visible = false;
            grdViewVenta.Columns["Serie"].Visible = false;
            grdViewVenta.Columns["Numdoc"].Visible = false;
            grdViewVenta.Columns["CveImpuesto"].Visible = false;
            grdViewVenta.Columns["ClaveAlmacen"].Visible = false;
            grdViewVenta.Columns["Autorizado"].Visible = false;
            grdViewVenta.Columns["Descripcion"].Width = 150;
            grdViewVenta.Columns["CveUmedida1"].Visible = false;
            grdViewVenta.Columns["CveImpuesto"].Visible = false;
            grdViewVenta.Columns["Descuento"].Visible = false;

            grdViewVenta.Columns["Impuesto"].Visible = false;
            grdViewVenta.Columns["ImpuestoValor"].Visible = false;
            grdViewVenta.Columns["PrecioNeto"].Visible = false;
            grdViewVenta.Columns["SubTotal"].Visible = false;
            grdViewVenta.Columns["Cantidad"].Width = 40;
            grdViewVenta.Columns["Cantidad"].HeaderText = "Cant.";

            grdViewVenta.Columns["FechaCaptura"].Visible = false;
            grdViewVenta.Columns["FechaModificacion"].Visible = false;


            grdViewVenta.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewVenta.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewVenta.Columns["Total"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewVenta.Columns["Precio"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();

        }

        private void ReasgIdPart()
        {
            double subTotal = 0, total = 0, ccant = 0;

            for (int i = 0; i < PARTIDAS.Count; i++)
            {
                PARTIDAS[i].Partida = i + 1;
                subTotal = subTotal + PARTIDAS[i].SubTotal;
                total = total + PARTIDAS[i].Total;
                ccant = ccant + PARTIDAS[i].Cantidad;
            }

            txtSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
            txtTotal.Text = Util.FormtDouDec(total); //total.ToString();
            lblTotalArticulos.Text = "Artículos: " + Convert.ToInt32(ccant);
        }

        private void VerVentas_Click()
        {
            DcLstPventas LPv = new DcLstPventas(db, user, CveDoc, "LISTADO DE VENTAS");
            LPv.ShowDialog();
            if (LPv.dv[0] != null)
            {
                getRegistro(LPv.dv[0]);
                InhControles(false, 0);
                OptPartd = 3;
            }

            if (OptPartd != 3)
            {
                txtClaveArticulo.Focus();
            }
        }

        private void CancelEditPart()
        {
            ResetControles(1);
            InhControles(true, 1);
            if (OptPartd == 2)
            {
                PARTIDAS.Add(pr);
                ReasgIdPart();
            }

            LLenaGrid();
            OptPartd = 1;
            ShowLstArt();

        }

        private void getRegistro(String IdM)
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            sRq.keyidMov = IdM;
            sRq.GetDocumento();
            
            if (ConfigDoc.UsaSerie == 1)
            {
                serieticket = sRq.cmpSerie;
            }
            /*
            txtNumDoc.Text = Convert.ToString(sRq.cmpNumDoc);
            cboAlmacen.SelectedValue = sRq.cmpClaveAlmacen;
            FechaExpedicion.Value = sRq.cmpFechaExpedicion;
            */
            txtDescuento.Text = Convert.ToString(sRq.cmpDescuento);
            /*
            if (ConfigDoc.UsaProveedor == 1)
            {
                cboProveedor.SelectedValue = sRq.cmpCveProveedor;
            }
            if (ConfigDoc.UsaCliente == 0)
            {
                cboCliente.SelectedValue = sRq.cmpCveCliente;
            }
            */

            SqlDataAdapter DatosTbl = sRq.GetDatelleDoc(IdM);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);
            DataTable dt = ds.Tables[0];


            double subTotal = 0, impuesto = 0, total = 0, ccant = 0;

            foreach (DataRow row in dt.Rows)
            {
                DocPartidasReq partida = new DocPartidasReq();
                partida.idMov = row["idMov"].ToString();
                partida.Documento = row["Documento"].ToString();
                partida.Serie = row["Serie"].ToString();
                partida.Numdoc = long.Parse(row["Numdoc"].ToString());
                partida.ClaveAlmacen = row["ClaveAlmacen"].ToString();
                partida.Partida = int.Parse(row["Partida"].ToString());
                partida.CveArticulo = row["CveArticulo"].ToString();
                partida.Descripcion = row["Descripcion"].ToString();
                partida.Cantidad = double.Parse(row["Cantidad"].ToString());
                partida.CveUmedida1 = row["CveUmedida1"].ToString();
                partida.CveImpuesto = row["CveImpuesto"].ToString();
                partida.ImpuestoValor = Convert.ToDouble(row["ImpuestoValor"].ToString());
                partida.Precio = Convert.ToDouble(row["Precio"].ToString());
                partida.Descuento = Convert.ToDouble(row["Descuento"].ToString());
                partida.PrecioNeto = Convert.ToDouble(row["PrecioNeto"].ToString());
                partida.Impuesto = Convert.ToDouble(row["Impuesto"].ToString());
                partida.SubTotal = Convert.ToDouble(row["SubTotal"].ToString());
                partida.Total = Convert.ToDouble(row["Total"].ToString());
                partida.Autorizado = Boolean.Parse(row["Autorizado"].ToString());

                subTotal = subTotal + Convert.ToDouble(row["SubTotal"].ToString());
                impuesto = impuesto + Convert.ToDouble(row["Impuesto"].ToString());
                total = total + Convert.ToDouble(row["Total"].ToString());
                ccant = ccant + Convert.ToDouble(row["Cantidad"].ToString());
                PARTIDAS.Add(partida);

            }

            txtSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
            txtTotal.Text = Util.FormtDouDec(total); //total.ToString();
            lblTotalArticulos.Text = "Artículos: " + Convert.ToInt32(ccant);
            LLenaGrid();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                //ErrCalc = false;
            }
            else
            {
                if (ch == 13)
                {
                    if (Valida() == 0)
                    {
                        partida = new DocPartidasReq();
                        AbrirPArtidas();

                        if (partida != null)
                        {
                            if (!partida.CveArticulo.Equals(""))
                            {
                                double subTotal = 0, total = 0, ccant = 0;

                                PARTIDAS.Add(partida);
                                for (int i = 0; i < PARTIDAS.Count; i++)
                                {
                                    PARTIDAS[i].idMov = idmovimiento;
                                    PARTIDAS[i].Serie = serieticket;
                                    PARTIDAS[i].Partida = i + 1;
                                    PARTIDAS[i].ClaveAlmacen = user.AlmacenUsa;
                                    PARTIDAS[i].Autorizado = false;
                                    subTotal = subTotal + PARTIDAS[i].SubTotal;
                                    total = total + PARTIDAS[i].Total;
                                    ccant = ccant + PARTIDAS[i].Cantidad;
                                }
                                txtSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
                                txtTotal.Text = Util.FormtDouDec(total); //total.ToString("C2");
                                lblTotalArticulos.Text = "Artículos: " + Convert.ToInt32(ccant);
                                LLenaGrid();
                                ResetControles(1);
                                InhControles(true, 1);
                                OptPartd = 1;
                            }
                        }
                        ShowLstArt();
                    }
                }

                //ErrCalc = true;
            }
    
        }

        private int Valida()
        {
            int rs = 0;
            double Cantidad = 0;

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                rs = 1;
            }
            else
            {
                if (txtCantidad.Text.Length >= 1)
                {
                    if (!Util.Decimal(txtCantidad.Text))
                    {
                        Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        rs = 1;
                    }
                    else
                    {
                        Cantidad = Convert.ToDouble(txtCantidad.Text);
                        ttCantidad.Hide(txtCantidad);
                    }
                }
            }

            if(rs ==0)
            {
                int status = CantInv.CompareTo(Cantidad);
                if(status < 0)
                {
                    if (CfgAlma.NumRojo == 1)
                    {
                        if (MessageBoxAdv.Show("Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                " Existencia: " + CantInv + "\n" +
                                " ¿Desea continuar?",
                                "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            rs = 1;
                        }
                    }
                    else
                    {
                        rs = 1;
                        Util.MsjBox(ttCantidad, txtCantidad, "Cantidad", "Cantidad solicitada es mayor a la existencia del Articulo\n" +
                                                           " Existencia: " + CantInv + "\n", ToolTipIcon.Error);
                    }
                }
            }

            return rs;
        }


        private void txtClaveArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LlenaGridViewArt();
                grdViewArticulo.Focus();
            }
        }

        private void LlenaGridViewArt()
        {
            PuiCatArticulos pui = new PuiCatArticulos(db);
            DatosTbl = pui.BuscaArticuloVenta(txtClaveArticulo.Text.Trim(), user.AlmacenUsa, "LSTP001");
            DataSet Ds = new DataSet();
            try
            {
                grdViewArticulo.DataSource = null;
                DatosTbl.Fill(Ds);
                grdViewArticulo.DataSource = Ds.Tables[0];
                MO_FilasGrid();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MO_FilasGrid()
        {
            /*
                        0 - A.CveArticulo, " +
                        1 - A.CodigoBarra'," +
                        2 - A.Descripción, " +
                        3 - A.CodigoSat," +
                        4 - UM.CveUMedida, " +
                        5 - UM.Descripcion AS UMedida, " +
                        6 - Imp.CveImpuesto, " +
                        7 - Imp.Tipo, 
                        8 - Imp.Valor, " +
                        9 - L.CveLinea, " +
                        10 - L.Descripcion AS Linea, " +
                        11 - M.CveMarca, " +
                        12 - M.Descripcion AS Marca, " +
                        13 - C.CveClase, " +
                        14 - C.Descripcion AS Clase, " +
                        15 - A.Modelo," +
                        16 - A.Observacion " +
                        17 - ImmpIep.CveImpuesto AS CveIEPS, " +
                        18 - ImmpIep.Tipo AS TipoIEPS, " +
                        19 - ImmpIep.Valor AS ValorIEPS" +
                        20 - RequiereReceta
                        21.- Precio
                        22.- Existencia
                        23.- Foto
            */


            grdViewArticulo.Columns["CodigoBarra"].Frozen = true;//Inmovilizar columna
            grdViewArticulo.Columns["CodigoBarra"].Width = 100;
            grdViewArticulo.Columns["CodigoBarra"].HeaderText = "Código B";

            grdViewArticulo.Columns["Descripcion"].Frozen = true;//Inmovilizar columna
            grdViewArticulo.Columns["Descripcion"].Width = 300;


            if (ParamSystem.HideCveArt == 1)
            {
                grdViewArticulo.Columns["CveArticulo"].Visible = false;
            }
            else
            {
                grdViewArticulo.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
                grdViewArticulo.Columns["CveArticulo"].Width = 100;
                grdViewArticulo.Columns["CveArticulo"].HeaderText = "Clave";
            }


            grdViewArticulo.Columns["Modelo"].Visible = false;
            grdViewArticulo.Columns["CveLinea"].Visible = false;
            grdViewArticulo.Columns["CveMarca"].Visible = false;
            grdViewArticulo.Columns["CveClase"].Visible = false;
            grdViewArticulo.Columns["CveUMedida"].Visible = false;
            grdViewArticulo.Columns["CveImpuesto"].Visible = false;
            grdViewArticulo.Columns["Tipo"].Visible = false;
            grdViewArticulo.Columns["Valor"].Visible = false;
            grdViewArticulo.Columns["Observacion"].Visible = false;

            grdViewArticulo.Columns["CveIEPS"].Visible = false;
            grdViewArticulo.Columns["TipoIEPS"].Visible = false;
            grdViewArticulo.Columns["ValorIEPS"].Visible = false;
            grdViewArticulo.Columns["RequiereReceta"].Visible = false;
            grdViewArticulo.Columns["CodigoSat"].Visible = false;
            grdViewArticulo.Columns["Linea"].Visible = false;
            grdViewArticulo.Columns["Clase"].Visible = false;
            ((DataGridViewImageColumn)grdViewArticulo.Columns[23]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            grdViewArticulo.Columns["Foto"].Width = 100;




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

        private void Aceptar_click(int Exi)
        {
            switch (OptPartd)
            {
                case 1:
                    if (grdViewVenta.RowCount > 0)
                    {
                        DialogResult rsp = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rsp == DialogResult.Yes)
                        {
                            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                            idmovimiento = rq.AgregarDocEnBlanco(5000, user.FecServer, user.Usuario);
                            if (!idmovimiento.Equals(""))
                            {
                                Agregar();
                                if (Exi == 0)
                                    isDataSaved = false;
                            }
                            else
                            {
                                isDataSaved = false;
                                MessageBoxAdv.Show("Existen un error al guardar. (GD500)", "Guardando documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            if(Exi == 1)
                                isDataSaved = true;
                        }
                    }
                    break;
                case 2:
                    DialogResult rspw = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rspw == DialogResult.Yes)
                    {
                        DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                        int r = SetValues(sRq);
                        if(r == 0)
                        { 
                            if (sRq.ActualizaDocumento(OptPartd) == 1)
                            {
                                MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isDataSaved = true;
                            }
                            else
                            {
                                isDataSaved = false;
                            }
                        }

                    }
                    break;
                case 3:
                    ResetControles(0);
                    InhControles(true, 0);
                    break;
            }
        }

        private void Agregar()
        {

            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            int r = SetValues(sRq);
            if(r == 0)
            { 
                int _fol = int.Parse(ConfigDoc.Foliador);
                string _alm = "";
                //string _ser = "";
                int rsp = 0;

                if (ConfigDoc.UsaSerie == 1)
                {
                    _fol = int.Parse(CfgDocSerie.CodFoliador);
                    _alm = user.AlmacenUsa;
                }

                if (sRq.GuardarDocumento(_fol, _alm, ConfigDoc.CveDoc, serieticket , OptPartd) == 1)
                {
                    if (ConfigDoc.AfectaInventario == 1)
                    {
                        string strprov = Convert.ToString(cboCliente.SelectedValue);
                        MovtosInvRegistro Ventana = new MovtosInvRegistro(db,ParamSystem , null, "MINV", user);

                        rsp = Ventana.MigrarDocDetToMovDet(ConfigDoc.CveTipoMov, strprov, idmovimiento, user.AlmacenUsa);
                        if (rsp != 0)
                        {
                            string msj = "";
                            isDataSaved = false;
                            switch (rsp)
                            {
                                case 1: msj = "Al guardar cabecero"; break;
                                case 2: msj = "Al guardar detalle partidas"; break;
                                case 3: msj = "Al afectar existencias"; break;
                                case 13: msj = "Al afectar costos"; break;
                                case 4: msj = "Traspaso: Registro en blanco"; break;
                                case 5: msj = "Traspaso: Al guardar cabecero"; break;
                                case 6: msj = "Traspaso: Al guardar detalle partidas"; break;
                                case 7: msj = "Traspaso: Al afectar existencias"; break;
                                case 17: msj = "Traspaso: Al afectar costos"; break;
                                case 8: msj = "Traspaso: Al actualizar detalle partidas"; break;
                                case 9: msj = "El registro ya ha sido migrado"; break;
                                default: msj = "Error desconocido"; break;
                            }
                            MessageBoxAdv.Show(msj, "Afectando a inventarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (rsp == 0)
                    {
                        PrintDoc(idmovimiento);
                        ResetControles(0);
                        isDataSaved = true;
                        idmovimiento = "";
                    }
                }
                else
                {
                    isDataSaved = false;
                    MessageBoxAdv.Show("Existen un error al guardar", "Guardando documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private int SetValues(DocPuiRequisiciones sRq)
        {
            int r = 0;
            try
            {
                if (cboCliente.SelectedIndex < 0)
                {
                    MessageBoxAdv.Show("Cliente incorrecto.", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    sRq.keyidMov = idmovimiento;
                    sRq.cmpSerie = "";
                    sRq.cmpCveProveedor = "";
                    sRq.cmpCveCliente = cboCliente.SelectedValue.ToString();
                    sRq.keyidMov = idmovimiento;
                    sRq.keyDocumento = "";
                    sRq.cmpSerie = "";

                    sRq.cmpNumDoc = 0;
                    sRq.cmpCveDoc = CveDoc;
                    sRq.cmpClaveAlmacen = user.AlmacenUsa;
                    sRq.cmpFechaExpedicion = user.FecServer;

                    sRq.cmpFechaModificacion = user.FecServer;

                    sRq.cmpClaveImpuesto = CveImp;
                    sRq.cmpImpuesto = 0;
                    sRq.cmpDescuento = 0;
                    sRq.cmpSubTotal = Convert.ToDouble(Util.LimpiarTxt(txtSubTotal.Text));  //Convert.ToDouble(lblSubTotal.Text);
                    sRq.cmpTotal = Convert.ToDouble(Util.LimpiarTxt(txtTotal.Text));  //Convert.ToDouble(lblTotal.Text);
                    sRq.cmpObservaciones = "";
                    sRq.cmpEstatus = 1;
                    sRq.cmpAutorizado = false;
                    sRq.cmpEsperaAceptacion = 1;
                    sRq.cmpCveSucursal = "";
                    sRq.PartidasDoc = PARTIDAS;
                }
            }
            catch(Exception e)
            {
                r = 1;
                isDataSaved = false;
                MessageBoxAdv.Show("Existen un error al cargar los valores " + e.ToString(), "Guardando documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return r;

        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            VerVentas_Click();
        }

        private void PrintDoc(String cv)
        {
            String strEfe = Util.FormtStrDec(txtEfectivo.Text);
            DataTable dt = ToDataTable(PARTIDAS);// rq.DocDetPrint();
            fmtoTicket print = new fmtoTicket();
            String pict = Convert.ToString(GAFE.Properties.Resources.Editar);
            print.PrintTicket(db,user, dt, "FOLIO: " + PARTIDAS[0].Documento, 
                txtTotal.Text,"0", strEfe, txtCambio.Text );
        }

        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private int CalculaCambio()
        {
            int rsp = 1;
            double txtEfe = 0;
            double lblC = 0;
            String LblT = Util.LimpiarTxt(txtTotal.Text);
            double lblT = Convert.ToDouble(LblT);//Math.Round(Convert.ToDouble(LblT), 2);

            if (!Util.Decimal(txtEfectivo.Text))
            {
                new BalloonTip("Error de captura", "Cantidad: Contiene caracteres no validos. Sugiere: 0.0 - 0", txtEfectivo, BalloonTip.ICON.ERROR, 5000);
            }
            else
            {
                txtEfe = Convert.ToDouble(txtEfectivo.Text);

                if (!txtEfe.Equals(""))
                {
                    int status = lblT.CompareTo(0);
                    if (status <= 0)
                    {
                        new BalloonTip("Error de captura", "No se puede realizar dicha operación", txtTotal, BalloonTip.ICON.ERROR, 5000);
                    }
                    else
                    {
                        ttCantidad.Hide(txtTotal);
                        txtEfe = Math.Round(Convert.ToDouble(txtEfectivo.Text), 2);
                        lblC = txtEfe - lblT;
                        status = lblC.CompareTo(0);
                        if (status >= 0)
                        {
                            lblC = Math.Round(lblC, 2);
                            rsp = 0;
                        }
                        else
                        {
                            lblC = 0;
                        }
                    }
                }
            }

            txtCambio.Text = Util.FormtDouDec(lblC); //Convert.ToString(lblC);

            return rsp;

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 46 && ch != 13)
            {
                e.Handled = true;
            }
            else
            {
                if (ch == 13)
                {
                    if (CalculaCambio() == 0)
                        Aceptar_click(0);
                }
            }
        }
        
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
                //ErrCalc = false;
            }
            else
            {
                if (ch == 13)
                    txtEfectivo.Focus();

                //ErrCalc = true;
            }
        }

        /*Resize*/
        private void resizeChildrenControls()
        {
            resizeControl(lblTitleClienteOld, lblTitleCliente);
            resizeControl(cboClienteOld, cboCliente);

            resizeControl(txtClaveArticuloOld, txtClaveArticulo);
            resizeControl(btnEditarOld, btnEditar);
            resizeControl(btnEliminarOld, btnEliminar);
            resizeControl(grdViewVentaOld, grdViewVenta);
            resizeControl(grdViewArticuloOld, grdViewArticulo);
            resizeControl(lblTitCantidadOld, lblTitCantidad);
            resizeControl(txtCantidadOld, txtCantidad);
            resizeControl(lblTitSubTotalOld, lblTitSubTotal);
            resizeControl(lblSubTotalOld, txtSubTotal);
            resizeControl(lblTitDescuentoOld, lblTitDescuento);
            resizeControl(txtDescuentoOld, txtDescuento);
            resizeControl(lblTitTotalOld, lblTitTotal);
            resizeControl(lblTotalOld, txtTotal);
            resizeControl(btnVerVentasOld, btnVerVentas);
            resizeControl(lblTotalArticulosOld, lblTotalArticulos);
            resizeControl(lblTitEfectivoOld, lblTitEfectivo);
            resizeControl(txtEfectivoOld, txtEfectivo);
            resizeControl(lblTitCambioOld, lblTitCambio);
            resizeControl(txtCambioOld, txtCambio);
            resizeControl(lblTitBusquedaOld, lblTitBusqueda);
            resizeControl(panelLineOld, panelLine);

        }

        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);


            int newX = (int)(OriginalControlRect.X * xRatio);
            int newY = (int)(OriginalControlRect.Y * yRatio);

            int newWidth = (int)(OriginalControlRect.Width * xRatio);
            int newHeight = (int)(OriginalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        private void DcPtoVenta_Resize(object sender, EventArgs e)
        {
            resizeChildrenControls();
        }

        private void lblTitEfectivo_Click(object sender, EventArgs e)
        {

        }

        private void DcPtoVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmClose();
        }

        private void lblTitleCliente_Click(object sender, EventArgs e)
        {

        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

