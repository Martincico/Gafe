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
        private Double ImpuestoValor;
        private Double TotalIva;
        private Double SubTotal;
        private Double TotalPartida;
        private String FolioDocOrigen;
        private DateTime FechaMovimiento;
        private String NoMovtoTra;
        private String DocTra;
        private String PartTra;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[25, 2];
        private object[,] MatParamKeys = new object[2, 2];
        private object[,] MatParamInvExis = new object[9, 2];
        private SqlDataAdapter Datos;


        /* Informacion de Inventarios */
        private String inv_ClaveAlmacen;
        private double inv_Cantidad;
        private double inv_stockMin;
        private double inv_stockMax;
        private double inv_CantApartada;
        private double inv_CostoPromedio;
        private double inv_CostoUltimo;
        private double inv_CostoActual;



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

        public double cmpImpuestoValor
        {
            get { return ImpuestoValor; }
            set { ImpuestoValor = value; }
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

        public string cmpinv_ClaveAlmacen
        {
            get { return inv_ClaveAlmacen; }
            set { inv_ClaveAlmacen = value; }
        }
        public double cmpinv_Cantidad
        {
            get { return inv_Cantidad; }
            set { inv_Cantidad = value; }
        }
        public double cmpinv_stockMin
        {
            get { return inv_stockMin; }
            set { inv_stockMin = value; }
        }
        public double cmpinv_stockMax
        {

            get{return inv_stockMax;}
            set{inv_stockMax = value; }
        }
        public double cmpinv_CantApartada
        {
            get { return inv_CantApartada; }
            set { inv_CantApartada = value; }
        }
        public double cmpinv_CostoPromedio
        {
            get { return inv_CostoPromedio; }
            set { inv_CostoPromedio = value; }
        }
        public double cmpinv_CostoUltimo
        {
            get { return inv_CostoUltimo; }
            set { inv_CostoUltimo = value; }
        }
        public double cmpinv_CostoActual
        {
            get { return inv_CostoActual; }
            set { inv_CostoActual = value; }
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
            RegAddPartidasMovInv OpUp = new RegAddPartidasMovInv(MatParam, db);
            return OpUp.UpdatePartida();

        }

        public int EliminaPartida()
        {
            int dv = 1;
            RegAddPartidasMovInv OpDel = null;
            CargaParamMatKeys();
            OpDel = new RegAddPartidasMovInv(MatParamKeys, db);
            dv = OpDel.DeletePartida();
            OpDel = new RegAddPartidasMovInv(MatParamKeys, db);
            if (dv >= 1)
            {
                Datos = OpDel.ListPartidas();
                DataSet Ds = new DataSet();
                Datos.Fill(Ds);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    object[,] MatParam2 = new object[3, 2];

                    for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                    {
                        object[] ObjA = Ds.Tables[0].Rows[j].ItemArray;
                        MatParam2[0, 0] = "NoMovimiento"; MatParam2[0, 1] = keyNoMovimiento;
                        MatParam2[1, 0] = "PartAnt"; MatParam2[1, 1] = Convert.ToInt32(ObjA[1].ToString());
                        MatParam2[2, 0] = "PartNew"; MatParam2[2, 1] = j + 1;
                        OpDel = new RegAddPartidasMovInv(MatParam2, db);
                        dv = OpDel.UpdateIdxPart();
                        if (dv < 0)
                            break;
                    }
                }
            }
            return dv;
        }

        public int GetFolioPart(String NoMov)
        {
            RegAddPartidasMovInv OpRadd = new RegAddPartidasMovInv(db);
            return OpRadd.GetFolioPart(NoMov);
        }
        public SqlDataAdapter ListarPartidas()
        {
            CargaParamMatKeys();
            RegAddPartidasMovInv OpLst = new RegAddPartidasMovInv(MatParamKeys,db);
            return OpLst.ListPartidas();
        }

        public int MovParttoAlma()
        {
            MatParamKeys[0, 0] = "NoMovimiento"; MatParamKeys[0, 1] = NoMovimiento;
            MatParamKeys[1, 0] = "NoMovtoTra"; MatParamKeys[1, 1] = NoMovtoTra;

            RegAddPartidasMovInv OpEdit = new RegAddPartidasMovInv(MatParamKeys,db);
            return OpEdit.MovParttoAlmaSql();
        }

        public int GetDuplicado()
        {
            CargaParamMatKeys();

            RegAddPartidasMovInv OpEdit = new RegAddPartidasMovInv(MatParamKeys, db);
            Datos = OpEdit.GetDuplicadoSql();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            int i = Ds.Tables[0].Rows.Count;
            if(i>=1)
            {
                object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
                NoPartida = Convert.ToInt32(ObjA[1].ToString());
            }

            return i;
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
            ImpuestoValor = Convert.ToDouble(ObjA[16].ToString());
            TotalIva = Convert.ToDouble(ObjA[17].ToString());
            SubTotal = Convert.ToDouble(ObjA[18].ToString());
            TotalPartida = Convert.ToDouble(ObjA[19].ToString());
            FolioDocOrigen = ObjA[20].ToString();
            FechaMovimiento = Convert.ToDateTime(ObjA[21].ToString());
            NoMovtoTra = ObjA[22].ToString();
            DocTra = ObjA[23].ToString();
            PartTra = ObjA[24].ToString();

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
            MatParam[24, 0] = "ImpuestoValor"; MatParam[24, 1] = ImpuestoValor;
        }

        private void CargaParamMatKeys()
        {
            MatParamKeys[0, 0] = "NoMovimiento"; MatParamKeys[0, 1] = NoMovimiento;
            MatParamKeys[1, 0] = "NoPartida"; MatParamKeys[1, 1] = NoPartida;
        }

        private void CargaParamInnExist()
        {
            MatParamInvExis[0, 0] = "CveArticulo"; MatParamInvExis[0, 1] = CveArticulo;
            MatParamInvExis[1, 0] = "CveAlmacen"; MatParamInvExis[1, 1] = inv_ClaveAlmacen;
            MatParamInvExis[2, 0] = "Cantidad"; MatParamInvExis[2, 1] = inv_Cantidad;
            MatParamInvExis[3, 0] = "stockMin"; MatParamInvExis[3, 1] = inv_stockMin;
            MatParamInvExis[4, 0] = "stockMax"; MatParamInvExis[4, 1] = inv_stockMax;
            MatParamInvExis[5, 0] = "CantApartada"; MatParamInvExis[5, 1] = inv_CantApartada;
            MatParamInvExis[6, 0] = "CostoPromedio"; MatParamInvExis[6, 1] = inv_CostoPromedio;
            MatParamInvExis[7, 0] = "CostoUltimo"; MatParamInvExis[7, 1] = inv_CostoUltimo;
            MatParamInvExis[8, 0] = "CostoActual"; MatParamInvExis[8, 1] = inv_CostoActual;
        }


        public void BuscaPrecio(String PModLlama)
        {
            CargaParamInnExist();

            RegAddPartidasMovInv OpEdit = new RegAddPartidasMovInv(MatParamInvExis, db);
            Datos = OpEdit.BusPrecio(PModLlama);
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            inv_ClaveAlmacen = ObjA[0].ToString();
            inv_Cantidad = Convert.ToDouble(ObjA[2].ToString().Equals("")?"0": ObjA[2].ToString());
            inv_stockMin = Convert.ToDouble(ObjA[3].ToString().Equals("") ? "0" : ObjA[3].ToString());
            inv_stockMax = Convert.ToDouble(ObjA[4].ToString().Equals("") ? "0" : ObjA[4].ToString());
            inv_CantApartada = Convert.ToDouble(ObjA[5].ToString().Equals("") ? "0" : ObjA[5].ToString());
            inv_CostoPromedio = Convert.ToDouble(ObjA[6].ToString().Equals("") ? "0" : ObjA[6].ToString());
            inv_CostoUltimo = Convert.ToDouble(ObjA[7].ToString().Equals("") ? "0" : ObjA[7].ToString());
            inv_CostoActual = Convert.ToDouble(ObjA[8].ToString().Equals("") ? "0" : ObjA[8].ToString());
        }


    }
}
