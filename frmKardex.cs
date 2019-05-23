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
        private string Perfil;
        private clsUtil uT;
        DataTable dt;
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
            Perfil = perfil;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos art = new frmLstArticulos(db, Perfil, 3);
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
            /*
            path = Directory.GetCurrentDirectory();
            CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            */
            uT = new clsUtil(db, Perfil);
            uT.CargaArbolAcceso();


            clsUsPerfil up = uT.BuscarIdNodo("1Inv012A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv012B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

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

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                PuiCatKardex kar = new PuiCatKardex(db);
                kar.keyCveArticulo = txtClaveArticulo.Text;
                kar.cmpCveAlmacenMov = cboAlmacenes.SelectedValue.ToString();
               // kar.cmpFechaIni = dtFechaInicio.Value;
                //kar.cmpFechaFin = dtFechaFin.Value;
                dt= kar.verKardex();
                decimal CantSaldo = 0.00M, Cantidad = 0.00M;
                decimal PrecioProm = 0.00M, PrecioEnt = 0.00M;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    if (row["Concepto"].ToString() == "Entrada")
                    {
                        if (!decimal.TryParse(row["Cantidad_Entrada"].ToString(), out Cantidad))
                            Cantidad = 0;
                        if (!decimal.TryParse(row["Precio_Entrada"].ToString(), out PrecioEnt))
                            PrecioEnt = 0;
                        PrecioProm = ((Cantidad * PrecioEnt) + (CantSaldo * PrecioProm)) / (Cantidad + CantSaldo);
                        CantSaldo += Cantidad;
                    }
                    else
                    {
                        if (!decimal.TryParse(row["Cantidad_Salida"].ToString(), out Cantidad))
                            Cantidad = 0;
                        CantSaldo -= Cantidad;
                        row["Precio_Salida"] =PrecioProm;
                        row["Total_Salida"] = Cantidad * PrecioProm;
                    }
                    row["Cantidad_Saldo"] = CantSaldo;
                    row["Precio_Prom"] = PrecioProm;
                    row["Total_Saldo"] = CantSaldo * PrecioProm;
                }
                
                DataRow[] dtr = dt.Select("Fecha < #"+dtFechaInicio.Value.ToString("MM/dd/yyyy") +"# OR Fecha > #"+ dtFechaFin.Value.ToString("MM/dd/yyyy")+"#");
                foreach (var drow in dtr)
                {
                    drow.Delete();
                }
                dt.AcceptChanges();
                
                grdView.DataSource = dt;
                cmdImprimir.Visible = true;
            }
            
        }

        private Boolean Validar()
        {
            Boolean resp = true;
            
            if(String.IsNullOrEmpty(txtClaveArticulo.Text))
            {
                MessageBox.Show("Clave de Artículo: Debe seleccionar un artículo.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmdArticulo.Focus();
                resp = false;
            }
            if(cboAlmacenes.SelectedIndex<0)
            {
                MessageBox.Show("Clave de Almacen: Debe seleccionar un Almacen.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAlmacenes.Focus();
                resp = false;
            }
            if(dtFechaInicio.Value>dtFechaFin.Value)
            {
                MessageBox.Show("Fecha Inicio: La Fecha de Inicio debe ser mayor a la Fecha Final.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFechaInicio.Focus();
                resp = false;
            }
            return resp;
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            frmRptKardex print = new frmRptKardex();
            this.Cursor = Cursors.AppStarting;
            print.Kardex(dt, txtClaveArticulo.Text+" - "+txtDscArticulo.Text, cboAlmacenes.Text, dtFechaInicio.Value, dtFechaFin.Value);
            this.Cursor = Cursors.Default;
            print.ShowDialog();
        }
    }
}
