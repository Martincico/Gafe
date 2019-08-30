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
            string sql = "Insert into CfgDocumentos (CveAlmacen,CodMovProv,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus) " +
                         "values(@CveAlmacen,@CodMovProv,@Serie,@Descripcion,@CodFoliador," +
                         "                         @EditaFolio,@FmtoImpresion,@NoCopiasImp,@NombImpresora,@PregImpresion," +
                         "                         @Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateCfgDocumentos()
        {
            string sql = "Update CfgDocumentos set Descripcion = @Descripcion, " +
                         "       CodFoliador = @CodFoliador, EditaFolio = @EditaFolio, FmtoImpresion = @FmtoImpresion, " +
                         "       NoCopiasImp = @NoCopiasImp, NombImpresora = @NombImpresora, PregImpresion = @PregImpresion, " +
                         "       Estatu = @Estatus " +
                         " Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteCfgDocumentos()
        {
            string sql = "Delete from CfgDocumentos where Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListCfgDocumentos()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CodMovProv,TipoMtos.Nombre as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM dbo.CfgDocumentos AS DocProv " +
                        " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN dbo.CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN CfgTipoMovProv AS TipoMtos ON TipoMtos.ClaveDoc = DocProv.CodMovProv ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveAlmacen,CodMovProv,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus " +
                         " from CfgDocumentos " +
                         " Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaCfgDocumentos(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CodMovProv,TipoMtos.Nombre as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM CfgDocumentos AS DocProv " +
                        " INNER JOIN Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN CfgTipoMovProv AS TipoMtos ON TipoMtos.ClaveDoc = DocProv.CodMovProv " +
                        " Where DocProv.CveAlmacen  like '%" + bsq + "%' OR  DocProv.CodMovProv LIKE '%" + bsq + "%' OR DocProv.Serie LIKE '%" + bsq + "%'";

            dt = db.SelectDA(sql);
            return dt;
        }

        public int AddRegCfgFoliadores()
        {
            string sql = "Insert into CfgFoliadores (CveFoliador,CveAlmacen,FolioActual, FolioSiguiente) " +
                         "values( @CodFoliador,@CveAlmacen,0,1)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter cboCfgSeries(string Alm, string MProv)
        {
            SqlDataAdapter dt = null;
            string Sql = "Select Serie as Clave, Descripcion " +
                         " from CfgDocumentos " +
                         " Where CveAlmacen ='" + Alm + "' AND CodMovProv = '" + MProv + "'";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
