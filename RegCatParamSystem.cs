using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatParamSystem
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatParamSystem(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatParamSystem(MsSql Odat) { db = Odat; }


        public int AddRegParamSystem()
        {
            string sql = "Insert into application_parameters (CodParametro,Descripción,ModUsa,Valor) " +
                         "values(@CodParametro,@Descripcion,@ModUsa,@Valor)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateParamSystem()
        {
            string sql = "Update application_parameters set Descripcion = @Descripcion, " +
                         "ModUsa = @ModUsa, Valor = @Valor " +
                         "Where CodParametro = @CodParametro";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteParamSystem()
        {
            string sql = "Delete from application_parameters where CodParametro = @CodParametro";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListParamSystems()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodParametro,Descripcion " +
                         "from application_parameters";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodParametro,Descripcion,ModUsa,Valor " +
                          "from application_parameters where CodParametro =@CodParametro";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaParamSystem(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CodParametro,Descripcion " +
               "from application_parameters " +
               "where CodParametro like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter ComboParamSystem()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodParametro as Clave,Descripcion " +
                         "from application_parameters";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
