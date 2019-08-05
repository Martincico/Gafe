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
    class RegSegUsuarioCfg
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegSegUsuarioCfg(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegSegUsuarioCfg(MsSql Odat) { db = Odat; }



        public int AddRegUsrCfg()
        {
            string sql = "Insert into SUsuarioConf (CveUsuario,CveAlmacen,CambiaAlmacen,fondo, StiloTema) " +
                         "values (@CveUsuario,@CveAlmacen,@CambiaAlmacen,@fondo, @StiloTema)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateUsrCfg()
        {
            string sql = "Update SUsuarioConf set CveAlmacen = @CveAlmacen,CambiaAlmacen = @CambiaAlmacen, " +
                         "                        fondo = @fondo, StiloTema = @StiloTema " +
                         "Where CveUsuario = @CveUsuario";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteUsrCfg()
        {
            string sql = "Delete from SUsuarioConf where CveUsuario = @CveUsuario";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListUsrCfg()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveUsuario,CveAlmacen " +
               " from SUsuarioConf ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveUsuario, CveAlmacen,CambiaAlmacen,fondo, StiloTema " +
                          "from SUsuarioConf where CveUsuario = @CveUsuario";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaUsrCfg(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveUsuario,CveAlmacen " +
               "from SUsuarioConf " +
               "where CveUsuario like '%" + bsq + "%' OR " +
               " CveAlmacen like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public SqlDataAdapter GetParamTema()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select Encabezado,HoverEncabezado,FontColor " +
                          "from CfgEstilos where CveStilo =@Usuario";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter CboTemas()
        {
            SqlDataAdapter dt = null;

            string Sql = " SELECT CveStilo as  Clave, CveStilo as Descripcion FROM CfgEstilos ";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
