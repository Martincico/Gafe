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
    class PuiCatCfgTipoMovProv
    {
        private string ClaveDoc;
        private string Nombre;
        private string CargoAbono;
        private string CveTipoMov;
        private string Foliador;
        private int UsaSerie;
        private int EditaFecha;
        private int EsInterno;
        private int Estatus;


        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[9, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatCfgTipoMovProv(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Linea

        public string keyClaveDoc
        {
            get { return ClaveDoc; }
            set { ClaveDoc = value; }
        }

        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string cmpCargoAbono
        {
            get { return CargoAbono; }
            set { CargoAbono = value; }
        }

        public String cmpCveTipoMov
        {
            get { return CveTipoMov; }
            set { CveTipoMov = value; }
        }

        public String cmpFoliador
        {
            get { return Foliador; }
            set { Foliador = value; }
        }

        public int cmpUsaSerie
        {
            get { return UsaSerie; }
            set { UsaSerie = value; }
        }

        public int cmpEditaFecha
        {
            get { return EditaFecha; }
            set { EditaFecha = value; }
        }

        public int cmpEsInterno
        {
            get { return EsInterno; }
            set { EsInterno = value; }
        }

        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }


        #endregion

        public int AgregarTipoMovProv()
        {
            CargaParametroMat();
            RegCatCfgTipoMovProv OpRadd = new RegCatCfgTipoMovProv(MatParam, db);
            return OpRadd.AddRegTipoMovProv();
        }

        public int ActualizaTipoMovProv()
        {
            CargaParametroMat();
            RegCatCfgTipoMovProv OpUp = new RegCatCfgTipoMovProv(MatParam, db);
            return OpUp.UpdateTipoMovProv();

        }

        public int EliminaTipoMovProv()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "ClaveDoc"; MatParam[0, 1] = ClaveDoc;
            RegCatCfgTipoMovProv OpDel = new RegCatCfgTipoMovProv(MatParam, db);
            return OpDel.DeleteTipoMovProv();
        }

        public SqlDataAdapter ListarTipoMovProvs()
        {
            CargaParametroMat();
            RegCatCfgTipoMovProv OpLst = new RegCatCfgTipoMovProv(db);
            return OpLst.ListTipoMovProvs();
        }

        public void EditarTipoMovProv()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "ClaveDoc"; MatParam[0, 1] = ClaveDoc;
            RegCatCfgTipoMovProv OpEdit = new RegCatCfgTipoMovProv(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            ClaveDoc = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            CargoAbono = ObjA[2].ToString();
            CveTipoMov = ObjA[3].ToString();
            Foliador = ObjA[4].ToString();
            UsaSerie = int.Parse(ObjA[5].ToString());
            EditaFecha = int.Parse(ObjA[6].ToString());
            EsInterno = int.Parse(ObjA[7].ToString());
            Estatus = int.Parse(ObjA[8].ToString());


        }

        public SqlDataAdapter BuscaTipoMovProv(string buscar)
        {
            RegCatCfgTipoMovProv OpBsq = new RegCatCfgTipoMovProv(db);
            return OpBsq.BuscaTipoMovProv(buscar);
        }

        public int AddRegCfgFoliadores()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Foliador"; MatParam[0, 1] = Foliador;
            RegCatCfgTipoMovProv OpRadd = new RegCatCfgTipoMovProv(MatParam, db);
            return OpRadd.AddRegCfgFoliadores();
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "ClaveDoc"; MatParam[0, 1] = ClaveDoc;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "CargoAbono"; MatParam[2, 1] = CargoAbono;
            MatParam[3, 0] = "CveTipoMov"; MatParam[3, 1] = CveTipoMov;
            MatParam[4, 0] = "Foliador"; MatParam[4, 1] = Foliador;
            MatParam[5, 0] = "UsaSerie"; MatParam[5, 1] = UsaSerie;
            MatParam[6, 0] = "EditaFecha"; MatParam[6, 1] = EditaFecha;
            MatParam[7, 0] = "EsInterno"; MatParam[7, 1] = EsInterno;
            MatParam[8, 0] = "Estatus"; MatParam[8, 1] = Estatus;
        }

    }
}
