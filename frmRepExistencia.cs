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

namespace GAFE
{
    public partial class frmRepExistencia : Form
    {
        private string Articulo;
        private string Almacen;
        private string Linea;
        private string Buscar;

        MsSql dbR;

        public frmRepExistencia()
        {
            InitializeComponent();
        }

        public frmRepExistencia(string claveArticulo, string claveAlmacen, string claveLinea, string buscar, MsSql db)
        {
            Articulo = claveArticulo;
            Almacen = claveAlmacen;
            Linea = claveLinea;
            Buscar = buscar;
            dbR = db;
            InitializeComponent();
        }

        private void frmRepExistencia_Load(object sender, EventArgs e)
        {
            object[,] MatParam = new object[4, 3];
            MatParam[0, 0] = "@ClaveArticulo"; MatParam[0, 1] = Articulo; MatParam[0, 2] = "1";
            MatParam[1, 0] = "@ClaveAlmacen"; MatParam[1, 1] = Almacen; MatParam[1, 2] = "1";
            MatParam[2, 0] = "@ClaveLinea"; MatParam[2, 1] = Linea; MatParam[2, 2] = "1";
            MatParam[3, 0] = "@Buscar"; MatParam[3, 1] = Buscar; MatParam[3, 2] = "1";
            SqlDataAdapter da = dbR.ExeProc_DA("RepExistencias", MatParam);
            DataSet Ds = new DataSet();
            da.Fill(Ds);
            List<RepExistencias> DatEs = new List<RepExistencias>();
            for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
            {
                Object[] ObjA = Ds.Tables[0].Rows[j].ItemArray;

                RepExistencias Es = new RepExistencias();

                Es.ClaveArticulo = ObjA[0].ToString();
                Es.DscArticulo = ObjA[1].ToString();
                Es.DscLinea = ObjA[2].ToString();
                Es.ClaveAlmacen = ObjA[3].ToString();
                Es.Cantidad = Convert.ToDouble(ObjA[4]);
                Es.CantidaApartada = Convert.ToDouble(ObjA[5]);
                Es.ExTotal = Convert.ToDouble(ObjA[6]);
                Es.stockMin = Convert.ToDouble(ObjA[7]);
                Es.stockMax = Convert.ToDouble(ObjA[8]);
                Es.CostoPromedio = Convert.ToDouble(ObjA[9]);
                Es.CostoUltimo = Convert.ToDouble(ObjA[10]);
                Es.CostoActual = Convert.ToDouble(ObjA[11]);
                Es.Ubicacion = ObjA[12].ToString();
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


            this.reportViewer1.RefreshReport();
        }
    }
}
