using Lab.Net.LINQ.UI.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            do
            {
                Console.Clear();
                Menu();
                Console.Write("----> ");
                opcion = Console.ReadLine();
                eleccion(opcion);
                Console.ReadLine();
            }while (opcion != "0");
        }

        static void Menu()
        {
            Console.WriteLine("Selecciona el ejercicio");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Ejercicio 1");
            Console.WriteLine("2 - Ejercicio 2");
            Console.WriteLine("3 - Ejercicio 3");
            Console.WriteLine("4 - Ejercicio 4");
            Console.WriteLine("5 - Ejercicio 5");
            Console.WriteLine("6 - Ejercicio 6");
            Console.WriteLine("7 - Ejercicio 7");
            Console.WriteLine("8 - Ejercicio 8");
            Console.WriteLine("9 - Ejercicio 9");
            Console.WriteLine("10 - Ejercicio 10");
            Console.WriteLine("11 - Ejercicio 11");
            Console.WriteLine("12 - Ejercicio 12");
            Console.WriteLine("13 - Ejercicio 13");

            Console.WriteLine("-------------");
            Console.WriteLine("0 - Salir");
        }

        static void eleccion(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    Ejercicios.EjercicioUno();
                    break;
                case "2":
                    Ejercicios.EjercicioDos();
                    break;
                case "3":
                    Ejercicios.EjercicioTres();
                    break;
                case "4":
                    Ejercicios.EjercicioCuatro();
                    break;
                case "5":
                    Ejercicios.EjercicioCinco();
                    break;
                case "6":
                    Ejercicios.EjercicioSeis();
                    break;
                case "7":
                    Ejercicios.EjercicioSiete();
                    break;
                case "8":
                    OtrosEjercicios.EjercicioOcho();
                    break;
                case "9":
                    OtrosEjercicios.EjercicioNueve();
                    break;
                case "10":
                    OtrosEjercicios.EjercicioDiez();
                    break;
                case "11":
                    OtrosEjercicios.EjercicioOnce();
                    break;
                case "12":
                    OtrosEjercicios.EjercicioDoce();
                    break;
                case "13":
                    OtrosEjercicios.EjercicioTrece();
                    break;

                case "0":
                    Console.WriteLine("Gracias por corregir mi trabajo :D");
                    break;
                default:
                    Console.WriteLine("Opción invalida");
                    break;
            }
        }
    }
}
