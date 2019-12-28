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
    public partial class frmRptKardex : MetroForm
    {
        public frmRptKardex()
        {
            InitializeComponent();
        }

        private void frmRptKardex_Load(object sender, EventArgs e)
        {

            this.rptKardex.RefreshReport();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        public void Kardex(DataTable dt, String Articulo, String Almacen, DateTime FechaIni, DateTime FechaFin, 
                           String P_NombreEmpresa, DateTime PFechaImp)
        {
            rptKardex.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.RepKardex.rdlc";
            rptKardex.LocalReport.DataSources.Clear();
            rptKardex.LocalReport.DataSources.Add(new ReportDataSource("Kardex", dt));
            rptKardex.LocalReport.SetParameters(new ReportParameter("Articulo", Articulo));
            rptKardex.LocalReport.SetParameters(new ReportParameter("FechaIni", FechaIni.ToString("dd/MM/yyy")));
            rptKardex.LocalReport.SetParameters(new ReportParameter("FechaFin", FechaFin.ToString("dd/MM/yyy")));
            rptKardex.LocalReport.SetParameters(new ReportParameter("Almacen", Almacen));
            rptKardex.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", P_NombreEmpresa));
            rptKardex.LocalReport.SetParameters(new ReportParameter("PFechaImp", PFechaImp.ToString("dd/MM/yyy")));
            rptKardex.SetDisplayMode(DisplayMode.PrintLayout);
            //rptKardex.RefreshReport();
        }

        private void frmRptKardex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
