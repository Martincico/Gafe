using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DatSql;

namespace GAFE
{
    class PuiCatKardex
    {
        private object[,] MatParam = new object[2, 2];

        //private SqlDataAdapter Datos;

        private String CveArticulo;
        private String CveAlmacenMov;
 

        #region Definicion de propiedades de la Articulo

        public string keyCveArticulo
        {
            get { return CveArticulo; }
            set { CveArticulo = value; }
        }
        public String cmpCveAlmacenMov
        {
            get { return CveAlmacenMov; }
            set { CveAlmacenMov = value; }
        }
        #endregion

        private MsSql db = null;


        public PuiCatKardex(MsSql Odat)
        {
            db = Odat;
        }

        public DataTable verKardex()
        {
            CargaParametroMat();
            RegCatKardex OpLst = new RegCatKardex(MatParam, db);
            DataSet Ds = new DataSet();
            OpLst.Kardex().Fill(Ds);
            return Ds.Tables[0];
        }
        private void CargaParametroMat()
        {

            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            MatParam[1, 0] = "CveAlmacenMov"; MatParam[1, 1] = CveAlmacenMov;

        }
    }
}
