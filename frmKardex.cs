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

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmKardex : MetroForm
    {
        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;
        private clsUtil uT;
        DataTable dt;

        public DatCfgUsuario user;

        public frmKardex()
        {
            InitializeComponent();
        }

        public frmKardex(MsSql Odat, DatCfgUsuario DatUsr)
        {
            
            InitializeComponent();
            db = Odat;
            user = DatUsr;

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void cmdArticulo_Click(object sender, EventArgs e)
        {
            frmLstArticulos art = new frmLstArticulos(db, user.CodPerfil, 3);
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

            uT = new clsUtil(db, user.CodPerfil);
            uT.CargaArbolAcceso();


            clsUsPerfil up = uT.BuscarIdNodo("1Inv012A");
            int AcCOP = (up != null) ? up.Acceso : 0;
            cmdConsultar.Enabled = (AcCOP == 1) ? true : false;

            up = uT.BuscarIdNodo("1Inv012B");
            AcCOP = (up != null) ? up.Acceso : 0;
            cmdImprimir.Enabled = (AcCOP == 1) ? true : false;

            PuiCatAlmacenes alm = new PuiCatAlmacenes(db);
            cboAlmacenes.DataSource = alm.CboInv_CatAlmacenes();

            cboAlmacenes.Enabled = user.CambiaAlmacen == 1 ? true : false;
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
                MessageBoxAdv.Show("Clave de Artículo: Debe seleccionar un artículo.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmdArticulo.Focus();
                resp = false;
            }
            if(cboAlmacenes.SelectedIndex<0)
            {
                MessageBoxAdv.Show("Clave de Almacen: Debe seleccionar un Almacen.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAlmacenes.Focus();
                resp = false;
            }
            if(dtFechaInicio.Value>dtFechaFin.Value)
            {
                MessageBoxAdv.Show("Fecha Inicio: La Fecha de Inicio debe ser mayor a la Fecha Final.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmKardex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
