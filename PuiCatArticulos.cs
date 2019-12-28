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
    class PuiCatArticulos
    {
        private String CveArticulo;
        private String CodigoAlterno;
        private String CodigoBarra;
        private String CodigoSat;
        private DateTime Fecha_Alta;
        private String Descripcion;
        private String CveAlmacen;
        private int EsInventa;
        private int DispVenta;
        private int EsServicio;
        private int DispKit;
        private int EsKit;
        private int RequiereReceta;
        private string FecUltCompra;
        private String CveProveedorUlt;
        private Byte[] Foto;
        private String Observacion;
        private int Estatus;

        public string CveLinea;
        public string CveImpuesto;
        public string CveImpIEPS;
        public string CveImpRetIVA;
        public string CveImpRetISR;
        public string CveImpOtro;
        public string CveMarca;
        public string CveClase1;
        public string CveClase2;
        public string CveClase3;
        public string CveUMedida1;
        public string CveUMedida2;
        public string CveUMedidaEquiv;




        //public PuiCatProveedor Proveedor;
        private String Modelo;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[28, 2];
        //private object[,] MatParam = new object[26, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatArticulos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Articulo

        public string keyCveArticulo
        {
            get { return CveArticulo; }
            set { CveArticulo = value; }
        }
        public String cmpCodigoAlterno
        {
            get { return CodigoAlterno; }
            set { CodigoAlterno = value; }
        }
        public String cmpCodigoBarra
        {
            get { return CodigoBarra; }
            set { CodigoBarra = value; }
        }
        public String cmpCodigoSat
        {
            get { return CodigoSat; }
            set { CodigoSat = value; }
        }
        public String cmpCveAlmacen
        {
            get { return CveAlmacen; }
            set { CveAlmacen = value; }
        }
        

        public DateTime cmpFecha_Alta
        {
            get { return Fecha_Alta; }
            set { Fecha_Alta = value; }
        }
        public String cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public String cmpModelo
        {
            get { return Modelo; }
            set { Modelo = value; }
        }

        public String cmpCveLinea
        {
            get { return CveLinea; }
            set { CveLinea = value; }
        }

        public String cmpCveImpuesto
        {
            get { return CveImpuesto; }
            set { CveImpuesto = value; }
        }

        public String cmpCveImpIEPS
        {
            get { return CveImpIEPS; }
            set { CveImpIEPS = value; }
        }

        public String cmpCveImpRetIVA
        {
            get { return CveImpRetIVA; }
            set { CveImpRetIVA = value; }
        }
        public String cmpCveImpRetISR
        {
            get { return CveImpRetISR; }
            set { CveImpRetISR = value; }
        }

        public String cmpCveImpOtro
        {
            get { return CveImpOtro; }
            set { CveImpOtro = value; }
        }

        public String cmpCveMarca
        {
            get { return CveMarca; }
            set { CveMarca = value; }
        }

        public String cmpCveClase1
        {
            get { return CveClase1; }
            set { CveClase1 = value; }
        }
        public String cmpCveClase2
        {
            get { return CveClase2; }
            set { CveClase2 = value; }
        }
        public String cmpCveClase3
        {
            get { return CveClase3; }
            set { CveClase3 = value; }
        }

        public String cmpCveUMedida1
        {
            get { return CveUMedida1; }
            set { CveUMedida1 = value; }
        }
        public String cmpCveUMedida2
        {
            get { return CveUMedida2; }
            set { CveUMedida2 = value; }
        }

        public String cmpCveUMedidaEquiv
        {
            get { return CveUMedidaEquiv; }
            set { CveUMedidaEquiv = value; }
        }


        public int cmpRequiereReceta
        {
            get { return RequiereReceta; }
            set { RequiereReceta = value; }
        }

        public Boolean cmpEsInventa
        {   
            get
            {
                if (EsInventa == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsInventa = 1;
                else
                    EsInventa = 0;
            }
        }
        public Boolean cmpDispVenta
        {
            
            get
            {
                if (DispVenta == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    DispVenta = 1;
                else
                    DispVenta = 0;
            }
        }
        public Boolean cmpEsServicio
        {
            get
            {
                if (EsServicio == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsServicio = 1;
                else
                    EsServicio = 0;
            }
        }
        public Boolean cmpDispKit
        {   
            get
            {
                if (DispKit == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    DispKit = 1;
                else
                    DispKit = 0;
            }
        }
        public Boolean cmpEsKit
        {
            get
            {
                if (EsKit == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsKit = 1;
                else
                    EsKit = 0;
            }
        }


        public String cmpFecUltCompra
        {
            get { return FecUltCompra; }
            set { FecUltCompra = value; }
        }
        public String cmpCveProveedorUlt
        {
            get { return CveProveedorUlt; }
            set { CveProveedorUlt = value; }
        }
        public Byte[] cmpFoto
        {
            get { return Foto; }
            set { Foto = value; }
        }
        public String cmpObservacion
        {
            get { return Observacion; }
            set { Observacion = value; }
        }
        public Boolean cmpEstatus
        {
            get { if (Estatus == 1)
                    return true;
                else
                    return false;
            }
            set { if(value)
                    Estatus=1;
                  else
                    Estatus = 0;
            }
        }





        #endregion

        public int AgregarArticulo()
        {
            int resp = 0;
            CargaParametroMat();
            RegCatArticulo OpRadd = new RegCatArticulo(MatParam, db);
            resp = OpRadd.AddRegArticulo();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "ClaveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpRaddExis = new RegCatArticulo(MatParam, db);
            resp = OpRaddExis.AddRegExistencias();
            return resp;
        }

        public int AddArticulo_LstPrecio()
        {
            int resp = 0;
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpRaddExis = new RegCatArticulo(MatParam, db);
            resp = OpRaddExis.AddRegLstPrecios();
            return resp;
        }


        public int ActualizaArticulo()
        {
            CargaParametroMat();
            RegCatArticulo OpUp = new RegCatArticulo(MatParam, db);
            return OpUp.UpdateArticulo();

        }

        public int EliminaArticulo()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpDel = new RegCatArticulo(MatParam, db);
            return OpDel.DeleteArticulo();
        }
        /*
        public SqlDataAdapter ListarArticulos()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            return OpLst.ListArticulos();
        }
        */
        public int EditarArticulo(int HideCveArt)
        {
            int Nreg = 0;
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpEdit = new RegCatArticulo(MatParam, db);
            Datos = OpEdit.RegistroActivo(HideCveArt);
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            Nreg = Ds.Tables[0].Rows.Count;
            if (Nreg > 0)
            {
                object[] objA = Ds.Tables[0].Rows[0].ItemArray;

                CveArticulo = objA[0].ToString();
                CodigoAlterno = objA[1].ToString();
                CodigoBarra = objA[2].ToString();
                CodigoSat = objA[3].ToString();
                Fecha_Alta = DateTime.Parse(objA[4].ToString());
                Descripcion = objA[5].ToString();
                Modelo = objA[6].ToString();
                CveLinea = objA[7].ToString();
                CveMarca = objA[8].ToString();
                CveClase1 = objA[9].ToString();
                CveClase2 = objA[10].ToString();
                CveClase3 = objA[11].ToString();
                CveImpuesto = objA[12].ToString();
                CveUMedida1 = objA[13].ToString();
                CveUMedida2 = objA[14].ToString();
                CveUMedidaEquiv = objA[15].ToString();
                EsInventa = int.Parse(objA[16].ToString());
                DispVenta = int.Parse(objA[17].ToString());
                EsServicio = int.Parse(objA[18].ToString());
                DispKit = int.Parse(objA[19].ToString());
                EsKit = int.Parse(objA[20].ToString());
                FecUltCompra = objA[21].ToString();
                CveProveedorUlt = objA[22].ToString();
                Foto = null;
                if (objA[23].ToString().Length > 0)
                    Foto = (byte[])objA[23];
                Observacion = objA[24].ToString();
                Estatus = int.Parse(objA[25].ToString());
                CveImpIEPS = objA[26].ToString();
                CveImpRetIVA = objA[27].ToString();
                CveImpRetISR = objA[28].ToString();
                CveImpOtro = objA[29].ToString();
                RequiereReceta = int.Parse(objA[30].ToString());

            }

            return Nreg;
        }

        public SqlDataAdapter BuscaArticulo(string buscar)
        {
            RegCatArticulo OpBsq = new RegCatArticulo(db);
            return OpBsq.BuscaArticulo(buscar);
        }
        
        private void CargaParametroMat()
        {

            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            MatParam[1, 0] = "CodigoAlterno"; MatParam[1, 1] = CodigoAlterno;
            MatParam[2, 0] = "CodigoBarra"; MatParam[2, 1] = CodigoBarra;
            MatParam[3, 0] = "CodigoSat";   MatParam[3, 1] = CodigoSat;
            MatParam[4, 0] = "Fecha_Alta";  MatParam[4, 1] = Fecha_Alta;
            MatParam[5, 0] = "Descripcion"; MatParam[5, 1] = Descripcion;
            MatParam[6, 0] = "CveLinea";    MatParam[6, 1] = CveLinea;
            MatParam[7, 0] = "CveUMedida1"; MatParam[7, 1] = CveUMedida1;
            MatParam[8, 0] = "CveUMedida2"; MatParam[8, 1] = CveUMedida2;
            MatParam[9, 0] = "UMedidaEquiv2"; MatParam[9, 1] = CveUMedidaEquiv;
            MatParam[10, 0] = "EsInventa";  MatParam[10, 1] = EsInventa;
            MatParam[11, 0] = "DispVenta";  MatParam[11, 1] = DispVenta;
            MatParam[12, 0] = "EsServicio"; MatParam[12, 1] = EsServicio;
            MatParam[13, 0] = "DispKit";    MatParam[13, 1] = DispKit;
            MatParam[14, 0] = "EsKit";      MatParam[14, 1] = EsKit;
            MatParam[15, 0] = "Observacion";MatParam[15, 1] = Observacion;
            MatParam[16, 0] = "Estatus";    MatParam[16, 1] = Estatus;
            MatParam[17, 0] = "CveImpuesto"; MatParam[17, 1] = CveImpuesto;
            MatParam[18, 0] = "CveClase1";   MatParam[18, 1] = CveClase1;
            MatParam[19, 0] = "CveClase2";   MatParam[19, 1] = CveClase2;
            MatParam[20, 0] = "CveClase3";   MatParam[20, 1] = CveClase3;
            MatParam[21, 0] = "Foto";        MatParam[21, 1] = Foto;
            MatParam[22, 0] = "CveMarca";    MatParam[22, 1] = CveMarca;

            MatParam[23, 0] = "RequiereReceta"; MatParam[23, 1] = RequiereReceta;
            MatParam[24, 0] = "CveImpIEPS"; MatParam[24, 1] = CveImpIEPS;
            MatParam[25, 0] = "CveImpRetIVA"; MatParam[25, 1] = CveImpRetIVA;
            MatParam[26, 0] = "CveImpRetISR"; MatParam[26, 1] = CveImpRetISR;
            MatParam[27, 0] = "CveImpOtro"; MatParam[27, 1] = CveImpOtro;

            //MatParam[24, 0] = "FecUltCompra"; MatParam[24, 1] = FecUltCompra;
            //MatParam[25, 0] = "CveProveedorUlt"; MatParam[25, 1] = CveProveedorUlt;
            //MatParam[22, 0] = "Modelo"; MatParam[22, 1] = Modelo;

        }
    }
}
