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
using Syncfusion.Windows.Forms.Tools;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace GAFE
{
    public partial class DcRegPVenta : MetroForm
    {

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

        public DcRegPVenta()
        {
            InitializeComponent();
        }


        public DcRegPVenta(MsSql Odat, Form lg,  String PUsr, int Opc,
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

        }

        private void DcRegPVenta_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();


            PuiSegUsuarioCfg team = new PuiSegUsuarioCfg(db);
            team.cmpStiloTema = user.StiloTema;
            Object[] reg = team.GetParamTema();
            NewColor.Encabezado = reg[0].ToString();
            NewColor.HoverEncabezado = reg[1].ToString();
            NewColor.FontColor = reg[2].ToString();

            LlecboCliente();

            GetDatoAlmacen();

            PARTIDAS = new List<DocPartidasReq>();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            this.FormBorderStyle = FormBorderStyle.None; //Form without bord and resize
            this.DoubleBuffered = true; //Form without bord and resize
            this.SetStyle(ControlStyles.ResizeRedraw, true); //Form without bord and resize

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
                            if (grdViewD.RowCount > 0)
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
                lblDescArticulo.Text = ar.dv[1];
                CveImp = ar.dv[10];
                CveUmed = ar.dv[8];

                PuiCatArticulos Art = new PuiCatArticulos(db);
                Art.keyCveArticulo = ar.dv[0];
                Art.EditarArticulo(ParamSystem.HideCveArt);

                if (Art.cmpFoto != null)
                {
                    
                    MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                    Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                    pbArticulo.Image = Image.FromStream(Mf);
                    
                }

                ExistArt();
                /*
                int rcant = CantInv.CompareTo(0);
                if (rcant > 0)
                {
                */
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
                /*
                }
                else
                {
                    ResetControles(1);
                    MessageBoxAdv.Show("No tiene", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                */
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
                    lblPrecioArt.Text = Util.FormtStrDec(ObjA[4].ToString());//ObjA[4].ToString();
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
            lblDescArticulo.Text = "";
            lblPrecioArt.Text = "0";
            txtCantidad.Text = "1";
            CantInv = 0;
            if (_All == 0)
            {
                //pbArticulo
                lblSubTotal.Text = "0";
                txtDescuento.Text = "0";
                lblTotal.Text = "0";
                grdViewD.DataSource = null;
                PARTIDAS = new List<DocPartidasReq>();
                lblTotalArticulos.Text = "Artículos: 0";
                lblCambio.Text = "0";
                txtEfectivo.Text = "";
                OptPartd = 1;

            }   

            txtClaveArticulo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);
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
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);
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
            lblDescArticulo.Text = part.Descripcion;
            lblPrecioArt.Text = part.Precio.ToString();
            //txtDescuento.Text = (part.Descuento > 0) ? part.Descuento.ToString() : "0.00";
            //lblPrecioArtNeto.Text = part.PrecioNeto.ToString();
            txtCantidad.Text = part.Cantidad.ToString();
            //txtImpuesto.Text = part.Impuesto.ToString();
            //txtSubtotal.Text = part.SubTotal.ToString();
            //txtTotal.Text = part.Total.ToString();
            //txtIva.Text = part.ImpuestoValor.ToString();

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
            partida.Descripcion = lblDescArticulo.Text;
            partida.Cantidad = Convert.ToDouble(txtCantidad.Text);
            partida.CveUmedida1 = CveUmed;
            partida.CveImpuesto = CveImp;
            partida.ImpuestoValor = 0;//Convert.ToDouble(txtIva.Text);
            double PreA = Convert.ToDouble(Util.LimpiarTxt(lblPrecioArt.Text));
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
            grdViewD.DataSource = null;
            grdViewD.DataSource = PARTIDAS;
            grdViewD.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
            grdViewD.Columns["Partida"].Visible = false;

            grdViewD.Columns["idMov"].Visible = false;
            grdViewD.Columns["Documento"].Visible = false;
            grdViewD.Columns["Serie"].Visible = false;
            grdViewD.Columns["Numdoc"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["ClaveAlmacen"].Visible = false;
            grdViewD.Columns["Autorizado"].Visible = false;
            grdViewD.Columns["Descripcion"].Width = 150;
            grdViewD.Columns["CveUmedida1"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["Descuento"].Visible = false;

            grdViewD.Columns["Impuesto"].Visible = false;
            grdViewD.Columns["ImpuestoValor"].Visible = false;
            grdViewD.Columns["PrecioNeto"].Visible = false;
            grdViewD.Columns["SubTotal"].Visible = false;
            grdViewD.Columns["Cantidad"].Width = 40;
            grdViewD.Columns["Cantidad"].HeaderText = "Cant.";

            grdViewD.Columns["FechaCaptura"].Visible = false;
            grdViewD.Columns["FechaModificacion"].Visible = false;


            grdViewD.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Total"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["Precio"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();

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

            lblSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
            lblTotal.Text = Util.FormtDouDec(total); //total.ToString();
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

            lblSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
            lblTotal.Text = Util.FormtDouDec(total); //total.ToString();
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
                                lblSubTotal.Text = Util.FormtDouDec(subTotal);//subTotal.ToString("C2");
                                lblTotal.Text = Util.FormtDouDec(total); //total.ToString("C2");
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
                PuiCatArticulos Art = new PuiCatArticulos(db);

                Art.keyCveArticulo = txtClaveArticulo.Text;
                if (Art.EditarArticulo(ParamSystem.HideCveArt) > 0)
                {
                    IdArt = Art.keyCveArticulo;
                    txtClaveArticulo.Text = Art.keyCveArticulo;
                    lblDescArticulo.Text = Art.cmpDescripcion;

                    CveImp = Art.cmpCveImpuesto;
                    CveUmed = Art.cmpCveUMedida1;
                    if (Art.cmpFoto.Length > 0)
                    {
                        MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                        Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                        pbArticulo.Image = Image.FromStream(Mf);
  
                    }
                    ExistArt();
                    /*
                    int rcant = CantInv.CompareTo(0);
                    if (rcant > 0)
                    {
                    */
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
                        /*
                    }
                    else
                    {
                        ResetControles(1);
                        MessageBoxAdv.Show("No es posible su venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    */
                }
                else
                {
                    ResetControles(1);
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    if (grdViewD.RowCount > 0)
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
                    sRq.cmpSubTotal = Convert.ToDouble(Util.LimpiarTxt(lblSubTotal.Text));  //Convert.ToDouble(lblSubTotal.Text);
                    sRq.cmpTotal = Convert.ToDouble(Util.LimpiarTxt(lblTotal.Text));  //Convert.ToDouble(lblTotal.Text);
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
                lblTotal.Text,"0", strEfe, lblCambio.Text );
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
            String LblT = Util.LimpiarTxt(lblTotal.Text);
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
                        new BalloonTip("Error de captura", "No se puede realizar dicha operación", lblTotal, BalloonTip.ICON.ERROR, 5000);
                    }
                    else
                    {
                        ttCantidad.Hide(lblTotal);
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

            lblCambio.Text = Util.FormtDouDec(lblC); //Convert.ToString(lblC);

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
    }
}

