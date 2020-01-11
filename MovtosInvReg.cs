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
    class MovtosInvReg
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public MovtosInvReg(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public MovtosInvReg(MsSql Odat) { db = Odat; }

        public int AddRegBlanco()
        {
            string sql = "Insert into Inv_MovtosMaster (NoMovimiento, FechaMovimiento) " +
                         "values( @NoMovimiento, (CONVERT(DATETIME, @FechaMovimiento) + CONVERT(DATETIME, CONVERT(time, GETDATE()))) )";
            return db.InsertarRegistro(sql, ArrParametros);
        }

       
        public int AddRegInvMaster(String DcOrigen)
        {
            string sql = "Update Inv_MovtosMaster set CveAlmacenMov=@CveAlmacenMov, CveTipoMov=@CveTipoMov, EntSal=@EntSal, CveSucursal = @CveSucursal," +
            "           NoDoc=@NoDoc, Documento=@Documento,CveAlmacenDes=@CveAlmacenDes,CveTipoMovDest=@CveTipoMovDest, EntSalDest=@EntSalDest," +
            "           Modulo=@Modulo, Descuento=@Descuento, " +
            "           TotalDscto=@TotalDscto, TIva=@TIva, SubTotal=@SubTotal, TotalDoc=@TotalDoc, CveProveedor=@CveProveedor," +
            "           Cancelado=@Cancelado, CveUsarioCaptu=@CveUsarioCaptu, NoMovtoTra = @NoMovtoTra, DocTra = @DocTra," +
            "           DocOrigen = @DocOrigen, Observacion = @Observacion, " +
            "          TotalIEPS = @TotalIEPS, TotalRetISR = @TotalRetISR, " +
            "          TotalRetiVA=@TotalRetiVA, TotalImpOtro=@TotalImpOtro" +
            " Where NoMovimiento = @NoMovimiento";

            int rsp = db.UpdateRegistro(sql, ArrParametros);

            if (!DcOrigen.Equals(""))
            {
                if (rsp > 0)
                {
                    sql = " UPDATE DocCab  " +
                             " SET 	  EsperaAceptacion = 0" +
                             " WHERE idMov = @DocOrigen";

                    db.UpdateRegistro(sql, ArrParametros);
                }
            }

            return rsp;
        }

        public int UpdateInvDet()
        {
            String sql = "Update Inv_MovtosDetalles set CveAlmacenMov = @CveAlmacenMov, CveTipoMov= @CveTipoMov," +
                      "                      EntSal = @EntSal, NoDoc = @NoDoc, Documento = @Documento" +
                      " Where NoMovimiento = @NoMovimiento AND Cancelado = 1";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteInventarioMov()
        {
            string sql = "Delete from Inv_MovtosDetalles  where NoMovimiento = @NoMovimiento";
            int rp = db.UpdateRegistro(sql, ArrParametros);
            sql = "Delete from Inv_MovtosMaster where NoMovimiento = @NoMovimiento";
            int rp2 = db.UpdateRegistro(sql, ArrParametros);
            return rp2;
        }

        public int DelRegCerosSql() //Ponemos en ceros al Eliminar
        {
            int rsp = -1;

            string sql = "Update Inv_MovtosMaster set Descuento=0," +
            "           TotalDscto=0, TIva=0, SubTotal=0, TotalDoc=0, " +
            "           Cancelado= 2 " +
            " Where NoMovimiento = @NoMovimiento";

            rsp =  db.UpdateRegistro(sql, ArrParametros);
            if(rsp > 0)
            {
                sql = "Update Inv_MovtosDetalles set Cantidad = 0,CantidadPkt = 0,Precio = 0,Descuento = 0,TotalDscto = 0," +
                         "        ImpuestoValor = 0,TotalIva = 0,SubTotal = 0,TotalPartida = 0, Cancelado= 2" +
                      " Where NoMovimiento = @NoMovimiento";
                rsp = db.UpdateRegistro(sql, ArrParametros);
            }

            return rsp;
        }

        public int AfectaCostosSql(String _CveTipoMov, int Op, String CveArt, String Canti, String Precio)
        {
            int rtn = -1;
            String Opera = " ";
            String Add_UltPrecio = "0";

            if (Op == 1)
            {
                Opera = "+";
                Add_UltPrecio = Precio;

            }
            else
            {
                Opera = "-";
                Add_UltPrecio = " ( SELECT TOP 1 Precio " +
                                "  FROM Inv_MovtosDetalles " +
                                "  WHERE CveArticulo = '" + CveArt + "'" +
                                "    AND CveTipoMov =  '" + _CveTipoMov + "'" +
                                "    AND NoMovimiento != @NoMovimiento" +
                                "    AND Cancelado = 1 " +
                                " ORDER BY CONVERT(INT, NoMovimiento) DESC ) ";
            }
            String Cp = " ((( ISNULL(Cantidad,0) * ISNULL(CostoPromedio,0))" + Opera + "( "+ Canti + " * " + Precio + " ))/ " +
                    "          (CASE (ISNULL(Cantidad,0) " + Opera + " " + Canti + ") WHEN 0 THEN 1 ELSE (ISNULL(Cantidad,0) " + Opera + "  " + Canti + ") END))  ";

            String Sql = " UPDATE Inv_Existencias SET    CostoPromedio = "+ Cp + ", " +
                            "                            CostoUltimo = ISNULL(" + Add_UltPrecio +",0)"+
                    "       WHERE ClaveArticulo = '"+ CveArt + "' and ClaveAlmacen = @ClaveAlmacen ";


            rtn = db.UpdateRegistro(Sql, ArrParametros);

            if (rtn >= 0)
            {
                Sql = " UPDATE Inv_LstPreciosDet SET CostoUltimo = " + Add_UltPrecio +" ,"+
                    "                                Precio = (CASE WHEN (ISNULL(Porcentaje,0)) = 0 THEN 0 ELSE (( Porcentaje  / 100) * " + Precio + ") + " + Precio +" END)" +
                    " WHERE CveArticulo = '" + CveArt + "'";
                rtn = db.UpdateRegistro(Sql, ArrParametros);
            }

            return rtn;
            
        }

        public int AfectaExistenciasSql(String _EntSal, int Op)
        {
            String Opera = (Op == 1) ? (_EntSal.Equals("E")) ? "+" : "-" : (_EntSal.Equals("E")) ? "-" : "+"; //Trae 1 cuando es registro nuevo, 0 cuando se quiere reinvertir

            string sql = " UPDATE Inv_Existencias SET  Inv_Existencias.Cantidad = ISNULL(t1.Cantidad,0) " + Opera + " Rsp.Cant" +
                         " FROM Inv_Existencias t1, " +
                         "     (SELECT MDet.CveArticulo, MDet.Cantidad as Cant " +
                         "      FROM Inv_MovtosDetalles MDet" +
                         "       WHERE MDet.NoMovimiento = @NoMovimiento AND Cancelado = 1) AS Rsp" +
                         " WHERE t1.ClaveArticulo = Rsp.CveArticulo AND t1.ClaveAlmacen = @ClaveAlmacen";
            int r = db.DeleteRegistro(sql, ArrParametros);
            return r;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = " Select MM.NoMovimiento, MM.FechaMovimiento, MM.CveAlmacenMov, MM.CveTipoMov, MM.EntSal," +
                         "       MM.NoDoc, MM.Documento, MM.CveAlmacenDes,CveTipoMovDest, MM.EntSalDest," +
                         "       MM.Modulo, MM.TipoDoc, MM.SerieDoc, MM.FolioDocOrigen, MM.Descuento," +
                         "       MM.TotalDscto, MM.TIva, MM.SubTotal, MM.TotalDoc, MM.CveProveedor," +
                         "       MM.CveCliente, MM.Cancelado, MM.CveUsarioCaptu, MM.CveCentroCosto, MM.NoMovtoTra," +
                         "       MM.DocTra, TM.CveClsMov, MM.CveSucursal,  " +
                         "       MM.TotalIEPS, MM.TotalRetISR, " +
                         "       MM.TotalRetiVA, MM.TotalImpOtro, MM.Observacion" +
                         " from Inv_MovtosMaster AS MM " +
                         " INNER JOIN Inv_TipoMovtos as TM ON TM.CveTipoMov = MM.CveTipoMov " +
                         " where NoMovimiento = @NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter RegistroActivoDetalle(String NoMovimiento)
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveArticulo,Descripcion,CveUMedida,Cantidad,CantidadPkt,Costo,Precio " +
                            "FROM Inv_MovtosDetalles " +
                            "WHERE NoMovimiento = '"+ NoMovimiento + "' AND Cancelado = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }



            public SqlDataAdapter ListInventarioMovtos(String CodProve, String CodAlm, String CodTipoMov, String FIni, String FFin)
        {
            String StrSql = "";


            if (!CodAlm.Equals("0") && !CodAlm.Equals(""))
            {
                StrSql += " AND Alm.ClaveAlmacen = '" + CodAlm + "'";
            }
            if (!CodProve.Equals("0") && !CodProve.Equals(""))
            {
                StrSql += " AND Prov.CveProveedor = '" + CodProve + "'";
            }

            if (!CodTipoMov.Equals("0") && !CodTipoMov.Equals(""))
            {
                StrSql += " AND TMvto.CveTipoMov = '" + CodTipoMov + "'";
            }

            SqlDataAdapter dt = null;
            string Sql = "SELECT MM.NoMovimiento,MM.Documento,MM.FechaMovimiento,Alm.Descripcion AS Almacen, " +
                         "       TMvto.Descripcion AS TipoMov, Prov.Nombre AS Proveedor, MM.Cancelado,MM.TotalDoc, " +
                         "        MM.CveTipoMov,MM.NoMovtoTra,MM.DocTra, MM.DocOrigen, Suc.Nombre as Sucursal " +
                         " FROM Inv_MovtosMaster MM " +
                         " INNER JOIN Inv_CatAlmacenes Alm ON Alm.ClaveAlmacen = mm.CveAlmacenMov " +
                         " LEFT JOIN CatProveedores Prov ON Prov.CveProveedor = mm.CveProveedor " +
                         " LEFT JOIN CatSucursales Suc ON Suc.CveSucursal = MM.CveSucursal " +
                         " INNER JOIN Inv_TipoMovtos TMvto ON TMvto.CveTipoMov = mm.CveTipoMov" +
                        //" WHERE MM.Cancelado = 1 " + StrSql;
                        " WHERE (CONVERT(date,MM.FechaMovimiento) BETWEEN '"+FIni+"' AND '"+FFin+ "') " +
                        "   AND TMvto.EsInterno = 0 " +
                        "   AND MM.Cancelado = 1" + StrSql;
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int AddPartMigraDoc()
        {
            string sql = "INSERT INTO Inv_MovtosDetalles ( " +
                         "            NoMovimiento,NoPartida,CveArticulo,Descripcion,Cantidad," +
                         "            CantidadPkt,CveUMedida,CveImpuesto,ImpuestoValor,Precio,Costo," +
                         "            CveImpIEPS, ImpIEPSValor,CveImpRetIVA,ImpRetIVAValor,CveImpRetISR," +
                         "            ImpRetISRValor,CveImpOtro,ImpValorOtro, "+
                         "            Descuento,TotalDscto,TotalIva, TotalIEPS,TotalRetISR,TotalRetIVA,TotalImpOtro," +
                         "            SubTotal,TotalPartida," +
                         "            FechaMovimiento, " +
                         "            CveAlmacenMov,CveTipoMov,EntSal,NoDoc, " +
                         "            Documento,FolioDocOrigen,NoMovtoTra,DocTra,PartTra ) " +
                         "(SELECT @NoMovimiento, DD.Partida,DD.CveArticulo,DD.Descripcion,DD.Cantidad," +
                         "        DD.Cantidad,DD.CveUmedida1,DD.CveImpuesto,DD.ImpuestoValor,DD.Precio,0," +
                         "        DD.CveImpIEPS, DD.ImpIEPSValor,DD.CveImpRetIVA,DD.ImpRetIVAValor,DD.CveImpRetISR, " +                        
                         "        DD.ImpRetISRValor,DD.CveImpOtro,DD.ImpValorOtro, " +
                         "        DD.Descuento,DD.TotalDscto,DD.Impuesto, DD.TotalIEPS,DD.TotalRetISR,DD.TotalRetIVA,DD.TotalImpOtro," +
                         "        DD.SubTotal,DD.Total," +
                         "        (CONVERT(DATETIME, CONVERT(DATE, GETDATE())) + CONVERT(DATETIME, CONVERT(time, GETDATE())))," +
                         "        '','','',''," +
                         "        '','','','','' " +
                         " FROM  DocDet AS DD " +
                         " INNER JOIN DocCab DC ON DD.idMov = DC.idMov " +
                         " WHERE DC.EsperaAceptacion = 1  " +
                         "   AND DD.idMov = @IdDoc)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter GetRegMovTraspaso()
        {//Obtenemos el IdMov del registro del Traspaso
            SqlDataAdapter dt = null;
            string Sql = "Select MM.NoMovimiento "+
                         "from Inv_MovtosMaster AS MM " +
                         "where NoMovtoTra = @NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }


        public SqlDataAdapter GetParamAlma()
        {
            SqlDataAdapter dt = null;

            string Sql = "SELECT EsDeCompra,EsDeVenta,EsDeConsigna,NumRojo" +
                         " from Inv_CatAlmacenes where ClaveAlmacen =@ClaveAlmacen";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter GetIdMov()
        {// Obtenemos el IdMov y TipoMov de acuerdo al DocOrigen
            SqlDataAdapter dt = null;
            string Sql = "Select NoMovimiento, CveTipoMov " +
                         "from Inv_MovtosMaster " +
                         "where DocOrigen =@DocOrigen";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter SqlMovInvDetPrint()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT MD.NoMovimiento,MD.NoPartida,MD.CveAlmacenMov,MD.CveTipoMov,MD.EntSal, " +
                         "        MD.NoDoc,MD.Documento,MD.CveArticulo,MD.Descripcion,MD.CveUMedida, " +
                         "        MD.CveImpuesto,MD.ImpuestoValor,MD.CveImpIEPS,MD.ImpIEPSValor,MD.CveImpRetIVA, " +
                         "        MD.ImpRetIVAValor,MD.CveImpRetISR,MD.ImpRetISRValor,MD.CveImpOtro,MD.ImpValorOtro, " +
                         "        MD.Cantidad,MD.CantidadPkt,MD.Costo,MD.Precio,MD.Descuento, " +
                         "        MD.TotalDscto,MD.TotalIva,MD.TotalIEPS,MD.TotalRetIVA,MD.TotalRetISR, " +
                         "        MD.TotalImpOtro,MD.SubTotal,MD.TotalPartida,MD.FolioDocOrigen,MD.FechaMovimiento, " +
                         "        MD.NoMovtoTra,MD.DocTra,MD.PartTra,MD.Cancelado,Art.CodigoBarra " +
                         " FROM Inv_MovtosDetalles AS MD  " +
                         " INNER JOIN inv_CatArticulos AS Art ON MD.CveArticulo = Art.CveArticulo" +
                         " WHERE MD.NoMovimiento = @NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter SqlMovInvMastPrint()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT MM.NoMovimiento,MM.FechaMovimiento,MM.CveAlmacenMov,MM.CveTipoMov,MM.EntSal, " +
                         "        MM.CveSucursal,MM.NoDoc,MM.Documento,MM.CveAlmacenDes,MM.CveTipoMovDest, " +
                         "        MM.EntSalDest,MM.Modulo,MM.TipoDoc,MM.SerieDoc,MM.FolioDocOrigen,MM.Descuento, " +
                         "        MM.TotalDscto,MM.TIva,MM.SubTotal,MM.TotalDoc,MM.Observacion,MM.CveProveedor, " +
                         "        MM.CveCliente,MM.CveUsarioCaptu,MM.CveCentroCosto,MM.NoMovtoTra,MM.DocTra,MM.DocOrigen, MM.Cancelado, " +
                         "        AlmO.Descripcion AS AlmacenOrigen, " +
                         "       TMO.Descripcion AS TipoMovOrigen, TMO.DescCorta AS TippMovDesCortaO, TMO.EsTraspaso AS EsTraspasoO, " +
                         "       AlmD.Descripcion AS AlmacenDest, " +
                         "       TMD.Descripcion AS TipoMovDest, " +
                         "       MM.TotalIEPS, MM.TotalRetISR, " +
                         "       MM.TotalRetiVA, MM.TotalImpOtro" +
                         " FROM Inv_MovtosMaster AS MM " +
                         " INNER JOIN dbo.Inv_TipoMovtos AS TMO ON MM.CveTipoMov = TMO.CveTipoMov " +
                         " INNER JOIN dbo.Inv_CatAlmacenes AS AlmO ON MM.CveAlmacenMov = AlmO.ClaveAlmacen " +
                         " LEFT JOIN dbo.Inv_CatAlmacenes AS AlmD ON AlmD.ClaveAlmacen = MM.CveAlmacenDes  " +
                         " LEFT JOIN dbo.Inv_TipoMovtos AS TMD ON TMD.CveTipoMov = MM.CveTipoMovDest " +
                         " WHERE Mm.NoMovimiento = @NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }


    }

}
