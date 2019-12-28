using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms;
using System.Globalization;

namespace GAFE
{
    //class clsLocalizer : ILocalizationProvider
    internal class localizer : ILocalizationProvider
    {

        public string GetLocalizedString(System.Globalization.CultureInfo culture, string name, object obj)
        {

            switch (name)
            {
                case ResourceIdentifiers.Yes:
                    return "Si";
                case ResourceIdentifiers.No:
                    return "No";
                case ResourceIdentifiers.OK:
                    return "Aceptar";
                case ResourceIdentifiers.Cancel:
                    return "Cancelar";
                default:
                    return string.Empty;

            }


        }
    }
}
