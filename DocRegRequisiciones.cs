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
        private object[,] MatParamP = new object[18,2];

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

        public string[] getIdDoc(int f, string _alm,string Documento)
        {
            string dv = Documento;
            string x = db.GetFolioMov(f,_alm);

            string[] folDoc = new string[2];
            folDoc[0] = x;
           

            for (int i = 1; i <= (6 - x.Length); i++)
                dv = dv + "0";
            dv = dv + x ;
            folDoc[1] = dv;

            return folDoc;
        }


        public SqlDataAdapter ListDocumentos(String CodAlm, String FIni, String FFin)
        {
            String StrSql = "";


            if (!CodAlm.Equals("0") && !CodAlm.Equals(""))
            {
                StrSql += " AND Alm.ClaveAlmacen = '" + CodAlm + "'";
            }

            SqlDataAdapter dt = null;


            string Sql = "SELECT M.idMov,M.Documento,M.Serie,M.NumDoc,M.ClaveAlmacen, Alm.Descripcion 'Almacén'," +
                         "       M.FechaExpedicion as 'Fec Exp',M.Impuesto,M.Descuento,M.SubTotal,M.Total" +
                         " FROM dbo.ReqMaster AS M " +
                         " INNER JOIN dbo.Inv_CatAlmacenes AS Alm ON M.ClaveAlmacen = Alm.ClaveAlmacen " +
                         " WHERE (CONVERT(date,M.FechaExpedicion) BETWEEN '" + FIni + "' AND '" + FFin + "')" + StrSql;
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int AddRegEnBlanco()
        {
            string sql = "Insert into ReqMaster (idMov,FechaExpedicion) " +
                        "values(@idMov,@FechaExpedicion)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int DeleteRegEnBlanco()
        {
            string sql = "Delete from ReqMaster where idmov = @idMov";
            return db.DeleteRegistro(sql,ArrParametros);
        }

        public int SaveDocumento(int op)
        {
            int bandDev = 0;
            string sql = "Update ReqMaster Set Documento = @Documento,Serie = @Serie,NumDoc=@NumDoc,ClaveAlmacen=@ClaveAlmacen,FechaExpedicion=@FechaExpedicion," +
                   "ClaveImpuesto=@ClaveImpuesto,Impuesto=@Impuesto,Descuento=@Descuento,SubTotal=@SubTotal,Total=@Total,Observaciones=@Observaciones," +
                   "Estatus=@Estatus,Autorizado=@Autorizado,Cancelado=@Cancelado where idMov = @idMov";
            db.IniciaTrans();

            if (db.UpdateRegistro(sql, ArrParametros) > 0)
            {
                if (op == 2)
                {
                    sql = "Delete from ReqDetalle  where idMov = @idMov";
                    int rp = db.UpdateRegistro(sql, ArrParametros);
                    
                }

                int j = 0;
                foreach (DocPartidasReq lst in Partidas)
                {
                    string SqlP = "insert into ReqDetalle (idMov,Documento,Serie,Numdoc,ClaveAlmacen,Partida,CveArticulo,Descripcion,Cantidad," +
                                  "CveUmedida1,CveImpuesto,ImpuestoValor,Precio,Descuento,PrecioNeto,Impuesto,SubTotal,Total)" +
                             "  values(@idMov,@Documento,@Serie,@Numdoc,@ClaveAlmacen,@Partida,@CveArticulo,@Descripcion,@Cantidad," +
                                       "@CveUmedida1,@CveImpuesto,@ImpuestoValor,@Precio,@Descuento,@PrecioNeto,@Impuesto,@SubTotal,@Total)";

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
                         "       RM.Total,RM.Observaciones,RM.Estatus,RM.Autorizado,RM.Cancelado," +
                         "       Alm.Descripcion " +
                         " FROM dbo.ReqMaster AS RM " +
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
                         "        RD.SubTotal, RD.Total, Art.CveArticulo, Art.Descripcion as DescArticulo "+
                         " FROM dbo.ReqDetalle AS RD " +
                         " INNER JOIN dbo.inv_CatArticulos AS Art ON RD.CveArticulo = Art.CveArticulo " +
                         " INNER JOIN dbo.Inv_UMedidas AS Umed ON RD.CveUmedida1 = Umed.CveUMedida" +
                         " WHERE RD.idMov = '" + Doc+"'";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public int DeleteDocumento()
        {
            string sql = "Delete from ReqDetalle  where idMov = @idMov";
            int rp = db.UpdateRegistro(sql, ArrParametros);
            sql = "Delete from ReqMaster where idMov = @idMov";
            int rp2 = db.UpdateRegistro(sql, ArrParametros);
            return rp2;
        }


    }
}
