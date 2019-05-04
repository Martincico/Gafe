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
using System.Net;

namespace GAFE
{
    public partial class frmKardex : Form
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

        public frmKardex()
        {
            InitializeComponent();
        }

        public frmKardex(MsSql Odat, string perfil)
        {
            
            InitializeComponent();
            db = Odat;
            // Perfil = perfil;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos art = new frmLstArticulos(db, "perfil", 3);
            art.ShowDialog();
            if (!string.IsNullOrEmpty(art.KeyCampo))
            {
                PuiCatArticulos arti = new PuiCatArticulos(db);
                arti.keyCveArticulo = art.KeyCampo;
                arti.EditarArticulo();
                txtClaveArticulo.Text = arti.keyCveArticulo;
                txtDscArticulo.Text = arti.cmpDescripcion;
            }
        }

        private void frmKardex_Load(object sender, EventArgs e)
        {
            
            path = Directory.GetCurrentDirectory();
            CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            PuiCatAlmacenes alm = new PuiCatAlmacenes(db);
            cboAlmacenes.DataSource = alm.CboInv_CatAlmacenes();
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
    }
}
