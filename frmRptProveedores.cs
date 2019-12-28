using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmRepProveedores : MetroForm
    {
        public frmRepProveedores()
        {
            InitializeComponent();
        }

        private void frmRepProveedores_Load(object sender, EventArgs e)
        {

            this.rptProveedores.RefreshReport();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        public void Proveedores(DataTable dt, String CveProv, String Almacen, DateTime FechaIni, DateTime FechaFin, 
                           String P_NombreEmpresa, DateTime PFechaImp)
        {
            rptProveedores.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.RepKardex.rdlc";
            rptProveedores.LocalReport.DataSources.Clear();
            rptProveedores.LocalReport.DataSources.Add(new ReportDataSource("Kardex", dt));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("P_CveProv", CveProv));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("FechaIni", FechaIni.ToString("dd/MM/yyy")));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("FechaFin", FechaFin.ToString("dd/MM/yyy")));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("Almacen", Almacen));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", P_NombreEmpresa));
            rptProveedores.LocalReport.SetParameters(new ReportParameter("PFechaImp", PFechaImp.ToString("dd/MM/yyy")));
            rptProveedores.SetDisplayMode(DisplayMode.PrintLayout);
            //rptProveedores.RefreshReport();
        }

        private void frmRepProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
