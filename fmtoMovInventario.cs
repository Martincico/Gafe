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

        public void DoctosCab(MsSql Odat, DatCfgUsuario DatUsr,DataTable dtMaster, DataTable dtDetalle, String IdM, string PNombreDoc, String PImg,
            String FmtDec)
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
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DSMovtoMaster", dtMaster));

            rptViewer.LocalReport.SetParameters(new ReportParameter("P_NombreDoc", PNombreDoc));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_ImgEmpresa", PImg));
            rptViewer.LocalReport.SetParameters(new ReportParameter("FtmoRedondear", FmtDec));


            /*
            
            
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Sucursal", DatUsr.AlmacenUsa));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Folio", IdM));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("P_Fecha", PFecha));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Total", PTotal));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Descuento", PDescuento));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Efectivo", PEfectivo));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Cambio", PCambio));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Round", "2"));
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_DatosSuc", PDatosSuc));
            String LetTotal = ALetra.Convertir(PTotal, 2);
            rptViewer.LocalReport.SetParameters(new ReportParameter("P_Letras", LetTotal));

    */


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
