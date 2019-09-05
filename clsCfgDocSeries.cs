using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
  public class clsCfgDocSeries
    {
        public string CveAlmacen;
        public string CveDoc;
        public string Serie;
        public string Descripcion;
        public string CodFoliador;
        public int EditaFolio;
        public string FmtoImpresion;
        public int NoCopiasImp;
        public string NombImpresora;
        public int PregImpresion;
        public int Estatus;

        private MsSql db = null;
        //private SqlParameter[] ArrParametros;

        public clsCfgDocSeries(string CveAlm, string _CveDoc, string Ser, MsSql Odat)
        {
            CveAlmacen = CveAlm;
            CveDoc = _CveDoc;
            Serie = Ser;
            db = Odat;
        }

        public clsCfgDocSeries()
        {
            
        }

        public clsCfgDocSeries ConfigDocSerie()
        {
            clsCfgDocSeries Doc = new clsCfgDocSeries();
            string Sql = "Select * " +
                         "from CfgDocSerie " +
                         "WHERE CveAlmacen = '" + CveAlmacen + "' AND CveDoc = '"+ CveDoc + "' AND Serie = '"+ Serie+"'" ;
            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.CveAlmacen = Convert.ToString(dr["CveAlmacen"]);
                Doc.CveDoc = Convert.ToString(dr["CveDoc"]);
                Doc.Serie = Convert.ToString(dr["Serie"]);
                Doc.Descripcion = Convert.ToString(dr["Descripcion"]);
                Doc.CodFoliador = Convert.ToString(dr["CodFoliador"]);
                Doc.EditaFolio = Convert.ToInt32(dr["EditaFolio"]);
                Doc.FmtoImpresion = Convert.ToString(dr["FmtoImpresion"]);
                Doc.NoCopiasImp = Convert.ToInt32(dr["NoCopiasImp"]);
                Doc.NombImpresora = Convert.ToString(dr["NombImpresora"]);
                Doc.PregImpresion = Convert.ToInt32(dr["PregImpresion"]);
                Doc.Estatus = Convert.ToInt32(dr["Estatus"]);
                
            }
            dr.Close();
            return Doc;
        }


    }
}
