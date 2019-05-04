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
    class PuiExistencias
    {
        private string ClaveArticulo;
        private string ClaveAlmacen;        
        private double Cantidad;
        private double stockMin;
        private double stockMax;
        private double CantApartada;
        private double CostoPromedio;
        private double CostoUltimo;
        private double CostoActual;
        private string Ubicacion;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[10, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiExistencias(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyClaveArticulo
        {
            get { return ClaveArticulo; }
            set { ClaveArticulo = value; }
        }

        public string keyClaveAlmacen
        {
            get { return ClaveAlmacen; }
            set { ClaveAlmacen = value; }
        }

        public double cmpCantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public double cmpstockMin
        {
            get { return stockMin; }
            set { stockMin = value; }
        }

        public double cmpstockMax
        {
            get { return stockMax; }
            set { stockMax = value; }
        }

        public double cmpCantApartada
        {
            get { return CantApartada; }
            set { CantApartada = value; }
        }

        public double cmpCostoPromedio
        {
            get { return CostoPromedio; }
            set { CostoPromedio = value; }
        }

        public double cmpCostoUltimo
        {
            get { return CostoUltimo; }
            set { CostoUltimo = value; }
        }

        public double cmpCostoActual
        {
            get { return CostoActual; }
            set { CostoActual = value; }
        }

        public string cmpUbicacion
        {
            get { return Ubicacion; }
            set { Ubicacion = value; }
        }


        #endregion

        
        public int AgregarExistencia()
        {
            CargaParametroMat();
            RegExistencias OpRadd = new RegExistencias(MatParam,db);
            return OpRadd.AddRegExistencia();
        }
        

        public int ActualizaExistencia()
        {
            CargaParametroMat();
            RegExistencias OpUp = new RegExistencias(MatParam,db);
            return OpUp.UpdateExistencia();

        }

        public int EliminaExistencia()
        {
            //CargaParametroMat();
            MatParam = new object[2, 2];
            MatParam[0, 0] = "ClaveArticulo"; MatParam[0, 1] = ClaveArticulo;
            MatParam[1, 0] = "ClaveAlmacen"; MatParam[1, 1] = ClaveAlmacen;

            RegExistencias OpDel = new RegExistencias(MatParam,db);
            return OpDel.DeleteExistencia();
        }


        public int AsignaPorAlmacen()
        {
            MatParam = new object[5, 2];
            MatParam[0, 0] = "ClaveArticulo"; MatParam[0, 1] = ClaveArticulo;
            MatParam[1, 0] = "ClaveAlmacen";  MatParam[1, 1] = ClaveAlmacen;
            MatParam[2, 0] = "Ubicacion";     MatParam[2, 1] = Ubicacion;
            MatParam[3, 0] = "stockMin";      MatParam[3, 1] = stockMin;
            MatParam[4, 0] = "stockMax";      MatParam[4, 1] = stockMax;

            RegExistencias OpUp = new RegExistencias(MatParam, db);
            return OpUp.UpdateAsignaPorAlmacen();
        }

        public SqlDataAdapter ListarExistencias()
        {
            CargaParametroMat();
            RegExistencias OpLst = new RegExistencias(db);
            return OpLst.ListExistencias();
        }

        public void EditarExistencia()
        {
            MatParam = new object[2, 2];
            MatParam[0, 0] = "ClaveArticulo"; MatParam[0, 1] = ClaveArticulo;
            MatParam[1, 0] = "ClaveAlmacen"; MatParam[1, 1] = ClaveAlmacen;
            RegExistencias OpEdit = new RegExistencias(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            ClaveArticulo   = ObjA[0].ToString();
            ClaveAlmacen    = ObjA[1].ToString();
            Cantidad        = Convert.ToDouble(ObjA[2]);
            stockMin        = Convert.ToDouble(ObjA[3]);
            stockMax        = Convert.ToDouble(ObjA[4]);
            CantApartada    = Convert.ToDouble(ObjA[5]);
            CostoPromedio   = Convert.ToDouble(ObjA[6]);
            CostoUltimo     = Convert.ToDouble(ObjA[7]);
            CostoActual     = Convert.ToDouble(ObjA[8]);
            Ubicacion       = ObjA[9].ToString();
        }

        public SqlDataAdapter BuscaExistencia(string Articulo,string Almacen,string linea)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodAlmacen"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegExistencias OpBsq = new RegExistencias(MatParam);/
             */
            RegExistencias OpBsq = new RegExistencias(db);
            return OpBsq.BuscaExistencia(Articulo,Almacen,linea);
        }

        public DataTable CboInv_CatAlmacenes()
        {
            RegExistencias OpLst = new RegExistencias(db);
            DataSet Cbo = new DataSet();
            OpLst.CboInv_CatAlmacenes().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "ClaveArticulo";   MatParam[0, 1] = ClaveArticulo;
            MatParam[1, 0] = "ClaveAlmacen";    MatParam[1, 1] = ClaveAlmacen;
            MatParam[2, 0] = "Cantidad";        MatParam[2, 1] = Cantidad;
            MatParam[3, 0] = "stockMin";        MatParam[3, 1] = stockMin;
            MatParam[4, 0] = "stockMax";        MatParam[4, 1] = stockMax;
            MatParam[5, 0] = "CantApartada";    MatParam[5, 1] = CantApartada;
            MatParam[6, 0] = "CostoPromedio";   MatParam[6, 1] = CostoPromedio;
            MatParam[7, 0] = "CostoUltimo";     MatParam[7, 1] = CostoUltimo;
            MatParam[8, 0] = "CostoActual";     MatParam[8, 1] = CostoActual;
            MatParam[9, 0] = "Ubicaion";        MatParam[9, 1] = Ubicacion;
        }
    }
}
