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
    public partial class LstCatViewLstPrecio : MetroForm
    {
        private SqlDataAdapter DatosTbl;

        public string KeyCampo = null;

        private MsSql db = null;
        public DatCfgUsuario user;
        private clsUtil uT;

        private String CveLstPre;

        private Boolean DtError;

        private double OldValCell;

        public LstCatViewLstPrecio()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKey);
        }


        public LstCatViewLstPrecio(MsSql Odat, DatCfgUsuario DatUsr, String CveLstPrec)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;

            CveLstPre = CveLstPrec;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            this.KeyDown += new KeyEventHandler(PressKey);
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            */
        }

        /*
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        */
        private void LstCatViewLstPrecio_Load(object sender, EventArgs e)
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
            DtError = false;
        }

        

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
                LlenaGridView();
        }


        private void LlenaGridView()
        {

            PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
            pui.keyCveLstPrecio = CveLstPre;
            DatosTbl = pui.LstArticulo_LstPrecio(txtBuscar.Text);
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();
                grdView.DataSource = Ds.Tables[0];

                grdView.Columns["Precio"].ReadOnly = false;
                grdView.Columns["Articulo"].ReadOnly = true;
                grdView.Columns["Descripcion"].ReadOnly = true;
                grdView.Columns["Modelo"].ReadOnly = true;
                grdView.Columns["FechaModifacion"].ReadOnly = true;


                grdView.Columns["FechaModifacion"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdBuscar_Click(sender,e);
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (!DtError)
            {
                try
                {
                    double NewValCell = Convert.ToDouble(grdView[3, grdView.CurrentRow.Index].Value.ToString());


                    if (NewValCell != OldValCell)
                    {
                        PuiCatLstPrecios Lstp = new PuiCatLstPrecios(db);
                        Lstp.keyCveLstPrecio = CveLstPre;
                        Lstp.cmpCveArticulo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                        Lstp.cmpPrecio = NewValCell;
                        Lstp.cmpFechaModifacion = user.FecServer;
                        if (Lstp.UpdLstPrecio_Art() <= 0)
                        {
                            MessageBoxAdv.Show("Error al actualizar precio", "Existe un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxAdv.Show(ex.Message, "Alerta", MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
                }
            }
            
            DtError = false;


        }

        private void grdView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBoxAdv.Show("value change " + grdView[0, grdView.CurrentRow.Index].Value.ToString(), "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void grdView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Don't throw an exception when we're done.
            e.ThrowException = false;

            // Display an error message.
            string txt = "Error with " +
                grdView.Columns[e.ColumnIndex].HeaderText +
                "\n\n" + e.Exception.Message;
            MessageBox.Show(txt, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            // If this is true, then the user is trapped in this cell.
            e.Cancel = false;

            DtError = true;

            
        }

        private void grdView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /*
            var oldValue = grdView[e.ColumnIndex, e.RowIndex].Value;
            MessageBoxAdv.Show("value old " + oldValue, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            var newValue = e.FormattedValue;
            MessageBoxAdv.Show("value new " + oldValue, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            */

            string headerText = grdView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Precio")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBoxAdv.Show("Valor ingresado no debe ser nulo o vació", "Error de captura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdView.Rows[e.RowIndex].ErrorText = "Valor ingresado no debe ser nulo o vació";
                e.Cancel = true;

                grdView.CancelEdit();

            }

        }

        private void grdView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                grdView.CancelEdit();
        }

        private void grdView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string headerText = grdView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Precio")) return;
            String vale = grdView[3, grdView.CurrentRow.Index].Value.ToString();
            if (vale.Equals(""))
                OldValCell = 0;
            else
                OldValCell = Convert.ToDouble(vale);
        }
    }
}
