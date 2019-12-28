using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatSucursales
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatSucursales(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatSucursales(MsSql Odat) { db = Odat; }


        public int AddRegSucursales()
        {
            string sql = "Insert into CatSucursales (CveSucursal,Nombre,Calle,CveLocalidad,CP,Tel,Mail,Contacto,Cargo,Estatus) " +
                         "values(@CveSucursal,@Nombre,@Calle,@CveLocalidad,@CP,@Tel,@Mail,@Contacto,@Cargo,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateSucursales()
        {
            string sql = "Update CatSucursales set " +
                        "Nombre=@Nombre, " +
                        "Calle=@Calle, " +
                        "CveLocalidad=@CveLocalidad, " +
                        "CP=@CP, " +
                        "Tel=@Tel, " +
                        "Mail=@Mail, " +
                        "Estatus=@Estatus, " +
                        "Contacto=@Contacto, " +
                        "Cargo=@Cargo " +
                        "Where CveSucursal = @CveSucursal";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteSucursales()
        {
            /*
            string sql = "Delete from CatSucursales where CveSucursal = @CveSucursal";
            return db.UpdateRegistro(sql, ArrParametros);
            */
            string sql = "Update CatSucursales set Estatus = 0 Where CveSucursal = @CveSucursal";
            return db.DeleteRegistro(sql, ArrParametros);
        }


        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveSucursal,Nombre,Calle,CveLocalidad,CP,Tel,Mail,Contacto,Cargo,Estatus " +
                          "from CatSucursales where CveSucursal = @CveSucursal";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter ListSucursales()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT P.CveSucursal, P.Nombre,P.Calle,G2.Descripcion,G2.Descripcion as Municipio " +
                         " FROM dbo.CatSucursales AS P " +
                         " INNER JOIN dbo.CatGeografia AS G1 ON P.CveLocalidad = G1.id " +
                         " INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre" +
                         " WHERE P.Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter BuscaSucursal(string bsq)
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT CveSucursal, P.Nombre,P.Calle,G2.Descripcion,P.RFC,G2.Descripcion as Municipio " +
                        " FROM dbo.CatSucursales AS P " +
                        " INNER JOIN dbo.CatGeografia AS G1 ON P.CveLocalidad = G1.id " +
                        " INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre " +
                        " WHERE P.Estatus = 1 AND (P.CveSucursal like '%" + bsq + "%' OR " +
                        "P.Nombre like '%" + bsq + "%')";

            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter LLenaCboSucursales()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveSucursal as Clave,Nombre as Descripcion " +
                         "from CatSucursales where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}

