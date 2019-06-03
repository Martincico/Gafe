using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAFE
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA2NzQ5QDMxMzcyZTMxMmUzME9ISThjMDhVamFMdzdMS0lIYldJc3UxSlFBODhGK3FKWkt4VVl6L3J0Ujg9");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmEmpresas());
        }
    }
}
