using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatClientes
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatClientes(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatClientes(MsSql Odat) { db = Odat; }

        public int AddRegClientes()
        {
            string sql = "Insert into CatClientes (CveCliente,Nombre,RFC,Calle,CveLocalidad,CP,Tel1,Mail1,TipoPersona,Estatus,Contacto,Tel2,Mail2,Cargo,Celular) " +
                         "values(@CveCliente,@Nombre,@RFC,@Calle,@CveLocalidad,@CP,@Tel1,@Mail1,@TipoPersona,@Estatus,@Contacto,@Tel2,@Mail2,@Cargo,@Celular)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateClientes()
        {
            string sql = "Update CatClientes set " +
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
                         "Where CveCliente = @CveCliente";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteClientes()
        {
            string sql = "Delete from CatClientes where CveCliente = @CveCliente";
            return db.UpdateRegistro(sql, ArrParametros);
        }


        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveCliente,Nombre,CveLstPrecio " +
                          "from CatClientes where CveCliente = @CveCliente";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter ListClientes()
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT P.CveCliente, P.Nombre, P.RFC, P.Calle, G.Descripcion AS Localidad, P.CP, P.Tel1, P.Mail1, " +
                        "P.TipoPersona, IIF(P.Estatus=1,'ACTIVO','BAJA') AS Estatus, P.Contacto, P.Tel2, P.Mail2, P.Cargo, P.Celular " +
                         "FROM CatClientes P JOIN CatGeografia G ON P.CveLocalidad = G.id";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter BuscaArticulo(string bsq)
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT P.CveCliente, P.Nombre, P.RFC, P.Calle, G.Descripcion AS Localidad, P.CP, P.Tel1, P.Mail1, " +
                        "P.TipoPersona, IIF(P.Estatus=1,'ACTIVO','BAJA') AS Estatus, P.Contacto, P.Tel2, P.Mail2, P.Cargo, P.Celular " +
                        "FROM CatClientes P " +
                        "JOIN CatGeografia G ON P.CveLocalidad = G.id " +
                        "WHERE P.CveCliente like '%" + bsq + "%' OR " +
                        "P.Nombre like '%" + bsq + "%' OR " +
                        "P.CveCliente like '%" + bsq + "%' OR " +
                        "P.Nombre like '%" + bsq + "%' OR " +
                        "P.RFC like '%" + bsq + "%' OR " +
                        "P.Calle like '%" + bsq + "%' OR " +
                        "G.Descripcion like '%" + bsq + "%' OR " +
                        "P.CP like '%" + bsq + "%' OR " +
                        "P.Mail1 like '%" + bsq + "%' OR " +
                        "P.Mail2 like '%" + bsq + "%' OR " +
                        "P.Tel1 like '%" + bsq + "%' OR " +
                        "P.Contacto like '%" + bsq + "%' OR " +
                        "P.Cargo like '%" + bsq + "%' OR " +
                        "P.Tel2 like '%" + bsq + "%'";

            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter LLenaCboClientes()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveCliente as Clave,Nombre as Descripcion " +
                         "from CatClientes where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}

