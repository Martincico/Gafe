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
using System.IO;
using System.Xml;
using DatSql;

namespace GAFE
{
    public partial class frmLogin : Form
    {

        DateTime hoy;
        private MsSql db = null;
        private string path;

        private string Id;
        private string Empresa;
        private string Servidor;
        private string Datos;
        private string Usuario;
        private string Password;

        Form Flg;

        public frmLogin()
        {
            InitializeComponent();
            path = Directory.GetCurrentDirectory();
        }

        public frmLogin(string id, string empresa, string servidor, string datos, string usr, string pwd,Form emp)
        {
            InitializeComponent();
            Id = id;
            Empresa = empresa;
            Servidor = servidor;
            Datos = datos;
            Usuario = usr;
            Password = pwd;
            Flg = emp;
            // path = Directory.GetCurrentDirectory();
        }


        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            hoy = DateTime.Now;
            lblFecha.Text = hoy.ToLongDateString() + " " + hoy.ToShortTimeString();
            //CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        private void btnAceptar_MouseEnter(object sender, EventArgs e)
        {
            cmdAceptar.FlatAppearance.BorderColor = Color.GreenYellow;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            cmdAceptar.FlatAppearance.BorderColor = Color.Black;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            cmdCancelar.FlatAppearance.BorderColor = Color.OrangeRed;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            cmdCancelar.FlatAppearance.BorderColor = Color.Black;
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

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("No puedes iniciar accesar con esas credenciales", "Alerta", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
            }
            else
            {
                PuiSegUsuarios us = new PuiSegUsuarios(db);
                us.keySusuario = txtUsuario.Text;
                us.getUsuario();
                if (String.Equals(us.keySusuario, txtUsuario.Text) == true)
                {
                    if (String.Equals(us.cmpPassword, txtPassword.Text) == true)
                    {
                        Menu mn = new Menu(db, this, us.cmpCodPerfil);
                        this.Hide();
                        mn.Show();
                        
                        //MessageBox.Show("Acceso correcto!!", "Login", MessageBoxButtons.OK,
                        //MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no esta registrado en el sistema", "Alerta", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Flg.Close();
        }
    }
}
