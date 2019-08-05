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
    class PuiSegUsuarioCfg
    {
        private string CveUsuario;
        private string CveAlmacen;
        private int CambiaAlmacen;
        private string Fondo;
        private string StiloTema;




        //matriz para UsrCfgar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[5, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiSegUsuarioCfg(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keySUsrCfg
        {
            get { return CveUsuario; }
            set { CveUsuario = value; }
        }

        public string cmpCveAlmacen
        {
            get { return CveAlmacen; }
            set { CveAlmacen = value; }
        }

        public int cmpCambiaAlmacen
        {
            get { return CambiaAlmacen; }
            set { CambiaAlmacen = value; }
        }

        public string cmpFondo
        {
            get { return Fondo; }
            set { Fondo = value; }
        }

        public string cmpStiloTema
        {
            get { return StiloTema; }
            set { StiloTema = value; }
        }


        #endregion

        public int AgregarUsrCfg()
        {
            CargaParametroMat();
            RegSegUsuarioCfg OpRadd = new RegSegUsuarioCfg(MatParam, db);
            return OpRadd.AddRegUsrCfg();
        }

        public int ActualizaUsrCfg()
        {
            CargaParametroMat();
            RegSegUsuarioCfg OpUp = new RegSegUsuarioCfg(MatParam, db);
            return OpUp.UpdateUsrCfg();

        }

        public int EliminaUsrCfg()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveUsuario"; MatParam[0, 1] = CveUsuario;
            RegSegUsuarioCfg OpDel = new RegSegUsuarioCfg(MatParam, db);
            return OpDel.DeleteUsrCfg();
        }

        public SqlDataAdapter ListarUsrCfg()
        {
            CargaParametroMat();
            RegSegUsuarioCfg OpLst = new RegSegUsuarioCfg(db);
            return OpLst.ListUsrCfg();
        }

        public void EditarUsrCfg()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveUsuario"; MatParam[0, 1] = CveUsuario;
            RegSegUsuarioCfg OpEdit = new RegSegUsuarioCfg(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveUsuario = ObjA[0].ToString();
            CveAlmacen = ObjA[1].ToString();
            CambiaAlmacen = Convert.ToInt32(ObjA[2].ToString());
            Fondo = ObjA[3].ToString();
            StiloTema = ObjA[4].ToString();


        }

        
        public SqlDataAdapter BuscaUsrCfg(string buscar)
        {

            RegSegUsuarioCfg OpBsq = new RegSegUsuarioCfg(db);
            return OpBsq.BuscaUsrCfg(buscar);
        }
        
        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveUsuario"; MatParam[0, 1] = CveUsuario;
            MatParam[1, 0] = "CveAlmacen"; MatParam[1, 1] = CveAlmacen;
            MatParam[2, 0] = "CambiaAlmacen"; MatParam[2, 1] = CambiaAlmacen;
            MatParam[3, 0] = "Fondo"; MatParam[3, 1] = Fondo;
            MatParam[4, 0] = "StiloTema"; MatParam[4, 1] = StiloTema;

        }

        public DataTable CboTemas()
        {
            RegSegUsuarioCfg OpLst = new RegSegUsuarioCfg(db);
            DataSet Cbo = new DataSet();
            OpLst.CboTemas().Fill(Cbo);
            return Cbo.Tables[0];
        }

        public Object[] GetParamTema()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "Usuario"; MatParam[0, 1] = StiloTema;
            RegSegUsuarioCfg OpEdit = new RegSegUsuarioCfg(MatParam, db);
            Datos = OpEdit.GetParamTema();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);

            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            return ObjA;


        }

    }
}
