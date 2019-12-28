using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatProveedores
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatProveedores(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatProveedores(MsSql Odat) { db = Odat; }


        public int AddRegProveedores()
        {
            string sql = "Insert into CatProveedores (CveProveedor,Nombre,RFC,Calle,CveLocalidad,CP,Tel1,Mail1,TipoPersona,Estatus,Contacto,Tel2,Mail2,Cargo,Celular) " +
                         "values(@CveProveedor,@Nombre,@RFC,@Calle,@CveLocalidad,@CP,@Tel1,@Mail1,@TipoPersona,@Estatus,@Contacto,@Tel2,@Mail2,@Cargo,@Celular)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateProveedores()
        {
            string sql = "Update CatProveedores set " +
                        "Nombre=@Nombre, " +
                        "RFC=@RFC, " +
                        "Calle=@Calle, " +
                        "CveLocalidad=@CveLocalidad, " +
                        "CP=@CP, " +
                        "Tel1=@Tel1, " +
                        "Mail1=@Mail1, " +
                        "TipoPersona=@TipoPersona, " +
                        "Estatus=@Estatus, " +
                        "Contacto=@Contacto, " +
                        "Tel2=@Tel2, " +
                        "Mail2=@Mail2, " +
                        "Cargo=@Cargo, " +
                        "Celular=@Celular " +
                         "Where CveProveedor = @CveProveedor";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteProveedores()
        {
            string sql = "Delete from CatProveedores where CveProveedor = @CveProveedor";
            return db.UpdateRegistro(sql, ArrParametros);
        }


        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveProveedor,Nombre,RFC,Calle,CveLocalidad,CP,Tel1,Mail1,TipoPersona,Estatus,Contacto,Tel2,Mail2,Cargo,Celular " +
                          "from CatProveedores where CveProveedor = @CveProveedor";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter ListProveedores()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT P.CveProveedor, P.Nombre,P.Calle,G2.Descripcion,P.RFC,G2.Descripcion as Municipio " +
                         " FROM dbo.CatProveedores AS P " +
                         " INNER JOIN dbo.CatGeografia AS G1 ON P.CveLocalidad = G1.id " +
                         " INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre" +
                         " WHERE P.Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter BuscaProvedor(string bsq)
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT CveProveedor, P.Nombre,P.Calle,G2.Descripcion,P.RFC,G2.Descripcion as Municipio " +
                        " FROM dbo.CatProveedores AS P " +
                        " INNER JOIN dbo.CatGeografia AS G1 ON P.CveLocalidad = G1.id " +
                        " INNER JOIN dbo.CatGeografia AS G2 ON G2.id = G1.Padre " +
                        " WHERE P.Estatus = 1 AND (P.CveProveedor like '%" + bsq + "%' OR " +
                        "P.Nombre like '%" + bsq + "%' OR " +
                        "P.RFC like '%" + bsq + "%' OR " +
                        "P.Contacto like '%" + bsq + "%' )";

            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter LLenaCboProveedores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveProveedor as Clave,Nombre as Descripcion " +
                         "from CatProveedores where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}

