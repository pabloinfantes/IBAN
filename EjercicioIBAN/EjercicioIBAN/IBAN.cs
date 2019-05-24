using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionBancaria
{
    public class LongitudIncorrectaException : Exception { }
    public class ParametroNullException : Exception { }
    public class ParametroFormatoIncorrecto : Exception { }


    public class IBAN
    {


        public static string CalcularIBAN(string cadena)
        {
            string ES = "142800";
            string[] IbanFragmentado = new string[5]; 
            cadena = cadena + ES;
            string resultado = "";
            string tmp = "";
            IbanFragmentado[0] = cadena.Substring(0,5);
            IbanFragmentado[1] = cadena.Substring(5, 5);
            IbanFragmentado[2] = cadena.Substring(10, 5);
            IbanFragmentado[3] = cadena.Substring(15, 5);
            IbanFragmentado[4] = cadena.Substring(20, 6);
            for (int i = 0; i < IbanFragmentado.Length; i++)
            {
                tmp += IbanFragmentado[i];
                resultado = (int.Parse(tmp) % 97).ToString();
            }
            resultado = (98 - (int.Parse(resultado))).ToString();
            if (resultado.Length == 1)
            {
                resultado = "0" + resultado;
            }
            return resultado;
        }


        public static bool esUnCCValido(string cadena)
        {
            return (CalcularDC(cadena) == cadena.Substring(8, 2));
        }


        public static string CalcularDC(string cadena)
        {
            int[] multiplicador = new int[] { 4, 8, 5, 10, 9, 7, 3, 6, 0, 0, 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            string resultado;

            int acumulador1 = 0;
            int acumulador2 = 0;

            if (cadena == null)
            {
                throw new ParametroNullException();
            }

            if (cadena.Length != 20)
            {
                throw new LongitudIncorrectaException();
            }

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    acumulador1 += int.Parse(cadena[i].ToString()) * multiplicador[i];

                    acumulador2 += int.Parse(cadena[i + 10].ToString()) * multiplicador[i + 10];
                }
                catch (FormatException)
                {
                    throw new ParametroFormatoIncorrecto();
                }
            }
            int resultadoParcial = 11 - (acumulador1 % 11);
            if (resultadoParcial == 10)
                resultado = "1";
            else if (resultadoParcial == 11)
                resultado = "0";
            else
                resultado = resultadoParcial.ToString();


            resultadoParcial = 11 - (acumulador2 % 11);
            if (resultadoParcial == 10)
                resultado = "1";
            else if (resultadoParcial == 11)
                resultado = "0";
            else
                resultado += resultadoParcial.ToString();

            return resultado;
        }





    }
}
