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
        clsCfgDocumento ConfigDoc;
        clsCfgDocSeries CfgDocSerie;

        string idmovimiento;
        private MsSql db = null;
        int Opcion;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        private String CveDoc;

        private Boolean isDataSaved = false;//Valida el cerrar el doc

        List<clsFillCbo> lp;
        List<DocPartidasReq> PARTIDAS;

        public DocRegistroRequisicion()
        {
            InitializeComponent();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        public DocRegistroRequisicion(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op, 
            clsCfgDocumento CfgDoc,string mov, String _CveDoc)
        {
            StiloColor = NewColor;

            db = Odat;
            ConfigDoc = CfgDoc;
            idmovimiento = mov;
            Opcion = op;
            user = DatUsr;
            CveDoc = _CveDoc;
            InitializeComponent();
            PARTIDAS = new List<DocPartidasReq>();

            FechaExpedicion.Enabled = (ConfigDoc.EditaFecha == 1)?true:false;

            if (op>=2)
            {
                getRegistro();
                if(op==3)
                {
                    HD_Botones(3,false);
                }
            }
        }



        private void DocRegistroRequisicion_Load(object sender, EventArgs e)
        {
            LlecboAlmacen();
        }

        private void LlecboAlmacen()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboAlmacen.DataSource = lin.CboInv_CatAlmacenes();
            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";

            cboAlmacen.SelectedValue = user.AlmacenUsa;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Boolean DellAll = true;
            int RspVal = -1;

            switch (Opcion)
            {
                case 1:
                    if (grdViewD.RowCount > 0)
                    {
                        DialogResult rsp = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rsp == DialogResult.Yes)
                        {
                            RspVal = Valida();
                            if (RspVal == 0)
                            {
                                DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                                SetValues(sRq);
                                
                                if (sRq.GuardarDocumento(ConfigDoc.UsaSerie == 1 ? int.Parse(CfgDocSerie.CodFoliador) : 5000, cboAlmacen.SelectedValue.ToString(), ConfigDoc.ClaveDoc, Opcion) == 1)
                                {
                                    MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    isDataSaved = true;
                                    DellAll = false;
                                }
                            }
                        }

                    }
                    break;
                case 2:
                    DialogResult rspw = MessageBox.Show("Quieres guardar el documento", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rspw == DialogResult.Yes)
                    {
                        RspVal = Valida();
                        if (RspVal == 0)
                        {
                            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
                            SetValues(sRq);
                            if (sRq.ActualizaDocumento(Opcion) == 1)
                            {
                                MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                isDataSaved = true;
                                DellAll = false;
                            }
                        }
                    }
                break;
                default: isDataSaved = true; DellAll = false; break;
            }

            if (RspVal <= 0)
            {
                if (DellAll)
                    ConfirmarSalir();

                this.Close();
            }
        }

        private void SetValues(DocPuiRequisiciones sRq)
        {
            sRq.keyidMov = idmovimiento;
            sRq.keyDocumento = (Opcion == 2) ? txtDocumento.Text : "";
            sRq.cmpSerie = cboSerie.SelectedValue.ToString();
            sRq.cmpNumDoc = Convert.ToInt64(txtNumDoc.Text);
            sRq.cmpClaveAlmacen = cboAlmacen.SelectedValue.ToString();
            sRq.cmpFechaExpedicion = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", FechaExpedicion.Value));
            sRq.cmpClaveImpuesto = "";
            sRq.cmpImpuesto = Convert.ToDouble(txtIva.Text);
            sRq.cmpDescuento = 0;
            sRq.cmpSubTotal = Convert.ToDouble(txtSubTotal.Text);
            sRq.cmpTotal = Convert.ToDouble(txtTotal.Text);
            sRq.cmpObservaciones = txtObservaciones.Text;
            sRq.cmpEstatus = "";
            sRq.cmpAutorizado = "N";
            sRq.cmpCancelado = 0;
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
            ConfirmarSalir();
        }


        private void AddPartida_Click(object sender, EventArgs e)
        {
            DocPartidasReq par = new DocPartidasReq();
            DocPartidaRequisiciones DP = new DocPartidaRequisiciones(db, user, StiloColor,1, par);
            DP.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
            DP.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
            DP.ShowDialog();
            
            DocPartidasReq partida = DP.partida;
            double subTotal = 0, impuesto = 0, total = 0;

            if (partida != null)
            {
                PARTIDAS.Add(partida);
                for (int i = 0; i < PARTIDAS.Count; i++)
                {
                    PARTIDAS[i].idMov = idmovimiento;
                    PARTIDAS[i].Serie = "";
                    PARTIDAS[i].Partida = i+1;
                    PARTIDAS[i].ClaveAlmacen = cboAlmacen.SelectedValue.ToString();
                    subTotal = subTotal + PARTIDAS[i].SubTotal;
                    impuesto = impuesto + PARTIDAS[i].Impuesto;
                    total = total + PARTIDAS[i].Total;
                }
                txtSubTotal.Text =  subTotal.ToString();
                txtIva.Text = impuesto.ToString();
                txtTotal.Text = total.ToString();

                grdViewD.DataSource = null;
                grdViewD.DataSource = PARTIDAS;
               
                grdViewD.Columns["idMov"].Visible = false;
                grdViewD.Columns["Documento"].Visible = false;
                grdViewD.Columns["Serie"].Visible = false;
                grdViewD.Columns["Numdoc"].Visible = false;
                grdViewD.Columns["CveImpuesto"].Visible = false;
                grdViewD.Columns["ClaveAlmacen"].Visible = false;
                grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
                grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";

            }
               
        }



        private void EditPartida_Click(object sender, EventArgs e)
        {
            try
            {
                double subTotal = 0, impuesto = 0, total = 0;
                int partida = Convert.ToInt32(grdViewD[5, grdViewD.CurrentRow.Index].Value);

                DocPartidasReq pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);

                DocPartidaRequisiciones prV = new DocPartidaRequisiciones(db, user, StiloColor,2,pr);
                prV.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                prV.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);

                prV.ShowDialog();

                if (prV.partida != null)
                    PARTIDAS.Insert(idx, prV.partida);
                else
                    PARTIDAS.Insert(idx, pr);

                for (int i = 0; i < PARTIDAS.Count; i++)
                {
                    subTotal = subTotal + PARTIDAS[i].SubTotal;
                    impuesto = impuesto + PARTIDAS[i].Impuesto;
                    total = total + PARTIDAS[i].Total;
                }
                txtSubTotal.Text = subTotal.ToString();
                txtIva.Text = impuesto.ToString();
                txtTotal.Text = total.ToString();

                grdViewD.DataSource = null;
                grdViewD.DataSource = PARTIDAS;
               
                grdViewD.Columns["idMov"].Visible = false;
                grdViewD.Columns["Documento"].Visible = false;
                grdViewD.Columns["Serie"].Visible = false;
                grdViewD.Columns["Numdoc"].Visible = false;
                grdViewD.Columns["CveImpuesto"].Visible = false;
                grdViewD.Columns["ClaveAlmacen"].Visible = false;
                grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
                grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:"+ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DelPartida_Click(object sender, EventArgs e)
        {
            try
            {
                double subTotal = 0, impuesto = 0, total = 0;
                int partida = Convert.ToInt32(grdViewD[5, grdViewD.CurrentRow.Index].Value);

                DocPartidasReq pr = PARTIDAS.Find(x => x.Partida.Equals(partida));
                int idx = PARTIDAS.IndexOf(pr);
                PARTIDAS.RemoveAt(idx);

                for (int i = 0; i < PARTIDAS.Count; i++)
                {
                    subTotal = subTotal + PARTIDAS[i].SubTotal;
                    impuesto = impuesto + PARTIDAS[i].Impuesto;
                    total = total + PARTIDAS[i].Total;
                }
                txtSubTotal.Text = subTotal.ToString();
                txtIva.Text = impuesto.ToString();
                txtTotal.Text = total.ToString();

                grdViewD.DataSource = null;
                grdViewD.DataSource = PARTIDAS;

                grdViewD.Columns["idMov"].Visible = false;
                grdViewD.Columns["Documento"].Visible = false;
                grdViewD.Columns["Serie"].Visible = false;
                grdViewD.Columns["Numdoc"].Visible = false;
                grdViewD.Columns["CveImpuesto"].Visible = false;
                grdViewD.Columns["ClaveAlmacen"].Visible = false;
                grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
                grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void getRegistro()
        {
            DocPuiRequisiciones sRq = new DocPuiRequisiciones(db);
            sRq.keyidMov = idmovimiento;
            sRq.GetDocumento();

            txtDocumento.Text = sRq.keyDocumento;
            //txtSerie.Text = sRq.cmpSerie;
            cboSerie.SelectedValue = sRq.cmpSerie;
            txtNumDoc.Text = Convert.ToString(sRq.cmpNumDoc);
            cboAlmacen.SelectedValue = sRq.cmpClaveAlmacen;
            FechaExpedicion.Value = sRq.cmpFechaExpedicion;
            txtDescuento.Text = Convert.ToString(sRq.cmpDescuento);
            txtObservaciones.Text = sRq.cmpObservaciones;

            SqlDataAdapter DatosTbl = sRq.GetDatelleDoc(idmovimiento);
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

                subTotal = subTotal + Convert.ToDouble(row["SubTotal"].ToString());
                impuesto = impuesto + Convert.ToDouble(row["Impuesto"].ToString());
                total = total + Convert.ToDouble(row["Total"].ToString());

                PARTIDAS.Add(partida);

            }

            txtSubTotal.Text = subTotal.ToString();
            txtIva.Text = impuesto.ToString();
            txtTotal.Text = total.ToString();

            grdViewD.DataSource = null;
            grdViewD.DataSource = PARTIDAS;

            grdViewD.Columns["idMov"].Visible = false;
            grdViewD.Columns["Documento"].Visible = false;
            grdViewD.Columns["Serie"].Visible = false;
            grdViewD.Columns["Numdoc"].Visible = false;
            grdViewD.Columns["CveImpuesto"].Visible = false;
            grdViewD.Columns["ClaveAlmacen"].Visible = false;
            grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
            grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";

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
                ConfirmarSalir();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ConfirmarSalir()
        {
            NoGuardaElDocumento();
            isDataSaved = true;
            this.Close();

        }

        private void LlecboSerie(String CveAlm)
        {
            PuiCatCfgDocProv lin = new PuiCatCfgDocProv(db);
            cboSerie.DataSource = lin.CbollenaSerie(CveAlm, CveDoc);

            cboSerie.ValueMember = "Clave";
            cboSerie.DisplayMember = "Descripcion";

            //cboSerie.SelectedValue = CveAlm;
        }

        private int Valida()
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

            if(rsp==1)
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
                cboSerie.Enabled = Bol;
                txtNumDoc.Enabled = Bol;
                cboAlmacen.Enabled = Bol;
                FechaExpedicion.Enabled = Bol;
                txtDescuento.Enabled = Bol;
                txtObservaciones.Enabled = Bol;
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
                    if (ConfigDoc.UsaSerie == 1)
                    {
                        LlecboSerie(val);
                        cboSerie.Enabled = true;
                    }
                    else
                    {
                        HD_Botones(1, false);
                    }
                }
            }
        }
    }
}
