using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAFE
{
    public class DatCfgUsuario
    {
        public String Usuario;
        public String UsrName;
        public String Password;
        public String CodPerfil;
        public String AlmacenUsa;
        public int CambiaAlmacen;
        public int Alm_EsDeCompra;
        public int Alm_EsDeVenta;
        public int Alm_EsDeConsigna;
        public int Alm_NumRojo;
        public String Fondo;
        public String StiloTema;
        public DateTime FecServer;


        public String NoSessiones;
        public String CambiarSerie;

        public DatCfgUsuario(object[] DatosUsuario)
        {
            this.Usuario            =   DatosUsuario[0].ToString();
            this.UsrName            =   DatosUsuario[1].ToString();
            this.Password           =   DatosUsuario[2].ToString();
            this.CodPerfil          =   DatosUsuario[3].ToString();
            this.AlmacenUsa         =   DatosUsuario[4].ToString();
            this.CambiaAlmacen      =   int.Parse(DatosUsuario[5].ToString());
            this.Alm_EsDeCompra     =   int.Parse(DatosUsuario[6].ToString());
            this.Alm_EsDeVenta      =   int.Parse(DatosUsuario[7].ToString());
            this.Alm_EsDeConsigna   =   int.Parse(DatosUsuario[8].ToString());
            this.Alm_NumRojo        =   int.Parse(DatosUsuario[9].ToString());
            this.Fondo              =   DatosUsuario[10].ToString();
            this.StiloTema          =   DatosUsuario[11].ToString();
            this.FecServer          =   DateTime.Parse(DatosUsuario[12].ToString());

        }
    }
}
