using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatSql;
using System.Data.SqlClient;

namespace GAFE
{
    public class DatCfgSystem
    {
        public String NombreEmpresa;
        public String Ubicacion;
        public String Direccion;
        public String Municipio;
        public String Estado;
        public int ActivaModulo;
        public int EsMatriz;
        public int EsSucursal;
        public int TiempoSic;

        private MsSql db = null;

        public DatCfgSystem( MsSql db)
        {
            this.db = db;
        }

        public DatCfgSystem()
        {
        }

        public DatCfgSystem CfgSistema()
        {
            DatCfgSystem Doc = new DatCfgSystem();
            string Sql = " SELECT * FROM ConfigSistema "; 

            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.NombreEmpresa = Convert.ToString(dr["NombreEmpresa"]);
                Doc.Ubicacion = Convert.ToString(dr["Ubicacion"]);
                Doc.Direccion = Convert.ToString(dr["Direccion"]);
                Doc.Municipio = Convert.ToString(dr["Municipio"]);
                Doc.Estado = Convert.ToString(dr["Estado"]);
                Doc.ActivaModulo = Convert.ToInt32(dr["ActivaModulo"]);
                Doc.EsMatriz = Convert.ToInt32(dr["EsMatriz"]);
                Doc.EsSucursal = Convert.ToInt32(dr["EsSucursal"]);
                Doc.TiempoSic = Convert.ToInt32(dr["TiempoSic"]);
            }
            dr.Close();
            return Doc;

        }

 

    }
}
