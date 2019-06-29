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
        public String NoSessiones;
        public String AlmacenUsa;
        public String StiloTema;
        public String Fondo;

        public String CambiarAlmacen;
        public String CambiarSerie;

        public DatCfgUsuario(object[] DatosUsuario)
        {
            this.Usuario            =   DatosUsuario[ 0].ToString();
            this.UsrName            =   DatosUsuario[ 1].ToString();
            this.Password           =   DatosUsuario[ 2].ToString();
            this.CodPerfil          =   DatosUsuario[ 3].ToString();
            this.AlmacenUsa         =   DatosUsuario[ 4].ToString();
            this.StiloTema          =   DatosUsuario[ 5].ToString();
            this.Fondo              =   DatosUsuario[ 6].ToString();
            //this.NoSessiones        =   DatosUsuario[ 5].ToString();
            //this.CambiarAlmacen     =   DatosUsuario[ 6].ToString();
            //this.CambiarSerie       =   DatosUsuario[ 7].ToString();
        }
    }
}
