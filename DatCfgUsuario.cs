using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatSql;
using System.Data.SqlClient;

namespace GAFE
{
    public class DatCfgUsuario
    {
        public String Usuario;
        public String Nombre;
        public String Password;
        public String CodPerfil;
        public String AlmacenUsa;
        public int CambiaAlmacen;
        public int Alm_EsDeCompra;
        public int Alm_EsDeVenta;
        public int Alm_EsDeConsigna;
        public int Alm_NumRojo;
        public String Fondo;
        public String StiloTema;
        public DateTime FecServer;
        public String SucursalUsa;


        public String NoSessiones;
        public String CambiarSerie;

        private MsSql db = null;

        public DatCfgUsuario(string usuario, MsSql db)
        {
            Usuario = usuario;
            this.db = db;
        }

        public DatCfgUsuario()
        {
        }

        public DatCfgUsuario CfgUsario()
        {
            DatCfgUsuario Doc = new DatCfgUsuario();
            string Sql = " SELECT Usr.Usuario, Usr.Nombre,Usr.Password,Usr.CodPerfil,UsrCfg.CveAlmacen, " +
                         "        UsrCfg.CambiaAlmacen, Alm.EsDeCompra,Alm.EsDeVenta,Alm.EsDeConsigna,Alm.NumRojo, " +
                         "        UsrCfg.Fondo,UsrCfg.StiloTema,CONVERT (date, GETDATE()) as FecServer, Alm.CveSucursal " +
                         " FROM dbo.SUsuarios AS Usr " +
                         " INNER JOIN SUsuarioConf AS UsrCfg ON UsrCfg.CveUsuario = Usr.Usuario " +
                         " INNER JOIN Inv_CatAlmacenes AS Alm ON UsrCfg.CveAlmacen = Alm.ClaveAlmacen " +
                         " WHERE Usr.Usuario = '"+ Usuario + "'";
            SqlDataReader dr = db.SelectDR(Sql);
            while (dr.Read())
            {
                Doc.Usuario = Convert.ToString(dr["Usuario"]);
                Doc.Nombre = Convert.ToString(dr["Nombre"]);
                Doc.Password = Convert.ToString(dr["Password"]);
                Doc.CodPerfil = Convert.ToString(dr["CodPerfil"]);
                Doc.AlmacenUsa = Convert.ToString(dr["CveAlmacen"]);
                Doc.CambiaAlmacen = Convert.ToInt32(dr["CambiaAlmacen"]);
                Doc.Alm_EsDeCompra = Convert.ToInt32(dr["EsDeCompra"]);
                Doc.Alm_EsDeVenta = Convert.ToInt32(dr["EsDeVenta"]);
                Doc.Alm_EsDeConsigna = Convert.ToInt32(dr["EsDeConsigna"]);
                Doc.Alm_NumRojo = Convert.ToInt32(dr["NumRojo"]);
                Doc.Fondo = Convert.ToString(dr["Fondo"]);
                Doc.StiloTema = Convert.ToString(dr["StiloTema"]);
                Doc.FecServer = Convert.ToDateTime(dr["FecServer"]);
                Doc.SucursalUsa = Convert.ToString(dr["CveSucursal"]);

            }
            dr.Close();
            return Doc;

        }


    }
}
