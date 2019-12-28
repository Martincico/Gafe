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
    class PuiCatClientes
    {
        private string CveCliente;
        private string Nombre;
        private string CveLstPrecio;

        public PuiCatGeografia Geo;
        

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatClientes(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Clientes


        public string keyCveClientes
        {
            get { return CveCliente; }
            set { CveCliente = value; }
        }
        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string cmpCveLstPrecio
        {
            get { return CveLstPrecio; }
            set { CveLstPrecio = value; }
        }

        #endregion

        public int AgregarClientes()
        {
            CargaParametroMat();
            RegCatClientes OpRadd = new RegCatClientes(MatParam, db);
            return OpRadd.AddRegClientes();
        }

        public int ActualizaClientes()
        {
            CargaParametroMat();
            RegCatClientes OpUp = new RegCatClientes(MatParam, db);
            return OpUp.UpdateClientes();

        }

        public int EliminaClientes()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveCliente"; MatParam[0, 1] = CveCliente;
            RegCatClientes OpDel = new RegCatClientes(MatParam, db);
            return OpDel.DeleteClientes();
        }


        public void EditarClientes()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveCliente"; MatParam[0, 1] = CveCliente;
            RegCatClientes OpEdit = new RegCatClientes(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
            
            CveCliente = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            CveLstPrecio = ObjA[2].ToString();


        }

        public DataTable ListClientes()
        {
            RegCatClientes OpLst = new RegCatClientes(db);
            DataSet Cbo = new DataSet();
            OpLst.ListClientes().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public SqlDataAdapter BuscaProveedor(string buscar)
        {
            RegCatClientes OpBsq = new RegCatClientes(db);
            return OpBsq.BuscaArticulo(buscar);
        }

        public DataTable LLenaCboClientes(int padre = 0)
        {
            RegCatClientes OpLst = new RegCatClientes(db);
            DataSet Cbo = new DataSet();
            OpLst.LLenaCboClientes().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveCliente"; MatParam[0, 1] = CveCliente;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[1, 0] = "CveLstPrecio"; MatParam[1, 1] = CveLstPrecio;

        }
    }
}
