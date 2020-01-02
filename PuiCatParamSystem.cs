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
    class PuiCatParamSystem
    {
        private string CodParametro;
        private string Descripcion;
        private string ModUsa;
        private string Valor;


        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatParamSystem(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la ParamSystem

        public string keyCodParametro
        {
            get { return CodParametro; }
            set { CodParametro = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpModUsa
        {
            get { return ModUsa; }
            set { ModUsa = value; }
        }

        public string cmpValor
        {
            get { return Valor; }
            set { Valor = value; }
        }


        #endregion

        public int AgregarParamSystem()
        {
            CargaParametroMat();
            RegCatParamSystem OpRadd = new RegCatParamSystem(MatParam, db);
            return OpRadd.AddRegParamSystem();
        }

        public int ActualizaParamSystem()
        {
            CargaParametroMat();
            RegCatParamSystem OpUp = new RegCatParamSystem(MatParam, db);
            return OpUp.UpdateParamSystem();

        }

        public int EliminaParamSystem()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodParametro"; MatParam[0, 1] = CodParametro;
            RegCatParamSystem OpDel = new RegCatParamSystem(MatParam, db);
            return OpDel.DeleteParamSystem();
        }

        public SqlDataAdapter ListarParamSystems()
        {
            CargaParametroMat();
            RegCatParamSystem OpLst = new RegCatParamSystem(db);
            return OpLst.ListParamSystems();
        }

        public void EditarParamSystem()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodParametro"; MatParam[0, 1] = CodParametro;
            RegCatParamSystem OpEdit = new RegCatParamSystem(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CodParametro = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            ModUsa = ObjA[2].ToString();
            Valor = ObjA[3].ToString();

        }

        public SqlDataAdapter BuscaParamSystem(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodParamSystem"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatParamSystem OpBsq = new RegCatParamSystem(MatParam);/
             */
            RegCatParamSystem OpBsq = new RegCatParamSystem(db);
            return OpBsq.BuscaParamSystem(buscar);
        }

        public Object[] GetHora()
        {
            RegCatParamSystem OpEdit = new RegCatParamSystem(db);
            Datos = OpEdit.GetHora();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);

            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            return ObjA;


        }

        public DataTable CboParamSystem()
        {
            CargaParametroMat();
            RegCatParamSystem OpLst = new RegCatParamSystem(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboParamSystem().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CodParametro"; MatParam[0, 1] = CodParametro;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "ModUsa"; MatParam[2, 1] = ModUsa;
            MatParam[3, 0] = "Valor"; MatParam[3, 1] = Valor;
        }

    }
}
