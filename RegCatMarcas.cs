using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatMarcas
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatMarcas(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatMarcas(MsSql Odat) { db = Odat; }

        public int AddRegMarcas()
        {
            string sql = "Insert into Inv_Marcas (CveMarca,Descripción,Estatus) " +
                         "values(@CveMarca,@Descripcion,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateMarcas()
        {
            string sql = "Update Inv_Marcas set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus " +
                         "Where CveMarca = @CveMarca";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteMarcas()
        {
            string sql = "Delete from Inv_Marcas where CveMarca = @CveMarca";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListMarcas()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMarca,Descripcion " +
                         "from Inv_Marcas";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMarca,Descripcion,Estatus " +
                          "from Inv_Marcas where CveMarca =@CveMarca";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaMarcas(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveMarca,Descripcion " +
               "from Inv_Marcas " +
               "where CveMarca like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
    }
}
