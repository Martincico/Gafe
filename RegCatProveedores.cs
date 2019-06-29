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
            string Sql = "SELECT P.CveProveedor, P.Nombre, P.RFC, P.Calle, G.Descripcion AS Localidad, P.CP, P.Tel1, P.Mail1, " +
                        "P.TipoPersona, IIF(P.Estatus=1,'ACTIVO','BAJA') AS Estatus, P.Contacto, P.Tel2, P.Mail2, P.Cargo, P.Celular " +
                         "FROM CatProveedores P JOIN CatGeografia G ON P.CveLocalidad = G.id";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter BuscaArticulo(string bsq)
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT P.CveProveedor, P.Nombre, P.RFC, P.Calle, G.Descripcion AS Localidad, P.CP, P.Tel1, P.Mail1, " +
                        "P.TipoPersona, IIF(P.Estatus=1,'ACTIVO','BAJA') AS Estatus, P.Contacto, P.Tel2, P.Mail2, P.Cargo, P.Celular " +
                        "FROM CatProveedores P " +
                        "JOIN CatGeografia G ON P.CveLocalidad = G.id " +
                        "WHERE P.CveProveedor like '%" + bsq + "%' OR " +
                        "P.Nombre like '%" + bsq + "%' OR " +
                        "P.CveProveedor like '%" + bsq + "%' OR " +
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
        public SqlDataAdapter ComboProveedores()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select id as Clave,Nombre as Descripcion " +
                         "from CatProveedores where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}

