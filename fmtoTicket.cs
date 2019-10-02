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

using DatSql;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class fmtoTicket : MetroForm
    {
        MsSql db;
        private String IdMo;

        public fmtoTicket()
        {
            InitializeComponent();
        }

        public void PrintTicket(MsSql Odat, DataTable dt,String IdM,  String PNameEmp, String PImg, String PNameDoc)
        {
            db = Odat;
            IdMo = IdM;
            rptTicket.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoTicket.rdlc";
            rptTicket.LocalReport.DataSources.Clear();
            rptTicket.LocalReport.DataSources.Add(new ReportDataSource("TicketDet", dt));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_NombreDoc", PNameDoc));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_ImgEmpresa",  PImg));
            rptTicket.LocalReport.PrintToPrinter();

        }


        private void fmtoTicket_Load(object sender, EventArgs e)
        {
            this.rptTicket.RefreshReport();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void fmtoTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
