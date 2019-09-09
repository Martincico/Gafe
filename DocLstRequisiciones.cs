﻿using System;
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
        DateTime FecDia;
        clsCfgDocumento ConfigDoc;
        DataTable dt = null;
        DataRow row = null;
        MsSql db;
        private SqlDataAdapter DatosTbl;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        private String CveDoc;
        private String NameDoc;

        public DocLstRequisiciones(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, String CveDc, String _NameDoc)
        {
            InitializeComponent();
            FecDia = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Today));
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
            if(!ConfigDoc.DocRel.Equals(""))
            {
                btnGenerarDoc.Visible = true;
                btnGenerarDoc.Text = ConfigDoc.txtBotonDocRel;
            }
        }

        private void DocLstRequisiciones_Load(object sender, EventArgs e)
        {
            LlecboAlmaOri(user.AlmacenUsa);

            LlenaGridView();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(int.Parse(ConfigDoc.Foliador),FecDia);
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
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            rq.keyDocumento = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            if (rq.keyDocumento.Length == 0)
            {
                MessageBoxAdv.Show("Documento en uso por otro usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor,  3, ConfigDoc, rq.keyDocumento, CveDoc, NameDoc);
                Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Rcap.ShowDialog();
                LlenaGridView();
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
            funcParaGenererDocM2002();
        }

        private void funcParaGenererDocM2002()
        {
            clsCfgDocumento Ccd = new clsCfgDocumento(ConfigDoc.DocRel, db);
            clsCfgDocumento CfgDocTrans = Ccd.ConfigDoc();
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            string movimiento = rq.AgregarDocEnBlanco(int.Parse(CfgDocTrans.Foliador), FecDia);
            rq.keyidMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            if (movimiento.CompareTo("Error") != 0)
            {
                rq.keyidMovNew = movimiento;
                rq.cmpCveDoc = ConfigDoc.DocRel;
                int _fol = 5000;
                string _alm = "5000";
                string _ser = "";
                rq.cmpSerie = _ser;
                if (CfgDocTrans.UsaSerie == 1)
                {
                    _alm = user.AlmacenUsa;
                    _ser = "SERIE";//Poner serie seleccionada
                    clsCfgDocSeries cds = new clsCfgDocSeries(_alm, ConfigDoc.DocRel, _ser, db);
                    clsCfgDocSeries CfgDocSerie = cds.ConfigDocSerie();

                    _fol = int.Parse(CfgDocSerie.CodFoliador);
                    
                    rq.cmpSerie = _ser;
                }

                /*
                   Aca seria la segunda fase del guardado del documento, si el documento afecta inventario se supone ya 
                   leiste la configuracion en algun punto de este codigo, 
                   aka llamaras tu clase donde esta la funcionalidad del almacen y le pasaras el cabecero y detalle del
                   documento.
                   y se guardaran como un mov de inv afectando las tablas reacionadas con el mod de inv, articulo, precios, existencia
                   ....
                   ok

                 */

                if (rq.GuardarDocTransf(_fol, _alm, CfgDocTrans.CveDoc, _ser) == 1)
                {
                    MessageBox.Show("Documento guardado ...", "Confimacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro", "ERROR "+ NameDoc, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
