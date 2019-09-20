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
        private object[,] MatParamP = new object[21,2];

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


        public SqlDataAdapter ListDocumentos(String CodAlm, String FIni, String FFin, String CveDc)
        {
            String StrSql = "";


            if (!CodAlm.Equals("0") && !CodAlm.Equals(""))
            {
                StrSql += " AND Alm.ClaveAlmacen = '" + CodAlm + "'";
            }

            SqlDataAdapter dt = null;


            string Sql = "SELECT M.idMov,M.Documento,M.Serie,M.NumDoc,M.ClaveAlmacen, Alm.Descripcion 'Almacén'," +
                         "       M.FechaExpedicion as 'Fec Exp',M.Impuesto,M.Descuento,M.SubTotal,M.Total,M.CveProveedor," +
                         "       M.EsperaAceptacion, M.DocOrigen" +
                         " FROM DocCab AS M " +
                         " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON M.ClaveAlmacen = Alm.ClaveAlmacen " +
                         " WHERE (CONVERT(date,M.FechaExpedicion) BETWEEN '" + FIni + "' AND '" + FFin + "')" +
                         "   AND CveDoc = '"+CveDc+"' " + StrSql;
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int AddRegEnBlanco()
        {
            string sql = "Insert into DocCab (idMov,FechaExpedicion, FechaCaptura) " +
                        "values(@idMov,@FechaExpedicion,@FechaExpedicion )";
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
                         "       FechaModificacion = @FechaModificacion, Estatus=@Estatus, " +
                         "       Autorizado=@Autorizado, EsperaAceptacion = @EsperaAceptacion " +
                         " WHERE idMov = @idMov";
            db.IniciaTrans();

            if (db.UpdateRegistro(sql, ArrParametros) > 0)
            {
                if (op == 2)
                {
                    sql = "Delete from DocDet  where idMov = @idMov";
                    int rp = db.UpdateRegistro(sql, ArrParametros);
                    
                }

                foreach (DocPartidasReq lst in Partidas)
                {
                    string SqlP = "insert into DocDet (idMov,Documento,Serie,Numdoc,ClaveAlmacen,Partida,CveArticulo,Descripcion,Cantidad," +
                                  "CveUmedida1,CveImpuesto,ImpuestoValor,Precio,Descuento,PrecioNeto,Impuesto,SubTotal,Total, Autorizado," +
                                  "FechaCaptura,FechaModificacion)" +
                             "  values(@idMov,@Documento,@Serie,@Numdoc,@ClaveAlmacen,@Partida,@CveArticulo,@Descripcion,@Cantidad," +
                                       "@CveUmedida1,@CveImpuesto,@ImpuestoValor,@Precio,@Descuento,@PrecioNeto,@Impuesto,@SubTotal,@Total, @Autorizado," +
                                       "@FechaCaptura,@FechaModificacion)";

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
                         "       Alm.Descripcion, Rm.CveProveedor, CveCliente,EsperaAceptacion " +
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
                         "        RD.Autorizado,FechaCaptura,FechaModificacion " +
                         " FROM DocDet AS RD " +
                         " INNER JOIN dbo.inv_CatArticulos AS Art ON RD.CveArticulo = Art.CveArticulo " +
                         " INNER JOIN dbo.Inv_UMedidas AS Umed ON RD.CveUmedida1 = Umed.CveUMedida" +
                         " WHERE RD.idMov = '" + Doc+"'";
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

        public int SaveDocTransf()
        {
            int bandDev = 0;
            db.IniciaTrans();
            string sql = " UPDATE DocCab  " +
                         " SET 	  DocCab.Documento = @Documento, DocCab.Serie = @Serie, DocCab.CveDoc = @CveDoc," +
                         "	      DocCab.NumDoc = @NumDoc, DocCab.ClaveAlmacen = DCI.ClaveAlmacen, DocCab.ClaveImpuesto = DCI.ClaveImpuesto," +
                         "	 	  DocCab.Impuesto = DCI.Impuesto, DocCab.Descuento = DCI.Descuento,	DocCab.SubTotal = DCI.SubTotal, " +
                         "        DocCab.Total = DCI.Total, DocCab.CveProveedor = DCI.CveProveedor, DocCab.Observaciones = DCI.Observaciones," +
                         "        DocCab.FechaModificacion = DCI.FechaModificacion, DocCab.Estatus = DCI.Estatus, DocCab.Autorizado = DCI.Autorizado," +
                         "        DocCab.DocOrigen = @DocOrigen" +
                         " FROM  ( SELECT Documento, Serie,	CveDoc, NumDoc, ClaveAlmacen, ClaveImpuesto,Impuesto, Descuento, SubTotal, Total," +
                         "     	          CveProveedor, Observaciones, FechaModificacion, Estatus, Autorizado " +
                         "         FROM DocCab WHERE idMov = @idMov) DCI " +
                         " WHERE DocCab.idMov = @idMovNew";

            if (db.UpdateRegistro(sql, ArrParametros) > 0)
            {
                sql = " INSERT INTO DocDet (idMov, Documento,Serie,Numdoc,ClaveAlmacen,Partida,CveArticulo,Descripcion," +
                     "                      Cantidad,CveUmedida1,CveImpuesto,ImpuestoValor,Precio,Descuento,PrecioNeto," +
                     "                      Impuesto,SubTotal,Total,CodAlmacen,FechaModificacion,FechaCaptura,EstatusDoc,Autorizado) " +
                     " SELECT @idMovNew, @Documento, @Serie, @Numdoc, ClaveAlmacen, Partida, CveArticulo, Descripcion, " +
                     "        Cantidad, CveUmedida1, CveImpuesto, ImpuestoValor, Precio, Descuento, PrecioNeto, " +
                     "        Impuesto, SubTotal, Total, CodAlmacen, FechaModificacion, FechaCaptura, EstatusDoc, Autorizado" +
                     " FROM   DocDet AS DCI WHERE DCI.idMov = @idMov";

                int rps = db.InsertarRegistro(sql, ArrParametros);

                if (rps > 0)
                {
                    bandDev = 1;

                    sql = " UPDATE DocCab  " +
                         " SET 	  EsperaAceptacion = 0" +
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
    }
}
