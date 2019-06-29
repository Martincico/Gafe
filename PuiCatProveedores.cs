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
    class PuiCatProveedores
    {
        private string CveProveedor;
        private string Nombre;
        private string RFC;
        private string Calle;
        private int CveLocalidad;
        private string CP;
        private string Tel1;
        private string Mail1;
        private string TipoPersona;
        private int Estatus;
        private string Contacto;
        private string Tel2;
        private string Mail2;
        private string Cargo;
        private string Celular;
        public PuiCatGeografia Geo;
        

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[15, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatProveedores(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Proveedores


        public string keyCveProveedores
        {
            get { return CveProveedor; }
            set { CveProveedor = value; }
        }
    public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
    public string cmpRFC
        {
            get { return RFC; }
            set { RFC = value; }
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
    public string cmpTel1
        {
            get { return Tel1; }
            set { Tel1 = value; }
        }
    public string cmpMail1
        {
            get { return Mail1; }
            set { Mail1 = value; }
        }
    public string cmpTipoPersona
        {
            get { return TipoPersona; }
            set { TipoPersona = value; }
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
    public string cmpTel2
        {
            get { return Tel2; }
            set { Tel2 = value; }
        }
    public string cmpMail2
        {
            get { return Mail2; }
            set { Mail2 = value; }
        }
    public string cmpCargo
        {
            get { return Cargo; }
            set { Cargo = value; }
        }
    public string cmpCelular
        {
            get { return Celular; }
            set { Celular = value; }
        }

        #endregion

        public int AgregarProveedores()
        {
            CargaParametroMat();
            RegCatProveedores OpRadd = new RegCatProveedores(MatParam, db);
            return OpRadd.AddRegProveedores();
        }

        public int ActualizaProveedores()
        {
            CargaParametroMat();
            RegCatProveedores OpUp = new RegCatProveedores(MatParam, db);
            return OpUp.UpdateProveedores();

        }

        public int EliminaProveedores()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveProveedor"; MatParam[0, 1] = CveProveedor;
            RegCatProveedores OpDel = new RegCatProveedores(MatParam, db);
            return OpDel.DeleteProveedores();
        }


        public void EditarProveedores()
        {
            int aux;
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveProveedor"; MatParam[0, 1] = CveProveedor;
            RegCatProveedores OpEdit = new RegCatProveedores(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
            
            CveProveedor = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            RFC = ObjA[2].ToString();
            Calle = ObjA[3].ToString();
            if (!int.TryParse(ObjA[4].ToString(), out aux))
                aux = 0;
            CveLocalidad = aux;
            CP = ObjA[5].ToString();
            Tel1 = ObjA[6].ToString();
            Mail1 = ObjA[7].ToString();
            TipoPersona = ObjA[8].ToString();
            if (!int.TryParse(ObjA[9].ToString(), out aux))
                aux = 0;
            Estatus = aux;
            Contacto = ObjA[10].ToString();
            Tel2 = ObjA[11].ToString();
            Mail2 = ObjA[12].ToString();
            Cargo = ObjA[13].ToString();
            Celular = ObjA[14].ToString();
            
        }

        public DataTable ListProveedores()
        {
            RegCatProveedores OpLst = new RegCatProveedores(db);
            DataSet Cbo = new DataSet();
            OpLst.ListProveedores().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public SqlDataAdapter BuscaProveedor(string buscar)
        {
            RegCatProveedores OpBsq = new RegCatProveedores(db);
            return OpBsq.BuscaArticulo(buscar);
        }

        public DataTable ComboProveedores(int padre = 0)
        {
            RegCatProveedores OpLst = new RegCatProveedores(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboProveedores().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveProveedor"; MatParam[0, 1] = CveProveedor;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "RFC"; MatParam[2, 1] = RFC;
            MatParam[3, 0] = "Calle"; MatParam[3, 1] = Calle;
            MatParam[4, 0] = "CveLocalidad"; MatParam[4, 1] = CveLocalidad;
            MatParam[5, 0] = "CP"; MatParam[5, 1] = CP;
            MatParam[6, 0] = "Tel1"; MatParam[6, 1] = Tel1;
            MatParam[7, 0] = "Mail1"; MatParam[7, 1] = Mail1;
            MatParam[8, 0] = "TipoPersona"; MatParam[8, 1] = TipoPersona;
            MatParam[9, 0] = "Estatus"; MatParam[9, 1] = Estatus;
            MatParam[10, 0] = "Contacto"; MatParam[10, 1] = Contacto;
            MatParam[11, 0] = "Tel2"; MatParam[11, 1] = Tel2;
            MatParam[12, 0] = "Mail2"; MatParam[12, 1] = Mail2;
            MatParam[13, 0] = "Cargo"; MatParam[13, 1] = Cargo;
            MatParam[14, 0] = "Celular"; MatParam[14, 1] = Celular;
        }
    }
}
