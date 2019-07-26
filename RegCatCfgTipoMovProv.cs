using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatCfgTipoMovProv
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgTipoMovProv(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgTipoMovProv(MsSql Odat) { db = Odat; }


        public int AddRegTipoMovProv()
        {
            string sql = "Insert into CfgTipoMovProv (ClaveDoc,Nombre,CargoAbono,CveTipoMov,Foliador, UsaSerie,EditaFecha, UsaCliente, UsaProveedor, EsInterno, SolicitaAutorizar,Estatus) " +
                         "values(@ClaveDoc,@Nombre,@CargoAbono,@CveTipoMov,@Foliador,@UsaSerie,@EditaFecha, @UsaCliente, @UsaProveedor, @EsInterno,@SolicitaAutorizar, @Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateTipoMovProv()
        {
            string sql = "Update CfgTipoMovProv set Nombre = @Nombre, " +
                         "      CargoAbono = @CargoAbono, CveTipoMov = @CveTipoMov,Foliador = @Foliador," +
                         "      UsaSerie = @UsaSerie,EditaFecha = @EditaFecha, " +
                         "      UsaCliente = @UsaCliente, UsaProveedor = @UsaProveedor," +
                         "      EsInterno = @EsInterno, SolicitaAutorizar =  @SolicitaAutorizar, " +
                         "      Estatus= @Estatus" +
                         " Where ClaveDoc = @ClaveDoc";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteTipoMovProv()
        {
            string sql = "Update CfgTipoMovProv SET Estatus = 0 where ClaveDoc = @ClaveDoc";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListTipoMovProvs()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select ClaveDoc,Nombre " +
                         "from CfgTipoMovProv WHERE Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select ClaveDoc,Nombre,CargoAbono,CveTipoMov,Foliador, UsaSerie,EditaFecha, UsaCliente, " +
                         "       UsaProveedor, EsInterno, SolicitaAutorizar, Estatus" +
                         " FROM CfgTipoMovProv where ClaveDoc =@ClaveDoc";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaTipoMovProv(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select ClaveDoc,Nombre " +
               "from CfgTipoMovProv " +
               "where Estatus = 1 AND (ClaveDoc like '%" + bsq + "%' OR " +
               "Nombre like '%" + bsq + "%') ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public int AddRegCfgFoliadores()
        {
            string sql = "Insert into CfgFoliadores (CveFoliador,CveAlmacen,FolioActual, FolioSiguiente) " +
                         "values( @Foliador,'',0,1)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter cboTipoMovProvee()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select ClaveDoc as Clave, Nombre as Descripcion " +
                         "from CfgTipoMovProv WHERE estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
