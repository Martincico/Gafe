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
    public partial class frmExistencias : Form
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

        List<clsFillCbo> lp;
        List<clsFillCbo> ln;

        public frmExistencias()
        {
            InitializeComponent();
        }


        public frmExistencias(MsSql Odat, string perfil)
        {
            InitializeComponent();
            db = Odat;
            // Perfil = perfil;
        }

        private void frmExistencias_Load(object sender, EventArgs e)
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
            this.Size = this.MinimumSize;
            path = Directory.GetCurrentDirectory();
            CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            string Sqlstr = " SELECT  ClaveAlmacen,Descripcion FROM Inv_CatAlmacenes WHERE Estatus = 1";
            SqlDataReader dr = db.SelectDR(Sqlstr);
            lp = new List<clsFillCbo>();

            clsFillCbo Prv1 = new clsFillCbo();
            Prv1.Id = "";
            Prv1.Descripcion = "";
            lp.Add(Prv1);

            while (dr.Read())
            {
                clsFillCbo Prv = new clsFillCbo();
                Prv.Id = Convert.ToString(dr["ClaveAlmacen"]);
                Prv.Descripcion = Convert.ToString(dr["Descripcion"]);
                lp.Add(Prv);
            }
            dr.Close();
            cboAlmacen.DataSource = lp;
            cboAlmacen.ValueMember = "Id";
            cboAlmacen.DisplayMember = "Descripcion";
            //cboAlmacen.SelectedText = "Activo";


            string Sqlstr2 = " SELECT CveLinea,Descripcion FROM Inv_Lineas WHERE Estatus = 1";
            SqlDataReader dr2 = db.SelectDR(Sqlstr2);
            ln = new List<clsFillCbo>();

            clsFillCbo Rln = new clsFillCbo();
            Rln.Id = "";
            Rln.Descripcion = "";
            ln.Add(Rln);

            while (dr2.Read())
            {
                clsFillCbo Rlnc = new clsFillCbo();
                Rlnc.Id = Convert.ToString(dr2["CveLinea"]);
                Rlnc.Descripcion = Convert.ToString(dr2["Descripcion"]);
                ln.Add(Rlnc);
            }
            dr2.Close();
            cboLineas.DataSource = ln;
            cboLineas.ValueMember = "Id";
            cboLineas.DisplayMember = "Descripcion";
            //cboAlmacen.SelectedText = "Activo";
            
            LlenaGridView(0);
        }


        private void LlenaGridView(int tieneFiltro)
        {
            PuiExistencias pui = new PuiExistencias(db);
            DatosTbl = (tieneFiltro == 0) ? pui.ListarExistencias() : pui.BuscaExistencia(txtClaveArticulo.Text,cboAlmacen.SelectedValue.ToString(),
                                                                              cboLineas.SelectedValue.ToString());
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

       

        private void cboAlmacen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos la = new frmLstArticulos(db,"",3);
            la.ShowDialog();
            txtClaveArticulo.Text = la.dv[0];
            txtDscArticulo.Text = la.dv[1];
            LlenaGridView(1);
        }

        private void cboLineas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenaGridView(1);
        }

        private void cmdAsignaStock_Click(object sender, EventArgs e)
        {
            string ClaveArticulo = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            string ClaveAlmacen = grdView[3, grdView.CurrentRow.Index].Value.ToString();
            string Descripcion = grdView[1, grdView.CurrentRow.Index].Value.ToString();
            string Ubicacion = grdView[12, grdView.CurrentRow.Index].Value.ToString(); ;
            string stockMin = grdView[7, grdView.CurrentRow.Index].Value.ToString();
            string stockMax = grdView[8, grdView.CurrentRow.Index].Value.ToString();

            AsignaPorAlmacen fas = new AsignaPorAlmacen(ClaveArticulo,ClaveAlmacen,Descripcion,Ubicacion,stockMin,stockMax,db);
            fas.ShowDialog();
            LlenaGridView(1);
        }
    }
}
