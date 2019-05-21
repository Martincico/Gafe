using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using DatSql;

namespace CtrlAcceso
{
    class PuiSegAccesos
    {
        private string CodPerfil;
        private string idNodo;
        private string idPadre;
        private int    Acceso;

        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiSegAccesos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }

        #region Definicion de propiedades de la clase

        public string keySAcceso
        {
            get { return CodPerfil; }
            set { CodPerfil = value; }
        }

        public string cmpIdNodo
        {
            get { return idNodo; }
            set { idNodo = value; }
        }

        public string cmpIdPadre
        {
            get { return idPadre; }
            set { idPadre = value; }
        }

        public int cmpAcceso
        {
            get { return Acceso; }
            set { Acceso = value; }
        }
        #endregion


        public int EsAccesoNuevo()
        {
            int dv = 1;

            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            RegSegAccesos OpEdit = new RegSegAccesos(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            if (Ds.Tables[0].Rows.Count > 0)
                dv = 0;

          return dv;
        }

        public int ElRegistroEsNuevo()
        {
            int dv = 1;
            MatParam = new object[3, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            MatParam[1, 0] = "idNodo"; MatParam[1, 1] = idNodo;
            MatParam[2, 0] = "idPadre"; MatParam[2, 1] = idPadre;
            RegSegAccesos OpEdit = new RegSegAccesos(MatParam, db);
            Datos = OpEdit.RegistroActivo2();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            if (Ds.Tables[0].Rows.Count > 0)
                dv = 0;
            return dv;
        }


        public int ValorDeAcceso()
        {
            MatParam = new object[3, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            MatParam[1, 0] = "idNodo"; MatParam[1, 1] = idNodo;
            MatParam[2, 0] = "idPadre"; MatParam[2, 1] = idPadre;
            RegSegAccesos OpEdit = new RegSegAccesos(MatParam, db);
            Datos = OpEdit.RegistroActivo2();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);            
            if (Ds.Tables[0].Rows.Count > 0)
            {
                object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;
                Acceso = Convert.ToInt16(ObjA[3]);
            }
            else
                Acceso = 0;

            return Acceso;
        }




        public int AgregarAcceso()
        {
            CargaParametroMat();
            RegSegAccesos OpRadd = new RegSegAccesos(MatParam, db);
            return OpRadd.AddRegAcceso();
        }

        public int ActualizaAcceso()
        {
            CargaParametroMat();
            RegSegAccesos OpUp = new RegSegAccesos(MatParam, db);
            return OpUp.UpdatePerfil();
        }

        private void CargaParametroMat()
        {
            MatParam = new object[4, 2];
            MatParam[0, 0] = "CodPerfil"; MatParam[0, 1] = CodPerfil;
            MatParam[1, 0] = "idNodo"; MatParam[1, 1] = idNodo;
            MatParam[2, 0] = "idPadre"; MatParam[2, 1] = idPadre;
            MatParam[3, 0] = "Acceso"; MatParam[3, 1] = Acceso;

        }


    }
}
