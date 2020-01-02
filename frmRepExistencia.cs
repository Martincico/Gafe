using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using System.Data.SqlClient;
using DatSql;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    public partial class frmRepExistencia : MetroForm
    {
        private string Articulo;
        private string Almacen;
        private string Linea;
        private string Buscar;
        private int Omit0;
        private string PLinea;
        private string PAlmacen;
        private string PArticulo;
        private DateTime PFechaImp;



        private string PNameEmp;

        MsSql dbR;

        public frmRepExistencia()
        {
            InitializeComponent();
        }

        public frmRepExistencia(string claveArticulo, string claveAlmacen, string claveLinea, string buscar,int omit0, String pNameEmp,
                                string P_Articulo, string P_Almacen, string P_Linea, DateTime pFechaImp, MsSql db)
        {
            Articulo = claveArticulo;
            Almacen = claveAlmacen;
            Linea = claveLinea;
            Buscar = buscar;
            Omit0 = omit0;
            dbR = db;
            PNameEmp = pNameEmp;
            PArticulo = P_Articulo;
            PAlmacen = P_Almacen;
            PLinea = P_Linea;
            PFechaImp = pFechaImp;
            InitializeComponent();

            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
        }

        private void frmRepExistencia_Load(object sender, EventArgs e)
        {
  
            PuiExistencias pui = new PuiExistencias(dbR);
            SqlDataAdapter DatosTbl = pui.BuscaExistencia(Articulo, Almacen, Linea, Buscar, Omit0);
            DataSet Ds = new DataSet();
            DatosTbl.Fill(Ds);
            List<RepExistencias> DatEs = new List<RepExistencias>();
            for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
            {
                Object[] ObjA = Ds.Tables[0].Rows[j].ItemArray;

                RepExistencias Es = new RepExistencias();

                Es.ClaveArticulo = ObjA[1].ToString();
                Es.DscArticulo = ObjA[2].ToString();
                Es.DscLinea = ObjA[3].ToString();
                Es.ClaveAlmacen = ObjA[4].ToString();
                Es.Cantidad = Convert.ToDouble(ObjA[5]);
                Es.CantidaApartada = Convert.ToDouble(ObjA[6]);
                Es.ExTotal = Convert.ToDouble(ObjA[7]);
                Es.stockMin = Convert.ToDouble(ObjA[8]);
                Es.stockMax = Convert.ToDouble(ObjA[9]);
                Es.CostoPromedio = Convert.ToDouble(ObjA[10]);
                Es.CostoUltimo = Convert.ToDouble(ObjA[11]);
                Es.CostoActual = Convert.ToDouble(ObjA[12]);
                Es.Ubicacion = ObjA[13].ToString();
                DatEs.Add(Es);


            }


            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GAFE.Reportes.RepExistencias.rdlc";
            ReportDataSource rds1 = new ReportDataSource("RepExistencias", DatEs);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);

            ReportParameter Art = new ReportParameter("ClaveArticulo", Articulo);
            ReportParameter Alm = new ReportParameter("ClaveAlmacen", Almacen);
            ReportParameter Lin = new ReportParameter("ClaveLinea", Linea);
            ReportParameter Bsc = new ReportParameter("Buscar", Buscar);
            
            this.reportViewer1.LocalReport.SetParameters(Art);
            this.reportViewer1.LocalReport.SetParameters(Alm);
            this.reportViewer1.LocalReport.SetParameters(Lin);
            this.reportViewer1.LocalReport.SetParameters(Bsc);
            reportViewer1.LocalReport.SetParameters(new ReportParameter("P_NombreEmpresa", PNameEmp));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("OmiteExis0", Convert.ToString(Omit0)));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("PArticulo", PArticulo));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("PAlmacen", PAlmacen));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("PLinea", PLinea));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("PFechaImp", PFechaImp.ToString("dd/MM/yyy")));



            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //this.reportViewer1.RefreshReport();
        }

        private void frmRepExistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
