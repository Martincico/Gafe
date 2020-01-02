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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTY5MzY2QDMxMzcyZTMzMmUzMEJ1YmV2MmNKR2tEWDl2UGVac2FubFZoSzZCK3ZnM3dGdUVZY0dCM2Z3N2M9");
            Syncfusion.Windows.Forms.LocalizationProvider.Provider = new localizer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInicio());
        }
    }
}
