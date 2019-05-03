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
    class RegExistencias
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegExistencias(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegExistencias(MsSql Odat) { db = Odat; }

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

        public int AddRegExistencia()
        {
            string sql = "Insert into Inv_CatAlmacenes (ClaveAlmacen,Descripcion,Estatus,EsDeCompra,EsDeVenta,EsDeConsigna,NumRojo) " +
                         "values(@ClaveAlmacen,@Descripcion,@Estatus,@EsDeCompra,@EsDeVenta,@EsDeConsigna,@NumRojo)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateExistencia()
        {
            string sql = "Update Inv_CatAlmacenes set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus, " +
                         "EsDeCompra = @EsDeCompra, " +
                         "EsDeVenta = @EsDeVenta, " +
                         "EsDeConsigna = @EsDeConsigna, " +
                         "NumRojo = @NumRojo " +
                         "Where ClaveAlmacen = @ClaveAlmacen";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteExistencia()
        {
            string sql = "Delete from Inv_CatAlmacenes where ClaveAlmacen = @ClaveAlmacen";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListExistencias()
        {
            SqlDataAdapter dt = null;
            string Sql = "select Ex.ClaveArticulo,Ar.Descripcion,Ex.ClaveAlmacen,Ex.Cantidad,Ex.CantApartada," +
                         "(Ex.Cantidad - Ex.CantApartada) as ExTotal, Ex.stockMin,Ex.stockMax,Ex.CostoPromedio," +
                         "Ex.CostoUltimo,Ex.CostoActual " +
                         "from Inv_Existencias Ex join inv_CatArticulos Ar on Ex.ClaveArticulo = Ar.CveArticulo";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "select Ex.ClaveArticulo,Ar.Descripcion,Ex.ClaveAlmacen,Ex.Cantidad,Ex.CantApartada," +
                        "(Ex.Cantidad - Ex.CantApartada) as ExTotal, Ex.stockMin,Ex.stockMax,Ex.CostoPromedio," +
                        "Ex.CostoUltimo,Ex.CostoActual " +
                        "from Inv_Existencias Ex join inv_CatArticulos Ar on Ex.ClaveArticulo = Ar.CveArticulo";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaExistencia(string articulo,string clavealmacen,string linea)
        {
            SqlDataAdapter dt = null;
            string where;
            int usaAnd = 0;
            if (articulo.Length > 0)
            {
                where = "Ex.ClaveArticulo = '" + articulo + "'";
                usaAnd = 1;
            }


            string sql = "select Ex.ClaveArticulo,Ar.Descripcion,Ex.ClaveAlmacen,Ex.Cantidad,Ex.CantApartada," +
                        "(Ex.Cantidad - Ex.CantApartada) as ExTotal, Ex.stockMin,Ex.stockMax,Ex.CostoPromedio," +
                        "Ex.CostoUltimo,Ex.CostoActual " +
                        "from Inv_Existencias Ex join inv_CatArticulos Ar on Ex.ClaveArticulo = Ar.CveArticulo "+
                        "where ClaveAlmacen = '" + clavealmacen + "' ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public SqlDataAdapter CboInv_CatAlmacenes()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select ClaveAlmacen,Descripcion " +
                         "from Inv_CatAlmacenes where Estatus ='A' ";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
