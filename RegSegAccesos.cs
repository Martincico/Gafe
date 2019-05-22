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
    class RegSegAccesos
    {
        private MsSql db = null;

        private SqlParameter[] ArrParametros;


        public RegSegAccesos(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
        
            db = Odat;
        }

        public RegSegAccesos(MsSql Odat) { db = Odat; }


        public int AddRegAcceso()
        {
            string sql = "Insert into SAccesos (CodPerfil,idNodo,idPadre,Acceso) " +
                         "values(@CodPerfil,@idNodo,@idPadre,@Acceso)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int UpdatePerfil()
        {
            string sql = "Update SAccesos set Acceso = @Acceso " +
                         "Where CodPerfil = @CodPerfil and " +
                         "idNodo = @idNodo and " +
                         "idPadre = @idPadre";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select * " +
                          "from SAccesos where CodPerfil =@CodPerfil";
            dt = db.SelectDA(Sql, ArrParametros);
       
            return dt;
        }


        public SqlDataAdapter RegistroActivo2()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select * " +
                          "from SAccesos where CodPerfil =@CodPerfil and idNodo = @idNodo and idPadre = @idPadre";
            dt = db.SelectDA(Sql, ArrParametros);

            return dt;
        }

    }
}
