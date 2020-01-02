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
    class PuiCatCfgCatFoliadores
    {
        private string CveFoliador;
        private string CveModulo;
        private string Descripcion;        
        private string Uso;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatCfgCatFoliadores(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyCveFoliador
        {
            get { return CveFoliador; }
            set { CveFoliador = value; }
        }

        public string cmpCveModulo
        {
            get { return CveModulo; }
            set { CveModulo = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpUso
        {
            get { return Uso; }
            set { Uso = value; }
        }


        #endregion

        public int AgregarClase()
        {
            CargaParametroMat();
            RegCatCfgCatFoliador OpRadd = new RegCatCfgCatFoliador(MatParam,db);
            return OpRadd.AddRegCfgCatFoliador();
        }

        public int ActualizaCfgCatFoliador()
        {
            CargaParametroMat();
            RegCatCfgCatFoliador OpUp = new RegCatCfgCatFoliador(MatParam,db);
            return OpUp.UpdateCfgCatFoliador();

        }

        public int EliminaCfgCatFoliador()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveFoliador"; MatParam[0, 1] = CveFoliador;
            RegCatCfgCatFoliador OpDel = new RegCatCfgCatFoliador(MatParam,db);
            return OpDel.DeleteCfgCatFoliador();
        }

        public SqlDataAdapter ListarCfgCatFoliadores()
        {
            CargaParametroMat();
            RegCatCfgCatFoliador OpLst = new RegCatCfgCatFoliador(db);
            return OpLst.ListCfgCatFoliadores();
        }

        public void EditarCfgCatFoliador()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveFoliador"; MatParam[0, 1] = CveFoliador;
            RegCatCfgCatFoliador OpEdit = new RegCatCfgCatFoliador(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveFoliador = ObjA[0].ToString();
            CveModulo = ObjA[1].ToString();
            Descripcion = ObjA[2].ToString();
            Uso = ObjA[3].ToString();


        }

        public SqlDataAdapter BuscaClase(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodClase"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatCfgCatFoliador OpBsq = new RegCatCfgCatFoliador(MatParam);/
             */
            RegCatCfgCatFoliador OpBsq = new RegCatCfgCatFoliador(db);
            return OpBsq.BuscaCfgCatFoliador(buscar);
        }
        public DataTable CboCfgModuloSys()
        {
            RegCatCfgCatFoliador OpLst = new RegCatCfgCatFoliador(db);
            DataSet Cbo = new DataSet();
            OpLst.CboCfgModuloSys().Fill(Cbo);
            return Cbo.Tables[0];

        }

        public DataTable cboCfgCatFoliadores(int _EnUso)
        {
            RegCatCfgCatFoliador OpLst = new RegCatCfgCatFoliador(db);
            DataSet Cbo = new DataSet();
            OpLst.cboCfgCatFoliadores(_EnUso).Fill(Cbo);
            return Cbo.Tables[0];

        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveFoliador"; MatParam[0, 1] = CveFoliador;
            MatParam[1, 0] = "CveModulo"; MatParam[1, 1] = CveModulo;
            MatParam[2, 0] = "Descripcion"; MatParam[2, 1] = Descripcion;
            MatParam[3, 0] = "Uso"; MatParam[3, 1] = Uso;
        }
    }
}
