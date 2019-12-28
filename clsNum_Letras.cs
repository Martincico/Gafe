using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace GAFE
{
    class clsNum_Letras
    {
        private double tyCantidad;
        private int lyCantidad = 0;
        private int lnDigito;

        private String PesosMN = "";

        //Obtenemos lo decimal y lo convertimos a entero
        private int lyCentavos;

        String[] laUnidades = new String[] {"UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ",
                                        "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO",
                                        "DIECINUEVE", "VEINTE", "VEINTIUN", "VEINTIDOS", "VEINTITRES", "VEINTICUATRO", "VEINTICINCO",
                                        "VEINTISEIS", "VEINTISIETE", "VEINTIOCHO", "VEINTINUEVE"};
        String[] laDecenas = new String[] { "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };
        String[] laCentenas = new String[] {"CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS",
                                        "OCHOCIENTOS", "NOVECIENTOS"};
        int lnNumeroBloques = 1;

        NumberFormatInfo nfi = new CultureInfo("es-MX", false).NumberFormat;

        public clsNum_Letras()
        {
        }


        public String Convertir(String numero, int IntDec)
        {
            numero = numero.Replace("$", "").Replace(",", "").Trim();

            tyCantidad = Convert.ToDouble(numero);


            lyCantidad = (int)tyCantidad;

            //DecimalFormat df = new DecimalFormat("#.##");
            nfi.CurrencyPositivePattern = IntDec;
            //df.format(0.912385);

            double CantDouble = (tyCantidad - lyCantidad);
            String CantDouble2 = string.Format(nfi, "{0:C}", CantDouble); //df.format(CantDouble);
            CantDouble2 = CantDouble2.Replace("$", "").Replace(",", "").Trim();

            lyCentavos = (int)(Convert.ToDouble(CantDouble2) * 100);


            do
            {
                int lnPrimerDigito = 0, lnSegundoDigito = 0, lnTercerDigito = 0, lnBloqueCero = 0;
                String lcBloque = "";

                for (int i = 1; i <= 3; i++)
                {
                    lnDigito = lyCantidad % 10;
                    if (lnDigito != 0)
                    {
                        switch (i)
                        {
                            case 1:
                                lcBloque = " " + laUnidades[lnDigito - 1];
                                lnPrimerDigito = lnDigito;
                                break;
                            case 2:
                                if (lnDigito <= 2)
                                    lcBloque = " " + laUnidades[(lnDigito * 10) + lnPrimerDigito - 1];
                                else
                                    lcBloque = " " + laDecenas[lnDigito - 1] + ((lnPrimerDigito != 0) ? " Y" : "Null") + lcBloque;

                                lnSegundoDigito = lnDigito;
                                break;
                            case 3:
                                lcBloque = " " + ((lnDigito == 1 && lnPrimerDigito == 0 && lnSegundoDigito == 0) ? " CIEN " : laCentenas[lnDigito - 1]) + lcBloque;
                                lnTercerDigito = lnDigito;
                                break;
                        }//termina switch
                    }//Termina If
                    else
                        lnBloqueCero = lnBloqueCero + 1;

                    lyCantidad = (int)lyCantidad / 10;
                    if (lyCantidad == 0)
                        break;

                }//termina for
                switch (lnNumeroBloques)
                {
                    case 1: PesosMN = lcBloque; break;
                    case 2:
                        PesosMN = lcBloque + ((lnBloqueCero == 3) ? " " : " MIL") + PesosMN;
                        break;
                    case 3:
                        PesosMN = lcBloque + ((lnPrimerDigito == 1 && lnSegundoDigito == 0 && lnTercerDigito == 0) ? " MILLON" : " MILLONES") + PesosMN;
                        break;
                }
                lnNumeroBloques = lnNumeroBloques + 1;

            } while (lyCantidad != 0);

            PesosMN = "(" + PesosMN + ((tyCantidad > 1) ? " PESOS " : " PESO ") + lyCentavos + "/100 M.N.)";
            return PesosMN;
        }


    }
}
