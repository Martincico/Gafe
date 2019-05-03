using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatKardex
    {

        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg


        public SqlDataAdapter ListArticulos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveArticulo as Clave,CodigoBarra as Codigo,A.Descripcion,CodigoSat as 'Codigo SAT',Modelo," +
                         "L.Descripcion as Linea,M.Descripcion as Marca,C.Descripcion as Clase,UM.Descripcion as 'U Medida',Observacion " +
                         "FROM inv_CatArticulos A Left join Inv_Lineas L on A.CveLinea = L.CveLinea " +
                         "Left join Inv_Clases C on A.CveClase1 = C.CveClase " +
                         "Left Join Inv_UMedidas UM on A.CveUMedida1 = UM.CveUMedida  " +
                         "Left Join Inv_Marcas M on A.CveMarca = M.Descripción";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select * " +
                          "from Inv_CatArticulos where CveArticulo =@CveArticulo";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }
    }
}
