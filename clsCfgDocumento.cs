using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
  public class clsCfgDocumento
    {
        public string ClaveDoc;
        public string Nombre;
        public string CargoAbono;
        public String CveTipoMov;
        public String Foliador;
        public int UsaSerie;
        public int EditaFecha;
        public int Estatus;
        public int EsInterno;

        private MsSql db = null;
        //private SqlParameter[] ArrParametros;

        public clsCfgDocumento(string clavedoc, MsSql Odat)
        {
            ClaveDoc = clavedoc;
            db = Odat;
        }

        public clsCfgDocumento()
        {
            
        }

        public clsCfgDocumento ConfigDoc()
        {
            clsCfgDocumento Doc = new clsCfgDocumento();
            string Sql = "Select * " +
                         "from CfgTipoMovProv WHERE ClaveDoc = '"+this.ClaveDoc+"'";
            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.ClaveDoc = Convert.ToString(dr["ClaveDoc"]);
                Doc.Nombre = Convert.ToString(dr["Nombre"]);
                Doc.CargoAbono = Convert.ToString(dr["CargoAbono"]);
                Doc.CveTipoMov = Convert.ToString(dr["CveTipoMov"]);
                Doc.Foliador = Convert.ToString(dr["Foliador"]);
                Doc.UsaSerie = Convert.ToInt32(dr["UsaSerie"]);
                Doc.EditaFecha = Convert.ToInt32(dr["EditaFecha"]);
                Doc.EsInterno = Convert.ToInt32(dr["EsInterno"]);
                Doc.Estatus = Convert.ToInt32(dr["Estatus"]);
            }
            dr.Close();
            return Doc;
        }


    }
}
