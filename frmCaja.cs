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
    public partial class frmCaja : MetroForm
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

        private int Opcion;
        private int OptPartd = 1;

        private Boolean isDataSaved = false;

        private string idmovimiento = "";

        List<DocPartidasReq> PARTIDAS;
        clsCfgDocumento ConfigDoc;

        private String CveDoc;

        public frmCaja()
        {
            InitializeComponent();
        }


        public frmCaja(MsSql Odat, Form lg, DatCfgUsuario DatUsr, int Opc, String CveDc)
        {
            InitializeComponent();
            
            db = Odat;
            user = DatUsr;
            Flg = lg;
            //SelectTemaUser(user.StiloTema);
            Opcion = Opc;
            CveDoc = CveDc;

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
                InhControles(false, 1);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    MessageBox.Show("F1 pressed.", "Key Down Event");
                    cmdArticulo_Click(sender, e);
                    break;

                case Keys.F2:
                    MessageBox.Show("F2 pressed.", "Key Down Event");

                    break;

                case Keys.F4: CancelEditPart();
                    break;
                case Keys.Escape:
                    isDataSaved = true;
                    FrmClose();

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

            InhControles(false,0);
            txtCantidad.Enabled = true;
        }

        private void AbrirPArtidas()
        {
            double subTotal = 0, total = 0;
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
                        LimpiaVar(0);
                        InhControles(true,0);
                        txtClaveArticulo.Focus();
                        lblTotalArticulos.Text = lblTotalArticulos.Text + " " + grdViewD.RowCount;
                        OptPartd = 1;
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
            if(IdArt != null)
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
                getPrecio();
                txtCantidad.Focus();
                txtClaveArticulo.Enabled = false;
                cmdArticulo.Enabled = false;
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
                    getPrecio();
                    txtCantidad.Focus();
                    txtClaveArticulo.Enabled = false;
                    cmdArticulo.Enabled = false;
                }
                else
                {
                    LimpiaVar(0);
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


            lblPrecioArt.Text = ObjA[4].ToString();

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

        private void LimpiaVar(int _All)
        {

            IdArt = "";
            txtClaveArticulo.Text = "";
            lblDescArticulo.Text = "";
            lblPrecioArt.Text = "0";
            txtCantidad.Text = "1";

            if (_All == 1)
            {
                lblSubTotal.Text = "0";
                txtDescuento.Text = "0";
                lblSubTotal.Text = "0";
                //limppiar el grid
            }

            CveImp = "";
            CveUmed = "";
            
            txtClaveArticulo.Focus();
            
        }

        private void InhControles(Boolean Opt, int _all)
        {
            txtClaveArticulo.Enabled = Opt;
            txtCantidad.Enabled = Opt;
            txtDescuento.Enabled = Opt;
            cmdArticulo.Enabled = Opt;

            if (_all==1)
            {
                btnEditar.Enabled = Opt;
                btnEliminar.Enabled = Opt;
                cmdArticulo.Enabled = Opt;
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

        private void FrmClose()
        {
            if (!isDataSaved)
            {
                
                MessageBox.Show("You must save first.");
            }
            else
            {
                //e.Cancel = false;
                MessageBox.Show("Goodbye.");
                Flg.Close();

            }

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Boolean DellAll = true;
            //int RspVal = -1;

            switch (Opcion)
            {
                case 1:
                    if (grdViewD.RowCount > 0)
                    {
                        DialogResult rsp = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rsp == DialogResult.Yes)
                        {
                            /*
                            if (RspVal == 0)
                            {
                            */
                                DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                                SetValues(sRq);
                                int _fol = 5000;
                                string _alm = "5000";
                                string _ser = "";

                                if (sRq.GuardarDocumento( _fol, _alm, ConfigDoc.ClaveDoc,_ser ,Opcion) == 1)
                                {
                                    MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isDataSaved = true;
                                    DellAll = false;
                                }
                            //}
                        }

                    }
                    break;
                case 2:
                    DialogResult rspw = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rspw == DialogResult.Yes)
                    {
                        /*
                        RspVal = Valida();
                        if (RspVal == 0)
                        {
                        */
                            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                            SetValues(sRq);
                            if (sRq.ActualizaDocumento(Opcion) == 1)
                            {
                                MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isDataSaved = true;
                                DellAll = false;
                            }
                        //}
                    }
                break;
                default: isDataSaved = true; DellAll = false; break;
            }
            /*
            if (RspVal <= 0)
            {
            */
                if (DellAll)
                    FrmClose();

            //}
        }

        private void SetValues(DocPuiRequisiciones sRq)
        {
            sRq.cmpSerie = "";
            sRq.cmpCveProveedor = "";
            sRq.cmpCveCliente = cboCliente.SelectedValue.ToString();
            sRq.keyidMov = idmovimiento;
            sRq.keyDocumento = lblTicket.Text ;
            sRq.cmpSerie = "";

            sRq.cmpNumDoc = Convert.ToInt64(lblTicket.Text);
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
            sRq.cmpEstatus = "1";
            sRq.cmpAutorizado = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);
                pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                OptPartd = 2;
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

        private void CancelEditPart()
        {
            LimpiaVar(0);
            InhControles(true, 0);
            if(OptPartd == 2)
            {
                PARTIDAS.Add(pr);
                ReasgIdPart();
            }

            LLenaGrid();
            OptPartd = 1;
            txtClaveArticulo.Focus();

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
            lblTotalArticulos.Text = lblTotalArticulos.Text + " " + grdViewD.RowCount;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);
                pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                OptPartd = 2;
                PARTIDAS.RemoveAt(idx);
                ReasgIdPart();
                LLenaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

