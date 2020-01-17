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
    class PuiCatDoctores
    {
        
        private string Cedula;
        private string Nombre;
        private string Calle;
        private string Telefono;
        private string Correo;
        private int Localidad;
        private string CP;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[7, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatDoctores(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Doctores

        public string keyCveDoctor
        {
            get { return Cedula; }
            set { Cedula = value; }
        }

        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string cmpCalle
        {
            get { return Calle; }
            set {  Calle = value; }
        }
        public string cmpTelefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        public string cmpCP
        {
            get { return CP; }
            set { CP = value; }
        }
        public string cmpCorreo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        public int cmpLocalidad
        {
            get { return Localidad; }
            set { Localidad = value; }
        }
       


        #endregion

        public int AgregarDoctor()
        {
            CargaParametroMat();
            RegCatDoctores OpRadd = new RegCatDoctores(MatParam, db);
            return OpRadd.AddRegDoctores();
        }

        public int ActualizaDoctores()
        {
            CargaParametroMat();
            RegCatDoctores OpUp = new RegCatDoctores(MatParam, db);
            return OpUp.UpdateDoctores();

        }

        public int EliminaDoctores()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Cedula"; MatParam[0, 1] = Cedula;
            RegCatDoctores OpDel = new RegCatDoctores(MatParam, db);
            return OpDel.DeleteDoctores();
        }

        public SqlDataAdapter ListarDoctores()
        {
            CargaParametroMat();
            RegCatDoctores OpLst = new RegCatDoctores(db);
            return OpLst.ListDoctores();
        }

        public void EditarDoctores()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Cedula"; MatParam[0, 1] = Cedula;
            RegCatDoctores OpEdit = new RegCatDoctores(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
            //Cedula,Nombre,Calle,Telefono,Localidad,Correo,CP
            Cedula = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            Calle = ObjA[2].ToString();
            Telefono = ObjA[3].ToString();
            Localidad = int.Parse(ObjA[4].ToString());
            Correo = ObjA[5].ToString();
            CP = ObjA[6].ToString();

        }

        public SqlDataAdapter BuscaDoctores(string buscar)
        {
            RegCatDoctores OpBsq = new RegCatDoctores(db);
            return OpBsq.BuscaDoctores(buscar);
        }
        public DataTable CboDoctores()
        {
            CargaParametroMat();
            RegCatDoctores OpLst = new RegCatDoctores(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboDoctores().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            //Cedula,Nombre,Calle,Telefono,Localidad,Correo,CP
            MatParam[0, 0] = "Cedula"; MatParam[0, 1] = Cedula;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "Calle"; MatParam[2, 1] = Calle;
            MatParam[3, 0] = "Telefono"; MatParam[3, 1] = Telefono;
            MatParam[4, 0] = "Localidad"; MatParam[4, 1] = Localidad;
            MatParam[5, 0] = "Correo"; MatParam[5, 1] = Correo;
            MatParam[6, 0] = "CP"; MatParam[6, 1] = CP;

        }

    }
}
