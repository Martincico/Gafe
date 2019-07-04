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
    class PuiCatLstPrecios
    {
        private string CveLstPrecio;
        private string Nombre;
        private int EsDeVenta;
        private int EsDeCosto;
        private int Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[5, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatLstPrecios(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la LstPrecios

        public string keyCveLstPrecio
        {
            get { return CveLstPrecio; }
            set { CveLstPrecio = value; }
        }

        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public int cmpEsDeVenta
        {
            get { return EsDeVenta; }
            set { EsDeVenta = value; }
        }

        public int cmpEsDeCosto
        {
            get { return EsDeCosto; }
            set { EsDeCosto = value; }
        }


        #endregion

        public int AgregarLstPrecios()
        {
            CargaParametroMat();
            RegCatLstPrecios OpRadd = new RegCatLstPrecios(MatParam,db);
            return OpRadd.AddRegLstPrecios();
        }

        public int AddLstPreciosDet()
        {
            CargaParametroMat();
            RegCatLstPrecios OpRadd = new RegCatLstPrecios(MatParam, db);
            return OpRadd.AddLstPreciosDet();
        }

        public int ActualizaLstPrecios()
        {
            CargaParametroMat();
            RegCatLstPrecios OpUp = new RegCatLstPrecios(MatParam,db);
            return OpUp.UpdateLstPrecios();

        }

        public int EliminaLstPrecios()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveLstPrecio"; MatParam[0, 1] = CveLstPrecio;
            RegCatLstPrecios OpDel = new RegCatLstPrecios(MatParam,db);
            return OpDel.DeleteLstPrecios();
        }

        public SqlDataAdapter ListarLstPrecioss()
        {
            CargaParametroMat();
            RegCatLstPrecios OpLst = new RegCatLstPrecios(db);
            return OpLst.ListLstPrecios();
        }

        public void EditarLstPrecios()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveLstPrecio"; MatParam[0, 1] = CveLstPrecio;
            RegCatLstPrecios OpEdit = new RegCatLstPrecios(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveLstPrecio = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            EsDeVenta = Convert.ToInt32(ObjA[2]);
            EsDeCosto = Convert.ToInt32(ObjA[3]);
            Estatus = Convert.ToInt32(ObjA[4]);
        }

        public SqlDataAdapter BuscaLstPrecios(string buscar)
        {

            RegCatLstPrecios OpBsq = new RegCatLstPrecios(db);
            return OpBsq.BuscaLstPrecios(buscar);
        }

        public SqlDataAdapter ListadoPrecioArticulo()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveLstPrecio;
            RegCatLstPrecios OpBsq = new RegCatLstPrecios(MatParam, db);
            return OpBsq.ListadoPrecioArticulo();
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveLstPrecio"; MatParam[0, 1] = CveLstPrecio;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "EsDeVenta"; MatParam[2, 1] = EsDeVenta;
            MatParam[3, 0] = "EsDeCosto"; MatParam[3, 1] = EsDeCosto;
            MatParam[4, 0] = "Estatus"; MatParam[4, 1] = Estatus;
        }
    }
}
