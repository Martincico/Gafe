using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatSql;
using System.Data.SqlClient;
using System.Data;

namespace GAFE
{
    class clsUtil
    {

        public List<clsUsPerfil> LstUpf;
        private MsSql db;
        private SqlDataAdapter dtA = null;
        private string Perfil;
        DataSet Ds;

        public clsUtil(MsSql oDat,string perfil)
        {
            db = oDat;
            Perfil = perfil;
        }

        public void CargaArbolAcceso()
        {
            PuiSegUsuarios us = new PuiSegUsuarios(db);
            us.cmpCodPerfil = Perfil;
            dtA = us.CargaPerfilUsuario();
            Ds = new DataSet();
            dtA.Fill(Ds);
            LstUpf = new List<clsUsPerfil>();
            for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
            {
                object[] tmp = Ds.Tables[0].Rows[j].ItemArray;
                clsUsPerfil Aperfil = new clsUsPerfil();
                Aperfil.CodPerfil = tmp[0].ToString(); ;
                Aperfil.idNodo = tmp[1].ToString();
                Aperfil.idPadre = tmp[2].ToString();
                Aperfil.Acceso = Convert.ToInt32(tmp[3]);
                LstUpf.Add(Aperfil);
            }
        }

        public clsUsPerfil BuscarIdNodo(string nd)
        {
            clsUsPerfil ob = null;
            for (int j = 0; j < LstUpf.Count; j++)
            {
                if (LstUpf[j].idNodo == nd)
                    ob = LstUpf[j];
            }
            return ob;
        }
    }
}
