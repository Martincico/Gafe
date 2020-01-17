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
    class PuiCatCfgDocSerie
    {
        private string CveAlmacen;
        private string CveDoc;
        private string Serie;
        private string Descripcion;
        private string CodFoliador;
        private int EditaFolio;
        private string FmtoImpresion;
        private int NoCopiasImp;
        private string NombImpresora;
        private int PregImpresion;
        private int Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[11, 2];
        private object[,] MatParamK = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatCfgDocSerie(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la CfgDocSerie

        public string keyCveAlmacen
        {
            get { return CveAlmacen; }
            set { CveAlmacen = value; }
        }
        public string keyCveDoc
        {
            get { return CveDoc; }
            set { CveDoc = value; }
        }
        public string keySerie
        {
            get { return Serie; }
            set { Serie = value; }
        }
        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public string cmpCodFoliador
        {
            get { return CodFoliador; }
            set { CodFoliador = value; }
        }
        public int cmpEditaFolio
        {
            get { return EditaFolio; }
            set { EditaFolio = value; }
        }
        public string cmpFmtoImpresion
        {
            get { return FmtoImpresion; }
            set { FmtoImpresion = value; }
        }
        public int cmpNoCopiasImp
        {
            get { return NoCopiasImp; }
            set { NoCopiasImp = value; }
        }
        public string cmpNombImpresora
        {
            get { return NombImpresora; }
            set { NombImpresora = value; }
        }
        public int cmpPregImpresion
        {
            get { return PregImpresion; }
            set { PregImpresion = value; }
        }
        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }


        #endregion

        public int AgregarCfgDocSerie()
        {
            CargaParametroMat();
            RegCatCfgDocSerie OpRadd = new RegCatCfgDocSerie(MatParam, db);
            return OpRadd.AddRegCfgDocSerie();
        }

        public int ActualizaCfgDocSerie()
        {
            CargaParamKey();
            RegCatCfgDocSerie OpUp = new RegCatCfgDocSerie(MatParamK, db);
            return OpUp.UpdateCfgDocSerie();

        }

        public int EliminaCfgDocSerie()
        {
            CargaParamKey();
            RegCatCfgDocSerie OpDel = new RegCatCfgDocSerie(MatParamK, db);
            return OpDel.DeleteCfgDocSerie();
        }

        public SqlDataAdapter ListarCfgDocSeries()
        {
            RegCatCfgDocSerie OpLst = new RegCatCfgDocSerie(db);
            return OpLst.ListCfgDocSeries();
        }

        public void EditarCfgDocSerie()
        {
            CargaParamKey();
            RegCatCfgDocSerie OpEdit = new RegCatCfgDocSerie(MatParamK, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveAlmacen = ObjA[0].ToString();
            CveDoc = ObjA[1].ToString();
            Serie = ObjA[2].ToString();
            Descripcion = ObjA[3].ToString();
            CodFoliador = ObjA[4].ToString();
            EditaFolio = int.Parse(ObjA[5].ToString());
            FmtoImpresion = ObjA[6].ToString();
            NoCopiasImp = int.Parse(ObjA[7].ToString());
            NombImpresora = ObjA[8].ToString();
            PregImpresion = int.Parse(ObjA[9].ToString());
            Estatus = int.Parse(ObjA[10].ToString());
        }

        public SqlDataAdapter BuscaCfgDocSerie(string buscar)
        {
            RegCatCfgDocSerie OpBsq = new RegCatCfgDocSerie(db);
            return OpBsq.BuscaCfgDocSerie(buscar);
        }

        public int AddRegCfgFoliadores()
        {
            MatParam = new object[2, 2];
            MatParam[0, 0] = "CodFoliador"; MatParam[0, 1] = CodFoliador;
            MatParam[1, 0] = "CveAlmacen"; MatParam[1, 1] = CveAlmacen;
            RegCatCfgDocSerie OpRadd = new RegCatCfgDocSerie(MatParam, db);
            return OpRadd.AddRegCfgFoliadores();
        }

        public DataTable CbollenaSeries(string Alm, string MProv)
        {
            RegCatCfgDocSerie OpLst = new RegCatCfgDocSerie(db);
            DataSet Cbo = new DataSet();
            OpLst.cboCfgSeries(Alm, MProv).Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveAlmacen"; MatParam[0, 1] = CveAlmacen;
            MatParam[1, 0] = "CveDoc"; MatParam[1, 1] = CveDoc;
            MatParam[2, 0] = "Serie"; MatParam[2, 1] = Serie;
            MatParam[3, 0] = "Descripcion"; MatParam[3, 1] = Descripcion;
            MatParam[4, 0] = "CodFoliador"; MatParam[4, 1] = CodFoliador;
            MatParam[5, 0] = "EditaFolio"; MatParam[5, 1] = EditaFolio;
            MatParam[6, 0] = "FmtoImpresion"; MatParam[6, 1] = FmtoImpresion;
            MatParam[7, 0] = "NoCopiasImp"; MatParam[7, 1] = NoCopiasImp;
            MatParam[8, 0] = "NombImpresora"; MatParam[8, 1] = NombImpresora;
            MatParam[9, 0] = "PregImpresion"; MatParam[9, 1] = PregImpresion;
            MatParam[10, 0] = "Estatus"; MatParam[10, 1] = Estatus;
        }

        private void CargaParamKey()
        {
            MatParamK[0, 0] = "CveAlmacen"; MatParamK[0, 1] = CveAlmacen;
            MatParamK[1, 0] = "CveDoc"; MatParamK[1, 1] = CveDoc;
            MatParamK[2, 0] = "Serie"; MatParamK[2, 1] = Serie;
        }

    }
}
