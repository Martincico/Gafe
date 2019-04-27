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
    class PuiAddPartidasMovInv
    {
        private String NoMovimiento;
        private int    NoPartida;
        private String CveAlmacenMov;
        private String CveTipoMov;
        private String EntSal;
        private String NoDoc;
        private String Documento;
        private String CveArticulo;
        private String Descripcion;
        private String CveUMedida;
        private Double Cantidad;
        private Double CantidadPkt;
        private Double Precio;
        private Double Descuento;
        private Double TotalDscto;
        private String CveImpuesto;
        private Double TotalIva;
        private Double SubTotal;
        private Double TotalPartida;
        private String FolioDocOrigen;
        private DateTime FechaMovimiento;
        private String NoMovtoTra;
        private String DocTra;
        private String PartTra;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[24, 2];
        private object[,] MatParamKeys = new object[2, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiAddPartidasMovInv(MsSql Odat)
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

        public int keyNoPartida
        {
            get { return NoPartida; }
            set { NoPartida  = value; }
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

        public string cmpCveArticulo
        {
            get { return CveArticulo; }
            set { CveArticulo = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpFolioDocOrigen
        {
            get { return FolioDocOrigen; }
            set { FolioDocOrigen = value; }
        }

        public string cmpCveImpuesto

        {
            get { return CveImpuesto; }
            set { CveImpuesto = value; }
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

        public double cmpTotalIva
        {
            get { return TotalIva; }
            set { TotalIva = value; }
        }

        public double cmpSubTotal
        {
            get { return SubTotal; }
            set { SubTotal = value; }
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

        public string cmpCveUMedida
        {
            get { return CveUMedida; }
            set { CveUMedida = value; }
        }

        public double cmpCantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public double cmpCantidadPkt
        {
            get { return CantidadPkt; }
            set { CantidadPkt = value; }
        }

        public double cmpPrecio
        {
            get { return Precio; }
            set { Precio = value; }
        }

        public double cmpTotalPartida
        {
            get { return TotalPartida; }
            set { TotalPartida = value; }
        }
        public string cmpPartTra
        {
            get { return PartTra; }
            set { PartTra = value; }
        }



        #endregion



        public int AgregarPartida()
        {
            CargaParametroMat();
            RegAddPartidasMovInv OpRadd = new RegAddPartidasMovInv(MatParam,db);
            return OpRadd.AddRegPartida();
        }

        public int ActualizaPartida()
        {
            CargaParametroMat();
            RegAddPartidasMovInv OpUp = new RegAddPartidasMovInv(MatParam,db);
            return OpUp.UpdatePartida();

        }

        public int EliminaPartida()
        {
            CargaParamMatKeys();
            RegAddPartidasMovInv OpDel = new RegAddPartidasMovInv(MatParamKeys,db);
            return OpDel.DeletePartida();
        }

        public SqlDataAdapter ListarPartidas(String NoMov)
        {
            CargaParametroMat();
            RegAddPartidasMovInv OpLst = new RegAddPartidasMovInv(db);
            return OpLst.ListPartidas(NoMov);
        }

        public void EditarPartida()
        {
            CargaParamMatKeys();

            RegAddPartidasMovInv OpEdit = new RegAddPartidasMovInv(MatParamKeys, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            NoMovimiento = ObjA[0].ToString();
            NoPartida = Convert.ToInt32(ObjA[1].ToString());
            CveAlmacenMov = ObjA[2].ToString();
            CveTipoMov = ObjA[3].ToString();
            EntSal = ObjA[4].ToString();
            NoDoc = ObjA[5].ToString();
            Documento = ObjA[6].ToString();
            CveArticulo = ObjA[7].ToString();
            Descripcion = ObjA[8].ToString();
            CveUMedida = ObjA[9].ToString();
            Cantidad = Convert.ToDouble(ObjA[10].ToString());
            CantidadPkt = Convert.ToDouble(ObjA[11].ToString());
            Precio = Convert.ToDouble(ObjA[12].ToString());
            Descuento = Convert.ToDouble(ObjA[13].ToString());
            TotalDscto = Convert.ToDouble(ObjA[14].ToString());
            CveImpuesto = ObjA[15].ToString();
            TotalIva = Convert.ToDouble(ObjA[16].ToString());
            SubTotal = Convert.ToDouble(ObjA[17].ToString());
            TotalPartida = Convert.ToDouble(ObjA[18].ToString());
            FolioDocOrigen = ObjA[19].ToString();
            FechaMovimiento = Convert.ToDateTime(ObjA[20].ToString());
            NoMovtoTra = ObjA[21].ToString();
            DocTra = ObjA[22].ToString();
            PartTra = ObjA[23].ToString();

        }

        public SqlDataAdapter BuscaPartida(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodTipoMov"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegAddPartidasMovInv OpBsq = new RegAddPartidasMovInv(MatParam);/
             */
            RegAddPartidasMovInv OpBsq = new RegAddPartidasMovInv(db);
            return OpBsq.BuscaPartida(buscar);
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "NoMovimiento"; MatParam[0, 1] = NoMovimiento;
            MatParam[1, 0] = "NoPartida"; MatParam[1, 1] = NoPartida;
            MatParam[2, 0] = "CveAlmacenMov"; MatParam[2, 1] = CveAlmacenMov;
            MatParam[3, 0] = "CveTipoMov"; MatParam[3, 1] = CveTipoMov;
            MatParam[4, 0] = "EntSal"; MatParam[4, 1] = EntSal;
            MatParam[5, 0] = "NoDoc"; MatParam[5, 1] = NoDoc;
            MatParam[6, 0] = "Documento"; MatParam[6, 1] = Documento;
            MatParam[7, 0] = "CveArticulo"; MatParam[7, 1] = CveArticulo;
            MatParam[8, 0] = "Descripcion"; MatParam[8, 1] = Descripcion;
            MatParam[9, 0] = "CveUMedida"; MatParam[9, 1] = CveUMedida;
            MatParam[10, 0] = "Cantidad"; MatParam[10, 1] = Cantidad;
            MatParam[11, 0] = "CantidadPkt"; MatParam[11, 1] = CantidadPkt;
            MatParam[12, 0] = "Precio"; MatParam[12, 1] = Precio;
            MatParam[13, 0] = "Descuento"; MatParam[13, 1] = Descuento;
            MatParam[14, 0] = "TotalDscto"; MatParam[14, 1] = TotalDscto;
            MatParam[15, 0] = "CveImpuesto"; MatParam[15, 1] = CveImpuesto;
            MatParam[16, 0] = "TotalIva"; MatParam[16, 1] = TotalIva;
            MatParam[17, 0] = "SubTotal"; MatParam[17, 1] = SubTotal;
            MatParam[18, 0] = "TotalPartida"; MatParam[18, 1] = TotalPartida;
            MatParam[19, 0] = "FolioDocOrigen"; MatParam[19, 1] = FolioDocOrigen;
            MatParam[20, 0] = "FechaMovimiento"; MatParam[20, 1] = FechaMovimiento;
            MatParam[21, 0] = "NoMovtoTra"; MatParam[21, 1] = NoMovtoTra;
            MatParam[22, 0] = "DocTra"; MatParam[22, 1] = DocTra;
            MatParam[23, 0] = "PartTra"; MatParam[23, 1] = PartTra;
        }
        private void CargaParamMatKeys()
        {
            MatParamKeys[0, 0] = "NoMovimiento"; MatParamKeys[0, 1] = NoMovimiento;
            MatParamKeys[1, 0] = "NoPartida"; MatParamKeys[1, 1] = NoPartida;
        }
    }
}
