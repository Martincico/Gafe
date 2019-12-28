using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Globalization;

using Syncfusion.Windows.Forms;

using Syncfusion.Windows.Forms.Tools;

namespace GAFE
{
    class ClsUtilerias
    {
        private Boolean Ans = false;
        private Regex ExpReg = null;
        private int NumDec;

        public static List<int> ArrNum = new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
        public static List<int> ArrLet = new List<int>() { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
                                                            97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 };
        public static List<int> ArrCharComun = new List<int>() { 8, 127, 13 };//Retroceso, Suprimir, Enter
        public static List<int> ArrCharEspec = new List<int>() { 33,34,35,36,37,38,39,40,41,42,43,44,45,46,47 };
        //33 !,34 ",35 #,36 $,37 %,38 &,39 ',40 (,41),42 *,43 +,44 ,,45-,46 .,47 /
        public static List<int> ArrCharCVP = new List<int>() { 3,22, 24  }; //Copar, Pegar., Cortar

        NumberFormatInfo nfi = new CultureInfo("es-MX", false).NumberFormat;

        public ClsUtilerias(int NumD)
        {
            NumDec = NumD;
        }

        public Boolean Numeros(string PStr)
        {
            ExpReg = new Regex("^\\d*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean Letras(string PStr)
        {
            ExpReg = new Regex("^[a-zñÑA-Z]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean LetrasSpa(string PStr)
        {
            ExpReg = new Regex("^[a-zñÑA-Z\\s]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean LetrasNum(string PStr)
        {
            ExpReg = new Regex("^[0-9a-zñÑA-Z]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }
        public Boolean LetrasNumSpa(string PStr)
        {
            ExpReg = new Regex("^[0-9a-zñÑA-Z\\s]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }
        public Boolean Moneda(string PStr)//Obliga a poner comas cada 3 digitos, y si va con decimal obliga a poner minimo 1 digito maximo3
        {
            ExpReg = new Regex("^[0-9]{1,3}([\\,][0-9]{3})*([\\.][0-9]{1," + NumDec + "})*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }
        public Boolean Decimal(string PStr)//Valida números y si va con decimal obliga a poner minimo 1 digito maximo3
        {
            ExpReg = new Regex("^([0-9]{0,})[.]?[0-9]{1,"+ NumDec + "}$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean Cp(string PStr)//Valida codigo postal
        {
            ExpReg = new Regex("^[0-9]{5}$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public static void LetrasNumeros(KeyPressEventArgs e, int PermiCVP = 0)
        {
            if (!ArrCharComun.Contains(e.KeyChar))
            {
                if (!ArrNum.Contains(e.KeyChar))
                {
                    if (!ArrLet.Contains(e.KeyChar))
                    {
                        PermiCVP = PermiCVP == 0 ? 0 : ValCVP(e.KeyChar);//1 ecuentra

                        if (PermiCVP == 0)
                        {
                            e.Handled = true;
                            MessageBoxAdv.Show("Solo letras y números", "Carácter no válido", MessageBoxButtons.OK,
                                               MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        public static void Letras(KeyPressEventArgs e, int PermiCVP = 0)
        {
            if (!ArrCharComun.Contains(e.KeyChar))
            {
                if (!ArrLet.Contains(e.KeyChar))
                {
                    PermiCVP = PermiCVP == 0 ? 0 : ValCVP(e.KeyChar);//1 ecuentra

                    if (PermiCVP == 0)
                    {
                        e.Handled = true;
                        MessageBoxAdv.Show("Solo letras", "Carácter no válido", MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static void Numeros(KeyPressEventArgs e, int PermiCVP = 0)
        {
            if (!ArrCharComun.Contains(e.KeyChar))
            {
                if (!ArrNum.Contains(e.KeyChar))
                {
                    PermiCVP = PermiCVP == 0 ? 0 : ValCVP(e.KeyChar);//1 ecuentra

                    if (PermiCVP == 0)
                    {
                        e.Handled = true;
                        MessageBoxAdv.Show("Solo números", "Carácter no válido", MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static void LetrasNumerosEspacio(KeyPressEventArgs e, int PermiCVP = 0)
        {
            int hash = (int)e.KeyChar;
            if (!ArrCharComun.Contains(e.KeyChar) && (e.KeyChar) != 32 )
            {
                if (ArrNum.Contains(e.KeyChar))
                {
                    PermiCVP = PermiCVP == 0 ? 0 : ValCVP(e.KeyChar);//1 ecuentra

                    if (PermiCVP == 0)
                    {
                        e.Handled = true;
                        MessageBoxAdv.Show("Solo se permiten letras, números y espacios", "Carácter no válido", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static int ValCVP(int Val)
        {
            Val = (ArrCharCVP.Contains(Val)) ? 1 : 0;
            return Val;
        }

        public void MsjBox(ToolTip buttonToolTip,Control txt, String Tit,String Head, ToolTipIcon icn)
        {
            buttonToolTip.ToolTipTitle = Tit;
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.ToolTipIcon = icn;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 500;
            //buttonToolTip.SetToolTip(txt, Head);
            buttonToolTip.Show(Head, txt, txt.Width / 2, txt.Height, 5000);

        }

        public String LimpiarTxt(String txt) //Quitamos $ y , 
        {
            String rm = txt.Replace("$", "").Replace(",", "").Trim();
            return rm;
        }

        public String FormtStrDec(String txt) //Retornamos Strin Convertido en $ 100.x donde x es el número decimales
        {
            nfi.CurrencyPositivePattern = 2; //Posicionar el $ 
            return String.Format(nfi, "{0:C" + NumDec + "}", txt);
        }

        public String FormtDouDec(Double txt)//Retornamos Strin Convertido en $ 100.x donde x es el número decimales
        {
            nfi.CurrencyPositivePattern = 2; //Posicionar el $ 
            return String.Format(nfi, "{0:C" + NumDec + "}", txt);
        }

        public String TipoFmtoRedonder() //Para los grid
        {
            return "C" + NumDec;
        }

    }
}
