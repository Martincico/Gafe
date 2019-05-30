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

using System.Xml;
using System.Xml.Linq;


namespace GAFE
{
    public partial class frmEmpresas : Form
    {
        private string path;
        private int opcion;
        String Err;
        string clave_secreta = "necesitounaprostitutaoatuhermana";
        clsEncripta Seg;

        public frmEmpresas()
        {
            InitializeComponent();
            path = Directory.GetCurrentDirectory()+ "\\SrvConfig.xml";
            Seg = new clsEncripta();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            cargaDataGrid();
            this.Size = this.MinimumSize;
        }

        public void cargaDataGrid()
        {
            XElement xelement = XElement.Load(path);
            IEnumerable<XElement> Servidores = xelement.Elements();

            grdView.Rows.Clear();
            foreach (var Servidor in Servidores)
            {
                object[] tmp = new object[6];
                tmp[0] = Servidor.Element("Id").Value;
                tmp[1] = Servidor.Element("Empresa").Value;
                tmp[2] = Servidor.Element("Nombre").Value;
                tmp[3] = Servidor.Element("Datos").Value;
                tmp[4] = Servidor.Element("Usuario").Value;
                tmp[5] = Servidor.Element("Password").Value;
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


        private void Agregar()
        {
            if (Validar())
            {
                if (!BuscaPrimarykey())
                {
                    XElement xEle = XElement.Load(path);
                    xEle.Add(new XElement("Servidor",
                        new XElement("Id", txtid.Text),
                        new XElement("Empresa", txtEmpresa.Text),
                        new XElement("Nombre", txtNombre.Text),
                        new XElement("Datos", txtBaseDatos.Text),
                        new XElement("Usuario", txtUsr.Text),
                        new XElement("Password", Seg.encriptar(txtPwd.Text,clave_secreta))));
                    xEle.Save(path);
                    this.cargaDataGrid();
                    this.LimpiarControles();
                    this.Size = this.MinimumSize;
                    //MessageBox.Show("Cliente agregado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("El codigo del cliente ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(Err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void EditarSlc()
        {
            string ClaveEmp = grdView[0, grdView.CurrentRow.Index].Value.ToString();
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
                txtid.Text = itm.Id;               
                txtEmpresa.Text = itm.Empresa;
                txtNombre.Text = itm.Nombre;
                txtBaseDatos.Text = itm.Datos;
                txtUsr.Text = itm.Usuario;
                txtPwd.Text = Seg.desencriptar(itm.Password,clave_secreta); //desenciptar
            }

            txtid.Enabled = false;
        }

        private void Editar()
        {
            string ClaveEmp = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            XElement xEle = XElement.Load(path);
            var qr = from Servidor in xEle.Elements("Servidor")
                     where Servidor.Element("Id").Value == ClaveEmp
                     select Servidor;                    
            foreach (var itm in qr)
            {
                itm.Element("Empresa").Value = txtEmpresa.Text;
                itm.Element("Nombre").Value = txtNombre.Text;
                itm.Element("Datos").Value = txtBaseDatos.Text;
                itm.Element("Usuario").Value = txtUsr.Text;
                itm.Element("Password").Value = Seg.encriptar(txtPwd.Text,clave_secreta);
            }            
            xEle.Save(path);
            this.cargaDataGrid();
            this.LimpiarControles();
            this.Size = this.MinimumSize;
        }


        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            string ClaveEmp = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            if (MessageBox.Show("Esta seguro de eliminar la empresa  " + ClaveEmp + " " + grdView[1, grdView.CurrentRow.Index].Value.ToString(),
                    "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                XElement xEle = XElement.Load(path);
                var qr = from Servidor in xEle.Elements("Servidor")
                         where Servidor.Element("Id").Value == ClaveEmp
                         select Servidor;
                qr.Remove();
                xEle.Save(path);
                this.cargaDataGrid();
                this.LimpiarControles();
                this.Size = this.MinimumSize;
            }
        }


        private void frmEmpresas_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.I))
            {
                cmdInsertar.Visible = (cmdInsertar.Visible == false) ? true : false;
                cmdEditar.Visible = (cmdEditar.Visible == false) ? true : false;
                cmdEliminar.Visible = (cmdEliminar.Visible == false) ? true : false;
            }
                
        }

        private void cmdInsertar_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            opcion = 1;
            LimpiarControles();
            OpcionControles(true);
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize;
            opcion = 2;
            LimpiarControles();
            OpcionControles(true);
            EditarSlc();

        }


        private void cmdCancelar2_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void LimpiarControles()
        {
            txtid.Text = "";
            txtEmpresa.Text = "";
            txtNombre.Text = "";
            txtBaseDatos.Text = "";
            txtUsr.Text = "";
            txtPwd.Text = "";
        }

        private void OpcionControles(Boolean vl)
        {
            txtid.Enabled = vl;
            txtEmpresa.Enabled = vl;
            txtNombre.Enabled = vl;
            txtBaseDatos.Enabled = vl;
            txtUsr.Enabled = vl;
            txtPwd.Enabled = vl;
        }

        private Boolean BuscaPrimarykey()
        {
            Boolean pk = false;
            //txtBsq.Text = "";
            //this.filtraRegistros();
            for (int j = 0; j < this.grdView.RowCount; j++)
            {
                if (grdView[0, j].Value.ToString().Equals(this.txtid.Text))
                    pk = true;
            }
            return pk;
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            string id = grdView[0, grdView.CurrentRow.Index].Value.ToString();
            string emp = grdView[1, grdView.CurrentRow.Index].Value.ToString();
            string srv = grdView[2, grdView.CurrentRow.Index].Value.ToString();
            string dat =  grdView[3, grdView.CurrentRow.Index].Value.ToString();
            string usr = grdView[4, grdView.CurrentRow.Index].Value.ToString();
            string pwd = Seg.desencriptar(grdView[5, grdView.CurrentRow.Index].Value.ToString(),clave_secreta);
            char[] charsToTrim = { '\0' };
            pwd = pwd.Trim(charsToTrim);
            
            

            frmLogin flg = new frmLogin(id, emp, srv, dat, usr, pwd,this);
            this.Hide();
            flg.Show();
            
        }

        private Boolean Validar()
        {
            Boolean dv = true;
            Err = "";
            if (String.IsNullOrWhiteSpace(txtid.Text))
            {
                Err = Err + "Tienes que capturar la clave de la empresa" + Environment.NewLine;
                dv = false;
            }
            if (String.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                Err = Err + "Tienes que capturar el nombre de la empresa";
                dv = false;
            }
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Err = Err + "Tienes que capturar el nombre del servidor";
                dv = false;
            }
            if (String.IsNullOrWhiteSpace(txtBaseDatos.Text))
            {
                Err = Err + "Tienes que capturar el nombre de la base de datos";
                dv = false;
            }
            if (String.IsNullOrWhiteSpace(txtUsr.Text))
            {
                Err = Err + "Tienes que capturar el usuario del servidor";
                dv = false;
            }
            /*
            if (String.IsNullOrWhiteSpace(txtPwd.Text))
            {
                Err = Err + "Tienes que capturar la contraseña del servidor";
                dv = false;
            }*/

            return dv;
        }

    }
}
