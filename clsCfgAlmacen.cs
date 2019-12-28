using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
  public class clsCfgAlmacen
    {
        public String ClaveAlmacen;
        public String Descripcion;
        public String Estatus;
        public int EsDeCompra;
        public int EsDeVenta;
        public int EsDeConsigna;
        public int NumRojo;
        public String CveLstPrecio;


        private MsSql db = null;

        public clsCfgAlmacen(MsSql Odat, string CveAlm)
        {
            ClaveAlmacen = CveAlm;
            db = Odat;
        }

        public clsCfgAlmacen()
        {
            
        }

        public clsCfgAlmacen ConfigAlmacen()
        {
            clsCfgAlmacen Doc = new clsCfgAlmacen();
            string Sql = "Select * " +
                         "from Inv_CatAlmacenes " +
                         "WHERE ClaveAlmacen = '" + ClaveAlmacen + "' " +
                         "  AND Estatus = 'A'";
            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.ClaveAlmacen = Convert.ToString(dr["ClaveAlmacen"]);
                Doc.Descripcion = Convert.ToString(dr["Descripcion"]);
                Doc.Estatus = Convert.ToString(dr["Estatus"]);
                Doc.EsDeCompra = Convert.ToInt32(dr["EsDeCompra"]);
                Doc.EsDeVenta = Convert.ToInt32(dr["EsDeVenta"]);
                Doc.EsDeConsigna = Convert.ToInt32(dr["EsDeConsigna"]);
                Doc.NumRojo = Convert.ToInt32(dr["NumRojo"]);
                Doc.CveLstPrecio = Convert.ToString(dr["CveLstPrecio"]);
            }
            dr.Close();
            return Doc;
        }


    }
}
