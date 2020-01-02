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
        clsNum_Letras ALetra = new clsNum_Letras();


        public fmtoTicket()
        {
            InitializeComponent();
            
        }

        public void PrintTicket(MsSql Odat, DatCfgUsuario DatUsr, DataTable dt,String IdM, 
                                String PTotal,String PDescuento, String PEfectivo, String PCambio)
        {
            String PNameEmp = "GRUPO FARMACÉUTICO SALINAS DEL SURESTE SA DE CV";
            //String PImg = "";
            String PDatosEmp = "CALLE MIRADOR S/N Y TORBELLINO, COL. LINDOS AIRES, CP. 29130, BERRIOZÁBAL, CHIAPAS.";
            String PDatosSuc = "1A. SUR Y 1A ORIENTE, BARRIO SAN JUAN, OCOZOCOAUTLA, CHIAPAS.";
            db = Odat;
            IdMo = IdM;
            rptTicket.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.fmtoTicket.rdlc";
            rptTicket.LocalReport.DataSources.Clear();
            /*
             
             string path = "file:\\" + Application.StartupPath + infomacion.Rows[0]["logo"];
            string pathqr = "file:\\" + Application.StartupPath + factura.Rows[0]["QR"].ToString();
            parameters[15] = new ReportParameter("Path", @path, true);
            parameters[0] = new ReportParameter("PathQr", @pathqr, true);
              
            */

            rptTicket.LocalReport.DataSources.Add(new ReportDataSource("TicketDet", dt));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            //rptTicket.LocalReport.SetParameters(new ReportParameter("P_ImgEmpresa", PImg));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_DatosEmp", PDatosEmp));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Sucursal", DatUsr.AlmacenUsa));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Folio", IdM));
            //rptTicket.LocalReport.SetParameters(new ReportParameter("P_Fecha", PFecha));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Total", PTotal));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Descuento", PDescuento));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Efectivo", PEfectivo));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Cambio", PCambio));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Round", "2"));
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_DatosSuc", PDatosSuc));
            String LetTotal = ALetra.Convertir(PTotal, 2);
            rptTicket.LocalReport.SetParameters(new ReportParameter("P_Letras", LetTotal));




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
