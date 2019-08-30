﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatCfgDocSerie
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatCfgDocSerie(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatCfgDocSerie(MsSql Odat) { db = Odat; }

        public int AddRegCfgDocSerie()
        {
            string sql = "Insert into CfgDocSerie (CveAlmacen,CveDoc,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus) " +
                         "values(@CveAlmacen,@CveDoc,@Serie,@Descripcion,@CodFoliador," +
                         "                         @EditaFolio,@FmtoImpresion,@NoCopiasImp,@NombImpresora,@PregImpresion," +
                         "                         @Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateCfgDocSerie()
        {
            string sql = "Update CfgDocSerie set Descripcion = @Descripcion, "+
                         "       CodFoliador = @CodFoliador, EditaFolio = @EditaFolio, FmtoImpresion = @FmtoImpresion, " +
                         "       NoCopiasImp = @NoCopiasImp, NombImpresora = @NombImpresora, PregImpresion = @PregImpresion, " +
                         "       Estatu = @Estatus " +
                         " Where CveAlmacen = @CveAlmacen AND CveDoc = @CveDoc AND Serie = @Serie";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteCfgDocSerie()
        {
            string sql = "Delete from CfgDocSerie where Where CveAlmacen = @CveAlmacen AND CveDoc = @CveDoc AND Serie = @Serie";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListCfgDocSeries()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CveDoc,TipoMtos.Nombre as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM dbo.CfgDocSerie AS DocProv " +
                        " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN dbo.CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN CfgTipoMovProv AS TipoMtos ON TipoMtos.ClaveDoc = DocProv.CveDoc ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveAlmacen,CveDoc,Serie,Descripcion,CodFoliador," +
                         "                         EditaFolio,FmtoImpresion,NoCopiasImp,NombImpresora,PregImpresion," +
                         "                         Estatus " +
                         " from CfgDocSerie " +
                         " Where CveAlmacen = @CveAlmacen AND CveDoc = @CveDoc AND Serie = @Serie";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaCfgDocSerie(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = " SELECT DocProv.CveAlmacen, Alm.Descripcion as Almacén,DocProv.CveDoc,TipoMtos.Nombre as Mov_Inv," +
                        "         DocProv.Serie,DocProv.Descripcion,DocProv.CodFoliador,Fol.Descripcion as Foliador, " +
                        "         DocProv.FmtoImpresion,DocProv.NoCopiasImp, DocProv.NombImpresora " +
                        " FROM CfgDocSerie AS DocProv " +
                        " INNER JOIN Inv_CatAlmacenes AS Alm ON DocProv.CveAlmacen = Alm.ClaveAlmacen " +
                        " INNER JOIN CfgCatFoliadores AS Fol ON DocProv.CodFoliador = Fol.CveFoliador " +
                        " INNER JOIN CfgTipoMovProv AS TipoMtos ON TipoMtos.ClaveDoc = DocProv.CveDoc " +
                        " Where DocProv.CveAlmacen  like '%" + bsq + "%' OR  DocProv.CveDoc LIKE '%" + bsq + "%' OR DocProv.Serie LIKE '%" + bsq + "%'";

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
                         " from CfgDocSerie "+
                         " Where CveAlmacen ='" + Alm + "' AND CveDoc = '" + MProv + "'";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
