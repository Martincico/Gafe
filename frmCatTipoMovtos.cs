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

namespace GAFE
{
    public partial class frmCatTipoMovtos : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int idxG;

        private MsSql db = null;

        public DatCfgUsuario user;

        public clsStiloTemas StiloColor;

        public frmCatTipoMovtos()
        {
            InitializeComponent();
        }


        public frmCatTipoMovtos(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatTipoMovtos_Load(object sender, EventArgs e)
        {
            /*
             
                        clsUsPerfil up = uT.BuscarIdNodo("1Inv011A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv011E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdRestablecer.Enabled = (AcCOP == 1) ? true : false;


             * */



            LlenaGridView();

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmRegTipoMovtos Ventana = new frmRegTipoMovtos(db,1);
            Ventana.ShowDialog();
            LlenaGridView();
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            frmRegTipoMovtos Ventana = new frmRegTipoMovtos(db, 2, grdView[0, grdView.CurrentRow.Index].Value.ToString());
            Ventana.ShowDialog();
            LlenaGridView();
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            idxG = grdView.CurrentRow.Index;
            frmRegTipoMovtos Ventana = new frmRegTipoMovtos(db, 3, grdView[0, grdView.CurrentRow.Index].Value.ToString());
            Ventana.ShowDialog();
            LlenaGridView();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
                    pui.keyCveTipoMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaTipoMov();
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }


            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            DatosTbl = pui.BuscaTipoMov(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);

            grdView.Rows.Clear();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
        }
        
        private void frmCatTipoMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
        private void LlenaGridView()
        {
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            DatosTbl = pui.ListarTipoMovtos();
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Rows.Clear();

                for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                {
                    object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                    grdView.Rows.Add(tmp);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmEditar_Click(sender, e);
        }



    

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmCatTipoMovtos_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
