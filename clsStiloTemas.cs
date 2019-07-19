using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.Windows.Forms.Tools;
using System.Drawing;

namespace GAFE
{
    public class clsStiloTemas
    {
        public string Encabezado { get; set; }
        public string HoverEncabezado { get; set; }
        public string FontColor { get; set; }
        
        public Office2016ColorTable  StiloTeam()
        {


            //Creating instance of color table
            Office2016ColorTable color = new Office2016ColorTable();

            //To set the Header color
            color.HeaderColor = ColorTranslator.FromHtml(Encabezado);

            // To set the TabItem Back Color
            color.TabBackColor = ColorTranslator.FromHtml(Encabezado);

            //Color de fuente de las pestaña activa
            color.CheckedTabForeColor = ColorTranslator.FromHtml(FontColor);
            //Color de fondo de las pestaña activa
            color.CheckedTabColor = ColorTranslator.FromHtml(HoverEncabezado);

            // Color de fuente de los textos de pie de las pestañas
            color.CaptionForeColor = ColorTranslator.FromHtml(Encabezado);

            //Color de fondo pestaña al pasar el raton
            color.SelectedTabColor = ColorTranslator.FromHtml(HoverEncabezado);

            // Fondo de color de min y max 
            color.SystemButtonBackground = ColorTranslator.FromHtml(HoverEncabezado);

            // Fondo de color del bonton que esta a lado de min y max 
            color.QuickDropDownSelectedcolor = ColorTranslator.FromHtml(HoverEncabezado);

            // To set the TabItem fore color
            color.TabForeColor = ColorTranslator.FromHtml(FontColor);

            //To set the Title "menu principal"
            color.TitleColor = ColorTranslator.FromHtml(FontColor);

            //Color de fuente Al pasar el raton por las pestañas
            color.HoverTabForeColor = ColorTranslator.FromHtml(FontColor);

            //Color de fondo del pie del panel
            //color.CaptionBackColor = ColorTranslator.FromHtml("#F9D93A");

            //Color de fondo d los submenu
            //color.DropDownBackColor = ColorTranslator.FromHtml(HoverEncabezado);




            /*
            color.BackStageCaptionColor = ColorTranslator.FromHtml("#F9D93A");
            color.BackStageItemForeColor = ColorTranslator.FromHtml("#F9D93A");
            color.BottomToolStripBackColor = ColorTranslator.FromHtml("#F9D93A");
            color.ContextMenuBackColor = ColorTranslator.FromHtml("#ff0000");
            color.ContextMenuTitleBackground = ColorTranslator.FromHtml("#ff0000");
            
            
            

            color.GalleryItemNormalColor = ColorTranslator.FromHtml("#F7FCFE");
            color.PanelBackColor = ColorTranslator.FromHtml("#F7FCFE");
            color.QuickDropDownBackColor = ColorTranslator.FromHtml("#F7FCFE");
            color.ToolStripBackColor = ColorTranslator.FromHtml("#F7FCFE");
            color.ToolStripCheckBoxBackColor = ColorTranslator.FromHtml("#F7FCFE");
            
    */

            return color;
        }
    }
}
