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

        public String GetFolio(String Fol)
        {
            return db.GetFolioMov(Int32.Parse(Fol), "");
        }

        public int AddRegInvMov()
        {
            string sql = "Update Inv_MovtosMaster set CveAlmacenMov=@CveAlmacenMov, CveTipoMov=@CveTipoMov, EntSal=@EntSal," +
            "           NoDoc=@NoDoc, Documento=@Documento,CveAlmacenDes=@CveAlmacenDes,CveTipoMovDest=@CveTipoMovDest, EntSalDest=@EntSalDest," +
            "           Modulo=@Modulo, Descuento=@Descuento," +
            "           TotalDscto=@TotalDscto, TIva=@TIva, SubTotal=@SubTotal, TotalDoc=@TotalDoc, CveProveedor=@CveProveedor," +
            "           Cancelado=@Cancelado, CveUsarioCaptu=@CveUsarioCaptu " +
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

        public int AddRegInvMovRel()
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

        public int DeleteInventarioMov()
        {
            string  sql = "Delete from Inv_MovtosDetalles  where NoMovimiento = @NoMovimiento";
            int rp = db.UpdateRegistro(sql, ArrParametros);
            sql = "Delete from Inv_MovtosMaster where NoMovimiento = @NoMovimiento";
            int rp2 = db.UpdateRegistro(sql, ArrParametros);
            return rp2;
        }

        public SqlDataAdapter ListInventarioMovtos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select NoMovimiento,NoDoc " +
                         "from Inv_MovtosMaster";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select NoMovimiento, FechaMovimiento, CveAlmacenMov, CveTipoMov, EntSal," +
                        "           NoDoc, Documento, CveAlmacenDes,CveTipoMovDest, EntSalDest," +
                        "           Modulo, TipoDoc, SerieDoc, FolioDocOrigen, Descuento," +
                        "           TotalDscto, TIva, SubTotal, TotalDoc, CveProveedor," +
                        "           CveCliente, Cancelado, CveUsarioCaptu, CveCentroCosto, NoMovtoTra," +
                        "           DocTra " +
                         " from Inv_MovtosMaster where NoMovimiento =@NoMovimiento";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
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
