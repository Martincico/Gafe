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
    class PuiCatGeografia
    {
        private int id;
        private string Descripcion;
        private string Estatus;
        private int Padre;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatGeografia(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Geografia

        public int keyCveGeografia
        {
            get { return id; }
            set { id = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public int cmpPadre
        {
            get { return Padre; }
            set { Padre = value; }
        }

        #endregion

        public int AgregarGeografia()
        {
            CargaParametroMat();
            RegCatGeografia OpRadd = new RegCatGeografia(MatParam, db);
            return OpRadd.AddRegGeografia();
        }

        public int ActualizaGeografia()
        {
            CargaParametroMat();
            RegCatGeografia OpUp = new RegCatGeografia(MatParam, db);
            return OpUp.UpdateGeografia();

        }

        public int EliminaGeografia()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "id"; MatParam[0, 1] = id;
            RegCatGeografia OpDel = new RegCatGeografia(MatParam, db);
            return OpDel.DeleteGeografia();
        }


        public void EditarGeografia()
        {
            int aux;
            MatParam = new object[1, 2];
            MatParam[0, 0] = "id"; MatParam[0, 1] = id;
            RegCatGeografia OpEdit = new RegCatGeografia(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
            if(!int.TryParse(ObjA[0].ToString(),out aux))
            {
                aux = 0;
                return;
            }
            id = aux;
            Descripcion = ObjA[1].ToString();
            Estatus = ObjA[2].ToString();
            if (!int.TryParse(ObjA[3].ToString(), out aux))
            {
                aux = 0;
            }
            Padre = aux;
        }

        public DataTable ListGeografia(int padre=0)
        {
            
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Padre"; MatParam[0, 1] = padre;

            RegCatGeografia OpLst = new RegCatGeografia(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.ListHijos().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public DataTable ListPaises()
        {

            MatParam = new object[1, 2];
            MatParam[0, 0] = "Padre"; MatParam[0, 1] = 0;

            RegCatGeografia OpLst = new RegCatGeografia(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.ListHijos().Fill(Cbo);
            return Cbo.Tables[0];
        }

        public DataTable ComboGeografia(int padre=0)
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Padre"; MatParam[0, 1] = Padre;

            RegCatGeografia OpLst = new RegCatGeografia(MatParam, db);
            DataSet Cbo = new DataSet();
            OpLst.ComboGeografia().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "id"; MatParam[0, 1] = id;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
            MatParam[3, 0] = "Padre"; MatParam[3, 1] = Padre;
        }
    }
}
