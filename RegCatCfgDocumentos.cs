using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatCfgDocumentos
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgDocumentos(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgDocumentos(MsSql Odat) { db = Odat; }


        public int AddRegCfgDocumentos()
        {
            string sql = "Insert into CfgDocumentos (CveDoc,Nombre,CargoAbono,CveTipoMov,Foliador, UsaSerie,EditaFecha, " +
                         "                          UsaCliente, UsaProveedor, EsInterno, SolicitaAutorizar, " +
                         "                          AfectaInventario,Estatus,DocRel,txtBotonDocRel) " +
                         "values(@CveDoc,@Nombre,@CargoAbono,@CveTipoMov,@Foliador,@UsaSerie,@EditaFecha, " +
                         "                          @UsaCliente, @UsaProveedor, @EsInterno,@SolicitaAutorizar, " +
                         "                          @AfectaInventario,@Estatus, @DocRel,@txtBotonDocRel)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateCfgDocumentos()
        {
            string sql = "Update CfgDocumentos set Nombre = @Nombre, " +
                         "      CargoAbono = @CargoAbono, CveTipoMov = @CveTipoMov,Foliador = @Foliador," +
                         "      UsaSerie = @UsaSerie,EditaFecha = @EditaFecha, " +
                         "      UsaCliente = @UsaCliente, UsaProveedor = @UsaProveedor," +
                         "      EsInterno = @EsInterno, SolicitaAutorizar =  @SolicitaAutorizar, " +
                         "      AfectaInventario = @AfectaInventario, Estatus= @Estatus," +
                         "     DocRel = @DocRel,txtBotonDocRel = @txtBotonDocRel " +
                         " Where CveDoc = @CveDoc";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteCfgDocumentos()
        {
            string sql = "Update CfgDocumentos SET Estatus = 0 where CveDoc = @CveDoc";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListCfgDocumentos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveDoc,Nombre " +
                         "from CfgDocumentos WHERE Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveDoc,Nombre,CargoAbono,CveTipoMov,Foliador, UsaSerie,EditaFecha, UsaCliente, " +
                         "       UsaProveedor, EsInterno, SolicitaAutorizar, AfectaInventario, Estatus," +
                         "       DocRel,txtBotonDocRel" +
                         " FROM CfgDocumentos where CveDoc =@CveDoc";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaCfgDocumentos(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveDoc,Nombre " +
               "from CfgDocumentos " +
               "where Estatus = 1 AND (CveDoc like '%" + bsq + "%' OR " +
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

        public SqlDataAdapter cboCfgDocumentos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveDoc as Clave, Nombre as Descripcion " +
                         "from CfgDocumentos WHERE estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
