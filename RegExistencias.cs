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
                MessageBoxAdv.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public int UpdateAsignaPorAlmacen()
        {
            string sql = "Update Inv_Existencias set Ubicacion = @Ubicacion, " +
                         "stockMin = @stockMin, " +
                         "stockMax = @stockMax " +
                         "Where ClaveAlmacen = @ClaveAlmacen and " +
                          "ClaveArticulo = @ClaveArticulo";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteExistencia()
        {
            string sql = "Delete from Inv_CatAlmacenes where ClaveAlmacen = @ClaveAlmacen";
            return db.UpdateRegistro(sql, ArrParametros);
        }



        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "select Ex.ClaveArticulo,Ar.Descripcion,Ln.Descripcion,Ex.ClaveAlmacen,Ex.Cantidad,Ex.CantApartada," +
                        "        (Ex.Cantidad - Ex.CantApartada) as ExTotal, Ex.stockMin,Ex.stockMax,Ex.CostoPromedio," +
                        "        Ex.CostoUltimo,Ex.CostoActual,Ex.Ubicacion " +
                        " from Inv_Existencias Ex join inv_CatArticulos Ar on Ex.ClaveArticulo = Ar.CveArticulo " +
                        " join Inv_Lineas Ln on Ar.CveLinea = Ln.CveLinea " +
                        " WHERE Ar.Estatus = 1";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }


        public SqlDataAdapter BuscaExistencia(string articulo,string clavealmacen,string linea, string buscar, int OmiteExis0)
        {
            SqlDataAdapter dt = null;
            string where="";
            if (articulo.Length > 0)
                where += " AND Ex.ClaveArticulo = '" + articulo + "' ";

            if (clavealmacen.Length > 0)
                where += " AND Ex.ClaveAlmacen = '" + clavealmacen + "' ";

            if (linea.Length > 0)
                where += " AND Ln.CveLinea = '" + linea + "' ";

            if (buscar.Length > 0)
                where += " AND (Ex.ClaveArticulo like '%" + buscar + "%' OR Ar.Descripcion like '%"+buscar+"%' )";

            where += OmiteExis0 == 0 ? "" : " AND Ex.Cantidad > 0 ";

            string sql = "select Ex.ClaveArticulo as Clave,Ar.CodigoBarra as 'Cód. Barra' ,Ar.Descripcion as 'Artículo',Ln.Descripcion as 'Línea',Alm.Descripcion as 'Almacén',Ex.Cantidad,Ex.CantApartada AS 'Cant. Apartada'," +
                        "        (Ex.Cantidad - Ex.CantApartada) as 'Existencia', Ex.stockMin as 'Stock mín.',Ex.stockMax as 'Stock max.',Ex.CostoPromedio AS 'Costo Prom.'," +
                        "        Ex.CostoUltimo as 'Coston últ.',Ex.CostoActual as 'Costo Actual',Ex.Ubicacion as 'Ubicación' " +
                        " from Inv_Existencias Ex " +
                        " join inv_CatArticulos Ar on Ex.ClaveArticulo = Ar.CveArticulo " +
                        " join Inv_Lineas Ln on Ar.CveLinea = Ln.CveLinea " +
                        " join Inv_CatAlmacenes Alm on Ex.ClaveAlmacen = Alm.ClaveAlmacen " +
                        " WHERE Ar.Estatus = 1 " + where;
                       

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
