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
        private string Documento;
        private string Serie;
        private long NumDoc;
        private string ClaveAlmacen;
        private DateTime FechaExpedicion;
        private string ClaveImpuesto;
        private double Impuesto;
        private double Descuento;
        private double SubTotal;
        private double Total;
        private string Observaciones;
        private string Estatus;
        private string Autorizado;
        private int Cancelado;

        private List<DocPartidasReq> Partidas;



        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[15, 2];
        private object[,] MatParam2 = new object[2, 2];
       
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

        public string cmpClaveAlmacen
        {
            get { return ClaveAlmacen; }
            set { ClaveAlmacen = value; }
        }

        public DateTime cmpFechaExpedicion
        {
            get { return FechaExpedicion; }
            set { FechaExpedicion = value; }
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

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public string cmpAutorizado
        {
            get { return Autorizado; }
            set { Autorizado = value; }
        }

        public int cmpCancelado
        {
            get { return Cancelado; }
            set { Cancelado = value; }
        }

        public List<DocPartidasReq> PartidasDoc
        {
            get { return Partidas; }
            set { Partidas = value; }
        }

        #endregion

        public string AgregarDocEnBlanco(int Foliador, DateTime FechaExp)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            idMov = rRq.getIdMov(Foliador);
            FechaExpedicion = FechaExp;
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


        public int GuardarDocumento(int foliador, string _alm,string Doc, int op)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            string[] fd = rRq.getIdDoc(foliador, _alm, Doc);
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
            cmpEstatus = ObjA[12].ToString();
            cmpAutorizado = ObjA[13].ToString();
            cmpCancelado= int.Parse(ObjA[14].ToString());
            
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
        }

        public SqlDataAdapter ListarDocumentos(String CodAlm, String FIni, String FFin)
        {
            CargaParametroMat();
            DocRegRequisiciones OpLst = new DocRegRequisiciones(db);
            return OpLst.ListDocumentos(CodAlm, FIni, FFin);
        }


        public int EliminaDocumento()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            DocRegRequisiciones OpDel = new DocRegRequisiciones(MatParam, db);
            return OpDel.DeleteDocumento();
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "idMov"; MatParam[0, 1] = idMov;
            MatParam[1, 0] = "Documento"; MatParam[1, 1] = Documento;
            MatParam[2, 0] = "Serie"; MatParam[2, 1] = Serie;
            MatParam[3, 0] = "NumDoc"; MatParam[3, 1] = NumDoc;
            MatParam[4, 0] = "ClaveAlmacen"; MatParam[4, 1] = ClaveAlmacen;
            MatParam[5, 0] = "FechaExpedicion"; MatParam[5, 1] = FechaExpedicion;
            MatParam[6, 0] = "ClaveImpuesto"; MatParam[6, 1] = ClaveImpuesto;
            MatParam[7, 0] = "Impuesto"; MatParam[7, 1] = Impuesto;
            MatParam[8, 0] = "Descuento"; MatParam[8, 1] = Descuento;
            MatParam[9, 0] = "SubTotal"; MatParam[9, 1] = SubTotal;
            MatParam[10, 0] = "Total"; MatParam[10, 1] = Total;
            MatParam[11, 0] = "Observaciones"; MatParam[11, 1] = Observaciones;
            MatParam[12, 0] = "Estatus"; MatParam[12, 1] = Estatus;
            MatParam[13, 0] = "Autorizado"; MatParam[13, 1] = Autorizado;
            MatParam[14, 0] = "Cancelado"; MatParam[14, 1] = Cancelado;
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

    } 
}
