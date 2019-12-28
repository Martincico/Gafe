using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;


namespace GAFE
{
    class DocRegRequisiciones
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        private SqlParameter[] ArrParametrosP;

        DocPartidasReq cl = new DocPartidasReq();
        private object[,] MatParamP = new object[33,2];

        private List<DocPartidasReq> Partidas;

        //private string ClaveReg;

        public DocRegRequisiciones(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }


        public DocRegRequisiciones(object[,] Param, MsSql Odat, List<DocPartidasReq> lp)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
            Partidas = lp;
        }


        public DocRegRequisiciones(MsSql Odat) { db = Odat; }


        public void ParamPartidas(object[,] Param)
        {
            ArrParametrosP = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametrosP[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
        }



        public string getIdMov(int f)
        {
            string dv = "";
            string  x = db.GetFolioMov(f,"");
            for (int i = 1; i <= (9 - x.Length); i++)
                dv = dv + "0";
            dv = dv + x;
            return dv;
        }

        public string[] getIdDoc(int f, string _alm,string Documento, string ser)
        {
            string dv = Documento + ser;
            string x = db.GetFolioMov(f,_alm);

            string[] folDoc = new string[2];
            folDoc[0] = x;
           

            for (int i = 1; i <= (6 - x.Length); i++)
                dv = dv + "0";
            dv = dv + x ;
            folDoc[1] = dv;

            return folDoc;
        }


        public SqlDataAdapter ListDocumentos(String CodAlm, String FIni, String FFin, String CveDc, String CvS)
        {
            String StrSql = "";


            if (!CodAlm.Equals("0") && !CodAlm.Equals(""))
            {
                StrSql = " AND Alm.ClaveAlmacen = '" + CodAlm + "'";
                if (CodAlm.Equals("999"))
                {
                    if (!CvS.Equals("0") && !CvS.Equals(""))
                    {
                        StrSql = " AND M.CveSucursal = '" + CvS + "'";
                    }
                }
            }

            SqlDataAdapter dt = null;


            string Sql = "SELECT M.idMov,M.Documento,M.Serie,M.NumDoc,M.ClaveAlmacen, Alm.Descripcion 'Almacén'," +
                         "       M.FechaExpedicion as 'Fec Exp',M.Impuesto,M.Descuento,M.SubTotal,M.Total,M.CveProveedor," +
                         "       M.EsperaAceptacion, M.DocOrigen,M.CveSucursal, S.Nombre as Sucursal, P.Nombre AS Proveedor, " +
                         "       M.NoFactura " +
                         " FROM DocCab AS M " +
                         " INNER JOIN Inv_CatAlmacenes AS Alm ON M.ClaveAlmacen = Alm.ClaveAlmacen " +
                         " INNER JOIN CatProveedores AS P ON P.CveProveedor = M.CveProveedor" +
                         " LEFT JOIN  CatSucursales S ON S.CveSucursal = M.CveSucursal " +
                         " WHERE M.Estatus = 1" +
                         "   AND (CONVERT(date,M.FechaExpedicion) BETWEEN '" + FIni + "' AND '" + FFin + "')" +
                         "   AND CveDoc = '"+CveDc+"' " + StrSql;
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int AddRegEnBlanco()
        {
            string sql = "Insert into DocCab (idMov,FechaExpedicion, FechaCaptura, UsuarioCaptura, UsuarioModi) " +
                        "values(@idMov,  (CONVERT(DATETIME, @FechaExpedicion) + CONVERT(DATETIME, CONVERT(time, GETDATE())))   ," +
                        " (CONVERT(DATETIME, @FechaExpedicion) + CONVERT(DATETIME, CONVERT(time, GETDATE()))), " +
                        " @UsuarioModi, @UsuarioModi)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int DeleteRegEnBlanco()
        {
            string sql = "Delete from DocCab where idmov = @idMov";
            return db.DeleteRegistro(sql,ArrParametros);
        }

        public int SaveDocumento(int op)
        {
            int bandDev = 0;
            string sql = "Update DocCab Set Documento = @Documento,CveDoc = @CveDoc, Serie = @Serie,NumDoc=@NumDoc," +
                         "       ClaveAlmacen=@ClaveAlmacen," +
                         "       ClaveImpuesto=@ClaveImpuesto,Impuesto=@Impuesto,Descuento=@Descuento," +
                         "       SubTotal=@SubTotal,Total=@Total,CveProveedor =@CveProveedor, " +
                         "       CveCliente = @CveCliente, Observaciones=@Observaciones, " +
                         "       FechaModificacion = (CONVERT(DATETIME, @FechaModificacion) + CONVERT(DATETIME, CONVERT(time, GETDATE()))), " +
                         "       FechaExpedicion = (CONVERT(DATETIME, @FechaExpedicion) + CONVERT(DATETIME, CONVERT(time, GETDATE()))), " +
                         "       Estatus=@Estatus, UsuarioModi = @UsuarioModi, " +
                         "       Autorizado=@Autorizado, EsperaAceptacion = @EsperaAceptacion," +
                         "       CveSucursal = @CveSucursal, NoFactura =  @NoFactura " +
                         " WHERE idMov = @idMov";
            db.IniciaTrans();

            if (db.UpdateRegistro(sql, ArrParametros) > 0)
            {
                if (op == 2)//En caso este editando
                {
                    sql = "Delete from DocDet  where idMov = @idMov";
                    int rp = db.UpdateRegistro(sql, ArrParametros);
                    
                }

                foreach (DocPartidasReq lst in Partidas)
                {
                    string SqlP = "insert into DocDet (idMov,Documento,Serie,Numdoc,ClaveAlmacen,Partida,CveArticulo,Descripcion,Cantidad," +
                                  "CveUmedida1,CveImpuesto,ImpuestoValor,Precio,Descuento,PrecioNeto,Impuesto,SubTotal,Total, Autorizado," +
                                  "FechaCaptura,FechaModificacion," +
                                  "        CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
                                 "        TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro, " +
                                 "        ImpValorOtro, TotalImpOtro) " +
                             "  values(@idMov,@Documento,@Serie,@Numdoc,@ClaveAlmacen,@Partida,@CveArticulo,@Descripcion,@Cantidad," +
                                       "@CveUmedida1,@CveImpuesto,@ImpuestoValor,@Precio,@Descuento,@PrecioNeto,@Impuesto,@SubTotal,@Total, @Autorizado," +
                                       "(CONVERT(DATETIME, @FechaCaptura) + CONVERT(DATETIME, CONVERT(time, GETDATE())))," +
                                       "(CONVERT(DATETIME, @FechaModificacion) + CONVERT(DATETIME, CONVERT(time, GETDATE()))), "+
                                       "       @CveImpIEPS, @ImpIEPSValor, @TotalIEPS, @CveImpRetIVA, @ImpRetIVAValor, " +
                                    "       @TotalRetIVA, @CveImpRetISR, @ImpRetISRValor, @TotalRetISR, @CveImpOtro, " +
                                    "       @ImpValorOtro, @TotalImpOtro )";

                    MatParamP[0, 0] = "idMov"; MatParamP[0, 1] = lst.idMov;
                    MatParamP[1, 0] = "Documento"; MatParamP[1, 1] = lst.Documento;
                    MatParamP[2, 0] = "Serie"; MatParamP[2, 1] = lst.Serie;
                    MatParamP[3, 0] = "Numdoc"; MatParamP[3, 1] = lst.Numdoc;
                    MatParamP[4, 0] = "ClaveAlmacen"; MatParamP[4, 1] = lst.ClaveAlmacen;
                    MatParamP[5, 0] = "Partida"; MatParamP[5, 1] = lst.Partida;
                    MatParamP[6, 0] = "CveArticulo"; MatParamP[6, 1] = lst.CveArticulo;
                    MatParamP[7, 0] = "Descripcion"; MatParamP[7, 1] = lst.Descripcion;
                    MatParamP[8, 0] = "Cantidad"; MatParamP[8, 1] = lst.Cantidad;
                    MatParamP[9, 0] = "CveUmedida1"; MatParamP[9, 1] = lst.CveUmedida1;
                    MatParamP[10, 0] = "CveImpuesto"; MatParamP[10, 1] = lst.CveImpuesto;
                    MatParamP[11, 0] = "ImpuestoValor"; MatParamP[11, 1] = lst.ImpuestoValor;
                    MatParamP[12, 0] = "Precio"; MatParamP[12, 1] = lst.Precio;
                    MatParamP[13, 0] = "Descuento"; MatParamP[13, 1] = lst.Descuento;
                    MatParamP[14, 0] = "PrecioNeto"; MatParamP[14, 1] = lst.PrecioNeto;
                    MatParamP[15, 0] = "Impuesto"; MatParamP[15, 1] = lst.Impuesto;
                    MatParamP[16, 0] = "SubTotal"; MatParamP[16, 1] = lst.SubTotal;
                    MatParamP[17, 0] = "Total"; MatParamP[17, 1] = lst.Total;
                    MatParamP[18, 0] = "Autorizado"; MatParamP[18, 1] = lst.Autorizado;
                    MatParamP[19, 0] = "FechaCaptura"; MatParamP[19, 1] = lst.FechaCaptura;
                    MatParamP[20, 0] = "FechaModificacion"; MatParamP[20, 1] = lst.FechaModificacion;

                    MatParamP[21, 0] = "CveImpIEPS"; MatParamP[21, 1] = lst.CveImpIEPS;
                    MatParamP[22, 0] = "ImpIEPSValor"; MatParamP[22, 1] = lst.ImpIEPSValor;
                    MatParamP[23, 0] = "TotalIEPS"; MatParamP[23, 1] = lst.TotalIEPS;
                    MatParamP[24, 0] = "CveImpRetIVA"; MatParamP[24, 1] = lst.CveImpRetIVA;
                    MatParamP[25, 0] = "ImpRetIVAValor"; MatParamP[25, 1] = lst.ImpRetIVAValor;
                    MatParamP[26, 0] = "TotalRetIVA"; MatParamP[26, 1] = lst.TotalRetIVA;
                    MatParamP[27, 0] = "CveImpRetISR"; MatParamP[27, 1] = lst.CveImpRetISR;
                    MatParamP[28, 0] = "ImpRetISRValor"; MatParamP[28, 1] = lst.ImpRetISRValor;
                    MatParamP[29, 0] = "TotalRetISR"; MatParamP[29, 1] = lst.TotalRetISR;
                    MatParamP[30, 0] = "CveImpOtro"; MatParamP[30, 1] = lst.CveImpOtro;
                    MatParamP[31, 0] = "ImpValorOtro"; MatParamP[31, 1] = lst.ImpValorOtro;
                    MatParamP[32, 0] = "TotalImpOtro"; MatParamP[32, 1] = lst.TotalImpOtro;





                    ParamPartidas(MatParamP);
                    int rps = db.InsertarRegistro(SqlP, ArrParametrosP);

                    if (rps <=0)
                    {
                        bandDev = 0;
                        break;
                    }
                    bandDev = 1;
                }
            }

            if (bandDev == 1)
                db.TerminaTrans();
            else
                db.CancelaTrans();

            return bandDev;
        }
        


        public SqlDataAdapter GetDocumentoSql()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT RM.idMov,RM.Documento,RM.Serie,RM.NumDoc,RM.ClaveAlmacen," +
                         "       RM.FechaExpedicion,RM.ClaveImpuesto,RM.Impuesto,RM.Descuento, RM.SubTotal," +
                         "       RM.Total,RM.Observaciones,RM.Estatus,RM.Autorizado," +
                         "       Alm.Descripcion, Rm.CveProveedor, Rm.CveCliente,Rm.EsperaAceptacion,Rm.CveSucursal," +
                         "      RM.NoFactura " +
                         " FROM DocCab AS RM " +
                         " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON RM.ClaveAlmacen = Alm.ClaveAlmacen " +
                         " WHERE RM.idMov = @idMov";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter GetDetalleSql(String Doc)
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT RD.idMov, RD.Documento, RD.Serie, RD.Numdoc, RD.ClaveAlmacen, RD.Partida, " +
                         "        RD.CveArticulo, RD.Descripcion, RD.Cantidad, RD.CveUmedida1, RD.CveImpuesto, " +
                         "        RD.ImpuestoValor, RD.Precio, RD.Descuento, RD.PrecioNeto, RD.Impuesto, " +
                         "        RD.SubTotal, RD.Total, Art.CveArticulo, Art.Descripcion as DescArticulo," +
                         "        RD.Autorizado,FechaCaptura,FechaModificacion, Art.CodigoBarra, " +
                         "        RD.CveImpIEPS, RD.ImpIEPSValor, RD.TotalIEPS" +
                         " FROM DocDet AS RD " +
                         " INNER JOIN dbo.inv_CatArticulos AS Art ON RD.CveArticulo = Art.CveArticulo " +
                         " INNER JOIN dbo.Inv_UMedidas AS Umed ON RD.CveUmedida1 = Umed.CveUMedida" +
                         " WHERE RD.idMov = '" + Doc+ "' AND Art.Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int DeleteDocumento()
        {
            string sql = "Delete from DocDet  where idMov = @idMov";
            int rp = db.UpdateRegistro(sql, ArrParametros);
            sql = "Delete from DocCab where idMov = @idMov";
            int rp2 = db.UpdateRegistro(sql, ArrParametros);
            return rp2;
        }

        public int DelCeroDocumento()
        {

            int rsp = -1;

            string sql = "Update DocDet set Cantidad=0," +
            "           Precio=0, Descuento= 0,PrecioNeto=0, Impuesto=0, SubTotal=0, " +
            "           Total= 0, EstatusDoc=2  " +
            " Where idMov = @idMov";

            rsp = db.UpdateRegistro(sql, ArrParametros);
            if (rsp > 0)
            {
                sql = "Update DocCab set Impuesto = 0, Descuento = 0, Subtotal = 0, total=0,Estatus = 2, UsuarioModi = @UsuarioModi" +
                      " Where idMov = @idMov";
                rsp = db.UpdateRegistro(sql, ArrParametros);
            }

            return rsp;

        }

        public int SaveDocTransf(int EspAcep)
        {
            int bandDev = 0;
            db.IniciaTrans();
            string sql = " UPDATE DocCab  " +
                         " SET 	  DocCab.Documento = @Documento, DocCab.Serie = @Serie, DocCab.CveDoc = @CveDoc," +
                         "	      DocCab.NumDoc = @NumDoc, DocCab.ClaveAlmacen = @ClaveAlmacen, DocCab.ClaveImpuesto = DCI.ClaveImpuesto," +
                         "	 	  DocCab.Impuesto = DCI.Impuesto, DocCab.Descuento = DCI.Descuento,	DocCab.SubTotal = DCI.SubTotal, " +
                         "        DocCab.Total = DCI.Total, DocCab.CveProveedor = DCI.CveProveedor, DocCab.Observaciones = DCI.Observaciones," +
                         "        DocCab.FechaModificacion = DCI.FechaModificacion, DocCab.Estatus = DCI.Estatus, DocCab.Autorizado = DCI.Autorizado," +
                         "        DocCab.DocOrigen = @DocOrigen, DocCab.CveSucursal = DCI.CveSucursal, UsuarioModi = @UsuarioModi," +
                         "        DocCab.NoFactura = DCI.NoFactura   " +
                         " FROM  ( SELECT Documento, Serie,	CveDoc, NumDoc, ClaveImpuesto,Impuesto, Descuento, SubTotal, Total," +
                         "     	          CveProveedor, NoFactura,Observaciones, FechaModificacion, Estatus, Autorizado, CveSucursal " +
                         "         FROM DocCab WHERE idMov = @idMov) DCI " +
                         " WHERE DocCab.idMov = @idMovNew";

            if (db.UpdateRegistro(sql, ArrParametros) > 0)
            {
                sql = " INSERT INTO DocDet (idMov, Documento,Serie,Numdoc,ClaveAlmacen,Partida,CveArticulo,Descripcion," +
                     "                      Cantidad,CveUmedida1,CveImpuesto,ImpuestoValor,Precio,Descuento,PrecioNeto," +
                     "                      Impuesto,SubTotal,Total,FechaModificacion,FechaCaptura,EstatusDoc,Autorizado, " +
                     "                      CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
                     "                      TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro, " +
                     "                      ImpValorOtro, TotalImpOtro )" +

                     " SELECT @idMovNew, @Documento, @Serie, @Numdoc, @ClaveAlmacen, Partida, CveArticulo, Descripcion, " +
                     "        Cantidad, CveUmedida1, CveImpuesto, ImpuestoValor, Precio, Descuento, PrecioNeto, " +
                     "        Impuesto, SubTotal, Total,  FechaModificacion, FechaCaptura, EstatusDoc, Autorizado, " +
                     "        CveImpIEPS, ImpIEPSValor, TotalIEPS, CveImpRetIVA, ImpRetIVAValor, " +
                     "        TotalRetIVA, CveImpRetISR, ImpRetISRValor, TotalRetISR, CveImpOtro, " +
                     "        ImpValorOtro, TotalImpOtro " +

                     " FROM   DocDet AS DCI WHERE DCI.idMov = @idMov";

                int rps = db.InsertarRegistro(sql, ArrParametros);

                if (rps > 0)
                {
                    bandDev = 1;

                    sql = " UPDATE DocCab  " +
                         " SET 	  EsperaAceptacion = " +EspAcep +
                         " WHERE idMov = @idMov";
                    db.UpdateRegistro(sql, ArrParametros);

                }
            }

            if (bandDev == 1)
                db.TerminaTrans();
            else
                db.CancelaTrans();

            return bandDev;
        }

        public SqlDataAdapter SqlDocCabPrint()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT DC.idMov, DC.Documento, DC.Serie, DC.CveDoc, DC.NumDoc," +
                         "        DC.ClaveAlmacen, DC.FechaExpedicion, DC.ClaveImpuesto,  DC.Impuesto, DC.Descuento, " +
                         "        DC.SubTotal, DC.Total, DC.CveProveedor,  DC.CveCliente, DC.Observaciones, " +
                         "        DC.FechaCaptura, DC.FechaModificacion, DC.Autorizado, DC.EsperaAceptacion, DC.DocOrigen, " +
                         "        DC.Estatus, P.Nombre, P.RFC, P.Calle, P.CP, " +
                         "        P.Tel1, P.Mail1,  P.Contacto,  P.Tel2, P.Mail2, " +
                         "        P.Cargo, P.Celular,  GL.Descripcion AS Localidad, GM.Descripcion AS Municipio, " +
                         "        GE.Descripcion AS Estado, GP.Descripcion AS Pais " +
                         " FROM DocCab AS DC " +
                         " INNER JOIN CatProveedores AS P ON DC.CveProveedor = P.CveProveedor " +
                         " INNER JOIN CatGeografia AS GL ON P.CveLocalidad = GL.id" +
                         " INNER JOIN CatGeografia AS GM ON GM.id = GL.Padre " +
                         " INNER JOIN CatGeografia AS GE ON GE.id = GM.Padre " +
                         " INNER JOIN CatGeografia AS GP ON GP.id = GE.Padre" +
                         " WHERE DC.idMov = @idMov";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter SqlDocDetPrint()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT DD.idMov, DD.Documento, DD.Serie, DD.Numdoc, DD.ClaveAlmacen, " +
                         "        DD.Partida, DD.CveArticulo,  DD.Descripcion, DD.Cantidad, DD.CveUmedida1, " +
                         "        DD.CveImpuesto, DD.ImpuestoValor, DD.Precio, DD.Descuento, DD.PrecioNeto, " +
                         "        DD.Impuesto, DD.SubTotal, DD.Total, DD.CodAlmacen, DD.FechaModificacion, " +
                         "        DD.FechaCaptura, DD.EstatusDoc, DD.Autorizado, Alm.Descripcion AS Almacen, " +
                         "        DD.CveImpIEPS, DD.ImpIEPSValor, DD.TotalIEPS, DD.CveImpRetIVA, DD.ImpRetIVAValor, " +
                         "        DD.TotalRetIVA, DD.CveImpRetISR, DD.ImpRetISRValor, DD.TotalRetISR, DD.CveImpOtro, " +
                         "        DD.ImpValorOtro, DD.TotalImpOtro " +
                         " FROM DocDet AS DD " +
                         " INNER JOIN Inv_CatAlmacenes AS Alm ON DD.ClaveAlmacen = Alm.ClaveAlmacen" +
                         " WHERE DD.idMov = @idMov";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

    }
}
