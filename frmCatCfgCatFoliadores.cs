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
    public partial class frmCatCfgCatFoliadores : Form
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        //private string Perfil;
        //private clsUtil uT;

        private string path;

        private string Id;
        private string Empresa;
        private string Servidor;
        private string Datos;
        private string Usuario;
        private string Password;


        public frmCatCfgCatFoliadores()
        {
            InitializeComponent();
        }


        public frmCatCfgCatFoliadores(MsSql Odat, string perfil)
        {
            InitializeComponent();
            db = Odat;
            // Perfil = perfil;
        }



        private void frmCatCfgCatFoliadores_Load(object sender, EventArgs e)
        {
            /*
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();

            clsUsPerfil up = uT.BuscarIdNodo("1Vis001A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdAgregar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Vis001B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmEditar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Vis001C");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdEliminar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Vis001D");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;


            this.Size = this.MinimumSize;
            LlenaGridView();
            cboEstatus.SelectedText = "Activo";
            */
           
            path = Directory.GetCurrentDirectory();
            CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.Size = this.MinimumSize;
            LlenaGridView();
            LleCboClaseMov();
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

            PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);

            pui.keyCveFoliador= grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarCfgCatFoliador();
            txtClaveClase.Text = pui.keyCveFoliador;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboCfgModuloSys.SelectedValue = pui.cmpCveModulo;
            txtUso.Text = pui.cmpUso;

            txtClaveClase.Enabled = false;

        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Size = this.MaximumSize;
            opcion = 3;

            idxG = grdView.CurrentRow.Index;

            PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);

            pui.keyCveFoliador = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            pui.EditarCfgCatFoliador();
            txtClaveClase.Text = pui.keyCveFoliador;
            txtDescripcion.Text = pui.cmpDescripcion;
            cboCfgModuloSys.SelectedValue = pui.cmpCveModulo;
            txtUso.Text = pui.cmpUso;

            OpcionControles(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);
                    pui.keyCveFoliador = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EliminaCfgCatFoliador();
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
            PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);
            DatosTbl = pui.BuscaClase(txtBuscar.Text);
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

        private void frmCatCfgCatFoliadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }





        private void LlenaGridView()
        {
            PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);
            DatosTbl = pui.ListarCfgCatFoliadores();
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
                PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);
                                
                pui.keyCveFoliador = txtClaveClase.Text;
                pui.cmpDescripcion = txtDescripcion.Text;
                pui.cmpCveModulo   = Convert.ToString(cboCfgModuloSys.SelectedValue);
                pui.cmpUso = txtUso.Text;

                if (pui.AgregarClase() >= 1)
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
                    PuiCatCfgCatFoliadores pui = new PuiCatCfgCatFoliadores(db);

                    pui.keyCveFoliador = txtClaveClase.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;
                    pui.cmpCveModulo = Convert.ToString(cboCfgModuloSys.SelectedValue);
                    pui.cmpUso = txtUso.Text;

                    if (pui.ActualizaCfgCatFoliador() >= 0)
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
            if (String.IsNullOrEmpty(txtClaveClase.Text))
            {                
                MessageBox.Show("Código: No puede ir vacío.", "CatClasees", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveClase.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "Cfg Foliadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Descripción: No puede ir vacío.", "Cfg Foliadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBox.Show("Descripción: Contiene caracteres no validos.", "Cfg Foliadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            if (String.IsNullOrEmpty(txtUso.Text))
            {
                MessageBox.Show("Uso: No puede ir vacío.", "Cfg Foliadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBox.Show("txtUso: Contiene caracteres no validos.", "Cfg Foliadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            return dv;
        }


        private void OpcionControles(Boolean Op)
        {
            txtClaveClase.Enabled = Op;
            txtDescripcion.Enabled = Op;
            txtUso.Enabled = Op;
            cboCfgModuloSys.Enabled = Op;

        }

        private void LimpiarControles()
        {
            txtClaveClase.Text = "";
            txtDescripcion.Text = "";
            txtUso.Text = "";
            //cboCfgModuloSys.Text = "";
        }

        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmEditar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmEditar_Click(sender, e);
        }



        private void CargaDatosConexion()
        {
            System.Xml.XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + "\\SrvConfig.xml");
            XmlNodeList servidores = xDoc.GetElementsByTagName("Servidores");

            XmlNodeList lista =
            ((XmlElement)servidores[0]).GetElementsByTagName("Servidor");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList nId = nodo.GetElementsByTagName("Id");
                XmlNodeList nEmpresa = nodo.GetElementsByTagName("Empresa");
                XmlNodeList nNombre = nodo.GetElementsByTagName("Nombre");
                XmlNodeList nDatos = nodo.GetElementsByTagName("Datos");
                XmlNodeList nUsuario = nodo.GetElementsByTagName("Usuario");
                XmlNodeList nPassword = nodo.GetElementsByTagName("Password");

                Id = nId[i].InnerText;
                Empresa = nEmpresa[i].InnerText;
                Servidor = nNombre[i].InnerText;
                Datos = nDatos[i].InnerText;
                Usuario = nUsuario[i].InnerText;
                Password = nPassword[i++].InnerText;
            }
        }

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LleCboClaseMov()
        {
            PuiCatCfgCatFoliadores lin = new PuiCatCfgCatFoliadores(db);
            cboCfgModuloSys.DataSource = lin.CboCfgModuloSys();
            cboCfgModuloSys.ValueMember = "CveModulo";
            cboCfgModuloSys.DisplayMember = "Descripcion";

        }

    }
}
