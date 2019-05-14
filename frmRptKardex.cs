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

namespace GAFE
{
    public partial class frmRptKardex : Form
    {
        public frmRptKardex()
        {
            InitializeComponent();
        }

        private void frmRptKardex_Load(object sender, EventArgs e)
        {

            this.rptKardex.RefreshReport();
        }

        public void Kardex(DataTable dt, String Articulo, String Almacen, DateTime FechaIni, DateTime FechaFin)
        {
            rptKardex.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.RepKardex.rdlc";
            rptKardex.LocalReport.DataSources.Clear();
            rptKardex.LocalReport.DataSources.Add(new ReportDataSource("Kardex", dt));
            rptKardex.LocalReport.SetParameters(new ReportParameter("Articulo", Articulo));
            rptKardex.LocalReport.SetParameters(new ReportParameter("FechaIni", FechaIni.ToString("dd/MM/yyy")));
            rptKardex.LocalReport.SetParameters(new ReportParameter("FechaFin", FechaFin.ToString("dd/MM/yyy")));
            rptKardex.LocalReport.SetParameters(new ReportParameter("Almacen", Almacen));
            //rptKardex.RefreshReport();
        }
    }
}
