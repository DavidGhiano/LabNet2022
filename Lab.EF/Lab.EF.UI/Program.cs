using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            do
            {
                Console.Clear();
                Menus.MenuPrincipal();
                opcion = Console.ReadLine();
                Eleccion(opcion);
            } while (opcion != "0");

        }

        static void Eleccion(string opcion)
        {
            string opcionCrud = "";
            Console.Clear();
            switch (opcion)
            {
                case "1":
                    Listar.ListarEmployees();
                    Menus.MenuCRUD();
                    opcionCrud = Console.ReadLine();
                    EleccionEmployees(opcionCrud);
                    break;
                case "2":
                    Listar.ListarShippers();
                    Menus.MenuCRUD();
                    opcionCrud = Console.ReadLine();
                    EleccionShippers(opcionCrud);
                    break;
                case "0":
                    Console.WriteLine("Gracias por ver mi trabajo =)");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opción no valida, vuelva a intentar");
                    Console.ReadLine();
                    break;
            }
        }

        static void EleccionEmployees(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    Create.CreateEmployees();
                    break;
                case "2":
                    Edit.EditEmployees();
                    break;
                case "3":
                    Delete.DeleteEmployees();
                    break;
            }
        }

        static void EleccionShippers(string opcion)
        {
            switch (opcion)
            {
                case "1":
                    Create.CreateShipper();
                    break;
                case "2":
                    Edit.EditShipper();
                    break;
                case "3":
                    Delete.DeleteShipper();
                    break;
            }
        }

    }
}
