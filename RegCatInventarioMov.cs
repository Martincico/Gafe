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
                MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int AfectaCostosSql(String _CveTipoMov, int Op)
        {
            String Opera = " ";
            String Add_UltPrecio = "";
            //002 - 501 = Entrada o Salida por ajuste de inventarios

            if (Op == 1)
            {
                Opera = "+";
                Add_UltPrecio = (_CveTipoMov.Equals("002") || _CveTipoMov.Equals("501")) ? "" : " , Inv_Existencias.CostoUltimo = Rsp.Precio ";
            }
            else
            {
                Opera = "-";
                Add_UltPrecio = (_CveTipoMov.Equals("002") || _CveTipoMov.Equals("501")) ? "" : " , Inv_Existencias.CostoUltimo = ( SELECT TOP 1 Precio " +
                                                                                                                                 " ORDER BY NoMovimiento DESC) ";
            }


            string sql = " UPDATE Inv_Existencias SET Inv_Existencias.CostoPromedio = Rsp.CtoProm " + Add_UltPrecio +
                         " FROM Inv_Existencias t1, " +
                         "      (SELECT MDet.CveArticulo, MDet.CveTipoMov, " +
                         "          ((( ISNULL(Exis.Cantidad,0) * ISNULL(Exis.CostoPromedio,0))" + Opera + "( MDet.Cantidad * MDet.Precio ))/ (ISNULL(Exis.Cantidad,0) " + Opera + " MDet.Cantidad)) as CtoProm, " +
                         "          MDet.Precio  " +
                         "       FROM Inv_MovtosDetalles MDet" +
                         "       INNER JOIN  Inv_Existencias Exis ON MDet.CveArticulo =  Exis.ClaveArticulo and MDet.CveAlmacenMov = Exis.ClaveAlmacen " +
                         "       WHERE MDet.NoMovimiento = @NoMovimiento) AS Rsp" +
                         " WHERE t1.ClaveArticulo = Rsp.CveArticulo AND t1.ClaveAlmacen = @ClaveAlmacen";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int AfectaExistenciasSql(String _EntSal, int Op)
        {
            String Opera = (Op == 1) ? (_EntSal.Equals("E")) ? "+" : "-" : (_EntSal.Equals("E")) ? "-" : "+"; //Trae 1 cuando es registro nuevo, 0 cuando se quiere reinvertir

            string sql = " UPDATE Inv_Existencias SET  Inv_Existencias.Cantidad = ISNULL(t1.Cantidad,0) " + Opera + " Rsp.Cant" +
                         " FROM Inv_Existencias t1, " +
                         "     (SELECT MDet.CveArticulo, MDet.Cantidad as Cant " +
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
                         "        MM.CveTipoMov,MM.NoMovtoTra " +
                         " FROM Inv_MovtosMaster MM " +
                         " INNER JOIN Inv_CatAlmacenes Alm ON Alm.ClaveAlmacen = mm.CveAlmacenMov " +
                         " LEFT JOIN CatProveedores Prov ON Prov.CveProveedor = mm.CveProveedor " +
                         " INNER JOIN Inv_TipoMovtos TMvto ON TMvto.CveTipoMov = mm.CveTipoMov" +
                        //" WHERE MM.Cancelado = 1 " + StrSql;
                        " WHERE (CONVERT(date,MM.FechaMovimiento) BETWEEN '"+FIni+"' AND '"+FFin+ "') AND TMvto.EsInterno = 0 " + StrSql;
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
