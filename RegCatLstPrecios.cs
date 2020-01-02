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
    class RegCatLstPrecios
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatLstPrecios(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatLstPrecios(MsSql Odat) { db = Odat; }

        public int AddRegLstPrecios()
        {           
            string sql = "Insert into Inv_LstPreciosMast (CveLstPrecio,Nombre, EsDeVenta, EsDeCosto ,Estatus) " +
                         "values(@CveLstPrecio,@Nombre, @EsDeVenta, @EsDeCosto ,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int AddLstPreciosDet()
        {
            string sql = " INSERT INTO Inv_LstPreciosDet (CveLstPrecio, CveArticulo, Precio,Porcentaje,CostoUltimo, FechaModifacion) " +
                        "                        (SELECT @CveLstPrecio, CveArticulo, 0,0,0, GETDATE() " +
                        "                         FROM inv_CatArticulos WHERE Estatus = 1) ";
            return db.InsertarRegistro(sql, ArrParametros);
        }

        public int UpdateLstPrecios()
        {
            string sql = "Update Inv_LstPreciosMast set Nombre = @Nombre, " +
                        "EsDeVenta = @EsDeVenta, " +
                        "EsDeCosto = @EsDeCosto, " +
                        "Estatus = @Estatus " +
                         "Where CveLstPrecio = @CveLstPrecio";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteLstPrecios()
        {
            /*
            string sql = "Delete from Inv_LstPreciosMast where CveLstPrecio = @CveLstPrecio";
            return db.UpdateRegistro(sql, ArrParametros);
            */
            string sql = "Update Inv_LstPreciosMast set Estatus = 0 " +
                         "Where CveLstPrecio = @CveLstPrecio";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListLstPrecios()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLstPrecio,Nombre " +
                         "from Inv_LstPreciosMast WHERE Estatus = 1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLstPrecio,Nombre, EsDeVenta, EsDeCosto ,Estatus " +
                          "from Inv_LstPreciosMast where CveLstPrecio = @CveLstPrecio AND Estatus = 1";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaLstPrecios(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveLstPrecio,Nombre, EsDeVenta, EsDeCosto ,Estatus " +
               "from Inv_LstPreciosMast " +
               "where Estatus = 1 AND ( CveLstPrecio like '%" + bsq + "%' OR " +
               "Nombre like '%" + bsq + "%' )";

            dt = db.SelectDA(sql);
            return dt;
        }
/*
        public SqlDataAdapter ListadoPrecioArticulo()
        {
            SqlDataAdapter dt = null;
            string Sql = " SELECT LstPD.CveArticulo AS 'Articulo',Art.Descripcion,LstPD.CostoUltimo , LstPD.Porcentaje, LstPD.Precio " +
                         " FROM Inv_LstPreciosMast AS LstPM " +
                         " INNER JOIN Inv_LstPreciosDet AS LstPD ON LstPD.CveLstPrecio = LstPM.CveLstPrecio " +
                         " INNER JOIN inv_CatArticulos AS A ON A.CveArticulo = LstPD.CveArticulo " +
                         " WHERE LstPM.Estatus = 1 " +
                         "   AND A.Estatus = 1 " +
                         "   AND LstpD.CveArticulo  = @CveArticulo";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

    */
        public SqlDataAdapter GetPrecioArticulo()
        {//Se usa el GET PRECIO en la pantalla de VENTA
            SqlDataAdapter dt = null;
            string Sql = " SELECT LstPM.CveLstPrecio,LstPM.Nombre, LstPM.EsDeVenta, LstPM.EsDeCosto, LstPD.Precio " +
                         " FROM Inv_LstPreciosMast AS LstPM " +
                         " INNER JOIN Inv_LstPreciosDet AS LstPD ON LstPD.CveLstPrecio = LstPM.CveLstPrecio " +
                         " INNER JOIN inv_CatArticulos AS A ON A.CveArticulo = LstPD.CveArticulo " +
                         " WHERE LstPM.Estatus = 1 " +
                         "   AND A.Estatus = 1 " +
                         "   AND LstpD.CveArticulo  = @CveArticulo AND LstPM.CveLstPrecio = @CveLstPrecio ";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter LLenaCboLstPrecio()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLstPrecio as Clave,Nombre as Descripcion " +
                         "from Inv_LstPreciosMast where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter LstArticulo_LstPrecio(String CveLstPrecio, String txtArt, int OnlyCod)
        {    //Llena grid en la pantalla de VIEW lst precios para poder actualizar
            //Llena grid de Articulos en la pestaña de Listado de precio
            String Wh = "";
            txtArt = txtArt.Trim();


            if(!CveLstPrecio.Equals(""))
            {
                Wh = " AND LstpD.CveLstPrecio  = '"+CveLstPrecio +"'";
            }

            if(!txtArt.Equals(""))
            {
                if(OnlyCod == 0)
                    Wh += " AND (LstPD.CveArticulo LIKE '%" + txtArt + "%' OR Art.Descripcion LIKE '%" + txtArt + "%')";
                else
                    Wh += " AND LstPD.CveArticulo  = '" + txtArt + "'";
            }

            SqlDataAdapter dt = null;
            string Sql = " SELECT TOP 800 LstPD.CveArticulo, LstPM.Nombre,Art.Descripcion,LstPD.CostoUltimo , LstPD.Porcentaje, LstPD.Precio, " +
                         "    LstPD.CveLstPrecio " +
                         " FROM Inv_LstPreciosDet AS LstPD " +
                         " INNER JOIN Inv_LstPreciosMast AS LstPM ON LstPD.CveLstPrecio = LstPM.CveLstPrecio " +
                         " INNER JOIN inv_CatArticulos AS Art ON LstPD.CveArticulo = Art.CveArticulo " +
                         " WHERE Art.Estatus = 1 " + Wh+
                         " ORDER BY Art.Descripcion";

            dt = db.SelectDA(Sql);
            return dt;
        }

        public int UpdLstPrecio_Art()
        {
            string sql = "Update Inv_LstPreciosDet set Precio = @Precio, Porcentaje = @Porcentaje, " +
                         "       FechaModifacion = (CONVERT(DATETIME, @FechaModifacion) + CONVERT(DATETIME, CONVERT(time, GETDATE())))" +
                         " Where CveLstPrecio = @CveLstPrecio " +
                         "   AND   CveArticulo  = @CveArticulo";
            return db.DeleteRegistro(sql, ArrParametros);
        }

    }
}
