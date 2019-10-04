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

            //To set the Title "menu principal"
            color.TitleColor = ColorTranslator.FromHtml(FontColor);

            //Backstage customization // Barra lateral

                //To set the BackStageButton Hover color
                ///color.BackStageItemHoverColor = ColorTranslator.FromHtml("#19478a");

                // To set the BackStageButton SelectionColor
                //color.BackStageItemSelectionColor = Color.FromArgb(62, 109, 181);

                // To set the BackStageButton ForeColor
                //color.BackStageItemForeColor = Color.White;

                // To set the Backstage title fore color
                //color.BackStageTitleColor = ColorTranslator.FromHtml("#3a3a3a");

                // To set the BackStage SystemButton Background
                //color.BackStageSystemButtonBackground = ColorTranslator.FromHtml("#c5c5c5");

                // To set the Backstage caption color
                //color.BackStageCaptionColor = ColorTranslator.FromHtml("#f1f1f1");

            // Gallery Item Customization

                //To set the GalleryItem TextColor
                //color.GalleryItemNormalTextColor = ColorTranslator.FromHtml("#F0E700");

                //To set the GalleryItem Hover TextColor
                //color.GalleryItemHoveredTextColor = ColorTranslator.FromHtml("#2b2b2b");

                //To set the Gallery item back color
                //color.GalleryItemNormalColor = ColorTranslator.FromHtml("#ffffff");

                // To set the Gallery item checked color
                //color.GalleryItemCheckedColor = ColorTranslator.FromHtml("#afafaf");

                // To set the Gallery item hover color
                //color.GalleryItemSelectedColor = ColorTranslator.FromHtml("#afafaf");


            // ToolstripTabItem customization

                //Color de fondo pestaña al pasar el raton
                color.SelectedTabColor = ColorTranslator.FromHtml(HoverEncabezado);

                //Color de fuente Al pasar el raton por las pestañas
                color.HoverTabForeColor = ColorTranslator.FromHtml(FontColor);

                //Color de fondo de las pestaña activa
                color.CheckedTabColor = ColorTranslator.FromHtml(HoverEncabezado);

                //Color de fuente de las pestaña activa
                color.CheckedTabForeColor = ColorTranslator.FromHtml(FontColor);

                // To set the TabItem fore color
                color.TabForeColor = ColorTranslator.FromHtml(FontColor);

            // ToolstripEx customization

                // Color de fondo de los paneles contenedores 
                //color.ToolStripBackColor = ColorTranslator.FromHtml("#F0E700");

                //Color de fondo del pie del panel
                //color.CaptionBackColor = ColorTranslator.FromHtml("#F9D93A");

                // Color de fuente de los textos de pie de las pestañas
                color.CaptionForeColor = ColorTranslator.FromHtml(Encabezado);

                //Color de fondo Orilla del contorno de los paneles
                color.ToolStripSpliterColor = ColorTranslator.FromHtml(Encabezado);

            //ToolStripItem customization

                // Color de fuente del menu completo
//                color.ToolStripItemForeColor = ColorTranslator.FromHtml(Encabezado);

                // Color de fondo de la pestaña activa al presionar 
//                color.ButtonBackgroundPressed = ColorTranslator.FromHtml(HoverEncabezado);

                // Color de fondo al pasar el raton 
//                color.ButtonBackgroundSelected = ColorTranslator.FromHtml(FontColor);

                // To set the selected SplitButton Background color
                //color.SplitButtonBackgroundSelected = ColorTranslator.FromHtml("#F0E700");

            //Launcher customization

                //To set the Launcher back color
                //color.LauncherColorNormal = ColorTranslator.FromHtml("#F0E700");

                // To set the selected Launcher color
                //color.LauncherColorSelected = ColorTranslator.FromHtml("#F0E700");

                // To set the Selected Launcher back color
                //color.LauncherBackColorSelected = ColorTranslator.FromHtml("#F0E700");

            //RibbonPanel customization

                // Color de fondo del ribon panel
                //color.PanelBackColor = ColorTranslator.FromHtml("#F0E700");

                // Color de fondo contorno del ribon panel
                //color.RibbonPanelBorderColor = ColorTranslator.FromHtml("#F0E700");

                //Color de fondo al pasar el raton en minimiza ribbon (hover) 
                //color.UpDownButtonBackColor = ColorTranslator.FromHtml("#F0E700");

            //Context Menu customization

                // To set the Context menu back color
                //color.ContextMenuBackColor = ColorTranslator.FromHtml("#F0E700");

                // To set the ContextMenu Title Back color
                //color.ContextMenuTitleBackground = Color.FromArgb(30, Color.LightGray);

                // To set the ContextMenu Item selected back color
                //color.ContextMenuItemSelected = ColorTranslator.FromHtml("#c5c5c5");

            // Quick DropDown button customization

                // To set the Quick Access Button back color
                //color.QuickDropDownBackColor = ColorTranslator.FromHtml("#c5c5c5");

                // Fondo de color del bonton que esta a lado de min y max 
                color.QuickDropDownSelectedcolor = ColorTranslator.FromHtml(HoverEncabezado);

                // Al Presionar el boton de la ewsquina
                color.QuickDropDownPressedcolor = ColorTranslator.FromHtml(FontColor);

            //System Button customization

                // Fondo de color de min y max 
                color.SystemButtonBackground = ColorTranslator.FromHtml(HoverEncabezado);

            // To set the Close Button back color
            //color.CloseButtonBackground = ColorTranslator.FromHtml("#e81123");

            //Color de fondo d los submenu
            //color.DropDownBackColor = ColorTranslator.FromHtml(HoverEncabezado);

            //TabGroup Customization

            // To set the TabGroup back color
            //color.TabGroupBackColor = ColorTranslator.FromHtml("#F0E700");

            // To set the TabGroup fore color
            //color.TabGroupForeColor = ColorTranslator.FromHtml("#F0E700");

            return color;
        }
    }
}
