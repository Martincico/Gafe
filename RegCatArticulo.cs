using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatArticulo
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatArticulo(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatArticulo(MsSql Odat) { db = Odat; }

        public int AddRegArticulo()
        {
            string sql = "INSERT INTO inv_CatArticulos (CveArticulo,  CodigoAlterno,  CodigoBarra,  CodigoSat,  " +
                " Fecha_Alta,  " +
                " Descripcion,  CveLinea, " +
                "CveUMedida1,  CveUMedida2,  UMedidaEquiv2,  EsInventa,  DispVenta,  EsServicio,  DispKit,  EsKit,  RequiereReceta,  Observacion,  Estatus," +
                "  CveImpuesto, CveImpIEPS, CveImpRetIVA, CveImpRetISR, CveImpOtro, " +
                " CveClase1,  CveClase2,  CveClase3, Foto, CveMarca ) " +
                // "Modelo, FecUltCompra,  CveProveedorUlt)" +
                "VALUES ( @CveArticulo,  @CodigoAlterno,  @CodigoBarra,  @CodigoSat,  " +
                " (CONVERT(DATETIME, @Fecha_Alta) + CONVERT(DATETIME, CONVERT(time, GETDATE()))) ,  " +
                " @Descripcion,  @CveLinea, " +
                "@CveUMedida1,  @CveUMedida2, @UMedidaEquiv2,  @EsInventa,  @DispVenta,  @EsServicio,  @DispKit,  @EsKit, @RequiereReceta,  @Observacion,  @Estatus," +
                "@CveImpuesto, @CveImpIEPS, @CveImpRetIVA, @CveImpRetISR, @CveImpOtro , " +
                " @CveClase1,  @CveClase2,  @CveClase3, @Foto, @CveMarca) ";

            //"@Modelo, @FecUltCompra,  @CveProveedorUlt)";
            return db.InsertarRegistro(sql, ArrParametros);
        }
        public int AddRegExistencias()
        {
            string sql = "Insert into Inv_Existencias (ClaveArticulo, ClaveAlmacen, Cantidad, stockMin, stockMax, CantApartada," +
                         "            CostoPromedio, CostoUltimo, CostoActual) " +
                         " (SELECT @ClaveArticulo,ClaveAlmacen,0,0,0,0,0,0,0 FROM Inv_CatAlmacenes WHERE ESTATUS = 'A') ";
            return db.InsertarRegistro(sql, ArrParametros);
        }
        public int AddRegLstPrecios()
        {

            string sql = " INSERT INTO Inv_LstPreciosDet (CveLstPrecio, CveArticulo,Precio,Porcentaje,CostoUltimo, FechaModifacion) (SELECT CveLstPrecio, @CveArticulo,0,0,0, GETDATE() FROM Inv_LstPreciosMast WHERE ESTATUS = 1) ";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateArticulo()
        {
            string sql = "Update inv_CatArticulos set " +
                        "CveArticulo=@CveArticulo,  " +
                        "CodigoAlterno=@CodigoAlterno,  " +
                        "CodigoBarra=@CodigoBarra,  " +
                        "CodigoSat=@CodigoSat,  " +
                        "Fecha_Alta=@Fecha_Alta,  " +
                        "Descripcion=@Descripcion,  " +                        
                        "CveLinea=@CveLinea,  " +
                        "CveUMedida1=@CveUMedida1,  " +
                        "CveUMedida2=@CveUMedida2,  " +
                        "UMedidaEquiv2=@UMedidaEquiv2,  " +
                        "EsInventa=@EsInventa,  " +
                        "DispVenta=@DispVenta,  " +
                        "EsServicio=@EsServicio,  " +
                        "DispKit=@DispKit,  " +
                        "EsKit=@EsKit," +
                        "RequiereReceta =@RequiereReceta,  " +
                        "Foto=@Foto,  " +
                        "Observacion=@Observacion,  " +
                        "Estatus=@Estatus,  " +
                        "CveImpuesto=@CveImpuesto,  " +
                        "CveImpIEPS = @CveImpIEPS, " +
                        "CveImpRetIVA = @CveImpRetIVA, " +
                        "CveImpRetISR = @CveImpRetISR, " +
                        "CveImpOtro = @CveImpOtro, " +                        
                        "CveClase1=@CveClase1,  " +
                        "CveClase2=@CveClase2,  " +
                        //"Modelo=@Modelo,  " +
                        "CveMarca=@CveMarca,  " +
                        //"FecUltCompra=@FecUltCompra,  " +
                        //"CveProveedorUlt=@CveProveedorUlt, " +
                        "CveClase3=@CveClase3  " +
                        "Where CveArticulo = @CveArticulo";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteArticulo()
        {
            string sql = "UPDATE inv_CatArticulos SET Estatus = 0 WHERE CveArticulo = @CveArticulo";
            return db.UpdateRegistro(sql, ArrParametros);
        }
        
        public SqlDataAdapter RegistroActivo(int HideCveArt)
        {
            SqlDataAdapter dt = null;

            string Sql = "  SELECT CveArticulo,  CodigoAlterno,  CodigoBarra,  CodigoSat,  Fecha_Alta,  " +
                                "  Descripcion, Modelo,  CveLinea, CveMarca, CveClase1, " +
                                "  CveClase2,  CveClase3, CveImpuesto, CveUMedida1,  CveUMedida2, " +
                                "  UMedidaEquiv2, EsInventa,  DispVenta,  EsServicio,  DispKit, " +
                                "  EsKit,  FecUltCompra, CveProveedorUlt, Foto, Observacion, " +
                                "  Estatus, CveImpIEPS, CveImpRetIVA, CveImpRetISR, CveImpOtro, " +
                                "  RequiereReceta " +
                          " FROM Inv_CatArticulos " +
                          " WHERE Estatus = 1 AND "+(HideCveArt==1? "CodigoBarra = @CveArticulo": " CveArticulo =@CveArticulo ");
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaArticulo(string bsq)
        {
            SqlDataAdapter dt = null;
            String wh = "";
            if(!bsq.Equals(""))
            {
                wh = " AND (CveArticulo like '%" + bsq + "%' OR " +
                        " A.Descripcion  like '%" + bsq + "%' OR " +
                        " CodigoBarra    like '%" + bsq + "%' OR " +
                        " M.Descripcion  like '%" + bsq + "%' OR " +
                        " L.Descripcion  like '%" + bsq + "%' OR " +
                        " C.Descripcion  like '%" + bsq + "%' OR " +
                        " UM.Descripcion like '%" + bsq + "%' OR " +
                        " CodigoSat like '%" + bsq + "%') ";
            }

            string sql = "SELECT TOP 800 A.CveArticulo, " +
                         "       A.CodigoBarra," +
                         "       A.Descripcion, " +
                         "       A.CodigoSat," +
                         "       UM.CveUMedida, " +
                         "       UM.Descripcion AS UMedida, " +
                         "       Imp.CveImpuesto, " +
                         "       Imp.Tipo, " +
                         "       Imp.Valor, " +
                         "       L.CveLinea, " +
                         "       L.Descripcion AS Linea, " +
                         "       M.CveMarca, " +
                         "       M.Descripcion AS Marca, " +
                         "       C.CveClase, " +
                         "       C.Descripcion AS Clase, " +
                         "       A.Modelo," +
                         "       A.Observacion, " +
                         "       ImpIep.CveImpuesto AS CveIEPS, " +
                         "       ImpIep.Tipo AS TipoIEPS, " +
                         "       ImpIep.Valor AS ValorIEPS," +
                         "       A.RequiereReceta" +

                         " FROM dbo.inv_CatArticulos AS A " +
                         " INNER JOIN dbo.Inv_Lineas AS L ON A.CveLinea = L.CveLinea " +
                         " INNER JOIN dbo.Inv_Clases AS C ON A.CveClase1 = C.CveClase " +
                         " INNER JOIN dbo.Inv_UMedidas AS UM ON A.CveUMedida1 = UM.CveUMedida " +
                         " INNER JOIN dbo.Inv_Marcas AS M ON A.CveMarca = M.CveMarca " +
                         " INNER JOIN dbo.Inv_Impuestos AS Imp ON A.CveImpuesto = Imp.CveImpuesto  "+
                         " LEFT JOIN dbo.Inv_Impuestos AS ImpIep ON A.CveImpIEPS = ImpIep.CveImpuesto  " +
                         " where  A.Estatus = 1 " +wh+
                         " Order by Fecha_Alta DESC";


            dt = db.SelectDA(sql);
            return dt;
        }
        
    }
}
