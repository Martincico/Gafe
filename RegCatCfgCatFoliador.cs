using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DatSql;
using System.Windows.Forms;



namespace GAFE
{
    class RegCatCfgCatFoliador
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgCatFoliador(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgCatFoliador(MsSql Odat) { db = Odat; }

        /*
        public void Conn()
        {
            /*db = new DatSql.MsSql(
                   ConfigurationSettings.AppSettings.Get("Servidor"),
                   ConfigurationSettings.AppSettings.Get("Datos"),
                   ConfigurationSettings.AppSettings.Get("Usuario"),
                   ConfigurationSettings.AppSettings.Get("Password")
                   );
            
            db = new DatSql.MsSql("SIGMA6\\SQL14", "CtrlAcceso", "sa", "Remolachas1");
                   
            if (db.Conectar() < 1)
                MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    */

        public int AddRegCfgCatFoliador()
        {           
            string sql = "Insert into CfgCatFoliadores (CveFoliador,CveModulo,Descripción,Uso) " +
                         "values(@CveFoliador,@CveModulo,@Descripcion,@Uso)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateCfgCatFoliador()
        {
            string sql = "Update CfgCatFoliadores set Descripcion = @Descripcion, " +
                         "CveModulo = @CveModulo, " +
                         "Uso = @Uso " +
                         "Where CveFoliador = @CveFoliador";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteCfgCatFoliador()
        {
            string sql = "Delete from CfgCatFoliadores where CveFoliador = @CveFoliador";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListCfgCatFoliadores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveFoliador,Descripcion " +
                         "from CfgCatFoliadores";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveFoliador,CveModulo,Descripción,Uso " +
                          "from CfgCatFoliadores where CveFoliador =@CveFoliador";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaCfgCatFoliador(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveFoliador,Descripcion " +
               "from CfgCatFoliadores " +
               "where CveFoliador like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public SqlDataAdapter CboCfgModuloSys()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveModulo, Descripcion " +
                         "from CfgModuloSys WHERE activo=1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter cboCfgCatFoliadores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveFoliador, Descripcion " +
                         "from CfgCatFoliadores";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
