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

namespace GAFE
{
    public partial class frmCatAlmacenes : Form
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        private string Perfil;
        private clsUtil uT;

        private string path;

        private string Id;
        private string Empresa;
        private string Servidor;
        private string Datos;
        private string Usuario;
        private string Password;


        public frmCatAlmacenes()
        {
            InitializeComponent();
        }


        public frmCatAlmacenes(MsSql Odat, string perfil)
        {
            InitializeComponent();
            db = Odat;
             Perfil = perfil;
        }



        private void frmCatAlmacenes_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv005A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv005B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv005C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv005D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            /*
            up = uT.BuscarIdNodo("1Inv005E");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdSeleccionar.Enabled = (AcCOP == 1) ? true : false;
            */

            up = uT.BuscarIdNodo("1Inv005F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;


            this.Size = this.MinimumSize;
            LlenaGridView();
            cboEstatus.SelectedText = "Activo";
            
           /*
            path = Directory.GetCurrentDirectory();
            
            
            this.Size = this.MinimumSize;
            LlenaGridView();
            cboEstatus.SelectedText = "Activo";
            */
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 1;
        }

        private void cmEditar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 2;

            idxG = grdView.CurrentRow.Index;

            PuiCatAlmacenes pui = new PuiCatAlmacenes(db);

            pui.keyClaveAlmacen = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarAlmacen();
            txtClaveAlmacen.Text = pui.keyClaveAlmacen;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboEstatus.SelectedText = (pui.cmpEstatus == "A") ? "Activo" : "Baja";
            chkEsDeCompra.Checked = (pui.cmpEsDeCompra == 1) ? true : false;
            chkEsDeVenta.Checked = (pui.cmpEsDeVenta == 1) ? true : false;
            chkEsDeConsigna.Checked = (pui.cmpEsDeConsigna == 1) ? true : false;
            chkNumRojo.Checked = (pui.cmpNumRojo == 1) ? true : false;

            txtClaveAlmacen.Enabled = false;

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;

            PuiCatAlmacenes pui = new PuiCatAlmacenes(db);

            pui.keyClaveAlmacen = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarAlmacen();
            txtClaveAlmacen.Text = pui.keyClaveAlmacen;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboEstatus.SelectedText = (pui.cmpEstatus == "A") ? "Activo" : "Baja";
            chkEsDeCompra.Checked = (pui.cmpEsDeCompra == 1) ? true : false;
            chkEsDeVenta.Checked = (pui.cmpEsDeVenta == 1) ? true : false;
            chkEsDeConsigna.Checked = (pui.cmpEsDeConsigna == 1) ? true : false;
            chkNumRojo.Checked = (pui.cmpNumRojo == 1) ? true : false;

            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatAlmacenes pui = new PuiCatAlmacenes(db);
                    pui.keyClaveAlmacen = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaAlmacen();
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
        }


        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            PuiCatAlmacenes pui = new PuiCatAlmacenes(db);
            DatosTbl = pui.BuscaAlmacen(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);

            grdView.Rows.Clear();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
        }






        private void cmdAceptar_Click(object sender, EventArgs e)
        {

            switch (opcion)
            {
                case 1: Agregar(); break;
                case 2: Editar(); break;
                case 3: this.Size = this.MinimumSize; break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            LimpiarControles();
            OpcionControles(true);
        }

        private void frmCatAlmacenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatAlmacenes pui = new PuiCatAlmacenes(db);
            DatosTbl = pui.ListarAlmacenes();
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
                MessageBox.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Agregar()
        {
            if (Validar())
            {
                PuiCatAlmacenes pui = new PuiCatAlmacenes(db);
                                
                pui.keyClaveAlmacen = txtClaveAlmacen.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "A" : "B";
                pui.cmpEsDeCompra = (chkEsDeCompra.Checked == true) ? 1 : 0;
                pui.cmpEsDeVenta = (chkEsDeVenta.Checked == true) ? 1 : 0;
                pui.cmpEsDeConsigna  = (chkEsDeConsigna.Checked == true) ? 1 : 0;
                pui.cmpNumRojo =  (chkNumRojo.Checked == true) ? 1 : 0;

                if (pui.AgregarAlmacen() >= 1)
                {
                    MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LlenaGridView();
                    this.Size = this.MinimumSize;
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiCatAlmacenes pui = new PuiCatAlmacenes(db);

                    pui.keyClaveAlmacen = txtClaveAlmacen.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpEstatus = (cboEstatus.Text == "Activo") ? "A" : "B";
                    pui.cmpEsDeCompra = (chkEsDeCompra.Checked == true) ? 1 : 0;
                    pui.cmpEsDeVenta = (chkEsDeVenta.Checked == true) ? 1 : 0;
                    pui.cmpEsDeConsigna = (chkEsDeConsigna.Checked == true) ? 1 : 0;
                    pui.cmpNumRojo = (chkNumRojo.Checked == true) ? 1 : 0;

                    if (pui.ActualizaAlmacen() >= 0)
                    {
                        MessageBox.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    LlenaGridView();
                    //grdView.CurrentRow.Index = idxG;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveAlmacen.Text))
            {                
                MessageBox.Show("Código: No puede ir vacío.", "CatAlmacenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveAlmacen.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "CatAlmacenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Descripción: No puede ir vacío.", "CatAlmacenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBox.Show("Descripción: Contiene caracteres no validos.", "CatAlmacenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            txtClaveAlmacen.Enabled = Op;
            txtDescripcion.Enabled = Op;
            cboEstatus.Enabled = Op;
            chkEsDeCompra.Enabled = Op;
            chkEsDeVenta.Enabled = Op;
            chkEsDeConsigna.Enabled = Op;
            chkNumRojo.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveAlmacen.Text = "";
            txtDescripcion.Text = "";
            cboEstatus.Text = "";
            chkEsDeCompra.Checked = false;
            chkEsDeVenta.Checked = false;
            chkEsDeConsigna.Checked = false;
            chkNumRojo.Checked = false;
        }

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmEditar_Click(sender, e);
        }


        private void txtClaveAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }
    }
}
