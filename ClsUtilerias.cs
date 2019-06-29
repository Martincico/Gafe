using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Syncfusion.Windows.Forms;

namespace GAFE
{
    class ClsUtilerias
    {
        private Boolean Ans = false;
        private Regex ExpReg = null;

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
            ExpReg = new Regex("^[0-9]{1,3}([\\,][0-9]{3})*([\\.][0-9]{1,3})*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }
        public Boolean Decimal(string PStr)//Valida números y si va con decimal obliga a poner minimo 1 digito maximo3
        {
            ExpReg = new Regex("^([0-9]{0,})[.]?[0-9]{1,3}$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean Cp(string PStr)//Valida codigo postal
        {
            ExpReg = new Regex("^[0-9]{5}$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public static void LetrasNumeros(KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && e.KeyChar != 8
                || (e.KeyChar) > 57 && (e.KeyChar) < 65
                || (e.KeyChar) > 90 && (e.KeyChar) < 97
                || (e.KeyChar) > 122)

            {
                e.Handled = true;
                MessageBoxAdv.Show("Solo letras y números", "Carácter no válido", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
            }
        }

        public static void Letras(KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 65 && e.KeyChar != 8
                || (e.KeyChar) > 90 && (e.KeyChar) < 97
                || (e.KeyChar) > 122)
            {
                e.Handled = true;
                MessageBoxAdv.Show("Solo letras", "Carácter no válido", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
            }
        }

        public static void Numeros(KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && e.KeyChar != 8
                || (e.KeyChar) > 57)

            {
                e.Handled = true;
                MessageBoxAdv.Show("Solo números", "Carácter no válido", MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
            }
        }

        public static void LetrasNumerosEspacio(KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 32
                || (e.KeyChar) > 57 && (e.KeyChar) < 65
                || (e.KeyChar) > 90 && (e.KeyChar) < 97
                || (e.KeyChar) > 122)
            {
                e.Handled = true;
            }
        }




    }
}
