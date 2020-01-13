﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DatSql;

namespace GAFE
{
    class MovtosInvPui
    {
        private string NoMovimiento;
        private DateTime FechaMovimiento;
        private string CveAlmacenMov;
        private string CveTipoMov;
        private string EntSal;
        private string NoDoc;
        private string Documento;
        private string CveAlmacenDes;
        private string CveTipoMovDest;
        private string EntSalDest;
        private string CveSucursal;
        private string Modulo;
        private string TipoDoc;
        private string SerieDoc;
        private string FolioDocOrigen;
        private double Descuento;
        private double TotalDscto;
        private double TIva;
        private double TotalIEPS;
        private double TotalRetISR;
        private double TotalRetiVA;
        private double TotalImpOtro;
        private double SubTotal;
        private double TotalDoc;
        private string CveProveedor;
        private string CveCliente;
        private int Cancelado;
        private string CveUsarioCaptu;
        private string CveCentroCosto;
        private string NoMovtoTra;
        private string DocTra;
        private string DocOrigen;
        private string Observacion;

        //Se usa en consultar
        private string CveClaseTipoMov;

        //Parametros de Almance
        private int EsDeCompra;
        private int EsDeVenta;
        private int EsDeConsigna;
        private int NumRojo;


        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[27, 2];
        private object[,] MatParamParti = new object[6, 2];
        private object[,] MatParamAlma = new object[5, 2];

        
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public MovtosInvPui(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la TipoMov

        public string keyNoMovimiento
        {
            get { return NoMovimiento; }
            set { NoMovimiento = value; }
        }

        public DateTime cmpFechaMovimiento
        {
            get { return FechaMovimiento; }
            set { FechaMovimiento = value; }
        }

        public string cmpCveAlmacenMov
        {
            get { return CveAlmacenMov; }
            set { CveAlmacenMov = value; }
        }

        public string cmpObservacion
        {
            get { return Observacion; }
            set { Observacion = value; }
        }
        public string cmpCveClaseTipoMov
        {
            get { return CveClaseTipoMov; }
            set { CveClaseTipoMov = value; }
        }

        public string cmpCveTipoMov
        {
            get { return CveTipoMov; }
            set { CveTipoMov = value; }
        }

        public string cmpEntSal
        {
            get { return EntSal; }
            set { EntSal = value; }
        }
        public string cmpCveSucursal
        {
            get { return CveSucursal; }
            set { CveSucursal = value; }
        }

        public string cmpNoDoc
        {
            get { return NoDoc; }
            set { NoDoc = value; }
        }

        public string cmpDocumento
        {
            get { return Documento; }
            set { Documento = value; }
        }

        public string cmpCveAlmacenDes
        {
            get { return CveAlmacenDes; }
            set { CveAlmacenDes = value; }
        }

        public string cmpCveTipoMovDest
        {
            get { return CveTipoMovDest; }
            set { CveTipoMovDest = value; }
        }

        public string cmpEntSalDest
        {
            get { return EntSalDest; }
            set { EntSalDest = value; }
        }

        public string cmpModulo
        {
            get { return Modulo; }
            set { Modulo = value; }
        }

        public string cmpTipoDoc
        {
            get { return TipoDoc; }
            set { TipoDoc = value; }
        }

        public string cmpSerieDoc
        {
            get { return SerieDoc; }
            set { SerieDoc = value; }
        }

        public string cmpFolioDocOrigen
        {
            get { return FolioDocOrigen; }
            set { FolioDocOrigen = value; }
        }

        public double cmpDescuento
        {
            get { return Descuento; }
            set { Descuento = value; }
        }

        public double cmpTotalDscto
        {
            get { return TotalDscto; }
            set { TotalDscto = value; }
        }

        public double cmpTIva
        {
            get { return TIva; }
            set { TIva = value; }
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

        public double cmpSubTotal
        {
            get { return SubTotal; }
            set { SubTotal = value; }
        }

        public double cmpTotalDoc
        {
            get { return TotalDoc; }
            set { TotalDoc = value; }
        }

        public string cmpCveProveedor
        {
            get { return CveProveedor; }
            set { CveProveedor = value; }
        }

        public string cmpCveCliente
        {
            get { return CveCliente; }
            set { CveCliente = value; }
        }

        public int cmpCancelado
        {
            get { return Cancelado; }
            set { Cancelado = value; }
        }

        public string cmpCveUsarioCaptu
        {
            get { return CveUsarioCaptu; }
            set { CveUsarioCaptu = value; }
        }

        public string cmpCveCentroCosto
        {
            get { return CveCentroCosto; }
            set { CveCentroCosto = value; }
        }

        public string cmpNoMovtoTra
        {
            get { return NoMovtoTra; }
            set { NoMovtoTra = value; }
        }

        public string cmpDocTra
        {
            get { return DocTra; }
            set { DocTra = value; }
        }

        public string cmpDocOrigen
        {
            get { return DocOrigen; }
            set { DocOrigen = value; }
        }
        public int cmpEsDeCompra
        {
            get { return EsDeCompra; }
            set { EsDeCompra = value; }
        }
        public int cmpEsDeVenta
        {
            get { return EsDeVenta; }
            set { EsDeVenta = value; }
        }
        public int cmpEsDeConsigna
        {
            get { return EsDeConsigna; }
            set { EsDeConsigna = value; }
        }
        public int cmpNumRojo
        {
            get { return NumRojo; }
            set { NumRojo = value; }
        }
        #endregion

        public string AgregarBlanco(int Foliador, DateTime FechaExp)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            NoMovimiento = rRq.getIdMov(Foliador);
            FechaMovimiento = FechaExp;
            rRq = null;

            object[,] MatParam2 = new object[2, 2];
            MatParam2[0, 0] = "NoMovimiento"; MatParam2[0, 1] = NoMovimiento;
            MatParam2[1, 0] = "FechaMovimiento"; MatParam2[1, 1] = FechaMovimiento;
            MovtosInvReg OpRadd2 = new MovtosInvReg(MatParam2, db);
            if (OpRadd2.AddRegBlanco() > 0)
                return NoMovimiento;
            else
                return "Error";

        }

        public int AgregarInvMaster(int foliador, string Doc, int op, String DcOrigen)
        {
            DocRegRequisiciones rRq = new DocRegRequisiciones(db);
            string[] fd = rRq.getIdDoc(foliador, "", Doc,"");
            NoDoc = fd[0].ToString();
            Documento = fd[1];
            rRq = null;

            CargaParametroMat();
            MovtosInvReg OpRadd = new MovtosInvReg(MatParam, db);
            return OpRadd.AddRegInvMaster(DcOrigen);
        }

        public int AgregarInvDet()
        {
            CargaParamMatPart();
            MovtosInvReg OpRadd = new MovtosInvReg(MatParamParti, db);
            return OpRadd.UpdateInvDet();
        }

        public int EliminaInventarioMov()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpDel = new MovtosInvReg(MatParam, db);
            return OpDel.DeleteInventarioMov();
        }

        public int DelRegCerosSql()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpDel = new MovtosInvReg(MatParam, db);
            return OpDel.DelRegCerosSql();
        }


        public SqlDataAdapter ListarInventarioMovtos(String CodProve, String CodAlm, String CodTipoMov, String FIni, String FFin)
        {
            CargaParametroMat();
            MovtosInvReg OpLst = new MovtosInvReg(db);
            return OpLst.ListInventarioMovtos( CodProve,  CodAlm,  CodTipoMov, FIni, FFin);
        }

        public int AfectaCostos(String _CveTipoMov,int Op)
        {
            int rtn = -1;
            object[,] MatParAfec = new object[2, 2];
            MatParAfec[0, 0] = "NoMovimiento"; MatParAfec[0, 1] = NoMovimiento;
            MatParAfec[1, 0] = "ClaveAlmacen"; MatParAfec[1, 1] = CveAlmacenMov;
            MovtosInvReg Afe = new MovtosInvReg(MatParAfec, db);

            SqlDataAdapter DatosTbl = Afe.RegistroActivoDetalle(NoMovimiento); //CveArticulo,Descripcion,CveUMedida,Cantidad,CantidadPkt,Costo,Precio
            DataSet ds = new DataSet();
            DatosTbl.Fill(ds);
            int cpa = ds.Tables[0].Rows.Count;
            for (int j = 0; j < cpa;  j++)
            {
                object[] row = ds.Tables[0].Rows[j].ItemArray;
                rtn = Afe.AfectaCostosSql(_CveTipoMov, Op, row[0].ToString(), row[3].ToString(), row[6].ToString());
                if (rtn < 0)
                    return -1;
            }

            return rtn;
        }

        public int AfectaExistencias( String _EntSal, int Op)
        {
            object[,] MatParAfec = new object[2, 2];
            MatParAfec[0, 0] = "NoMovimiento"; MatParAfec[0, 1] = NoMovimiento;
            MatParAfec[1, 0] = "ClaveAlmacen"; MatParAfec[1, 1] = CveAlmacenMov;
            MovtosInvReg Afe = new MovtosInvReg(MatParAfec, db);
            return Afe.AfectaExistenciasSql(_EntSal, Op);
        }


        public void EditarInventarioMov()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpEdit = new MovtosInvReg(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            NoMovimiento = ObjA[0].ToString();
            FechaMovimiento = Convert.ToDateTime(ObjA[1].ToString());
            CveAlmacenMov = ObjA[2].ToString();
            CveTipoMov = ObjA[3].ToString();
            EntSal = ObjA[4].ToString();
            NoDoc = ObjA[5].ToString();
            Documento = ObjA[6].ToString();
            CveAlmacenDes = ObjA[7].ToString();
            CveTipoMovDest = ObjA[8].ToString();
            EntSalDest = ObjA[9].ToString();
            Modulo = ObjA[10].ToString();
            TipoDoc = ObjA[11].ToString();
            SerieDoc = ObjA[12].ToString();
            FolioDocOrigen = ObjA[13].ToString();
            Descuento = Convert.ToDouble(ObjA[14].ToString());
            TotalDscto = Convert.ToDouble(ObjA[15].ToString());
            TIva = Convert.ToDouble(ObjA[16].ToString());
            SubTotal = Convert.ToDouble(ObjA[17].ToString());
            TotalDoc = Convert.ToDouble(ObjA[18].ToString());
            CveProveedor = ObjA[19].ToString();
            CveCliente = ObjA[20].ToString();
            Cancelado = Convert.ToInt32(ObjA[21].ToString());
            CveUsarioCaptu = ObjA[22].ToString();
            CveCentroCosto = ObjA[23].ToString();
            NoMovtoTra = ObjA[24].ToString();
            DocTra = ObjA[25].ToString();
            CveClaseTipoMov = ObjA[26].ToString();
            CveSucursal = ObjA[27].ToString();



        }

        public void GetParamAlma()
        {
            CargaParamMatAlma();

            MovtosInvReg OpEdit = new MovtosInvReg(MatParamAlma, db);
            Datos = OpEdit.GetParamAlma();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            CveTipoMov = ObjA[0].ToString();
            EsDeCompra = Convert.ToInt32(ObjA[0].ToString());
            EsDeVenta = Convert.ToInt32(ObjA[1].ToString());
            EsDeConsigna = Convert.ToInt32(ObjA[2].ToString());
            NumRojo = Convert.ToInt32(ObjA[3].ToString());

        }

        public int AddPartMigraDoc()
        {
            object[,] MatParam2 = new object[2, 2];
            MatParam2[0, 0] = "NoMovimiento"; MatParam2[0, 1] = NoMovimiento;
            MatParam2[1, 0] = "IdDoc"; MatParam2[1, 1] = DocOrigen;
            MovtosInvReg OpRadd2 = new MovtosInvReg(MatParam2, db);
            int rsp = OpRadd2.AddPartMigraDoc();
            return rsp;
        }


        public void GetIdMov()
        { //Obtenemos el IdMov y TipoMov de acuerdo al DocOrigen
            MatParam = new object[1, 2];
            MatParam[0, 0] = "DocOrigen"; MatParam[0, 1] = DocOrigen;
            MovtosInvReg OpEdit = new MovtosInvReg(MatParam, db);
            Datos = OpEdit.GetIdMov();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            NoMovimiento = ObjA[0].ToString();
            CveTipoMov = ObjA[1].ToString();


        }

        public void GetRegMovTraspaso()
        {//Obtenemos el IdMov del registro del Traspaso
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpEdit = new MovtosInvReg(MatParam, db);
            Datos = OpEdit.GetRegMovTraspaso();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            NoMovimiento = ObjA[0].ToString();
        }




        private void CargaParametroMat()
        {
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MatParam[1, 0] = "CveAlmacenMov"; MatParam[1, 1] = CveAlmacenMov;
            MatParam[2, 0] = "CveTipoMov"; MatParam[2, 1] = CveTipoMov;
            MatParam[3, 0] = "EntSal"; MatParam[3, 1] = EntSal;
            MatParam[4, 0] = "NoDoc"; MatParam[4, 1] = NoDoc;
            MatParam[5, 0] = "Modulo"; MatParam[5, 1] = Modulo;
            MatParam[6, 0] = "Descuento"; MatParam[6, 1] = Descuento;
            MatParam[7, 0] = "TotalDscto"; MatParam[7, 1] = TotalDscto;
            MatParam[8, 0] = "TIva"; MatParam[8, 1] = TIva;
            MatParam[9, 0] = "SubTotal"; MatParam[9, 1] = SubTotal;
            MatParam[10, 0] = "TotalDoc"; MatParam[10, 1] = TotalDoc;
            MatParam[11, 0] = "CveProveedor"; MatParam[11, 1] = CveProveedor;
            MatParam[12, 0] = "Cancelado"; MatParam[12, 1] = Cancelado;
            MatParam[13, 0] = "Documento"; MatParam[13, 1] = Documento;
            MatParam[14, 0] = "CveUsarioCaptu"; MatParam[14, 1] = CveUsarioCaptu;
            MatParam[15, 0] = "CveTipoMovDest"; MatParam[15, 1] = CveTipoMovDest;
            MatParam[16, 0] = "EntSalDest"; MatParam[16, 1] = EntSalDest;
            MatParam[17, 0] = "CveAlmacenDes"; MatParam[17, 1] = CveAlmacenDes;
            MatParam[18, 0] = "NoMovtoTra"; MatParam[18, 1] = NoMovtoTra;
            MatParam[19, 0] = "DocTra"; MatParam[19, 1] = DocTra;
            MatParam[20, 0] = "DocOrigen"; MatParam[20, 1] = DocOrigen;
            MatParam[21, 0] = "CveSucursal"; MatParam[21, 1] = CveSucursal;
            MatParam[22, 0] = "TotalIEPS"; MatParam[22, 1] = TotalIEPS;
            MatParam[23, 0] = "TotalRetISR"; MatParam[23, 1] = TotalRetISR;
            MatParam[24, 0] = "TotalRetiVA"; MatParam[24, 1] = TotalRetiVA;
            MatParam[25, 0] = "TotalImpOtro"; MatParam[25, 1] = TotalImpOtro;
            MatParam[26, 0] = "Observacion"; MatParam[26, 1] = Observacion;

        }
        private void CargaParamMatPart()
        {

            MatParamParti[0, 0] = "NoMovimiento"; MatParamParti[0, 1] = NoMovimiento;
            MatParamParti[1, 0] = "CveAlmacenMov"; MatParamParti[1, 1] = CveAlmacenMov;
            MatParamParti[2, 0] = "CveTipoMov"; MatParamParti[2, 1] = CveTipoMov;
            MatParamParti[3, 0] = "EntSal"; MatParamParti[3, 1] = EntSal;
            MatParamParti[4, 0] = "NoDoc"; MatParamParti[4, 1] = NoDoc;
            MatParamParti[5, 0] = "Documento"; MatParamParti[5, 1] = Documento;
        }

        private void CargaParamMatAlma()
        {
            MatParamAlma[0, 0] = "ClaveAlmacen"; MatParamAlma[0, 1] = CveAlmacenMov;
            MatParamAlma[1, 0] = "EsDeCompra"; MatParamAlma[1, 1] = EsDeCompra;
            MatParamAlma[2, 0] = "EsDeVenta"; MatParamAlma[2, 1] = EsDeVenta;
            MatParamAlma[3, 0] = "EsDeConsigna"; MatParamAlma[3, 1] = EsDeConsigna;
            MatParamAlma[4, 0] = "NumRojo"; MatParamAlma[4, 1] = NumRojo;
        }

        public DataTable MovInvDetallePrint()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpLst = new MovtosInvReg(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.SqlMovInvDetPrint().Fill(Cbo);
            return Cbo.Tables[0];
        }
        /*
        public DataTable MovInvMasterPrint()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MovtosInvReg OpLst = new MovtosInvReg(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.SqlMovInvMastPrint().Fill(Cbo);
            return Cbo.Tables[0];
        }
        */

    }
}
