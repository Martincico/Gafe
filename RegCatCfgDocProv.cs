using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatCfgDocProv
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgDocProv(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgDocProv(MsSql Odat) { db = Odat; }

        public int AddRegLinea()
        {
            string sql = "Insert into CfgDocProv (CveLinea,Descripción,Estatus) " +
                         "values(@CveLinea,@Descripcion,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateLinea()
        {
            string sql = "Update CfgDocProv set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus " +
                         "Where CveLinea = @CveLinea";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteLinea()
        {
            string sql = "Delete from CfgDocProv where CveLinea = @CveLinea";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListLineas()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLinea,Descripcion " +
                         "from CfgDocProv";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLinea,Descripcion,Estatus " +
                          "from CfgDocProv where CveLinea =@CveLinea";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaLinea(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveLinea,Descripcion " +
               "from CfgDocProv " +
               "where CveLinea like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter ComboLinea()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLinea as Clave,Descripcion " +
                         "from CfgDocProv";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
