using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAFE
{
    class Validaciones
    {
        public static void LetrasNumeros(KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && e.KeyChar != 8 
                || (e.KeyChar) > 57 && (e.KeyChar) < 65 
                || (e.KeyChar) > 90 && (e.KeyChar) < 97 
                || (e.KeyChar) > 122)
                
            {
                e.Handled = true;
                MessageBox.Show("Solo letras y números", "Carácter no válido", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
            }
        }

        public static void Letras(KeyPressEventArgs e)
        {
            if((e.KeyChar) < 65 && e.KeyChar !=8
                || (e.KeyChar) > 90 && (e.KeyChar) < 97
                || (e.KeyChar) > 122)
            {
                e.Handled = true;
                MessageBox.Show("Solo letras", "Carácter no válido", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
            }
        }

        public static void Numeros(KeyPressEventArgs e)
        {
            if((e.KeyChar) < 48 && e.KeyChar != 8
                ||(e.KeyChar) > 57)

             {
                e.Handled = true;
                MessageBox.Show("Solo números", "Carácter no válido", MessageBoxButtons.OK,
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
