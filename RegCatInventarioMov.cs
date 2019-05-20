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
    class RegCatInventarioMov
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatInventarioMov(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatInventarioMov(MsSql Odat) { db = Odat; }

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
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    */
     
        public int AddRegBlanco()
        {
  
            string sql = "Insert into Inv_MovtosMaster (NoMovimiento, FechaMovimiento) " +
                         "values( @NoMovimiento,@FechaMovimiento)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public String GetFolioSql(String Fol)
        {
            return db.GetFolioMov(Int32.Parse(Fol), "");
        }

        public int AddRegInvMaster()
        {
            string sql = "Update Inv_MovtosMaster set CveAlmacenMov=@CveAlmacenMov, CveTipoMov=@CveTipoMov, EntSal=@EntSal," +
            "           NoDoc=@NoDoc, Documento=@Documento,CveAlmacenDes=@CveAlmacenDes,CveTipoMovDest=@CveTipoMovDest, EntSalDest=@EntSalDest," +
            "           Modulo=@Modulo, Descuento=@Descuento," +
            "           TotalDscto=@TotalDscto, TIva=@TIva, SubTotal=@SubTotal, TotalDoc=@TotalDoc, CveProveedor=@CveProveedor," +
            "           Cancelado=@Cancelado, CveUsarioCaptu=@CveUsarioCaptu, NoMovtoTra = @NoMovtoTra, DocTra = @DocTra " +
            " Where NoMovimiento = @NoMovimiento";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int UpdateInvDet()
        {
            String sql = "Update Inv_MovtosDetalles set CveAlmacenMov = @CveAlmacenMov, CveTipoMov= @CveTipoMov," +
                      "                      EntSal = @EntSal, NoDoc = @NoDoc, Documento = @Documento" +
                      " Where NoMovimiento = @NoMovimiento";
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

        public int AfectaCostosSql(int Op)
        {
            String Opera = (Op==1)?"+":"-"; //Trae 1 cuando es registro nuevo, 0 cuando se quiere reinvertir
            string sql = " UPDATE Inv_Existencias SET Inv_Existencias.CostoPromedio = Rsp.CtoProm " +
                         " FROM Inv_Existencias t1, " +
                         "      (SELECT MDet.CveArticulo, " +
                         "            ( ( ISNULL(Exis.Cantidad,0) * ISNULL(Exis.CostoPromedio,0)) " +
                         Opera+ 
                         "              ( MDet.Cantidad * MDet.Precio )/ ( CASE WHEN " +
                         "                                                       (ISNULL(Exis.Cantidad,0) " + Opera + "  MDet.Cantidad) = 0 THEN 1 " +
                         "                                                      ELSE (ISNULL(Exis.Cantidad,0) " + Opera + "  MDet.Cantidad) END ) " +
                         "            ) as CtoProm" +
                         //"(ISNULL(Exis.Cantidad,0) " + Opera + " MDet.Cantidad) as CtoProm  " +
                         "       FROM Inv_MovtosDetalles MDet" +
                         "       INNER JOIN  Inv_Existencias Exis ON MDet.CveArticulo =  Exis.ClaveArticulo and MDet.CveAlmacenMov = Exis.ClaveAlmacen " +
                         "       WHERE MDet.NoMovimiento = @NoMovimiento) AS Rsp" +
                         " WHERE t1.ClaveArticulo = Rsp.CveArticulo AND t1.ClaveAlmacen = @ClaveAlmacen";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int AfectaExistenciasSql(String _CveTipoMov, String _EntSal, int Op)
        {
            String Opera = (Op == 1) ? (_EntSal.Equals("E")) ? "+" : "-" : (_EntSal.Equals("E")) ? "-" : "+"; //Trae 1 cuando es registro nuevo, 0 cuando se quiere reinvertir
            String Add_UltPrecio = (_CveTipoMov.Equals("002") || _CveTipoMov.Equals("501")) ? "" : " , CostoUltimo = Rsp.Precio ";
            //002 - 501 = Entrada o Salida por ajuste de inventarios

            string sql = " UPDATE Inv_Existencias SET  Inv_Existencias.Cantidad = ISNULL(t1.Cantidad,0) " + Opera + " Rsp.Cant" + Add_UltPrecio+
                         " FROM Inv_Existencias t1, " +
                         "     (SELECT MDet.CveArticulo, MDet.Cantidad as Cant, MDet.Precio" +
                         "      FROM Inv_MovtosDetalles MDet" +
                         "       WHERE MDet.NoMovimiento = @NoMovimiento) AS Rsp" +
                         " WHERE t1.ClaveArticulo = Rsp.CveArticulo AND t1.ClaveAlmacen = @ClaveAlmacen";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select MM.NoMovimiento, MM.FechaMovimiento, MM.CveAlmacenMov, MM.CveTipoMov, MM.EntSal," +
                         "       MM.NoDoc, MM.Documento, MM.CveAlmacenDes,CveTipoMovDest, MM.EntSalDest," +
                         "       MM.Modulo, MM.TipoDoc, MM.SerieDoc, MM.FolioDocOrigen, MM.Descuento," +
                         "       MM.TotalDscto, MM.TIva, MM.SubTotal, MM.TotalDoc, MM.CveProveedor," +
                         "       MM.CveCliente, MM.Cancelado, MM.CveUsarioCaptu, MM.CveCentroCosto, MM.NoMovtoTra," +
                         "       MM.DocTra, TM.CveClsMov " +
                         "from Inv_MovtosMaster AS MM " +
                         "INNER JOIN Inv_TipoMovtos as TM ON TM.CveTipoMov = MM.CveTipoMov " +
                         "where NoMovimiento = @NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }



        /*
                public int UpdateInventarioMov()
                {
                    string sql = "Update Inv_MovtosMaster set FechaMovimiento=@FechaMovimiento, CveAlmacenMov=@CveAlmacenMov, CveTipoMov=@CveTipoMov, EntSal=@EntSal," +
                                "           NoDoc=@NoDoc, Documento=@Documento, CveAlmacenDes=@CveAlmacenDes,CveTipoMovDest=@CveTipoMovDest, EntSalDest=@EntSalDest," +
                                "           Modulo=@Modulo, TipoDoc=@TipoDoc, SerieDoc=@SerieDoc, FolioDocOrigen=@FolioDocOrigen, Descuento=@Descuento," +
                                "           TotalDscto=@TotalDscto, TIva=@TIva, SubTotal=@SubTotal, TotalDoc=@TotalDoc, CveProveedor=@CveProveedor," +
                                "           CveCliente=@CveCliente, Cancelado=@Cancelado, CveUsarioCaptu=@CveUsarioCaptu, CveCentroCosto=@CveCentroCosto, NoMovtoTra=@NoMovtoTra," +
                                "           DocTra=@DocTra " +
                                " Where NoMovimiento = @NoMovimiento";
                    return db.DeleteRegistro(sql, ArrParametros);
                }





                public SqlDataAdapter BuscaInventarioMov(string bsq)
                {
                    SqlDataAdapter dt = null;
                    string sql = "Select NoMovimiento,NoDoc " +
                       "from Inv_MovtosMaster " +
                       "where NoMovimiento like '%" + bsq + "%' OR " +
                       "NoDoc like '%" + bsq + "%' ";

                    dt = db.SelectDA(sql);
                    return dt;
                }

            */
        public SqlDataAdapter ListInventarioMovtos()
        {
            SqlDataAdapter dt = null;
            string Sql = "SELECT MM.NoMovimiento,MM.Documento,MM.FechaMovimiento,Alm.Descripcion AS Almacen, " +
                         "       TMvto.Descripcion AS TipoMov, Prov.Nombre AS Proveedor, MM.Cancelado,MM.TotalDoc, " +
                         "        MM.CveTipoMov,MM.NoMovtoTra " +
                         " FROM Inv_MovtosMaster MM " +
                         " INNER JOIN Inv_CatAlmacenes Alm ON Alm.ClaveAlmacen = mm.CveAlmacenMov " +
                         " LEFT JOIN CatProveedores Prov ON Prov.CveProveedor = mm.CveProveedor " +
                         " INNER JOIN Inv_TipoMovtos TMvto ON TMvto.CveTipoMov = MM.CveTipoMov";
            dt = db.SelectDA(Sql);
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
    }

}
