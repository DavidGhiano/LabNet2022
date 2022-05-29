using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    internal class Program
    {
        public static List<TransportePublico> listaVehiculos = new List<TransportePublico>();
        static void Main(string[] args)
        {
            string opcion = "";
            Console.WriteLine("~~~Bienvenido al sistema de Transporte Público~~~");
            Console.ReadLine();
            do
            {
                Console.Clear();
                opcion = Menu();
                switch (opcion)
                {
                    case "1":
                        CrearTransporte();
                        break;
                    case "2":
                        ListarTransporte();
                        break;
                    case "3":
                        ModificarTransporte();
                        break;
                    case "4":
                        EliminarTransporte();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Gracias por elejirnos");
                        break;
                    default:
                        Console.WriteLine("Opción invalida.. ingrese opción correcta.");
                        break;
                }
                Console.ReadLine();
            }while (opcion != "0");


        }

        #region Crear Transporte
        static void CrearTransporte()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Elija tipo de Transporte Público");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1 Taxi");
                Console.WriteLine("2 Omnibus");
                Console.WriteLine("----------------");
                Console.WriteLine("0 Volver");
                Console.Write("-> ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "0":
                        break;
                    case "1":
                        CrearTaxi();
                        break;
                    case "2":
                        CrearOmnibus();
                        break;
                    default:
                        Console.WriteLine("Opción invalidad");
                        break;
                }
            } while (opcion != "0");
        }
        private static void CrearOmnibus()
        {
            string patente = GenerarApatente();
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese cantidad de pasajeros entre 1 y 100");
                Console.Write("-> ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    if (!ValidarCantidadPasajeros("Omnibus", opcion))
                    {
                        Console.WriteLine("Cantidad erronea");
                        Console.ReadLine();
                        continue;
                    }
                    listaVehiculos.Add(new Omnibus(patente, opcion));
                    Console.WriteLine("Omnibus ingresado con éxito");
                    Console.ReadLine();
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine("valor erroneo, por favor, ingrese un valor numérico");
                    Console.ReadLine();
                    continue;
                }

            } while (true);
        }
        private static void CrearTaxi()
        {
            string patente = GenerarApatente();
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese cantidad de pasajeros entre 1 y 4");
                Console.Write("-> ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    if (!ValidarCantidadPasajeros("Taxi", opcion))
                    {
                        Console.WriteLine("Cantidad erronea");
                        Console.ReadLine();
                        continue;
                    }
                    listaVehiculos.Add(new Taxi(patente, opcion));
                    Console.WriteLine("Taxi ingresado con éxito");
                    Console.ReadLine();
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine("valor erroneo, por favor, ingrese un valor numérico");
                    Console.ReadLine();
                    continue;
                }

            } while (true);
        }
        #endregion
        #region Listar Transporte
        private static void ListarTransporte()
        {
            Console.Clear();
            foreach(TransportePublico transporte in listaVehiculos)
            {
                transporte.Info();
            }
        }
        #endregion
        #region Modificar Transporte
        private static void ModificarTransporte()
        {
            string patente = "";
            int pasajeros = 0;
            TransportePublico transporte = null;
            do
            {
                Console.Clear();
                ListarTransporte();
                Console.WriteLine("Selecciona un Transporte por su apatente: ");
                Console.WriteLine("------------");
                Console.WriteLine("0 Volver");
                Console.Write("-->");
                patente = Console.ReadLine().ToUpper();
                //Buscar transporte por patente
                if (patente == "0") break;
                foreach(TransportePublico vehiculo in listaVehiculos)
                {
                    if(vehiculo.patente == patente)
                    {
                        transporte = vehiculo;
                    }
                }
                //si no hay pregunta de nuevo
                if(transporte == null)
                {
                    Console.WriteLine("Patente mal ingresado o no hubo coinsidencia.. vuelva a probar");
                    continue;
                }
                
                listaVehiculos.Remove(transporte);
                
                do
                {
                    Console.Clear();
                    transporte.Info();
                    Console.WriteLine("Ingrese cantidad de pasajeros");
                    Console.Write("-->");
                    try
                    {
                        pasajeros = Convert.ToInt32(Console.ReadLine());
                        if (!ValidarCantidadPasajeros(transporte.tipo, pasajeros))
                        {
                            Console.WriteLine("Cantidad de pasajeros fuera del rango");
                            Console.ReadLine();
                            continue;
                        }
                        transporte.pasajeros = pasajeros;
                        listaVehiculos.Add(transporte);
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("valor erroneo, por favor, ingrese un valor numérico");
                        Console.ReadLine();
                        continue;
                    }

                } while (!ValidarCantidadPasajeros(transporte.tipo, pasajeros));
            } while (patente != "0");
        }
        #endregion
        #region Eliminar Transporte
        private static void EliminarTransporte()
        {
            string patente = "";
            int pasajeros = 0;
            TransportePublico transporte = null;
            do
            {
                Console.Clear();
                ListarTransporte();
                Console.WriteLine("Selecciona un Transporte por su apatente: ");
                Console.WriteLine("------------");
                Console.WriteLine("0 Volver");
                Console.Write("-->");
                patente = Console.ReadLine().ToUpper();
                //Buscar transporte por patente
                if (patente == "0") break;
                foreach (TransportePublico vehiculo in listaVehiculos)
                {
                    if (vehiculo.patente == patente)
                    {
                        transporte = vehiculo;
                    }
                }
                //si no hay pregunta de nuevo
                if (transporte == null)
                {
                    Console.WriteLine("Patente mal ingresado o no hubo coinsidencia.. vuelva a probar");
                    continue;
                }

                listaVehiculos.Remove(transporte);
            } while (patente != "0");
        }
        #endregion
        #region UTILIDADES
        static string Menu()
        {
            Estadisticas();
            string opcion;
            Console.WriteLine("Elija una opción");
            Console.WriteLine("----------------");
            Console.WriteLine("1 Ingresar un Transporte Público");
            Console.WriteLine("2 Ver los Transporte ingresados");
            Console.WriteLine("3 Actualizar un Transporte");
            Console.WriteLine("4 Eliminar un Transporte");
            Console.WriteLine("----------------");
            Console.WriteLine("0 Salir");
            Console.Write("--> ");
            opcion = Console.ReadLine();
            return opcion;

        }
        private static bool ValidarCantidadPasajeros(string tipo, int opcion)
        {
            if (tipo == "Taxi")
            {
                if (opcion < 1 || opcion > 4)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (opcion < 1 || opcion > 100)
                {
                    return false;
                }
                return true;
            }
        }
        static string GenerarApatente()
        {
            string patente = "";
            Random r = new Random();
            for(int i = 0; i < 3; i++)
            {
                patente += Convert.ToChar(((int)'A') + r.Next(26)).ToString();
            }
            patente +=  " ";
            for (int i = 0; i < 3; i++)
            {
                patente += r.Next(10);
            }

            return patente;
        }

        static void Estadisticas()
        {
            int taxi = 0;
            int taxiPasajeros = 0;
            int omnibus = 0;
            int omnibusPasajeros = 0;
            if(listaVehiculos.Count != 0)
            {
                foreach(TransportePublico vehiculo in listaVehiculos)
                {
                    if(vehiculo.tipo.ToUpper() == "TAXI")
                    {
                        taxi += 1;
                        taxiPasajeros += vehiculo.pasajeros;
                    }
                    else
                    {
                        omnibus += 1;
                        omnibusPasajeros += vehiculo.pasajeros;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Taxis: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{taxi}\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Pasajeros: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{taxiPasajeros}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Omnibus: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{omnibus}\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Pasajeros: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{omnibusPasajeros}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("----------TOTAL----------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Vehiculos: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{omnibus + taxi}\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Pasajeros: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{omnibusPasajeros + taxiPasajeros}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\r\r");
            }
        }
        #endregion
    }
}
