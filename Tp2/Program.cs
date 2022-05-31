using System;
using static System.Console;
using Tp2.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            do
            {
                Clear();
                Menu();
                Write("Ingrese una opción: ");
                opcion = ReadLine();
                WriteLine(Environment.NewLine);
                WriteLine("---------------");
                switch (opcion)
                {
                    case "1":
                        try
                        {
                            WriteLine("Ingrese un número");
                            Write("--> ");
                            int numero = Convert.ToInt32(ReadLine());
                            numero.Dividir();
                        }
                        catch(FormatException ex)
                        {
                            WriteLine("Se esperaba un número y se ingreso valores alfanumericos");
                        }
                        ReadKey();
                        break;
                    case "2":
                        try
                        {
                            WriteLine("Ingrese un número");
                            Write("--> ");
                            int? divisor = Convert.ToInt32(ReadLine());
                            WriteLine("Ingrese un número");
                            Write("--> ");
                            int? dividendo = Convert.ToInt32(ReadLine());
                            MyExtension.DividirDosNumeros(divisor, dividendo);
                        }
                        catch (FormatException ex)
                        {
                            WriteLine("Se esperaba un número y se ingreso valores alfanumericos");
                            WriteLine("Seguro ingreso una letra o no ingresó nada");
                        }
                        ReadKey();
                        break;
                    case "3":
                        try
                        {
                            Logic logica = new Logic();
                            logica.Trigger();
                        }catch(Exception ex)
                        {
                            WriteLine(ex.Message);
                            WriteLine(Environment.NewLine);
                            WriteLine(ex.GetType().Name);

                        }
                        ReadKey();
                        break;
                    case "4":
                        try
                        {
                            Logic logica = new Logic();
                            logica.CustomTrigger();
                        }catch(Exception ex)
                        {
                            WriteLine(ex.Message);
                            WriteLine(Environment.NewLine);
                            WriteLine(ex.GetType().Name);
                        }
                        ReadKey();
                        break;
                    case "0":
                        WriteLine(Environment.NewLine);
                        WriteLine("Gracias por corregir =)");
                        ReadKey(true);
                        break;
                    default:
                        WriteLine("Opcion invalida, vuelva a intentar");
                        ReadKey(true);
                        break;
                }
            } while (opcion != "0");
        }

        static void Menu()
        {
            WriteLine("(1) Ejercicio 1: Método que divide por cero y devuelve un mensaje de excepción");
            WriteLine("(2) Ejercicio 2: Método que divide dos numeros y devuelve un mensaje de excepción si hubo error");
            WriteLine("(3) Ejercicio 3: Método de una clase que devuelve una excepción y se captura en la presentación");
            WriteLine("(4) Ejercicio 4: Método de una clase con una exceción personalizada");
            WriteLine("---------------");
            WriteLine("(0) Salir");
        }
    }
}
