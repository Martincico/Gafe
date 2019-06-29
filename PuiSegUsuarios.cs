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
    class PuiSegUsuarios
    {


        private string Usuario;
        private string Nombre;
        private string Password;
        private string CodPerfil;
        private string ClaveAlmacen;
        //matriz para Usuarioar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[5, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

        public PuiSegUsuarios(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keySusuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string cmpPassword
        {
            get { return Password; }
            set { Password = value; }
        }

        public string cmpCodPerfil
        {
            get { return CodPerfil; }
            set { CodPerfil = value; }
        }

        public string cmpCveAlmacen
        {
            get { return ClaveAlmacen; }
            set { ClaveAlmacen = value; }
        }


        #endregion

        public int AgregarUsuario()
        {
            CargaParametroMat();
            RegSegUsuarios OpRadd = new RegSegUsuarios(MatParam, db);
            return OpRadd.AddRegUsuario();
        }

        public int ActualizaUsuario()
        {
            CargaParametroMat();
            RegSegUsuarios OpUp = new RegSegUsuarios(MatParam, db);
            return OpUp.UpdateUsuario();
        }

        public int ActTemaUsuario()
        {
            object[,] StilParam = new object[2, 2];
            StilParam[0, 0] = "Usuario"; StilParam[0, 1] = Usuario;
            StilParam[1, 0] = "StiloTema"; StilParam[1, 1] = Nombre;

            RegSegUsuarios OpUp = new RegSegUsuarios(StilParam, db);
            return OpUp.UpdTemaUsuario();

        }

        public int ActFondoUsuario()
        {
            object[,] FondParam = new object[2, 2];
            FondParam[0, 0] = "Usuario"; FondParam[0, 1] = Usuario;
            FondParam[1, 0] = "Fondo"; FondParam[1, 1] = Nombre;

            RegSegUsuarios OpUp = new RegSegUsuarios(FondParam, db);
            return OpUp.UpdFondoUsuario();

        }

        public int EliminaUsuario()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = Usuario;
            RegSegUsuarios OpDel = new RegSegUsuarios(MatParam, db);
            return OpDel.DeleteUsuario();
        }

        public SqlDataAdapter ListarUsuarios()
        {
            CargaParametroMat();
            RegSegUsuarios OpLst = new RegSegUsuarios(db);
            return OpLst.ListUsuarios();
        }

        public void EditarUsuario()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = Usuario;
            RegSegUsuarios OpEdit = new RegSegUsuarios(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            Usuario = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            Password = ObjA[2].ToString();
            CodPerfil = ObjA[3].ToString();
        }



        public Object[] getUsuario()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = Usuario;
            RegSegUsuarios OpEdit = new RegSegUsuarios(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = null;
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ObjA = Ds.Tables[0].Rows[0].ItemArray;
                Usuario = ObjA[0].ToString();
                Nombre = ObjA[1].ToString();
                Password = ObjA[2].ToString();
                CodPerfil = ObjA[3].ToString();
                ClaveAlmacen = ObjA[4].ToString();
            }
            else
            {
                ObjA = new object[1];
                Usuario = "";
                Nombre = "";
                Password = "";
                CodPerfil = "";
                ClaveAlmacen = "";
            }

            return ObjA;

        }

        public SqlDataAdapter CargaPerfilUsuario()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            RegSegUsuarios cP = new RegSegUsuarios(MatParam, db);
            return cP.PerfilUsuario();
        }


        public SqlDataAdapter BuscaUsuario(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "Usuario"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegSegUsuarios OpBsq = new RegSegUsuarios(MatParam);/
             */
            RegSegUsuarios OpBsq = new RegSegUsuarios(db);
            return OpBsq.BuscaUsuario(buscar);
        }


        public void getEstiloUser()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = Usuario;
            RegSegUsuarios OpEdit = new RegSegUsuarios(MatParam, db);
            Datos = OpEdit.EstiloUser();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            Usuario = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            Password = ObjA[2].ToString();

        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = Usuario;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "Password"; MatParam[2, 1] = Password;
            MatParam[3, 0] = "CodPerfil"; MatParam[3, 1] = CodPerfil;
            MatParam[4, 0] = "ClaveAlmacen"; MatParam[4, 1] = ClaveAlmacen;
        }

    }
}
