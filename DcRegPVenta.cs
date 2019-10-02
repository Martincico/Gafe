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
using System.Runtime.Serialization.Formatters.Binary;

namespace GAFE
{
    public partial class DcRegPVenta : MetroForm
    {

        private MsSql db = null;
        public DatCfgUsuario user;
        Form Flg;
        private clsUtil uT;
        clsStiloTemas NewColor = new clsStiloTemas();

        public DocPartidasReq partida;
        private DocPartidasReq pr;

        private String IdArt = "";
        private String CveImp = "";
        private String CveUmed = "";


        private String LstPre_Clie = "";
        private String LstPre_Alm = "";

        private int OptPartd = 1;

        private string idmovimiento = "";

        List<DocPartidasReq> PARTIDAS;
        clsCfgDocumento ConfigDoc;

        private String CveDoc;
        private Boolean isDataSaved = false;//Valida el cerrar el doc

        //Form without bord and resize
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 65;   // Caption bar height;

        private int Ww;

        public clsStiloTemas StiloColor;

        public DcRegPVenta()
        {
            InitializeComponent();
        }


        public DcRegPVenta(MsSql Odat, Form lg, DatCfgUsuario DatUsr, int Opc,
            String _CveDoc, string _namedoc, string _cveventa = "")
        {
            InitializeComponent();
            
            db = Odat;
            user = DatUsr;
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

            StiloColor = NewColor;


            LlecboCliente();

            GetDatoAlmacen();

            PARTIDAS = new List<DocPartidasReq>();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
            
            
            this.FormBorderStyle = FormBorderStyle.None; //Form without bord and resize
            this.DoubleBuffered = true; //Form without bord and resize
            this.SetStyle(ControlStyles.ResizeRedraw, true); //Form without bord and resize


            this.Size = this.MinimumSize;
            

        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);

            clsCfgDocumento cd = new clsCfgDocumento(CveDoc, db);
            ConfigDoc = cd.ConfigDoc();

            idmovimiento = rq.AgregarDocEnBlanco(int.Parse(ConfigDoc.Foliador), user.FecServer);
            if (!idmovimiento.Equals(""))
            {
                this.KeyDown += new KeyEventHandler(this.OnKeyDown);
                InhControles(true,0);
            }
            else
                InhControles(false, 0);

            Ww = this.Width - lblDescArticulo.Width;

            ResetControles(0);
            //LLenaGrid();

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            DialogResult rspw ;
            switch (e.KeyCode)
            {
                
                case Keys.F2://Muestra Articulos
                    if(OptPartd == 1)
                        ShowVentArt();
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
                    }
                    break;
                case Keys.Escape:
                    switch(OptPartd)
                    {
                        case 1: FrmClose(); break;
                        case 2: CancelEditPart(); break;
                        case 3: ResetControles(0); InhControles(true, 0); break;
                    }
  
                    break;
                default:
                    //MessageBox.Show(e.KeyCode.ToString() + " pressed.", "Key Down Event");
                    break;
            }
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
            lblDescArticulo.Text = part.Descripcion;
            lblPrecioArt.Text = part.Precio.ToString();
            //txtDescuento.Text = (part.Descuento > 0) ? part.Descuento.ToString() : "0.00";
            //lblPrecioArtNeto.Text = part.PrecioNeto.ToString();
            txtCantidad.Text = part.Cantidad.ToString();
            //txtImpuesto.Text = part.Impuesto.ToString();
            //txtSubtotal.Text = part.SubTotal.ToString();
            //txtTotal.Text = part.Total.ToString();
            //txtIva.Text = part.ImpuestoValor.ToString();

            InhControles(false,1);
            txtCantidad.Enabled = true;

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
            partida.Precio = Convert.ToDouble(lblPrecioArt.Text);
            subTotal = Convert.ToDouble(lblPrecioArt.Text) * Convert.ToDouble(txtCantidad.Text);
            partida.Descuento = 0;
            partida.PrecioNeto = Convert.ToDouble(lblPrecioArt.Text);
            partida.Impuesto = 0;;
            partida.SubTotal = subTotal;
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
            grdViewD.Columns["Precio"].Visible = false;
            grdViewD.Columns["SubTotal"].Visible = false;
            grdViewD.Columns["Cantidad"].Width = 40;
            grdViewD.Columns["Cantidad"].HeaderText = "Cant.";

            grdViewD.Columns["FechaCaptura"].Visible = false;
            grdViewD.Columns["FechaModificacion"].Visible = false;




        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            partida = new DocPartidasReq();
            if (e.KeyChar == (char)Keys.Enter)
            { 
                AbrirPArtidas();

                if (partida != null)
                {
                    if (!partida.CveArticulo.Equals(""))
                    {
                        double subTotal = 0, total = 0;
                        PARTIDAS.Add(partida);
                        for (int i = 0; i < PARTIDAS.Count; i++)
                        {
                            PARTIDAS[i].idMov = idmovimiento;
                            PARTIDAS[i].Serie = "";
                            PARTIDAS[i].Partida = i + 1;
                            PARTIDAS[i].ClaveAlmacen = user.AlmacenUsa;
                            PARTIDAS[i].Autorizado = false;
                            subTotal = subTotal + PARTIDAS[i].SubTotal;
                            total = total + PARTIDAS[i].Total;
                        }
                        lblSubTotal.Text = subTotal.ToString();
                        lblTotal.Text = total.ToString();

                        LLenaGrid();
                        ResetControles(1);
                        InhControles(true,1);
                        OptPartd = 1;
                    }
                }
                lblTotalArticulos.Text = Convert.ToString(grdViewD.RowCount);
                ShowVentArt();
            }
            
        }

        private void ShowVentArt()
        {

            frmLstArticulos ar = new frmLstArticulos(db, user, StiloColor, 3);
            ar.CaptionBarColor = ColorTranslator.FromHtml(NewColor.Encabezado);
            ar.CaptionForeColor = ColorTranslator.FromHtml(NewColor.FontColor);
            ar.ShowDialog();
            IdArt = ar.dv[0];
            if (IdArt != null)
            {
                txtClaveArticulo.Text = ar.dv[0];
                lblDescArticulo.Text = ar.dv[1];
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

                if (getPrecio() == 1)
                {
                    ResetControles(1);
                    MessageBoxAdv.Show("No es posible su venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtCantidad.Focus();
                    txtClaveArticulo.Enabled = false;
                }

            }
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
                    lblDescArticulo.Text = Art.cmpDescripcion;

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
                    if (getPrecio() == 1)
                    {
                        ResetControles(1);
                        MessageBoxAdv.Show("No es posible su venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtCantidad.Focus();
                        txtClaveArticulo.Enabled = false;
                    }
                }
                else
                {
                    ResetControles(1);
                    MessageBoxAdv.Show("No se encuentra el registro", "Error de busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if(Err == 0)
                lblPrecioArt.Text = ObjA[4].ToString();

            return Err;

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
                            Boolean rp = false;
                            if (grdViewD.RowCount > 0)
                            {
                                Aceptar_click(0);
                                rp = isDataSaved;
                            }
                            if (!rp)
                            {
                                DocPuiRequisiciones InvMast = new DocPuiRequisiciones(db);
                                InvMast.keyidMov = idmovimiento;
                                InvMast.EliminaDocumento();
                            }
                            Flg.Close();
                        break;
                    }
                }
                else
                {
                    CancelEditPart(); 
                }
            }
            else
            {
                Flg.Close();
            }



        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptar_click(1);
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
                            Agregar(Exi);
                        }
                    }
                    break;
                case 2:
                    DialogResult rspw = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rspw == DialogResult.Yes)
                    {
                        DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                        SetValues(sRq);
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
                    break;
                case 3:
                    ResetControles(0);
                    InhControles(true, 0);
                    break;
            }
        }

        private void Agregar(int Exi)
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            SetValues(sRq);
            int _fol = 5000;
            string _alm = "5000";
            string _ser = "";
            int rsp = 0;

            if (sRq.GuardarDocumento(_fol, _alm, ConfigDoc.CveDoc, _ser, OptPartd) == 1)
            {
                if (ConfigDoc.AfectaInventario == 1)
                {
                    string strprov = Convert.ToString(cboCliente.SelectedValue);
                    frmRegInventarioMovtos Ventana = new frmRegInventarioMovtos(db, null, "MINV", user);

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
                            case 4: msj = "Traspaso: Registro en blanco"; break;
                            case 5: msj = "Traspaso: Al guardar cabecero"; break;
                            case 6: msj = "Traspaso: Al guardar detalle partidas"; break;
                            case 7: msj = "Traspaso: Al afectar existencias"; break;
                            case 8: msj = "Traspaso: Al actualizar detalle partidas"; break;
                            default: msj = "Error desconocido"; break;
                        }
                        MessageBoxAdv.Show(msj, "Afectando a inventarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                PrintDoc(idmovimiento);

                if (rsp == 0 && Exi == 1)
                {
                    ResetControles(0);

                    DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                    idmovimiento = rq.AgregarDocEnBlanco(int.Parse(ConfigDoc.Foliador), user.FecServer);
                    if (!idmovimiento.Equals(""))
                    {
                        this.KeyDown += new KeyEventHandler(this.OnKeyDown);
                        InhControles(true, 0);
                    }
                    else
                        InhControles(false, 0);

                    isDataSaved = true;
                }




            }
            else
            {
                isDataSaved = false;
                MessageBoxAdv.Show("Existen un error al guardar", "Guardando documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void SetValues(DocPuiRequisiciones sRq)
        {
            sRq.cmpSerie = "";
            sRq.cmpCveProveedor = "";
            sRq.cmpCveCliente = cboCliente.SelectedValue.ToString();
            sRq.keyidMov = idmovimiento;
            sRq.keyDocumento = "" ;
            sRq.cmpSerie = "";

            sRq.cmpNumDoc = 0;
            sRq.cmpCveDoc = CveDoc;
            sRq.cmpClaveAlmacen = user.AlmacenUsa;
            sRq.cmpFechaExpedicion = user.FecServer;

            sRq.cmpFechaModificacion = user.FecServer;

            sRq.cmpClaveImpuesto = CveImp;
            sRq.cmpImpuesto = 0;
            sRq.cmpDescuento = 0;
            sRq.cmpSubTotal = Convert.ToDouble(lblSubTotal.Text);
            sRq.cmpTotal = Convert.ToDouble(lblTotal.Text);
            sRq.cmpObservaciones = "";
            sRq.cmpEstatus = 1;
            sRq.cmpAutorizado = false;
            sRq.PartidasDoc = PARTIDAS;

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
                lblTotalArticulos.Text = Convert.ToString(grdViewD.RowCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ShowVentArt();

        }

        private void ReasgIdPart()
        {
            double subTotal = 0, total = 0;

            for (int i = 0; i < PARTIDAS.Count; i++)
            {
                PARTIDAS[i].Partida = i + 1;
                subTotal = subTotal + PARTIDAS[i].SubTotal;
                total = total + PARTIDAS[i].Total;
            }

            lblSubTotal.Text = subTotal.ToString();
            lblTotal.Text = total.ToString();
            lblTotalArticulos.Text = Convert.ToString(grdViewD.RowCount); ;
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
                lblTotalArticulos.Text = Convert.ToString(grdViewD.RowCount);
                OptPartd = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            VerVentas_Click();
        }

        private void VerVentas_Click()
        {
            DcLstPventas LPv = new DcLstPventas(db, user, CveDoc, "LISTADO DE VENTAS");
            LPv.ShowDialog();
            if (!LPv.dv[0].Equals(""))
            {
                getRegistro(LPv.dv[0]);
                InhControles(false, 0);
                OptPartd = 3;
            }
            
            if(OptPartd != 3)
            {
                txtClaveArticulo.Focus();
            }
        }

        private void getRegistro(String IdM)
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            sRq.keyidMov = IdM;
            sRq.GetDocumento();
            /*
            if (ConfigDoc.UsaSerie == 1)
            {
                cboSerie.SelectedValue = sRq.cmpSerie;
            }
            
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


            double subTotal = 0, impuesto = 0, total = 0;

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

                PARTIDAS.Add(partida);

            }

            lblSubTotal.Text = subTotal.ToString();
            lblTotal.Text = total.ToString();

            LLenaGrid();
        }


        
        
        protected override void OnPaint(PaintEventArgs e)
        {
            //Form without bord and resize
            //Se dibuja un reactungolo pero sin fondo para que puedan mover
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.Transparent, rc);

        }
        
        protected override void WndProc(ref Message m)
        {
            //Form without bord and resize

            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                
            }
            base.WndProc(ref m);
        }
        

        private void DcRegPVenta_Resize(object sender, EventArgs e)
        {
            /*
                        int t = (this.Height * 12) / 100;
                        int l = (this.Width * 70) / 100;
                        int w = (this.Width * 42)/100;

                        cboCliente.Width = w;

                        w = (this.Width * 27) / 100;
                        txtClaveArticulo.Width = w;
                        txtClaveArticulo.Left = l;
                        */
                        //lblDescArticulo.Width = this.Width - Ww;
                    /*

                        l = (this.Width * 67) / 100;
                        lblDescArticulo.Left = l;
                        lblDescArticulo.Top = t-5;


                        lblDescArticulo.Width = lblDescArticulo.Width +  w;
                        
                        t = (this.Height * 91) / 400;
                        lblPrecioArt.Top = t ;

                        l = (this.Width * 78) / 100;
                        lblPrecioArt.Left = l;
                        w = (this.Width * 20) / 100;
                        lblPrecioArt.Width = w;
                        */
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
            
            if(_All == 0)
            {
                //pbArticulo
                lblSubTotal.Text = "0";
                txtDescuento.Text = "0";
                lblTotal.Text = "0";
                grdViewD.DataSource = null;
                PARTIDAS = new List<DocPartidasReq>();
                //lblTotalArticulos.Text = "0";
                lblTotalArticulos.Text = Convert.ToString(grdViewD.RowCount);

                OptPartd = 1;
            }
            
            txtClaveArticulo.Focus();
        }

        private void InhControles(Boolean Opt, int _all)
        {
            txtClaveArticulo.Enabled = Opt;
            txtCantidad.Enabled = Opt;
            txtDescuento.Enabled = Opt;

            if (_all == 0)
            {
                btnEditar.Enabled = Opt;
                btnEliminar.Enabled = Opt;
            }

        }


        private void PrintDoc(String cv)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            rq.keyidMov = cv;
            DataTable dt = rq.DocDetPrint();
            fmtoTicket print = new fmtoTicket();
            String pict = Convert.ToString(GAFE.Properties.Resources.Editar);
            print.PrintTicket(db, dt, cv, "Farmacias Salinas G", pict, "TICKET VENTA");
        }
    }
}

