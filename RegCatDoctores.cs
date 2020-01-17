using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatDoctores
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatDoctores(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatDoctores(MsSql Odat) { db = Odat; }

        

        public int AddRegDoctores()
        {
            string sql = "Insert into CatDoctores (Cedula,Nombre,Calle,Telefono,Localidad,Correo,CP) " +
                         "values (@Cedula,@Nombre,@Calle,@Telefono,@Localidad,@Correo,@CP)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateDoctores()
        {
            string sql = "Update CatDoctores set " +
                        "Nombre=@Nombre, " +
                        "Calle=@Calle, " +
                        "Telefono=@Telefono, " +
                        "Localidad=@Localidad, " +
                        "Correo=@Correo, " +
                        "CP=@CP " +
                         "Where Cedula=@Cedula";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteDoctores()
        {
            string sql = "Delete from CatDoctores where Cedula = @Cedula";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListDoctores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select D.Cedula,D.Nombre,D.Calle,D.Telefono,D.Correo,D.CP, G2.Descripcion as Municipio " +
                         "FROM CatDoctores AS D" +
                         "INNER JOIN dbo.CatGeografia AS G1 ON P.CveLocalidad = G1.id " +
                         "INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre " +
                         " order by D.Nombre ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select Cedula,Nombre,Calle,Telefono,Localidad,Correo,CP " +
                          "from CatDoctores where Cedula =@Cedula";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaDoctores(string bsq)
        {
            SqlDataAdapter dt = null;
            string Sql = "Select D.Cedula,D.Nombre,D.Calle,D.Telefono,D.Correo,D.CP, G2.Descripcion as Municipio " +
                       "FROM CatDoctores AS D " +
                       "INNER JOIN dbo.CatGeografia AS G1 ON D.Localidad = G1.id " +
                       "INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre " +
                       "WHERE D.Cedula like '%" + bsq + "%' OR " +
                       "D.Nombre like '%" + bsq + "%' OR " +
                       "D.Calle like '%" + bsq + "%' OR " +
                       "G2.Descripcion like '%" + bsq + "%' " +
                       "order by Nombre";

            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter ComboDoctores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select Cedula as Clave,Nombre " +
                         "from CatDoctores " +
                         "order by Nombre";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
