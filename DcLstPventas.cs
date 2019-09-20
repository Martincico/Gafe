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

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class DcLstPventas : MetroForm
    {
        private SqlDataAdapter DatosTbl;

        public string KeyCampo = null;

        private MsSql db = null;
        public DatCfgUsuario user;
        private clsUtil uT;

        public string[] dv = new string[13];

        private String CveDoc;
        private String NameDoc;

        public DcLstPventas()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKey);
        }


        public DcLstPventas(MsSql Odat, DatCfgUsuario DatUsr, String CveDc, String _NameDoc)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            CveDoc = CveDc;

            NameDoc = _NameDoc;

            this.KeyDown += new KeyEventHandler(PressKey);
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DcLstPventas_Load(object sender, EventArgs e)
        {

            uT = new clsUtil(db, user.AlmacenUsa);
            uT.CargaArbolAcceso();

            /*
            clsUsPerfil up = uT.BuscarIdNodo("1Inv001A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv001F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            */
            
            LlenaGridView();
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                dv[0] = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al Consultar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (dtFechaInicio.Value > dtFechaFin.Value)
            {
                dtFechaFin.Focus();
                MessageBoxAdv.Show("Fecha de Inicio debe ser mayor a Fecha Final.", "Listado registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LlenaGridView();
            }
        }


        private void LlenaGridView()
        {
            String FIni = dtFechaInicio.Value.ToString("dd/MM/yyyy");
            String FFin = dtFechaFin.Value.ToString("dd/MM/yyyy");

            DocPuiRequisiciones pui = new DocPuiRequisiciones(db);
            DatosTbl = pui.ListarDocumentos(user.AlmacenUsa, FIni, FFin, CveDoc);
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();
                grdView.DataSource = Ds.Tables[0];

                grdView.Columns["Serie"].Visible = false;
                grdView.Columns["NumDoc"].Visible = false;
                grdView.Columns["ClaveAlmacen"].Visible = false;
                grdView.Columns["Almacén"].Visible = false;
                grdView.Columns["Fec Exp"].Visible = false;
                grdView.Columns["Impuesto"].Visible = false;
                grdView.Columns["idMov"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        
        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdConsultar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmdConsultar_Click(sender, e);
        }


        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdBuscar_Click(sender,e);
            }
        }


    }
}
