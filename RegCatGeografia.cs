using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatGeografia
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatGeografia(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatGeografia(MsSql Odat) { db = Odat; }

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

        public int AddRegGeografia()
        {
            string sql = "Insert into CatGeografia (Descripcion, Estatus, Padre) " +
                         "values(@Descripcion, @Estatus, @Padre)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateGeografia()
        {
            string sql = "Update CatGeografia set " +
                         "Descripcion = @Descripcion, " +
                         "Estatus = @Estatus, " +
                         "Padre = @Padre " +
                         "Where id = @id";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteGeografia()
        {
            string sql = "Delete from CatGeografia where id = @id";
            return db.UpdateRegistro(sql, ArrParametros);
        }

       
        public SqlDataAdapter ListHijos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select id as Clave,Descripcion " +
                         "from CatGeografia " +
                         "where Padre = @Padre " +
                         "order by Descripcion";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }


        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select id ,Descripcion,Estatus,Padre " +
                          "from CatGeografia where id =@id";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter ComboGeografia()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select id as Clave,Descripcion " +
                         "from CatGeografia where Estatus=1 AND " +
                         "Padre = @Padre";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }
    }
}
