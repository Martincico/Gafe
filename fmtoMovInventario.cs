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
    public partial class fmtoMovInventario : MetroForm
    {
        MsSql db;
        private String IdMo;
        clsNum_Letras ALetra = new clsNum_Letras();
        public fmtoMovInventario()
        {
            InitializeComponent();
        }

        public void DoctosCab(MsSql Odat, DatCfgUsuario DatUsr, DataTable dtDetalle, String IdM, String PImg,string PDocumento,
            String FmtDec, string PEsTraspaso, string PTipoMov, string PEntSal, string PAlmacenOrigen, string PAlmacenDest,
            string PTotalDscto, string PSubTotal, string PTotalIEPS,string PTIva, string PTotalDoc,
            string PObservacion)
                                //String PTotal, String PDescuento, String PEfectivo, String PCambio)
        {
            db = Odat;
            IdMo = IdM;

            String PNameEmp = "GRUPO FARMACÉUTICO SALINAS DEL SURESTE SA DE CV";
         //   String PDatosSuc = "1A. SUR Y 1A ORIENTE, BARRIO SAN JUAN, OCOZOCOAUTLA, CHIAPAS.";
            db = Odat;
            rptViewer.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoMovInvetario.rdlc";
            rptViewer.LocalReport.DataSources.Clear();

            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DSMovtoDetalle", dtDetalle));
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DSMovtoMaster", dtMaster));

            rptViewer.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_ImgEmpresa", PImg));
            rptViewer.LocalReport.SetParameters(new ReportParameter("FtmoRedondear", FmtDec));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_EsTraspaso", PEsTraspaso));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_TipoMov", PTipoMov));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_EntSal", PEntSal));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_AlmacenOrigen", PAlmacenOrigen));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_AlmacenDest", PAlmacenDest));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_TotalDscto", PTotalDscto));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_SubTotal", PSubTotal));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_TotalIEPS", PTotalIEPS));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_TIva", PTIva));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_TotalDoc", PTotalDoc));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Observacion", PObservacion));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Documento", PDocumento));




            rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
        }


        private void fmtoMovInventario_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void fmtoMovInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
