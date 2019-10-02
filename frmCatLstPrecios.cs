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
    public partial class frmCatLstPrecios : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        private clsUtil uT;

        private int AcCOPEdit;

        public DatCfgUsuario user;
        public clsStiloTemas StiloColor;

        public frmCatLstPrecios()
        {
            InitializeComponent();
        }


        public frmCatLstPrecios(MsSql Odat, DatCfgUsuario DatUsr, clsStiloTemas NewColor)
        {
            InitializeComponent();
            db = Odat;
            user = DatUsr;
            StiloColor = NewColor;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }



        private void frmCatLstPrecios_Load(object sender, EventArgs e)
        {
            
            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Inv008A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv008B");
            AcCOPEdit = (up != null) ? up.Acceso : 0;
            cmdEditar.Enabled = (AcCOPEdit == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv008C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv008D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;
            
            up = uT.BuscarIdNodo("1Inv008E");
            AcCOP = (up != null) ? up.Acceso : 0;
            btnVer.Enabled = (AcCOP == 1) ? true : false;
            
            up = uT.BuscarIdNodo("1Inv008F");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdBuscar.Enabled = (AcCOP == 1) ? true : false;

            this.Size = this.MinimumSize;
            LlenaGridView();
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

            try
            {
                if (AcCOPEdit == 1)
                {
                    PuiCatLstPrecios pui = new PuiCatLstPrecios(db);

                    pui.keyCveLstPrecio = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EditarLstPrecios();
                    txtClaveLstPrecio.Text = pui.keyCveLstPrecio;
                    txtDescripcion.Text = pui.cmpNombre;
                    chkEsDeCosto.Checked = (pui.cmpEsDeCosto == 1) ? true : false;
                    chkEsDeVenta.Checked = (pui.cmpEsDeVenta == 1) ? true : false;
                    chkEstatus.Checked = (pui.cmpEstatus == 1) ? true : false;
                    txtClaveLstPrecio.Enabled = false;

                }
                else
                {
                    MessageBoxAdv.Show("No tienes privilegios suficientes",
                    "Error al editar registro", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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
            try
            {
                if (MessageBoxAdv.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
                    pui.keyCveLstPrecio = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaLstPrecios();
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
            PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
            DatosTbl = pui.BuscaLstPrecios(txtBuscar.Text);
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

        private void frmCatLstPrecios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
            DatosTbl = pui.ListarLstPrecios();
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

        private void Agregar()
        {
            if (Validar())
            {
                PuiCatLstPrecios pui = new PuiCatLstPrecios(db);
                                
                pui.keyCveLstPrecio = txtClaveLstPrecio.Text;
                pui.cmpNombre = txtDescripcion.Text;
                pui.cmpEsDeCosto = (chkEsDeCosto.Checked == true) ? 1 : 0;
                pui.cmpEsDeVenta = (chkEsDeVenta.Checked == true) ? 1 : 0;
                pui.cmpEstatus = (chkEstatus.Checked == true) ? 1 : 0;


                if (pui.AgregarLstPrecios() >= 1)
                {
                    if (pui.AddLstPreciosDet() >= 1)
                    {
                        MessageBoxAdv.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        LlenaGridView();
                        this.Size = this.MinimumSize;
                    }
                    else
                    {
                        MessageBoxAdv.Show("Existe un error al insertar el registro",
                            "Error al insertar", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiCatLstPrecios pui = new PuiCatLstPrecios(db);

                    pui.keyCveLstPrecio = txtClaveLstPrecio.Text;
                    pui.cmpNombre = txtDescripcion.Text;
                    pui.cmpEsDeCosto = (chkEsDeCosto.Checked == true) ? 1 : 0;
                    pui.cmpEsDeVenta = (chkEsDeVenta.Checked == true) ? 1 : 0;
                    pui.cmpEstatus = (chkEstatus.Checked == true) ? 1 : 0;

                    chkEstatus.Checked = (pui.cmpEstatus == 1) ? true : false;


                    if (pui.ActualizaLstPrecios() >= 0)
                    {
                        MessageBoxAdv.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    LlenaGridView();
                    //grdView.CurrentRow.Index = idxG;  
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveLstPrecio.Text))
            {                
                MessageBoxAdv.Show("Código: No puede ir vacío.", "Listas de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveLstPrecio.Text))
                {
                    MessageBoxAdv.Show("Código: Contiene caracteres no validos.", "Listas de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBoxAdv.Show("Descripción: No puede ir vacío.", "Listas de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBoxAdv.Show("Descripción: Contiene caracteres no validos.", "Listas de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtClaveLstPrecio.Enabled = Op;
            txtDescripcion.Enabled = Op;
            chkEsDeCosto.Enabled = Op;
            chkEsDeVenta.Enabled = Op;
            chkEstatus.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveLstPrecio.Text = "";
            txtDescripcion.Text = "";
            chkEsDeCosto.Checked = false;
            chkEsDeVenta.Checked = false;
            chkEstatus.Checked = true;
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

        private void txtClaveClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsUtilerias.LetrasNumeros(e);
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;

            try { 

                PuiCatLstPrecios pui = new PuiCatLstPrecios(db);

                pui.keyCveLstPrecio = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                pui.EditarLstPrecios();
                txtClaveLstPrecio.Text = pui.keyCveLstPrecio;
                txtDescripcion.Text = pui.cmpNombre;
                chkEsDeCosto.Checked = (pui.cmpEsDeCosto == 1) ? true : false;
                chkEsDeVenta.Checked = (pui.cmpEsDeVenta == 1) ? true : false;
                chkEstatus.Checked = (pui.cmpEstatus == 1) ? true : false;

                OpcionControles(false);

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
}

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            { 
                LstCatViewLstPrecio LPv = new LstCatViewLstPrecio(db, user, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                LPv.CaptionBarColor = ColorTranslator.FromHtml(StiloColor.Encabezado);
                LPv.CaptionForeColor = ColorTranslator.FromHtml(StiloColor.FontColor);
                LPv.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
}
    }
}
