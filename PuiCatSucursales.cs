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
    class PuiCatSucursales
    {
        private string CveSucursal;
        private string Nombre;
        private string Calle;
        private int CveLocalidad;
        private string CP;
        private string Tel;
        private string Mail;
        private int Estatus;
        private string Contacto;
        private string Cargo;
        public PuiCatGeografia Geo;
        

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[10, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatSucursales(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Sucursales


        public string keyCveSucursales
        {
            get { return CveSucursal; }
            set { CveSucursal = value; }
        }
    public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
    public string cmpCalle
        {
            get { return Calle; }
            set { Calle = value; }
        }
    public int cmpCveLocalidad
        {
            get { return CveLocalidad; }
            set { CveLocalidad = value; }
        }
    public string cmpCP
        {
            get { return CP; }
            set { CP = value; }
        }
    public string cmpTel
        {
            get { return Tel; }
            set { Tel = value; }
        }
    public string cmpMail
        {
            get { return Mail; }
            set { Mail = value; }
        }
    public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
    public string cmpContacto
        {
            get { return Contacto; }
            set { Contacto = value; }
        }
    public string cmpCargo
        {
            get { return Cargo; }
            set { Cargo = value; }
        }

        #endregion

        public int AgregarSucursales()
        {
            CargaParametroMat();
            RegCatSucursales OpRadd = new RegCatSucursales(MatParam, db);
            return OpRadd.AddRegSucursales();
        }

        public int ActualizaSucursales()
        {
            CargaParametroMat();
            RegCatSucursales OpUp = new RegCatSucursales(MatParam, db);
            return OpUp.UpdateSucursales();

        }

        public int EliminaSucursales()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveSucursal"; MatParam[0, 1] = CveSucursal;
            RegCatSucursales OpDel = new RegCatSucursales(MatParam, db);
            return OpDel.DeleteSucursales();
        }


        public void EditarSucursales()
        {
            int aux;
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveSucursal"; MatParam[0, 1] = CveSucursal;
            RegCatSucursales OpEdit = new RegCatSucursales(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
            
            CveSucursal = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            Calle = ObjA[2].ToString();
            if (!int.TryParse(ObjA[3].ToString(), out aux))
                aux = 0;
            CveLocalidad = aux;
            CP = ObjA[4].ToString();
            Tel = ObjA[5].ToString();
            Mail = ObjA[6].ToString();
            Contacto = ObjA[7].ToString();
            Cargo = ObjA[8].ToString();
            if (!int.TryParse(ObjA[9].ToString(), out aux))
                aux = 0;
            Estatus = aux;


        }

        public DataTable ListSucursales()
        {
            RegCatSucursales OpLst = new RegCatSucursales(db);
            DataSet Cbo = new DataSet();
            OpLst.ListSucursales().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public SqlDataAdapter BuscaSucursal(string buscar)
        {
            RegCatSucursales OpBsq = new RegCatSucursales(db);
            return OpBsq.BuscaSucursal(buscar);
        }

        public DataTable LLenaCboSucursales(int padre = 0)
        {
            RegCatSucursales OpLst = new RegCatSucursales(db);
            DataSet Cbo = new DataSet();
            OpLst.LLenaCboSucursales().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveSucursal"; MatParam[0, 1] = CveSucursal;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "Calle"; MatParam[2, 1] = Calle;
            MatParam[3, 0] = "CveLocalidad"; MatParam[3, 1] = CveLocalidad;
            MatParam[4, 0] = "CP"; MatParam[4, 1] = CP;
            MatParam[5, 0] = "Tel"; MatParam[5, 1] = Tel;
            MatParam[6, 0] = "Mail"; MatParam[6, 1] = Mail;
            MatParam[7, 0] = "Contacto"; MatParam[7, 1] = Contacto;
            MatParam[8, 0] = "Cargo"; MatParam[8, 1] = Cargo;
            MatParam[9, 0] = "Estatus"; MatParam[9, 1] = Estatus;

        }
    }
}
