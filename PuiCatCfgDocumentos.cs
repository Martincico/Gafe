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
    class PuiCatCfgDocumentos
    {
        private string CveDoc;
        private string Nombre;
        private string CargoAbono;
        private string CveTipoMov;
        private string Foliador;
        private int UsaSerie;
        private int EditaFecha;
        private int UsaCliente;
        private int UsaProveedor;
        private int EsInterno;
        private int SolicitaAutorizar;
        private int AfectaInventario;
        private int Estatus;
        private string DocRel;
        private string txtBotonDocRel;
        private int UsaAlmTmp;
        private int UsaAlmDest;
        private int UsaFactura;


        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[18, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatCfgDocumentos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Linea

        public string keyCveDoc
        {
            get { return CveDoc; }
            set { CveDoc = value; }
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
        public int cmpUsaFactura
        {
            get { return UsaFactura; }
            set { UsaFactura = value; }
        }

        public int cmpEsInterno
        {
            get { return EsInterno; }
            set { EsInterno = value; }
        }

        public int cmpUsaAlmDest
        {
            get { return UsaAlmDest; }
            set { UsaAlmDest = value; }
        }

        public int cmpUsaAlmTmp
        {
            get { return UsaAlmTmp; }
            set { UsaAlmTmp = value; }
        }


        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public int cmpUsaCliente
        {
            get { return UsaCliente; }
            set { UsaCliente = value; }
        }

        public int cmpUsaProvee
        {
            get { return UsaProveedor; }
            set { UsaProveedor = value; }
        }

        public int cmpSolicitaAutorizar
        {
            get { return SolicitaAutorizar; }
            set { SolicitaAutorizar = value; }
        }

        public int cmpAfectaInventario
        {
            get { return AfectaInventario; }
            set { AfectaInventario = value; }
        }

        public String cmpDocRel
        {
            get { return DocRel; }
            set { DocRel = value; }
        }

        public String cmptxtBotonDocRel
        {
            get { return txtBotonDocRel; }
            set { txtBotonDocRel = value; }
        }

        #endregion

        public int AgregarCfgDocumentos()
        {
            CargaParametroMat();
            RegCatCfgDocumentos OpRadd = new RegCatCfgDocumentos(MatParam, db);
            return OpRadd.AddRegCfgDocumentos();
        }

        public int ActualizaCfgDocumentos()
        {
            CargaParametroMat();
            RegCatCfgDocumentos OpUp = new RegCatCfgDocumentos(MatParam, db);
            return OpUp.UpdateCfgDocumentos();

        }

        public int EliminaCfgDocumentos()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveDoc"; MatParam[0, 1] = CveDoc;
            RegCatCfgDocumentos OpDel = new RegCatCfgDocumentos(MatParam, db);
            return OpDel.DeleteCfgDocumentos();
        }

        public SqlDataAdapter ListarCfgDocumentos()
        {
            CargaParametroMat();
            RegCatCfgDocumentos OpLst = new RegCatCfgDocumentos(db);
            return OpLst.ListCfgDocumentos();
        }

        public void EditarCfgDocumentos()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveDoc"; MatParam[0, 1] = CveDoc;
            RegCatCfgDocumentos OpEdit = new RegCatCfgDocumentos(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveDoc = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            CargoAbono = ObjA[2].ToString();
            CveTipoMov = ObjA[3].ToString();
            Foliador = ObjA[4].ToString();
            UsaSerie = int.Parse(ObjA[5].ToString());
            EditaFecha = int.Parse(ObjA[6].ToString());
            UsaCliente = int.Parse(ObjA[7].ToString());
            UsaProveedor = int.Parse(ObjA[8].ToString());
            EsInterno = int.Parse(ObjA[9].ToString());
            SolicitaAutorizar = int.Parse(ObjA[10].ToString());
            AfectaInventario = int.Parse(ObjA[11].ToString());
            Estatus = int.Parse(ObjA[12].ToString());
            DocRel = ObjA[13].ToString();
            txtBotonDocRel = ObjA[14].ToString();
            UsaAlmTmp = int.Parse(ObjA[15].ToString());
            UsaAlmDest = int.Parse(ObjA[16].ToString());
            UsaFactura = int.Parse(ObjA[17].ToString());


        }

        public SqlDataAdapter BuscaCfgDocumentos(string buscar)
        {
            RegCatCfgDocumentos OpBsq = new RegCatCfgDocumentos(db);
            return OpBsq.BuscaCfgDocumentos(buscar);
        }

        public int AddRegCfgFoliadores()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Foliador"; MatParam[0, 1] = Foliador;
            RegCatCfgDocumentos OpRadd = new RegCatCfgDocumentos(MatParam, db);
            return OpRadd.AddRegCfgFoliadores();
        }

        public DataTable cboCfgDocumentos()
        {
            RegCatCfgDocumentos OpLst = new RegCatCfgDocumentos(db);
            DataSet Cbo = new DataSet();
            OpLst.cboCfgDocumentos().Fill(Cbo);
            return Cbo.Tables[0];
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveDoc"; MatParam[0, 1] = CveDoc;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "CargoAbono"; MatParam[2, 1] = CargoAbono;
            MatParam[3, 0] = "CveTipoMov"; MatParam[3, 1] = CveTipoMov;
            MatParam[4, 0] = "Foliador"; MatParam[4, 1] = Foliador;
            MatParam[5, 0] = "UsaSerie"; MatParam[5, 1] = UsaSerie;
            MatParam[6, 0] = "EditaFecha"; MatParam[6, 1] = EditaFecha;
            MatParam[7, 0] = "UsaCliente"; MatParam[7, 1] = UsaCliente;
            MatParam[8, 0] = "UsaProveedor"; MatParam[8, 1] = UsaProveedor;
            MatParam[9, 0] = "EsInterno"; MatParam[9, 1] = EsInterno;
            MatParam[10, 0] = "SolicitaAutorizar"; MatParam[10, 1] = SolicitaAutorizar;
            MatParam[11, 0] = "AfectaInventario"; MatParam[11, 1] = AfectaInventario;
            MatParam[12, 0] = "Estatus"; MatParam[12, 1] = Estatus;
            MatParam[13, 0] = "DocRel"; MatParam[13, 1] = DocRel;
            MatParam[14, 0] = "txtBotonDocRel"; MatParam[14, 1] = txtBotonDocRel;
            MatParam[15, 0] = "UsaAlmTmp"; MatParam[15, 1] = UsaAlmTmp;
            MatParam[16, 0] = "UsaAlmDest"; MatParam[16, 1] = UsaAlmDest;
            MatParam[17, 0] = "UsaFactura"; MatParam[17, 1] = UsaFactura;
        }

    }
}
