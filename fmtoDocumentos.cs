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
    public partial class fmtoDocumentos : MetroForm
    {
        MsSql db;
        private String IdMo;
        public fmtoDocumentos()
        {
            InitializeComponent();
        }

        public void DoctosCab(MsSql Odat, DataTable dt,String IdM,  String PNameEmp, String PImg, String PNameDoc)
        {
            db = Odat;
            IdMo = IdM;
            rptDocumentos.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoDocumentos.rdlc";
            rptDocumentos.LocalReport.DataSources.Clear();
            rptDocumentos.LocalReport.DataSources.Add(new ReportDataSource("DoctosCab", dt));
            //private stream2 As StreamReader = File.OpenText(rdlc_name)
            //rptDocumentos.LocalReport.LoadSubreportDefinition();
            rptDocumentos.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(DocDetailsSubRpr);
            rptDocumentos.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            rptDocumentos.LocalReport.SetParameters(new ReportParameter("P_NombreDoc", PNameDoc));
            rptDocumentos.LocalReport.SetParameters(new ReportParameter("P_ImgEmpresa",  PImg));
            rptDocumentos.SetDisplayMode(DisplayMode.PrintLayout);
            //rptKardex.RefreshReport();
        }

        private void DocDetailsSubRpr(object sender, SubreportProcessingEventArgs e)
        {
            DocPuiRequisiciones rq = new DocPuiRequisiciones(db);
            rq.keyidMov = IdMo;
            DataTable dt = rq.DocDetPrint();
            ReportDataSource ds = new ReportDataSource("DoctosDet", dt);
            e.DataSources.Add(ds);
        }


        private void fmtoDocumentos_Load(object sender, EventArgs e)
        {
            this.rptDocumentos.RefreshReport();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void fmtoDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
