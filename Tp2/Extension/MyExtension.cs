using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Extension
{
    public static class MyExtension
    {
        public static void Dividir(this int value)
        {
            try
            {
                double d = value / 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Metodo terminado ! ! !");
            }
        }

        public static void DividirDosNumeros(int? dividendo, int? divisor)
        {
            try
            {
                double d = dividendo.Value / divisor.Value;
                Console.WriteLine(string.Format("El valor de dividir {0} con {1} es: {2}",dividendo, divisor, d));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("ERROR: Solo Chuck Norris divide por cero\r\r");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
