using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatSql;
using System.Data.SqlClient;

namespace GAFE
{
    public class DatCfgParamSystem
    {
        public int AfectaExistAuto;
        public int HideCveArt;
        public int MultipleCodBarra;
        public int NumDec;

        private MsSql db = null;

        public DatCfgParamSystem( MsSql db)
        {
            this.db = db;
        }

        public DatCfgParamSystem()
        {
        }

        public DatCfgParamSystem ParaSystem()
        {
            DatCfgParamSystem Doc = new DatCfgParamSystem();
            string Sql = " SELECT * FROM application_parameters "; //CodParametro,Descripción,ModUsa,Valor,

            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                switch (dr["CodParametro"])
                {
                    case "AfectaExistAuto": Doc.AfectaExistAuto = Convert.ToInt32(dr["Valor"]); break;
                    case "MultipleCodBarra": Doc.MultipleCodBarra  = Convert.ToInt32(dr["Valor"]); break;
                    case "NumDec": Doc.NumDec  = Convert.ToInt32(dr["Valor"]); break;
                    case "HideCveArt": Doc.HideCveArt = Convert.ToInt32(dr["Valor"]); break;
                }
            }
            dr.Close();
            return Doc;

        }

 

    }
}
