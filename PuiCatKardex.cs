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
        private object[,] MatParam = new object[3, 2];
        //private object[,] MatParam = new object[26, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

        public PuiCatKardex(MsSql Odat)
        {
            db = Odat;
        }

        public SqlDataAdapter verKardex()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            return OpLst.ListArticulos();
        }
        private void CargaParametroMat()
        {

            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = 1;
            MatParam[1, 0] = "CodigoAlterno"; MatParam[1, 1] = 2;            
        }
        }
    }
