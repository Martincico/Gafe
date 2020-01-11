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
    class DocPuiRequisiciones
    {
        private string idMov;
        private string idMovNew;
        private string Documento;
        private string Serie;
        private string CveDoc;
        private long NumDoc;
        private string ClaveAlmacen;
        private string CveSucursal;
        private DateTime FechaExpedicion;
        private string ClaveImpuesto;
        private double Impuesto;
        private double TotalIEPS;
        private double TotalRetISR;
        private double TotalRetiVA;
        private double TotalImpOtro;
        private double Descuento;
        private double SubTotal;
        private double Total;
        private string CveProveedor;
        private string NoFactura;
        private string CveCliente;
        private string Observaciones;
        private DateTime FechaModificacion;
        private string UsuarioModi;
        private string UsuarioCaptura;
        private int Estatus;
        private Boolean Autorizado;
        private int EsperaAceptacion;
        private string DocOrigen;

        private List<DocPartidasReq> Partidas;



        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[26, 2];
        private object[,] MatParam2 = new object[3, 2];
        private object[,] MatParTrans = new object[9, 2];

        private SqlDataAdapter Datos;

        private MsSql db = null;


        public DocPuiRequisiciones(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }

        #region Definicion de propiedades de la clase

        public string keyidMov
        {
            get { return idMov; }
            set { idMov = value; }
        }

        public string keyidMovNew
        {
            get { return idMovNew; }
            set { idMovNew = value; }
        }

        public string keyDocumento
        {
            get { return Documento; }
            set { Documento = value; }
        }

        public string cmpSerie
        {
            get { return Serie; }
            set { Serie = value; }
        }

        public long cmpNumDoc
        {
            get { return NumDoc; }
            set { NumDoc = value; }
        }

        public string cmpCveDoc
        {
            get { return CveDoc; }
            set { CveDoc = value; }
        }

        public string cmpCveProveedor
        {
            get { return CveProveedor; }
            set { CveProveedor = value; }
        }
        public string cmpNoFactura
        {
            get { return NoFactura; }
            set { NoFactura = value; }
        }

        public string cmpCveCliente
        {
            get { return CveCliente; }
            set { CveCliente = value; }
        }

        public string cmpClaveAlmacen
        {
            get { return ClaveAlmacen; }
            set { ClaveAlmacen = value; }
        }

        public string cmpCveSucursal
        {
            get { return CveSucursal; }
            set { CveSucursal = value; }
        }

        public DateTime cmpFechaExpedicion
        {
            get { return FechaExpedicion; }
            set { FechaExpedicion = value; }
        }

        public DateTime cmpFechaModificacion
        {
            get { return FechaModificacion; }
            set { FechaModificacion = value; }
        }

        public string cmpClaveImpuesto
        {
            get { return ClaveImpuesto; }
            set { ClaveImpuesto = value; }
        }

        public double cmpImpuesto
        {
            get { return Impuesto; }
            set { Impuesto = value; }
        }


        public double cmpTotalIEPS
        {
            get { return TotalIEPS; }
            set { TotalIEPS = value; }
        }
        public double cmpTotalRetISR
        {
            get { return TotalRetISR; }
            set { TotalRetISR = value; }
        }
        public double cmpTotalRetiVA
        {
            get { return TotalRetiVA; }
            set { TotalRetiVA = value; }
        }
        public double cmpTotalImpOtro
        {
            get { return TotalImpOtro; }
            set { TotalImpOtro = value; }
        }
        public double cmpDescuento
        {
            get { return Descuento; }
            set { Descuento = value; }
        }

        public double cmpSubTotal
        {
            get { return SubTotal; }
            set { SubTotal = value; }
        }

        public double cmpTotal
        {
            get { return Total; }
            set { Total = value; }
        }

        public string cmpObservaciones
        {
            get { return Observaciones; }
            set { Observaciones = value; }
        }

        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public Boolean cmpAutorizado
        {
            get { return Autorizado; }
            set { Autorizado = value; }
        }

        public int cmpEsperaAceptacion
        {
            get { return EsperaAceptacion; }
            set { EsperaAceptacion = value; }
        }

        public List<DocPartidasReq> PartidasDoc
        {
            get { return Partidas; }
            set { Partidas = value; }
        }

        public string cmpDocOrigen
        {
            get { return DocOrigen; }
            set { DocOrigen = value; }
        }

        public string cmpUsuarioCaptura
        {
            get { return UsuarioCaptura; }
            set { UsuarioCaptura = value; }
        }

        public string cmpUsuarioModi
        {
            get { return UsuarioModi; }
            set { UsuarioModi = value; }
        }

        #endregion

        public string AgregarDocEnBlanco(int Foliador, DateTime FechaExp, String User)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            idMov = rRq.getIdMov(Foliador);
            FechaExpedicion = FechaExp;
            UsuarioModi = User;
            rRq = null;
            CargaParametroMat2();
            rRq = new DocRegRequisiciones(MatParam2, db);
            if (rRq.AddRegEnBlanco() > 0)
                return idMov;
            else
                return "Error";

        }

        public void BorrarDocEnBlanco(string idmovto)
        {
            idMov = idmovto;
            //CargaParametroMat2();
            MatParam2 = new object[1, 2];
            MatParam2[0, 0] = "idMov"; MatParam2[0, 1] = idMov;
            DocRegRequisiciones rRq = new DocRegRequisiciones(MatParam2, db);
            rRq.DeleteRegEnBlanco();

        }


        public int GuardarDocumento(int foliador, string _alm,string Doc, string ser, int op)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            string[] fd = rRq.getIdDoc(foliador, _alm, Doc, ser);
            NumDoc = Convert.ToInt64(fd[0]);
            Documento = fd[1];
            rRq = null;
            CargaParametroMat();
            AsignaValPartidas();
            rRq = new DocRegRequisiciones(MatParam, db, Partidas);
            return rRq.SaveDocumento(op);
        }

        public int ActualizaDocumento(int op)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            rRq = null;
            CargaParametroMat();
            AsignaValPartidas();
            rRq = new DocRegRequisiciones(MatParam, db, Partidas);
            return rRq.SaveDocumento(op);
        }


        public void GetDocumento()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            DocRegRequisiciones rRq = new DocRegRequisiciones(MatParam, db);
            Datos = rRq.GetDocumentoSql();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            SetValuesDoc(ObjA);

        }

        public void GetDoc_PorDocOrigen()
        {
            //Se usa para obtener el Documento relacionado y así poder eliminar la Orden de Entrada
            //Viene con los mismos campos de  GetDocumento()
            MatParam = new object[1, 2];
            MatParam[0, 0] = "DocOrigen"; MatParam[0, 1] = DocOrigen;
            DocRegRequisiciones rRq = new DocRegRequisiciones(MatParam, db);
            Datos = rRq.GetDoc_PorDocOrigenSql();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            if (Ds.Tables[0].Rows.Count>0)
            {
                object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

                SetValuesDoc(ObjA);
            }
            else
                keyidMov = "";


        }


        private void SetValuesDoc(object[] ObjA)
        {
            keyidMov = ObjA[0].ToString();
            keyDocumento = ObjA[1].ToString();
            cmpSerie = ObjA[2].ToString();
            cmpNumDoc = long.Parse(ObjA[3].ToString());
            cmpClaveAlmacen = ObjA[4].ToString();
            cmpFechaExpedicion = DateTime.Parse(ObjA[5].ToString());
            cmpClaveImpuesto = ObjA[6].ToString();
            cmpImpuesto = double.Parse(ObjA[7].ToString());
            cmpDescuento = double.Parse(ObjA[8].ToString());
            cmpSubTotal = double.Parse(ObjA[9].ToString());
            cmpTotal = double.Parse(ObjA[10].ToString());
            cmpObservaciones = ObjA[11].ToString();
            cmpEstatus = Convert.ToInt32(ObjA[12].ToString());
            cmpAutorizado = Boolean.Parse(ObjA[13].ToString());
            //14 = Nombre Almacen
            cmpCveProveedor = ObjA[15].ToString();
            cmpCveCliente = ObjA[16].ToString();
            cmpEsperaAceptacion = Convert.ToInt32(ObjA[17].ToString());
            cmpCveSucursal = ObjA[18].ToString();
            cmpNoFactura = ObjA[19].ToString();


            cmpTotalIEPS = double.Parse(ObjA[20].ToString());
            cmpTotalRetISR = double.Parse(ObjA[21].ToString());
            cmpTotalRetiVA = double.Parse(ObjA[22].ToString());
            cmpTotalImpOtro = double.Parse(ObjA[23].ToString());

        }



        public SqlDataAdapter GetDatelleDoc(string doc)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            return rRq.GetDetalleSql(doc);
        }


        private void CargaParametroMat2()
        {
            MatParam2[0, 0] = "idMov"; MatParam2[0, 1] = idMov;
            MatParam2[1, 0] = "FechaExpedicion"; MatParam2[1, 1] = FechaExpedicion;
            MatParam2[2, 0] = "UsuarioModi"; MatParam2[2, 1] = UsuarioModi;

        }

        public SqlDataAdapter ListarDocumentos(String CodAlm, String FIni, String FFin, String Cvedoc, String CvS)
        {
            CargaParametroMat();
            DocRegRequisiciones OpLst = new DocRegRequisiciones(db);
            return OpLst.ListDocumentos(CodAlm, FIni, FFin, Cvedoc, CvS);
        }


        public int EliminaDocumento()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            DocRegRequisiciones OpDel = new DocRegRequisiciones(MatParam, db);
            return OpDel.DeleteDocumento();
        }

        public int DelCeroDocumento()
        {
            MatParam = new object[2, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            MatParam[1, 0] = "UsuarioModi"; MatParam[1, 1] = UsuarioModi;
            DocRegRequisiciones OpDel = new DocRegRequisiciones(MatParam, db);
            return OpDel.DelCeroDocumento();
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            MatParam[1, 0] = "Documento"; MatParam[1, 1] = Documento;
            MatParam[2, 0] = "Serie"; MatParam[2, 1] = Serie;
            MatParam[3, 0] = "CveDoc"; MatParam[3, 1] = CveDoc;
            MatParam[4, 0] = "NumDoc"; MatParam[4, 1] = NumDoc;
            MatParam[5, 0] = "ClaveAlmacen"; MatParam[5, 1] = ClaveAlmacen;
            MatParam[6, 0] = "FechaExpedicion"; MatParam[6, 1] = FechaExpedicion;
            MatParam[7, 0] = "ClaveImpuesto"; MatParam[7, 1] = ClaveImpuesto;
            MatParam[8, 0] = "Impuesto"; MatParam[8, 1] = Impuesto;
            MatParam[9, 0] = "Descuento"; MatParam[9, 1] = Descuento;
            MatParam[10, 0] = "SubTotal"; MatParam[10, 1] = SubTotal;
            MatParam[11, 0] = "Total"; MatParam[11, 1] = Total;
            MatParam[12, 0] = "CveProveedor"; MatParam[12, 1] = CveProveedor;
            MatParam[13, 0] = "CveCliente"; MatParam[13, 1] = CveCliente;
            MatParam[14, 0] = "Observaciones"; MatParam[14, 1] = Observaciones;
            MatParam[15, 0] = "FechaModificacion"; MatParam[15, 1] = FechaModificacion;
            MatParam[16, 0] = "Estatus"; MatParam[16, 1] = Estatus;
            MatParam[17, 0] = "Autorizado"; MatParam[17, 1] = Autorizado;
            MatParam[18, 0] = "EsperaAceptacion"; MatParam[18, 1] = EsperaAceptacion;
            MatParam[19, 0] = "CveSucursal"; MatParam[19, 1] = CveSucursal;
            MatParam[20, 0] = "UsuarioModi"; MatParam[20, 1] = UsuarioModi;
            MatParam[21, 0] = "NoFactura"; MatParam[21, 1] = NoFactura;
            MatParam[22, 0] = "TotalIEPS"; MatParam[22, 1] = TotalIEPS;
            MatParam[23, 0] = "TotalRetISR"; MatParam[23, 1] = TotalRetISR;
            MatParam[24, 0] = "TotalRetiVA"; MatParam[24, 1] = TotalRetiVA;
            MatParam[25, 0] = "TotalImpOtro"; MatParam[25, 1] = TotalImpOtro;

            
        }


        private void AsignaValPartidas()
        {
           for(int j = 0; j < Partidas.Count; j++)
            {
                Partidas[j].idMov = idMov;
                Partidas[j].Documento = Documento;
                Partidas[j].Serie = Serie;
                Partidas[j].Numdoc = NumDoc;             
            }
        }

        public int GuardarDocTransf(int foliador, string _alm, string Doc, string ser, int EspAcep)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            string[] fd = rRq.getIdDoc(foliador, _alm, Doc, ser);
            NumDoc = Convert.ToInt64(fd[0]);
            Documento = fd[1];
            CargaParametroTranfs();
            rRq = null;
            rRq = new DocRegRequisiciones(MatParTrans, db);
            return rRq.SaveDocTransf(EspAcep);
        }

        private void CargaParametroTranfs()
        {
            MatParTrans[0, 0] = "idMov"; MatParTrans[0, 1] = idMov;
            MatParTrans[1, 0] = "idMovNew"; MatParTrans[1, 1] = idMovNew;
            MatParTrans[2, 0] = "Documento"; MatParTrans[2, 1] = Documento;
            MatParTrans[3, 0] = "Serie"; MatParTrans[3, 1] = Serie;
            MatParTrans[4, 0] = "CveDoc"; MatParTrans[4, 1] = CveDoc;
            MatParTrans[5, 0] = "NumDoc"; MatParTrans[5, 1] = NumDoc;
            MatParTrans[6, 0] = "DocOrigen"; MatParTrans[6, 1] = DocOrigen;
            MatParTrans[7, 0] = "ClaveAlmacen"; MatParTrans[7, 1] = ClaveAlmacen;
            MatParTrans[8, 0] = "UsuarioModi"; MatParTrans[8, 1] = UsuarioModi;

        }

        public DataTable DocCabPrint()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            DocRegRequisiciones OpLst = new DocRegRequisiciones(MatParam,db);
            DataSet Cbo = new DataSet();
            OpLst.SqlDocCabPrint().Fill(Cbo);
            return Cbo.Tables[0];
        }

        public DataTable DocDetPrint()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            DocRegRequisiciones OpLst = new DocRegRequisiciones(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.SqlDocDetPrint().Fill(Cbo);
            return Cbo.Tables[0];
        }
    } 
}
