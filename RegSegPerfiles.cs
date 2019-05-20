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
    class RegSegPerfiles
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegSegPerfiles(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegSegPerfiles(MsSql Odat) { db = Odat; }



        public int AddRegPerfil()
        {
            string sql = "Insert into SPerfiles (CodPerfil,Descripcion) " +
                         "values (@CodPerfil,@Descripcion)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdatePerfil()
        {
            string sql = "Update SPerfiles set Descripcion = @Descripcion " +
                         "Where CodPerfil = @CodPerfil";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeletePerfil()
        {
            string sql = "Delete from SPerfiles where CodPerfil = @CodPerfil";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListPerfiles()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodPerfil,Descripcion " +
                         "from SPerfiles";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodPerfil, Descripcion " +
                          "from SPerfiles where CodPerfil = @CodPerfil";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaPerfil(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CodPerfil,Descripcion " +
               "from SPerfiles " +
               "where CodPerfil like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter ComboSPerfiles()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodPerfil as Clave,Descripcion " +
                         "from SPerfiles";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
