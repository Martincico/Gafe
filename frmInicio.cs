using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using DatSql;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmInicio : Form    {

        private MsSql db = null;
        private string path;

        private string Servidor = "";

        string clave_secreta = "necesitounaprostitutaoatuhermana";
        clsEncripta Seg;

        private int posY = 0;
        private int posX = 0;

        public frmInicio()
        {
            InitializeComponent();
            path = Directory.GetCurrentDirectory() + "\\SrvConfig.xml";
            Seg = new clsEncripta();
        }

       private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;

            LoadCboEmpresas();
            this.KeyPress += new KeyPressEventHandler(this.keypressed);


        }

        private void keypressed(Object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == 9)//assci table = ctrl-I
            {
                frmSlcEmpresas Ventana = new frmSlcEmpresas(path, clave_secreta);
                Ventana.ShowDialog();
                LoadCboEmpresas();
            }
            
        }

        public void LoadCboEmpresas()
        {
            XElement xelement = XElement.Load(path);
            IEnumerable<XElement> Servidores = xelement.Elements();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Empresa", typeof(string));

            foreach (var Servidor in Servidores)
            {
                dt.Rows.Add(Servidor.Element("Id").Value, Servidor.Element("Empresa").Value);
            }
            
            cboEmpresas.DataSource = dt;
            cboEmpresas.ValueMember = "Id";
            cboEmpresas.DisplayMember = "Empresa";
            ;
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
        

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string Id ="";
            string Empresa = "";
            
            string Datos = "";
            string Usuario = "";
            string Password = "";
            if (txtUsuario.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBoxAdv.Show("No puedes iniciar accesar con esas credenciales", "Alerta", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
            }
            else
            {
                string ClaveEmp = Convert.ToString(cboEmpresas.SelectedValue);

                if (cboEmpresas.SelectedIndex < 0 || ClaveEmp.Equals("System.Data.DataRowView"))
                {
                    MessageBoxAdv.Show("No ha seleccionado ningún servidor", "Alerta", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                else
                {
                    XElement xEle = XElement.Load(path);
                    var qr = from Servidor in xEle.Elements("Servidor")
                             where Servidor.Element("Id").Value == ClaveEmp
                             select new
                             {
                                 Id = (string)Servidor.Element("Id"),
                                 Empresa = (string)Servidor.Element("Empresa"),
                                 Nombre = (string)Servidor.Element("Nombre"),
                                 Datos = (string)Servidor.Element("Datos"),
                                 Usuario = (string)Servidor.Element("Usuario"),
                                 Password = (string)Servidor.Element("Password")
                             };
                    foreach (var itm in qr)
                    {
                        Id = itm.Id;
                        Empresa = itm.Empresa;
                        Servidor = itm.Nombre;
                        Datos = itm.Datos;
                        Usuario = itm.Usuario;
                        Password = Seg.desencriptar(itm.Password, clave_secreta); //desenciptar
                        char[] charsToTrim = { '\0' };
                        Password = Password.Trim(charsToTrim);
                    }

                    db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
                    if (db.Conectar() < 1)
                    {
                        MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        Application.Exit();
                    }
                    else
                    {

                        PuiSegUsuarios us = new PuiSegUsuarios(db);
                        us.keySusuario = txtUsuario.Text;
                        us.EditarUsuario();
                        if (!us.keySusuario.Equals(""))
                        {
                            if (String.Equals(us.keySusuario, txtUsuario.Text) == true)
                            {
                                if (String.Equals(us.cmpPassword, txtPassword.Text) == true)
                                {
                                    this.Hide();
                                    if (us.cmpCodPerfil == "CAJAS")
                                    {
                                        DcPtoVenta Rcap = new DcPtoVenta(db, this, us.keySusuario, 1, "M3001", "PUNTO DE VENTA");
                                        Rcap.Show();
                                        
                                    }
                                    else
                                    {
                                        Menu mn = new Menu(db, this, us.keySusuario, Empresa);
                                        mn.Show();
                                        
                                    }

                                }
                                else
                                {
                                    MessageBoxAdv.Show("Contraseña incorrecta", "Alerta", MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBoxAdv.Show("El usuario no esta registrado en el sistema", "Alerta", MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBoxAdv.Show("El usuario no esta registrado en el sistema", "Alerta", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

  

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void lblMin_MouseHover(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.SeaShell;
            lblMin.ForeColor = Color.Black;
        }

        private void lblMin_MouseLeave(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.Transparent;
            lblMin.ForeColor = Color.White;
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}