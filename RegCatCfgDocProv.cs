using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatCfgDocProv
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgDocProv(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgDocProv(MsSql Odat) { db = Odat; }

        public int AddRegCfgDocProv()
        {
            string sql = "Insert into CfgDocProv (CveAlmacen,CodMovProv,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus) " +
                         "values(@CveAlmacen,@CodMovProv,@Serie,@Descripcion,@CodFoliador," +
                         "                         @EditaFolio,@FmtoImpresion,@NoCopiasImp,@NombImpresora,@PregImpresion," +
                         "                         @Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateCfgDocProv()
        {
            string sql = "Update CfgDocProv set Descripcion = @Descripcion, "+
                         "       CodFoliador = @CodFoliador, EditaFolio = @EditaFolio, FmtoImpresion = @FmtoImpresion, " +
                         "       NoCopiasImp = @NoCopiasImp, NombImpresora = @NombImpresora, PregImpresion = @PregImpresion, " +
                         "       Estatu = @Estatus " +
                         " Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteCfgDocProv()
        {
            string sql = "Delete from CfgDocProv where Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListCfgDocProvs()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CodMovProv,TipoMtos.Descripcion as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM dbo.CfgDocProv AS DocProv " +
                        " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN dbo.CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN dbo.Inv_TipoMovtos AS TipoMtos ON DocProv.CodMovProv = TipoMtos.CveTipoMov ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveAlmacen,CodMovProv,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus " +
                         " from CfgDocProv " +
                         " Where CveAlmacen = @CveAlmacen AND CodMovProv = @CodMovProv AND Serie = @Serie";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaCfgDocProv(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CodMovProv,TipoMtos.Descripcion as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM dbo.CfgDocProv AS DocProv " +
                        " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN dbo.CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN dbo.Inv_TipoMovtos AS TipoMtos ON DocProv.CodMovProv = TipoMtos.CveTipoMov " +
                        " Where DocProv.CveAlmacen  like '%" + bsq + "%' OR  DocProv.CodMovProv = '%" + bsq + "%' OR DocProv.Serie = '%" + bsq + "%'";

            dt = db.SelectDA(sql);
            return dt;
        }

        public int AddRegCfgFoliadores()
        {
            string sql = "Insert into CfgFoliadores (CveFoliador,CveAlmacen,FolioActual, FolioSiguiente) " +
                         "values( @CodFoliador,@CveAlmacen,0,1)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

    }
}
