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
        private String NameDoc;

        private Boolean isDataSaved = false;//Valida el cerrar el doc

        List<DocPartidasReq> PARTIDAS;

        private Boolean AutTodo = false;

        public DocRegistroRequisicion()
        {
            InitializeComponent();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        public DocRegistroRequisicion(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, int op, 
            clsCfgDocumento CfgDoc,string mov, String _CveDoc, string _namedoc)
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

            NameDoc = _namedoc;

            this.Text = "registro de DE " + NameDoc;

            FechaExpedicion.Enabled = (ConfigDoc.EditaFecha == 1)?true:false;

            if (op>=2)
            {
                getRegistro();
                if(op==3)
                {
                    HD_Botones(3,false);
                }
            }

            panel1.Size = new Size(785, 73);
            panel2.Location = new Point(3, 82);
            this.Size = this.MinimumSize;

            if (ConfigDoc.UsaProveedor == 1)
            {
                lblProveedor.Visible = true;
                cboProveedor.Visible = true;
                if (ConfigDoc.UsaCliente == 0)
                {
                    lblProveedor.Location = new Point(5, 68);
                    cboProveedor.Location = new Point(78, 65);
                }
                LlecboProveedor();
                panel1.Size = new Size(785, 100);
                panel2.Location = new Point(3, 109);
                this.Size = this.MaximumSize;
            }

            if(ConfigDoc.SolicitaAutorizar ==1)
            {
                if(Opcion ==2)
                    cmdAutorizarTodo.Visible = true;
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

        private void LlecboProveedor()
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            cboProveedor.DataSource = lin.CboInv_CatAlmacenes();
            cboProveedor.ValueMember = "ClaveAlmacen";
            cboProveedor.DisplayMember = "Descripcion";

            cboProveedor.SelectedValue = user.AlmacenUsa;
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
                                int _fol = 5000;
                                string _alm = "5000";
                                string _ser = "";
                                if (ConfigDoc.UsaSerie == 1)
                                {
                                    _fol = int.Parse(CfgDocSerie.CodFoliador);
                                    _alm = cboAlmacen.SelectedValue.ToString();
                                    _ser = cboSerie.SelectedValue.ToString();
                                }

                                if (sRq.GuardarDocumento( _fol, _alm, ConfigDoc.CveDoc,_ser ,Opcion) == 1)
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
            sRq.cmpFechaExpedicion = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", FechaExpedicion.Value));

            if (Opcion==1)
                sRq.cmpFechaModificacion = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", FechaExpedicion.Value));
            else
                sRq.cmpFechaModificacion = user.FecServer;

            sRq.cmpClaveImpuesto = "";
            sRq.cmpImpuesto = Convert.ToDouble(txtIva.Text);
            sRq.cmpDescuento = 0;
            sRq.cmpSubTotal = Convert.ToDouble(txtSubTotal.Text);
            sRq.cmpTotal = Convert.ToDouble(txtTotal.Text);
            sRq.cmpObservaciones = txtObservaciones.Text;
            sRq.cmpEstatus = "1";
            sRq.cmpAutorizado =false;
            
            if (ConfigDoc.UsaProveedor == 1)
            {
                sRq.cmpCveProveedor = cboProveedor.SelectedValue.ToString();
            }

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
                if (partida.CveArticulo != null)
                {
                    PARTIDAS.Add(partida);
                    for (int i = 0; i < PARTIDAS.Count; i++)
                    {
                        PARTIDAS[i].idMov = idmovimiento;
                        PARTIDAS[i].Serie = "";
                        PARTIDAS[i].Partida = i + 1;
                        PARTIDAS[i].ClaveAlmacen = cboAlmacen.SelectedValue.ToString();
                        PARTIDAS[i].Autorizado = false;
                        subTotal = subTotal + PARTIDAS[i].SubTotal;
                        impuesto = impuesto + PARTIDAS[i].Impuesto;
                        total = total + PARTIDAS[i].Total;
                    }
                    txtSubTotal.Text = subTotal.ToString();
                    txtIva.Text = impuesto.ToString();
                    txtTotal.Text = total.ToString();

                    LLenaGrid();

                }

            }
               
        }



        private void EditPartida_Click(object sender, EventArgs e)
        {
            try
            {
                double subTotal = 0, impuesto = 0, total = 0;
                int partida = Convert.ToInt32(grdViewD[6, grdViewD.CurrentRow.Index].Value);

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

                LLenaGrid();
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
                LLenaGrid();

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
            if (ConfigDoc.UsaSerie == 1)
            {
                cboSerie.SelectedValue = sRq.cmpSerie;
            }
            txtNumDoc.Text = Convert.ToString(sRq.cmpNumDoc);
            cboAlmacen.SelectedValue = sRq.cmpClaveAlmacen;
            FechaExpedicion.Value = sRq.cmpFechaExpedicion;
            txtDescuento.Text = Convert.ToString(sRq.cmpDescuento);
            txtObservaciones.Text = sRq.cmpObservaciones;
            if (ConfigDoc.UsaProveedor == 1)
            {
                cboProveedor.SelectedValue = sRq.cmpCveProveedor;
            }
            
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
                partida.Autorizado = Boolean.Parse(row["Autorizado"].ToString());

                subTotal = subTotal + Convert.ToDouble(row["SubTotal"].ToString());
                impuesto = impuesto + Convert.ToDouble(row["Impuesto"].ToString());
                total = total + Convert.ToDouble(row["Total"].ToString());

                PARTIDAS.Add(partida);

            }

            txtSubTotal.Text = subTotal.ToString();
            txtIva.Text = impuesto.ToString();
            txtTotal.Text = total.ToString();

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
            
            cboSerie.DataSource = null;
            cboSerie.Items.Clear();
            PuiCatCfgDocSerie lin = new PuiCatCfgDocSerie(db);
            cboSerie.DataSource = lin.CbollenaSeries(CveAlm, CveDoc);

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

            if (ConfigDoc.UsaProveedor == 1)
            {
                if (cboProveedor.SelectedIndex < 0)
                {
                    rsp = 1;
                    msj += "No se ha seleccinado ningún proveedor.\n";
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
                        HD_Botones(1, true);
                    }
                }
            }
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
            grdViewD.Columns["CveArticulo"].HeaderText = "Clave";
            grdViewD.Columns["CveUmedida1"].HeaderText = "U.Medida";
            //grdViewD.Columns["Autorizado"].Visible = false;
            grdViewD.Columns["CveArticulo"].Frozen = true;//Inmovilizar columna
            if (Opcion == 1)
                grdViewD.Columns["Autorizado"].Visible = false;
            else
            {
                grdViewD.Columns["Autorizado"].Width = 30;
                grdViewD.Columns["Autorizado"].Visible = (ConfigDoc.SolicitaAutorizar == 1) ? true : false;
            }

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
                MessageBox.Show("Tienes que seleccionar una partida\n Error:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
