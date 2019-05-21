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
    class PuiSegPerfiles
    {
        private string CodPerfil;
        private string Descripcion;
        
        //matriz para Perfilar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[2, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiSegPerfiles(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keySperfil
        {
            get { return CodPerfil; }
            set { CodPerfil = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        #endregion

        public int AgregarPerfil()
        {
            CargaParametroMat();
            RegSegPerfiles OpRadd = new RegSegPerfiles(MatParam, db);
            return OpRadd.AddRegPerfil();
        }

        public int ActualizaPerfil()
        {
            CargaParametroMat();
            RegSegPerfiles OpUp = new RegSegPerfiles(MatParam, db);
            return OpUp.UpdatePerfil();

        }

        public int EliminaPerfil()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            RegSegPerfiles OpDel = new RegSegPerfiles(MatParam, db);
            return OpDel.DeletePerfil();
        }

        public SqlDataAdapter ListarPerfiles()
        {
            CargaParametroMat();
            RegSegPerfiles OpLst = new RegSegPerfiles(db);
            return OpLst.ListPerfiles();
        }

        public void EditarPerfil()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            RegSegPerfiles OpEdit = new RegSegPerfiles(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CodPerfil = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            
        }



        public void getPerfil()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            RegSegPerfiles OpEdit = new RegSegPerfiles(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

                CodPerfil = ObjA[0].ToString();
                Descripcion = ObjA[1].ToString();
            }
            else
            {
                CodPerfil = "";
                Descripcion = "";
            }

        }

        public SqlDataAdapter BuscaPerfil(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "Perfil"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegSegPerfiles OpBsq = new RegSegPerfiles(MatParam);/
             */
            RegSegPerfiles OpBsq = new RegSegPerfiles(db);
            return OpBsq.BuscaPerfil(buscar);
        }
        public DataTable CboPerfiles()
        {
            CargaParametroMat();
            RegSegPerfiles OpLst = new RegSegPerfiles(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboSPerfiles().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
        }

    }
}
