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

        /*
        public void Conn()
        {
            /*db = new DatSql.MsSql(
                   ConfigurationSettings.AppSettings.Get("Servidor"),
                   ConfigurationSettings.AppSettings.Get("Datos"),
                   ConfigurationSettings.AppSettings.Get("Usuario"),
                   ConfigurationSettings.AppSettings.Get("Password")
                   );
            
            db = new DatSql.MsSql("SIGMA6\\SQL14", "CtrlAcceso", "sa", "Remolachas1");
                   
            if (db.Conectar() < 1)
                MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    */

        public int AddRegArticulo()
        {
            string sql = "INSERT INTO inv_CatArticulos (CveArticulo,  CodigoAlterno,  CodigoBarra,  CodigoSat,  Fecha_Alta,  Descripcion,  CveLinea, " +
                "CveUMedida1,  CveUMedida2,  UMedidaEquiv2,  EsInventa,  DispVenta,  EsServicio,  DispKit,  EsKit,    Observacion,  Estatus," +
                "  CveImpuesto, CveClase1,  CveClase2,  CveClase3, Foto, CveMarca ) " +
                // "Modelo, FecUltCompra,  CveProveedorUlt)" +
                "VALUES ( @CveArticulo,  @CodigoAlterno,  @CodigoBarra,  @CodigoSat,  @Fecha_Alta,  @Descripcion,  @CveLinea, " +
                "@CveUMedida1,  @CveUMedida2, @UMedidaEquiv2,  @EsInventa,  @DispVenta,  @EsServicio,  @DispKit,  @EsKit,   @Observacion,  @Estatus,"+
                "@CveImpuesto, @CveClase1,  @CveClase2,  @CveClase3, @Foto, @CveMarca) ";

            //"@Modelo, @FecUltCompra,  @CveProveedorUlt)";
            return db.InsertarRegistro(sql, ArrParametros);
        }
        public int AddRegExistencias()
        {
            string sql = "Insert into Inv_Existencias (ClaveArticulo, ClaveAlmacen, Cantidad, stockMin, stockMax, CantApartada," +
                         "            CostoPromedio, CostoUltimo, CostoActual) " +
                         "      values(@ClaveArticulo,@ClaveAlmacen,0,0,0,0,0,0,0)";
            return db.InsertarRegistro(sql, ArrParametros);
        }
        public int AddRegLstPrecios()
        {
            string sql = " INSERT INTO Inv_LstPreciosDet (CveLstPrecio, CveArticulo, FechaModifacion) (SELECT CveLstPrecio, @CveArticulo, GETDATE() FROM Inv_LstPreciosMast WHERE ESTATUS = 1) ";
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
                        "EsKit=@EsKit,  " +
                        "Foto=@Foto,  " +
                        "Observacion=@Observacion,  " +
                        "Estatus=@Estatus,  " +
                        "CveImpuesto=@CveImpuesto,  " +                        
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
            string sql = "Delete from inv_CatArticulos where CveArticulo = @CveArticulo";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListArticulos()
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT A.CveArticulo AS Clave,A.CodigoBarra AS Codigo,A.Descripcion,A.CodigoSat AS [Codigo SAT],A.Modelo,A.Observacion, " +
                         "       L.CveLinea, L.Descripcion AS Linea, " +
                         "       M.CveMarca, M.Descripcion AS Marca, " +
                         "       C.CveClase, C.Descripcion AS Clase, " +
                         "       UM.CveUMedida, UM.Descripcion AS UMedida, " +
                         "       Imp.CveImpuesto, Imp.Tipo, Imp.Valor " +
                         " FROM dbo.inv_CatArticulos AS A " +
                         " INNER JOIN dbo.Inv_Lineas AS L ON A.CveLinea = L.CveLinea " +
                         " INNER JOIN dbo.Inv_Clases AS C ON A.CveClase1 = C.CveClase " +
                         " INNER JOIN dbo.Inv_UMedidas AS UM ON A.CveUMedida1 = UM.CveUMedida " +
                         " INNER JOIN dbo.Inv_Marcas AS M ON A.CveMarca = M.CveMarca " +
                         " INNER JOIN dbo.Inv_Impuestos AS Imp ON A.CveImpuesto = Imp.CveImpuesto  ";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select * " +
                          "from Inv_CatArticulos where CveArticulo =@CveArticulo";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaArticulo(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "SELECT A.CveArticulo AS Clave,A.CodigoBarra AS Codigo,A.Descripcion,A.CodigoSat AS [Codigo SAT],A.Modelo,A.Observacion, " +
                         "       L.CveLinea, L.Descripcion AS Linea, " +
                         "       M.CveMarca, M.Descripcion AS Marca, " +
                         "       C.CveClase, C.Descripcion AS Clase, " +
                         "       UM.CveUMedida, UM.Descripcion AS UMedida, " +
                         "       Imp.CveImpuesto, Imp.Tipo, Imp.Valor " +
                         " FROM dbo.inv_CatArticulos AS A " +
                         " INNER JOIN dbo.Inv_Lineas AS L ON A.CveLinea = L.CveLinea " +
                         " INNER JOIN dbo.Inv_Clases AS C ON A.CveClase1 = C.CveClase " +
                         " INNER JOIN dbo.Inv_UMedidas AS UM ON A.CveUMedida1 = UM.CveUMedida " +
                         " INNER JOIN dbo.Inv_Marcas AS M ON A.CveMarca = M.CveMarca " +
                         " INNER JOIN dbo.Inv_Impuestos AS Imp ON A.CveImpuesto = Imp.CveImpuesto  "+
                         " where CveArticulo like '%" + bsq + "%' OR " +
                        " A.Descripcion  like '%" + bsq + "%' OR " +
                        " CodigoBarra    like '%" + bsq + "%' OR " +
                        " M.Descripcion  like '%" + bsq + "%' OR " +
                        " L.Descripcion  like '%" + bsq + "%' OR " +
                        " C.Descripcion  like '%" + bsq + "%' OR " +
                        " UM.Descripcion like '%" + bsq + "%' OR " +
                        " CodigoSat like '%" + bsq + "%'";


            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter ComboImpuesto()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveImpuesto as Clave,Tipo as Descripcion " +
                         "from Inv_Impuestos where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter ComboClase()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClase as Clave,Descripcion " +
                         "from Inv_Clases where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter ComboMarca()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMarca as Clave,Descripcion " +
                         "from Inv_Marcas where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
