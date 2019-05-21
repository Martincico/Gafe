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

namespace GAFE
{
    public partial class frmCatInventarioMovtos : Form
    {
        private String TipoDocProv = "MINV"; //MINV aun no sta registrado
        private SqlDataAdapter DatosTbl;
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


        public frmCatInventarioMovtos()
        {
            InitializeComponent();
        }


        public frmCatInventarioMovtos(MsSql Odat, string perfil)
        {
            InitializeComponent();
            db = Odat;
            // Perfil = perfil;
        }

        private void frmCatInventarioMovtos_Load(object sender, EventArgs e)
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

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmRegInventarioMovtos Ventana = new frmRegInventarioMovtos(db,1,TipoDocProv);
            Ventana.ShowDialog();
            LlenaGridView();
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegInventarioMovtos Ventana = new frmRegInventarioMovtos(db, 3, TipoDocProv, grdView[0, grdView.CurrentRow.Index].Value.ToString());
                Ventana.ShowDialog();
                LlenaGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro ",
                    "Error al consultar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            /*
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            DatosTbl = pui.BuscaTipoMov(txtBuscar.Text);
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);

            grdView.Rows.Clear();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = ds.Tables[0].Rows[j].ItemArray;
                grdView.Rows.Add(tmp);
            }
            */
        }
        
        private void frmCatInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        
        private void LlenaGridView()
        {
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            DatosTbl = pui.ListarInventarioMovtos();
            DataSet Ds = new DataSet();

            try
            {
                DatosTbl.Fill(Ds);
                grdView.Columns.Clear();

                grdView.DataSource = Ds.Tables[0];
                grdView.Columns["NoMovimiento"].Visible = false;
                grdView.Columns["Cancelado"].Visible = false;
                grdView.Columns["TotalDoc"].Visible = false;
                grdView.Columns["CveTipoMov"].Visible = false;
                grdView.Columns["NoMovtoTra"].Visible = false;
                grdView.Columns["Documento"].Frozen = true;//Inmovilizar columna

                for (int i = 0; i < grdView.Columns.Count; i++)
                {
                    grdView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar listado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void grdView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdConsultar_Click(sender, e);
        }

        private void grdView_DoubleClick(object sender, EventArgs e)
        {
            cmdConsultar_Click(sender, e);
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

        private void cmEliminar_Click(object sender, EventArgs e)
        {
            Boolean Rsp = false;
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            String err = "";
            try
            {
                String NoMov = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                String IdTipMov = grdView[8, grdView.CurrentRow.Index].Value.ToString();
                db.IniciaTrans();
                if (MessageBox.Show("Esta seguro de eliminar el registro " + grdView[0, grdView.CurrentRow.Index].Value.ToString(),
                     "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pui.keyNoMovimiento = grdView[0, grdView.CurrentRow.Index].Value.ToString();
                    pui.EditarInventarioMov();

                    PuiCatTipoMovtos PuiTM = new PuiCatTipoMovtos(db);
                    PuiTM.keyCveTipoMov = IdTipMov; 
                    PuiTM.EditarTipoMov();
                    int rpp = 1;
                    if (PuiTM.cmpAfectaCosto == 1)
                    {
                        rpp = pui.AfectaCostos(pui.cmpCveTipoMov, 0);
                    }
                    if (pui.AfectaExistencias(pui.cmpEntSal, 0) >= 1 && rpp >= 1)
                    {
                        if (PuiTM.cmpEsTraspaso == 1)
                        {
                            PuiCatInventarioMov puiRel = new PuiCatInventarioMov(db);

                            puiRel.keyNoMovimiento = pui.cmpNoMovtoTra;
                            puiRel.EditarInventarioMov();

                            PuiCatTipoMovtos PuiTMRel = new PuiCatTipoMovtos(db);
                            PuiTMRel.keyCveTipoMov = puiRel.cmpCveTipoMov;
                            PuiTMRel.EditarTipoMov();

                            rpp = 1;
                            if (PuiTMRel.cmpAfectaCosto == 1)
                            {
                                rpp = puiRel.AfectaCostos(puiRel.cmpCveTipoMov, 0);
                            }
                            if (puiRel.AfectaExistencias(puiRel.cmpEntSal, 0) >= 1 && rpp >= 1)
                            {
                                Rsp = true;
                            }
                            else
                            {
                                err = "Existe un error al afectar existencias de relación";
                            }
                        }
                        else
                        {
                            Rsp = true;
                        }
                    }
                    else
                        err = "Existe un error al afectar existencias";

                    if (Rsp)
                    {
                        if (pui.EliminaInventarioMov() >= 1)
                        {
                            MessageBox.Show("Registro eliminado", "Confirmacion", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            db.TerminaTrans();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Existe un error al eliminar", "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            db.CancelaTrans();
                        }

                    }
                    else
                    {
                        MessageBox.Show(err, "Error de eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.CancelaTrans();
                    }



                }



                
                LlenaGridView();
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro\n" + ex.Message, "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
