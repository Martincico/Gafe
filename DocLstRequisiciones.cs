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
    public partial class DocLstRequisiciones : MetroForm
    {
        clsCfgDocumento ConfigDoc;
        DataTable dt = null;
        DataRow row = null;
        MsSql db;
        private SqlDataAdapter DatosTbl;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        private String CveDoc;
        private String NameDoc;
        private clsUtil uT;

        public DocLstRequisiciones(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, String CveDc, String _NameDoc)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;
            CveDoc = CveDc;
            clsCfgDocumento cd = new clsCfgDocumento(CveDoc, db);
            ConfigDoc = cd.ConfigDoc();
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            NameDoc = _NameDoc;

            this.Text = "LISTADO DE "+NameDoc;

            cmdAutorizarTodo.Visible = ConfigDoc.SolicitaAutorizar == 1 ? true : false;

            if (ConfigDoc.AfectaInventario == 1 || !ConfigDoc.DocRel.Equals(""))
            {
                btnGenerarDoc.Visible = true;
                btnGenerarDoc.Text = ConfigDoc.txtBotonDocRel;
            }
        }

        private void DocLstRequisiciones_Load(object sender, EventArgs e)
        {
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();
            String st = "";
            switch (NameDoc)
            {
                case "REQUISICIÓN": st = "R"; break;
                case "COTIZACIÓN": st = "C";  break;
                case "ORDEN DE COMPRA": st = "O"; break;
                case "COMPRAS": st = "CO"; break;
            }

            clsUsPerfil up = uT.BuscarIdNodo("1Prov" + st + "AG");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "ED");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "EL");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "CO");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Prov" + st + "MI");
            AcCOP = (up != null) ? up.Acceso : 0;
            btnGenerarDoc.Enabled = (AcCOP == 1) ? true : false;

            /*
            
            up = uT.BuscarIdNodo("1Prov" + st + "IM");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;
            
            up = uT.BuscarIdNodo("1Prov" + st + "BU");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;
            */


            LlecboAlmaOri(user.AlmacenUsa);

            LlenaGridView();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(int.Parse(ConfigDoc.Foliador),user.FecServer);
            //llamar la forma de regdoc
            if (movimiento.CompareTo("Error") != 0)
            {
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor,  1, ConfigDoc, movimiento, CveDoc, NameDoc);
                Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Rcap.ShowDialog();
                LlenaGridView();
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro", "ERROR "+ NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            try
            { 
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyDocumento = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                if (rq.keyDocumento.Length == 0)
                {
                    MessageBoxAdv.Show("Documento en uso por otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor, 2, ConfigDoc, rq.keyDocumento, CveDoc, NameDoc);
                        Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                        Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                        Rcap.ShowDialog();
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBoxAdv.Show("Error:" + ex.Message, "Alerta", MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation);
                    }
                    LlenaGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            try
            {
                String idMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                String Doc = grdView[1, grdView.CurrentRow.Index].Value.ToString();
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro: " + Doc,
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rq.keyidMov = idMov;
                    db.IniciaTrans();

                    if (ConfigDoc.AfectaInventario == 1)
                    {
                        frmLstInventarioMovtos Ventana = new frmLstInventarioMovtos(db, user, StiloColor);
                        int Rsp = Ventana.DelMigraMov(idMov);
                        String err = "";
                        if (Rsp < 0)
                        {
                            db.CancelaTrans();
                            switch (Rsp)
                            {
                                case -1: err = "Existe un error al eliminar registro"; break;
                                case -2: err = "Existe un error al afectar existencias de relación"; break;
                                case -3: err = "Existe un error al afectar existencias"; break;
                            }
                            MessageBoxAdv.Show(err, "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    
                    if (rq.EliminaDocumento() >= 1)
                    {
                        MessageBoxAdv.Show("Registro eliminado", "Confirmacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        db.TerminaTrans();
                    }
                    else
                    {
                        MessageBoxAdv.Show("Existe un error al eliminar", "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.CancelaTrans();
                    }
                }
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyDocumento = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                if (rq.keyDocumento.Length == 0)
                {
                    MessageBoxAdv.Show("Documento en uso por otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor, 3, ConfigDoc, rq.keyDocumento, CveDoc, NameDoc);
                    Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                    Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                    Rcap.ShowDialog();
                    LlenaGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void LlenaGridView()
        {
            String AlmOri = Convert.ToString(cboAlmacen.SelectedValue);
            String FIni = dtFechaInicio.Value.ToString("dd/MM/yyyy");
            String FFin = dtFechaFin.Value.ToString("dd/MM/yyyy");

            DocPuiRequisiciones pui = new DocPuiRequisiciones(db);
            DatosTbl = pui.ListarDocumentos(AlmOri, FIni, FFin, CveDoc);
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();
                grdView.DataSource = Ds.Tables[0];

                grdView.Columns["ClaveAlmacen"].Visible = false;
                grdView.Columns["CveProveedor"].Visible = false;
                grdView.Columns["EsperaAceptacion"].Visible = false;
                grdView.Columns["DocOrigen"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlecboAlmaOri(String CveUser)
        {
            PuiCatAlmacenes lin = new PuiCatAlmacenes(db);
            dt = lin.CboInv_CatAlmacenes();
            row = dt.NewRow();
            row["ClaveAlmacen"] = "0";
            row["Descripcion"] = "TODOS ";
            dt.Rows.Add(row);

            cboAlmacen.DataSource = dt;

            cboAlmacen.ValueMember = "ClaveAlmacen";
            cboAlmacen.DisplayMember = "Descripcion";

            cboAlmacen.SelectedValue = CveUser;
        }

        private void DocLstRequisiciones_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cmdRestablecer_Click(object sender, EventArgs e)
        {
            dtFechaFin.Value = dtFechaFin.MaxDate;

            dtFechaInicio.Value = DateTime.Now;
            cboAlmacen.SelectedValue = user.AlmacenUsa;
            dtFechaFin.Value = DateTime.Now;
        }

        private void cboAlmaOri_SelectedValueChanged(object sender, EventArgs e)
        {
            string val = Convert.ToString(cboAlmacen.SelectedValue);
            if (!val.Equals("System.Data.DataRowView") && !val.Equals(""))
            {
                LlenaGridView();
            }
        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                dtFechaInicio.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                LlenaGridView();
        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                dtFechaFin.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                LlenaGridView();
        }

        private void cmdAutorizarTodo_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfigDoc.AfectaInventario == 1)
                {
                    string IdDocOrg = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    string strprov = grdView[11, grdView.CurrentRow.Index].Value.ToString();
                    frmRegInventarioMovtos Ventana = new frmRegInventarioMovtos(db, StiloColor,"MINV", user);
                
                    int rsp = Ventana.MigrarDocDetToMovDet(ConfigDoc.CveTipoMov, strprov, IdDocOrg, Convert.ToString(cboAlmacen.SelectedValue));
                    if (rsp != 0)
                    {
                        string msj = "";
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
                        MessageBoxAdv.Show(msj, "Error al guardar el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    funcParaMigrarDoc();

                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }

        private void funcParaMigrarDoc()
        {
            clsCfgDocumento Ccd = new clsCfgDocumento(ConfigDoc.DocRel, db);
            clsCfgDocumento CfgDocTrans = Ccd.ConfigDoc();
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(int.Parse(CfgDocTrans.Foliador), user.FecServer);
            rq.keyidMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            if (movimiento.CompareTo("Error") != 0)
            {
                rq.keyidMovNew = movimiento;
                rq.cmpCveDoc = ConfigDoc.DocRel;
                rq.cmpDocOrigen = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                int _fol = 5000;
                string _alm = "5000";
                string _ser = "";
                rq.cmpSerie = _ser;
                if (CfgDocTrans.UsaSerie == 1)
                {
                    _alm = Convert.ToString(cboAlmacen.SelectedValue);
                    _ser = "SERIE";//Poner serie seleccionada
                    clsCfgDocSeries cds = new clsCfgDocSeries(_alm, ConfigDoc.DocRel, _ser, db);
                    clsCfgDocSeries CfgDocSerie = cds.ConfigDocSerie();

                    _fol = int.Parse(CfgDocSerie.CodFoliador);
                    
                    rq.cmpSerie = _ser;
                }

                if (rq.GuardarDocTransf(_fol, _alm, CfgDocTrans.CveDoc, _ser) == 1)
                {
                    MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxAdv.Show("Existe un error insertar registro", "ERROR " + NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro en blanco", "ERROR "+ NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdView_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip MnuDer = new ContextMenuStrip();
                int position_xy_mouse_row = grdView.HitTest(e.X, e.Y).RowIndex;

                //MessageBox.Show(position_xy_mouse_row.ToString());

                if (position_xy_mouse_row >= 0)
                {
                    MnuDer.Items.Add("Espera aceptación").Name = "EsperaAceptacion";
                }

                MnuDer.Show(grdView, new Point(e.X, e.Y));

                MnuDer.ItemClicked += new ToolStripItemClickedEventHandler(MnuDel_Click);
            }
            */
        }

        private void MnuDel_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            /*
            switch (e.ClickedItem.Name.ToString())
            {
                case "EsperaAceptacion":
                    MessageBoxAdv.Show(e.ClickedItem.Name.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            */
        }

        private void grdView_SelectionChanged(object sender, EventArgs e)
        {
            if (grdView.SelectedCells.Count > 0)
            {
                int EspAcept = Convert.ToInt32(grdView[12, grdView.CurrentRow.Index].Value.ToString());
                //btnGenerarDoc.Enabled = EspAcept == 1 ? true : false;
                Boolean rspAcep = EspAcept == 1 ? true : false;


                btnGenerarDoc.Enabled = rspAcep;
                cmEditar.Enabled = rspAcep;

            }
                //Do_Something_With_It(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                String cv = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
                rq.keyidMov = cv;
                DataTable dt = rq.DocCabPrint();
                fmtoDocumentos print = new fmtoDocumentos();
                //this.Cursor = Cursors.AppStarting;
                String pict = Convert.ToString(GAFE.Properties.Resources.Editar);


                print.DoctosCab(db,dt,cv,"Farmacias Salinas G", pict, NameDoc);
                //this.Cursor = Cursors.Default;
                print.ShowDialog();
                 
                                
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }

        }
    }
}
