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
    class PuiCatInv_ClaseMov
    {
        private string CveClsMov;
        private string Descripcion;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatInv_ClaseMov(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Linea

        public string keyCveClsMov
        {
            get { return CveClsMov; }
            set { CveClsMov = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        

        #endregion

        public int AgregarInv_ClaseMov()
        {
            CargaParametroMat();
            RegCatInv_ClaseMov OpRadd = new RegCatInv_ClaseMov(MatParam, db);
            return OpRadd.AddRegInv_ClaseMov();
        }

        public int ActualizaInv_ClaseMov()
        {
            CargaParametroMat();
            RegCatInv_ClaseMov OpUp = new RegCatInv_ClaseMov(MatParam, db);
            return OpUp.UpdateInv_ClaseMov();

        }

        public int EliminaInv_ClaseMov()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveClsMov"; MatParam[0, 1] = CveClsMov;
            RegCatInv_ClaseMov OpDel = new RegCatInv_ClaseMov(MatParam, db);
            return OpDel.DeleteInv_ClaseMov();
        }

        public SqlDataAdapter ListarInv_ClaseMov()
        {
            CargaParametroMat();
            RegCatInv_ClaseMov OpLst = new RegCatInv_ClaseMov(db);
            return OpLst.ListInv_ClaseMov();
        }

        public void EditarInv_ClaseMov()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveClsMov"; MatParam[0, 1] = CveClsMov;
            RegCatInv_ClaseMov OpEdit = new RegCatInv_ClaseMov(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveClsMov = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();

        }

        public SqlDataAdapter BuscaInv_ClaseMov(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodLinea"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatInv_ClaseMov OpBsq = new RegCatInv_ClaseMov(MatParam);/
             */
            RegCatInv_ClaseMov OpBsq = new RegCatInv_ClaseMov(db);
            return OpBsq.BuscaInv_ClaseMov(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveClsMov"; MatParam[0, 1] = CveClsMov;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
        }

        public DataTable CboInv_ClaseMov()
        {
            RegCatInv_ClaseMov OpLst = new RegCatInv_ClaseMov(db);
            DataSet Cbo = new DataSet();
            OpLst.CboInv_ClaseMov().Fill(Cbo);
            return Cbo.Tables[0];
        }
    }
}
