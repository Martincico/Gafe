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
    public partial class DocRegistroRequisicion : MetroForm
    {
        private DatCfgParamSystem ParamSystem;
        private DatCfgSystem CfgSystem;
        private DatCfgUsuario user;
        private clsStiloTemas StiloColor;
        ClsUtilerias Util;


        private clsCfgDocumento ConfigDoc;
        private clsCfgDocSeries CfgDocSerie;
        clsCfgAlmacen cfgAlma;

        string idmovimiento;
        private MsSql db = null;
        private int Opcion;
        
        private String CveDoc;
        private String NameDoc;

        private Boolean isDataSaved = false;//Valida el cerrar el doc

        List<DocPartidasReq> PARTIDAS;

        private Boolean AutTodo = false;

        private ToolTip ttDescuento = new ToolTip();
        private ToolTip ttTotal = new ToolTip();
        private ToolTip ttSubTotal = new ToolTip();
        Boolean ErrCalc = true;

        public DocRegistroRequisicion()
        {
            InitializeComponent();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        public DocRegistroRequisicion(MsSql Odat, DatCfgSystem CfgSys, DatCfgParamSystem ParamS, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op, 
            clsCfgDocumento CfgDoc,string mov, String _CveDoc, string _namedoc)
        {
            StiloColor = NewColor;
            ParamSystem = ParamS;
            CfgSystem = CfgSys;
            db = Odat;
            ConfigDoc = CfgDoc;
            idmovimiento = mov;
            Opcion = op;
            user = DatUsr;
            CveDoc = _CveDoc;
            InitializeComponent();
            PARTIDAS = new List<DocPartidasReq>();

            NameDoc = _namedoc;

            this.Text = "REGISTRO DE " + NameDoc;

            FechaExpedicion.Enabled = (ConfigDoc.EditaFecha == 1)?true:false;

            cboSucursal.Visible = (ConfigDoc.UsaAlmDestino == 1) ? true : false;
            lblSucursal.Visible = (ConfigDoc.UsaAlmDestino == 1) ? true : false;
            Util = new ClsUtilerias(ParamSystem.NumDec);
        }



        private void DocRegistroRequisicion_Load(object sender, EventArgs e)
        {

            cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;
            cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;

            LlecboAlmacen();

            if (Opcion >= 2)
            {
                getRegistro();
                if (Opcion == 3)
                {
                    HD_Botones(3, false);
                }
            }
            if (ConfigDoc.UsaProveedor == 1)
            {
                lblProveedor.Visible = true;
                cboProveedor.Visible = true;
                LlecboProveedor();
            }

            if (ConfigDoc.SolicitaAutorizar == 1)
            {
                if (Opcion == 2)
                    cmdAutorizarTodo.Visible = true;
            }

            if (ConfigDoc.UsaAlmDestino == 1)
            {
                LlecboSucursal();
                /*
                if (CfgSystem.EsSucursal == 1)
                {
                    cboSucursal.Enabled = true;
                    cboAlmacen.SelectedValue = user.SucursalUsa;
                }
                else
                    cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;
                    */
            }

            if(ConfigDoc.UsaFactura == 1)
            {
                lblNoFactura.Visible = true;
                txtNoFactura.Visible = true;
            }
        }


        private void LlecboAlmacen()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmacen.DataSource = lin.CboCatAlmacenes(0);
            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";

            cboAlmacen.SelectedValue = user.AlmacenUsa;
            CargaParamAlma(user.AlmacenUsa);
        }

        private void LlecboProveedor()
        {
            PuiCatProveedores lin = new PuiCatProveedores(db);
            cboProveedor.DataSource = lin.LLenaCboProveedores();
            cboProveedor.ValueMember = "Clave";
            cboProveedor.DisplayMember = "Descripcion";

        }

        private void LlecboSucursal()
        {
            PuiCatSucursales lin = new PuiCatSucursales(db);
            cboSucursal.DataSource = lin.LLenaCboSucursales();
            cboSucursal.ValueMember = "Clave";
            cboSucursal.DisplayMember = "Descripcion";

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdViewD.RowCount > 0)
            {
                if (Valida(1) == 0)
                {
                    switch (Opcion)
                    {
                        case 1:
                            Agregar();
                            break;
                        case 2:
                            DialogResult rspw = MessageBoxAdv.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rspw == DialogResult.Yes)
                            {
                                DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                                SetValues(sRq);
                                if (sRq.ActualizaDocumento(Opcion) == 1)
                                {
                                    MessageBoxAdv.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isDataSaved = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBoxAdv.Show("Existe un error al editar ", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    isDataSaved = false;
                                }
                            }
                            break;
                        case 3: this.Close(); break;
                        default: isDataSaved = true; break;
                    }
                }
            }
        }

        private void Agregar()
        {
            DialogResult rsp = MessageBoxAdv.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.Yes)
            {
                DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                SetValues(sRq);
                int _fol = int.Parse(ConfigDoc.Foliador);
                string _alm = "";
                string _ser = "";
                if (ConfigDoc.UsaSerie == 1)
                {
                    _fol = int.Parse(CfgDocSerie.CodFoliador);
                    _alm = cboAlmacen.SelectedValue.ToString();
                    _ser = cboSerie.SelectedValue.ToString();
                }

                if (sRq.GuardarDocumento(_fol, _alm, ConfigDoc.CveDoc, _ser, Opcion) == 1)
                {
                    MessageBoxAdv.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isDataSaved = true;

                    this.Close();
                }
                else
                {
                    MessageBoxAdv.Show("Existe un error al guardar ", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isDataSaved = false;
                }
            }
        }




        private void SetValues(DocPuiRequisiciones sRq)
        {
            sRq.cmpSerie = "";
            sRq.cmpCveProveedor = "";
            sRq.cmpCveCliente = "";
            sRq.keyidMov = idmovimiento;
            sRq.keyDocumento = (Opcion == 2) ? txtDocumento.Text : "";
            if (ConfigDoc.UsaSerie == 1)
            {
                sRq.cmpSerie = cboSerie.SelectedValue.ToString();
            }
            sRq.cmpNumDoc = Convert.ToInt64(txtNumDoc.Text);
            sRq.cmpCveDoc = CveDoc;

            sRq.cmpClaveAlmacen = cboAlmacen.SelectedValue.ToString();
            
            sRq.cmpCveSucursal =  (ConfigDoc.UsaAlmDestino == 1)? cboSucursal.SelectedValue.ToString():"";

            sRq.cmpFechaExpedicion = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", FechaExpedicion.Value));

            sRq.cmpFechaModificacion = user.FecServer;
            sRq.cmpUsuarioModi = user.Usuario;
            sRq.cmpClaveImpuesto = "";
            sRq.cmpImpuesto = Convert.ToDouble(Util.LimpiarTxt(txtIVA.Text));
            sRq.cmpDescuento = Convert.ToDouble(Util.LimpiarTxt(txtDescuento.Text));
            sRq.cmpSubTotal = Convert.ToDouble(Util.LimpiarTxt(txtSubTotal.Text));
            sRq.cmpTotal = Convert.ToDouble(Util.LimpiarTxt(txtTotal.Text));
            sRq.cmpObservaciones = txtObservaciones.Text;
            sRq.cmpEstatus = 1;
            sRq.cmpAutorizado =false;
            sRq.cmpEsperaAceptacion =  1;
            
            if (ConfigDoc.UsaProveedor == 1)
            {
                sRq.cmpCveProveedor = cboProveedor.SelectedValue.ToString();
            }
            sRq.cmpNoFactura = "";
            if (ConfigDoc.UsaFactura == 1)
                sRq.cmpNoFactura = txtNoFactura.Text.ToString().Trim();

                sRq.PartidasDoc = PARTIDAS;

        }

        private void NoGuardaElDocumento()
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);

            switch (Opcion)
            {
                case 1: sRq.BorrarDocEnBlanco(idmovimiento); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void AddPartida_Click(object sender, EventArgs e)
        {
            if (Valida(0) == 0)
            {
                DocPartidasReq par = new DocPartidasReq();
                DocPartidaRequisiciones DP = new DocPartidaRequisiciones(db, ParamSystem, user,ConfigDoc,cfgAlma, StiloColor, 1, par);
                DP.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                DP.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                DP.ShowDialog();

                DocPartidasReq partida = DP.partida;

                if (partida != null)
                {
                    if (partida.CveArticulo != null)
                    {
                        PARTIDAS.Add(partida);
                        for (int i = 0; i < PARTIDAS.Count; i++)
                        {
                            PARTIDAS[i].idMov = idmovimiento;
                            PARTIDAS[i].Serie = "";
                            PARTIDAS[i].Partida = i + 1;
                            PARTIDAS[i].ClaveAlmacen = cboAlmacen.SelectedValue.ToString() ;
                            //PARTIDAS[i].ClaveAlmacen = ConfigDoc.UsaAlmTmp ==1 ?"999": cboAlmacen.SelectedValue.ToString(); 
                            PARTIDAS[i].Autorizado = false;

                            if(Opcion == 1)
                                PARTIDAS[i].FechaCaptura = user.FecServer;

                            PARTIDAS[i].FechaModificacion = user.FecServer;

                        }

                        cboAlmacen.Enabled = false;
                        cboSucursal.Enabled =  false;

                        LLenaGrid();

                    }
                }
            }
 
        }



        private void EditPartida_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valida(0) == 0)
                { 
                    int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);

                    DocPartidasReq pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                    int idx = PARTIDAS.IndexOf(pr);
                    PARTIDAS.RemoveAt(idx);

                    DocPartidaRequisiciones prV = new DocPartidaRequisiciones(db, ParamSystem, user, ConfigDoc, cfgAlma, StiloColor,2,pr);
                    prV.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                    prV.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);

                    prV.ShowDialog();

                    if (prV.partida != null)
                    {
                        PARTIDAS.Insert(idx, prV.partida);
                        PARTIDAS[idx].FechaCaptura = pr.FechaCaptura;
                        PARTIDAS[idx].FechaModificacion = user.FecServer;
                    }
                    else
                        PARTIDAS.Insert(idx, pr);

                    LLenaGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar una partida\n Error:"+ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DelPartida_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);

                DocPartidasReq pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);

                LLenaGrid();

                if (grdViewD.RowCount <= 0)
                {
                    cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? true : false;
                    cboSucursal.Enabled = user.CambiaAlmacen == 1 ? true : false;
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void getRegistro()
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            sRq.keyidMov = idmovimiento;
            sRq.GetDocumento();
            txtDocumento.Text = sRq.keyDocumento;
            if (ConfigDoc.UsaSerie == 1)
            {
                cboSerie.SelectedValue = sRq.cmpSerie;
            }
            txtNumDoc.Text = Convert.ToString(sRq.cmpNumDoc);
            cboAlmacen.SelectedValue = sRq.cmpClaveAlmacen;
            FechaExpedicion.Value = sRq.cmpFechaExpedicion;
            
            txtObservaciones.Text = sRq.cmpObservaciones;
            if (ConfigDoc.UsaProveedor == 1)
            {
                cboProveedor.SelectedValue = sRq.cmpCveProveedor;
            }

            if (ConfigDoc.UsaAlmDestino == 1)
                cboProveedor.SelectedValue =  sRq.cmpCveSucursal;

            txtNoFactura.Text = "";
            if (ConfigDoc.UsaFactura == 1)
                txtNoFactura.Text = sRq.cmpNoFactura;

            SqlDataAdapter DatosTbl = sRq.GetDatelleDoc(idmovimiento);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);
            DataTable dt = ds.Tables[0];

            
            //double subTotal = 0, impuesto = 0, total = 0, descpartida = 0, descuento = 0;

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
                partida.CodigoBarra = row["CodigoBarra"].ToString();
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
                partida.FechaCaptura = Convert.ToDateTime(row["FechaCaptura"].ToString());
                partida.FechaModificacion = Convert.ToDateTime(row["FechaModificacion"].ToString());

                partida.CveImpIEPS = row["CveImpIEPS"].ToString();
                partida.ImpIEPSValor = Convert.ToDouble(row["ImpIEPSValor"].ToString());
                partida.CveImpRetISR = "";
                partida.ImpRetISRValor = 0;
                partida.CveImpRetIVA = "";
                partida.ImpRetIVAValor = 0;
                partida.CveImpOtro = "";
                partida.ImpValorOtro = 0;
                partida.TotalIEPS = Convert.ToDouble(row["TotalIEPS"].ToString());
                partida.TotalRetISR = 0;
                partida.TotalRetIVA = 0;
                partida.TotalImpOtro = 0;


                PARTIDAS.Add(partida);

            }
            txtDescuento.Text = Convert.ToString(Util.FormtDouDec(sRq.cmpDescuento));
            
            LLenaGrid();

        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void DocRegistroRequisicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDataSaved)
            {
                if (Opcion != 3)
                {
                    switch (MessageBoxAdv.Show(this, "¿En realidad desea salir del documento?", "Salir de "+NameDoc, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            e.Cancel = true;
                            break;
                        default:
                            Boolean rp = false;
                            if (grdViewD.RowCount > 0)
                            {
                                cmdAceptar_Click(sender, e);
                                rp = isDataSaved;
                            }
                            if(!rp && Opcion ==1)
                            {
                                DocPuiRequisiciones InvMast = new DocPuiRequisiciones(db);
                                InvMast.keyidMov = idmovimiento;
                                InvMast.EliminaDocumento();
                            }
                            e.Cancel = false;
                        break;
                    }
                }
                else
                {
                    e.Cancel = false;
                }

            }
            else
            {
                e.Cancel = false;
            }

        }


        private void LlecboSerie(String CveAlm)
        {
            
            cboSerie.DataSource = null;
            cboSerie.Items.Clear();
            PuiCatCfgDocSerie lin = new PuiCatCfgDocSerie(db);
            cboSerie.DataSource = lin.CbollenaSeries(CveAlm, CveDoc);

            cboSerie.ValueMember = "Clave";
            cboSerie.DisplayMember = "Descripcion";

            //cboSerie.SelectedValue = CveAlm;
        }

        private int Valida(int OpSave)
        {
            int rsp = 0;
            String msj = "";
            if (cboAlmacen.SelectedIndex < 0)
            {
                rsp = 1;
                msj += "No se ha seleccinado ningún almacén.\n";
            }

            if (ConfigDoc.UsaSerie == 1)
            {
                if (cboSerie.SelectedIndex < 0)
                {
                    rsp = 1;
                    msj += "No se ha seleccinado ninguna serie.\n";
                }
            }

            if (ConfigDoc.UsaProveedor == 1)
            {
                if (cboProveedor.SelectedIndex < 0)
                {
                    rsp = 1;
                    msj += "No se ha seleccinado ningún proveedor.\n";
                }
            }


            if (OpSave == 1)
            {
                if (ConfigDoc.UsaFactura == 1)
                {
                    if (string.IsNullOrEmpty(txtNoFactura.Text))
                    {
                        rsp = 1;
                        msj += "No se ha indicado ninguna Factura.\n";
                    }
                    else
                    {
                        if (!Util.LetrasNum(txtNoFactura.Text))
                        {
                            rsp = 1;
                            msj += "Factura contiene caracteres no validos.\n";
                        }
                    }
                }
            }

            if (rsp==1)
            {
                MessageBoxAdv.Show("Se han encontrado los siguientes errores: \n" +msj, "Registro de requisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return rsp;
        }

        private void HD_Botones(int oq, Boolean Bol)
        {
            AddPartida.Enabled = Bol;
            EditPartida.Enabled = Bol;
            DelPartida.Enabled = Bol;

            if (oq == 3)
            {
                cboSerie.Enabled = ConfigDoc.UsaSerie == 1 ? Bol : false;
                txtNumDoc.Enabled = Bol;
                cboAlmacen.Enabled = user.CambiaAlmacen == 1 ? Bol : false;
                
                FechaExpedicion.Enabled = Bol;
                //txtDescuento.Enabled = Bol;
                txtObservaciones.Enabled = Bol;
                cboProveedor.Enabled = Bol;

                txtDescuento.Enabled = Bol;
            }
        }

        private void cboSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboSerie.SelectedValue);
            if (cboSerie.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    HD_Botones(1, true);
                    string cboAlm = Convert.ToString(cboAlmacen.SelectedValue);
                    string cboSer = Convert.ToString(cboSerie.SelectedValue);

                    clsCfgDocSeries cds = new clsCfgDocSeries(cboAlm, CveDoc,  cboSer, db);
                    CfgDocSerie = cds.ConfigDocSerie();
                    
                }
            }
            else
            {
                HD_Botones(1, false);
            }
        }

        private void cboAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmacen.SelectedValue);
            if (cboAlmacen.SelectedIndex >= 0)
            {
                if (!val.Equals("System.Data.DataRowView"))
                {
                    CargaParamAlma(val);
                    if (ConfigDoc.UsaSerie == 1)
                    {
                        LlecboSerie(val);
                        cboSerie.Enabled = true;
                    }
                    else
                    {
                        HD_Botones(1, true);
                    }
                }
            }
        }

        private void LLenaGrid()
        {
            double subTotal = 0, impuesto = 0, impIEPS = 0, total = 0;

            grdViewD.DataSource = null;
            grdViewD.DataSource = PARTIDAS;
            
            grdViewD.Columns["idMov"].Visible = false;
            grdViewD.Columns["Documento"].Visible = false;
            grdViewD.Columns["Serie"].Visible = false;
            grdViewD.Columns["Numdoc"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["ClaveAlmacen"].Visible = false;
            grdViewD.Columns["FechaCaptura"].Visible = false;
            grdViewD.Columns["FechaModificacion"].Visible = false;
            grdViewD.Columns["ImpuestoValor"].Visible = false;
            grdViewD.Columns["Partida"].HeaderText = "Part";
            grdViewD.Columns["Partida"].Width = 30;
            grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
            grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";
            //grdViewD.Columns["Autorizado"].Visible = false;
            grdViewD.Columns["CodigoBarra"].Frozen = true;//Inmovilizar columna

            if (ParamSystem.HideCveArt == 1)
            {
                grdViewD.Columns["CveArticulo"].Visible = false;
            }
            else
            {
                grdViewD.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
                grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
            }

            if (Opcion == 1)
                grdViewD.Columns["Autorizado"].Visible = false;
            else
            {
                grdViewD.Columns["Autorizado"].Width = 30;
                grdViewD.Columns["Autorizado"].Visible = (ConfigDoc.SolicitaAutorizar == 1) ? true : false;
            }


            grdViewD.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Total"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["SubTotal"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Precio"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Descuento"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["Impuesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["Impuesto"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["TotalIEPS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdViewD.Columns["TotalIEPS"].DefaultCellStyle.Format = Util.TipoFmtoRedonder();
            grdViewD.Columns["Cantidad"].Width = 60;
            grdViewD.Columns["Impuesto"].HeaderText = "IVA";
            grdViewD.Columns["TotalIEPS"].HeaderText = "IEPS";


            grdViewD.Columns["PrecioNeto"].Visible = false;
            grdViewD.Columns["CveImpIEPS"].Visible = false;
            grdViewD.Columns["ImpIEPSValor"].Visible = false;
            
            grdViewD.Columns["CveImpRetIVA"].Visible = false;
            grdViewD.Columns["ImpRetIVAValor"].Visible = false;
            grdViewD.Columns["TotalRetIVA"].Visible = false;
            grdViewD.Columns["CveImpRetISR"].Visible = false;
            grdViewD.Columns["ImpRetISRValor"].Visible = false;
            grdViewD.Columns["TotalRetISR"].Visible = false;
            grdViewD.Columns["CveImpOtro"].Visible = false;
            grdViewD.Columns["ImpValorOtro"].Visible = false;
            grdViewD.Columns["TotalImpOtro"].Visible = false;
            
            for (int i = 0; i < PARTIDAS.Count; i++)
            {
                subTotal = subTotal + PARTIDAS[i].SubTotal;
                impuesto = impuesto + PARTIDAS[i].Impuesto;
                impIEPS = impIEPS + PARTIDAS[i].TotalIEPS;
                total = total + PARTIDAS[i].Total;
            }
            double descuento = Convert.ToDouble(Util.LimpiarTxt(txtDescuento.Text));
            
            txtSubTotal.Text = Util.FormtDouDec(subTotal);
            txtIVA.Text = Util.FormtDouDec(impuesto);
            txtIeps.Text = Util.FormtDouDec(impIEPS);
            txtTotal.Text = Util.FormtDouDec(total-descuento);

            Calculos(0);
        }

        private void grdViewD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ConfigDoc.SolicitaAutorizar == 1)
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    bool selected = (bool)grdViewD[e.ColumnIndex, e.RowIndex].Value;
                    grdViewD.Rows[e.RowIndex].DefaultCellStyle.BackColor = selected ? Color.Yellow : Color.White;
                    int part = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);

                    ActAutoriza(selected);
                }
            }
        }

        private void grdViewD_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ConfigDoc.SolicitaAutorizar == 1)
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    grdViewD.EndEdit();
                }
            }
        }

        private void ActAutoriza(Boolean chk)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);

                DocPartidasReq pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);

                pr.Autorizado = chk ? true : false;

                PARTIDAS.Insert(idx, pr);

                LLenaGrid();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cmdAutorizarTodo_Click(object sender, EventArgs e)
        {
            if (AutTodo)
            {
                cmdAutorizarTodo.Image = global::GAFE.Properties.Resources.UnCheck;
                AutTodo = false;
            }
            else
            {
                cmdAutorizarTodo.Image = global::GAFE.Properties.Resources.Check;
                AutTodo = true;
            }

            foreach (DataGridViewRow row in grdViewD.Rows)
            {
                grdViewD.Rows[row.Index].SetValues(AutTodo);
            }
            
        }

        private void grdViewD_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            //Checamos click ha sido en el encabezado?
            if(grdViewD.HitTest(e.X,e.Y).Type ==DataGridViewHitTestType.ColumnHeader )
            {
                //creamos un menu
                ContextMenu mnugrid = new ContextMenu();

                //Agregamos submenus
                foreach(DataGridViewColumn cols in grdViewD.Columns)
                {
                    MenuItem _items = new MenuItem();

                    _items.Text = cols.HeaderText;
                    _items.Checked = cols.Visible;

                    //Agregando evento al submenu al click
                    _items.Click += (obj, ea) =>
                    {
                        cols.Visible = !_items.Checked;

                        _items.Checked = cols.Visible;

                        mnugrid.Show(grdViewD, e.Location);
                    };

                    mnugrid.MenuItems.Add(_items);
                }

                //Mostrando menú
                mnugrid.Show(grdViewD, e.Location);
            }
            */
        }

        private void DocRegistroRequisicion_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void lblProveedor_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIeps_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            Calculos(0);
        }


        private void Calculos(int Op)
        {
            double Descuento = 0;
            double SubTotal = 0;
            double Total = 0;

            
            if (String.IsNullOrEmpty(txtDescuento.Text))
            {
                if (Op == 1)
                {
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
                        Util.MsjBox(ttDescuento, txtDescuento, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        ErrCalc = false;
                    }
                    else
                    {
                        Descuento = Convert.ToDouble(txtDescuento.Text);
                        ttDescuento.Hide(txtDescuento);
                    }
                }
            }

            if (String.IsNullOrEmpty(txtSubTotal.Text))
            {
                if (Op == 1)
                {
                    Util.MsjBox(ttSubTotal, txtSubTotal, "SubTotal", "SubTotal: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                    ErrCalc = false;
                }
                else
                {
                    SubTotal = 0;
                    ttSubTotal.Hide(txtSubTotal);
                }
            }
            else
            {
                if (txtSubTotal.Text.Length >= 1)
                {
                    if (!Util.Decimal(Util.LimpiarTxt(txtSubTotal.Text)))
                    {
                        Util.MsjBox(ttSubTotal, txtSubTotal, "SubTotal", "SubTotal: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                        ErrCalc = false;
                    }
                    else
                    {
                        SubTotal = Convert.ToDouble(Util.LimpiarTxt(txtSubTotal.Text));
                        ttSubTotal.Hide(txtSubTotal);
                    }
                }
            }

            if (ErrCalc)
            { 

                Total = SubTotal - Descuento;
                /*
                if (Descuento > 0)
                {
                    TotalIEPS = _iEPS > 0 ? SubTotal * (_iEPS / 100) : 0;
                    SubTotal = SubTotal + TotalIEPS;
                    TotalIva = iva > 0 ? SubTotal * (iva / 100) : 0;

                    TotalPartida = SubTotal + TotalIva;
                    SubTotal = SubTotal - TotalIEPS;

                }
                */
                if (Total >= 0)
                {
                    ttTotal.Hide(txtTotal);
                    txtTotal.Text = Util.FormtDouDec(Total);
                }
                else
                {
                    Util.MsjBox(ttTotal, txtTotal, "Descuento", "Descuento: Contiene caracteres no validos. Sugiere: 0", ToolTipIcon.Error);
                    ErrCalc = false;
                }

            }
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e, 1);
        }

        private void CargaParamAlma(String CveAlm)
        {
            clsCfgAlmacen cd = new clsCfgAlmacen(db, CveAlm);
            cfgAlma = cd.ConfigAlmacen();

        }
    }
}
