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
        DateTime FecDia;
        clsCfgDocumento ConfigDoc;
        DataTable dt = null;
        DataRow row = null;
        MsSql db;
        private SqlDataAdapter DatosTbl;
        private clsUtil uT;
        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;
        private String CveDoc;

        public DocLstRequisiciones(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor, String CveDc, String NameDoc)
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

            this.Text = "LISTADO DE "+NameDoc;

            cmdAutorizarTodo.Visible = ConfigDoc.SolicitaAutorizar == 1 ? true : false;

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
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor,  1, ConfigDoc, movimiento, CveDoc);
                Rcap.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                Rcap.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                Rcap.ShowDialog();
                LlenaGridView();
            }
            else
            {
                MessageBoxAdv.Show("Existe un error insertar registro", "Error de Requisición", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor, 2, ConfigDoc, rq.keyDocumento, CveDoc);
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
                DocRegistroRequisicion Rcap = new DocRegistroRequisicion(db, user, StiloColor,  3, ConfigDoc, rq.keyDocumento, CveDoc);
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

            /*
             
                        PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            DatosTbl = pui.ListarInventarioMovtos(CodProve, AlmOri, CodTipoMov, FIni, FFin);
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();
                grdView.DataSource = Ds.Tables[0];
                grdView.Columns["Documento"].Frozen = true;//Inmovilizar columna
                grdView.Columns["NoMovimiento"].Visible = false;
                grdView.Columns["Cancelado"].Visible = false;
                grdView.Columns["TotalDoc"].Visible = false;
                grdView.Columns["CveTipoMov"].Visible = false;
                grdView.Columns["NoMovtoTra"].Visible = false;
                

                for (int i = 0; i < grdView.Columns.Count; i++)
                {
                    grdView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


             */

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
    }
}
