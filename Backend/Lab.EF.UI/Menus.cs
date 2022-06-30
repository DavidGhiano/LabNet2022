using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.UI
{
    public class Menus
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("Seleccionar una opción: ");
            Console.WriteLine("1 - Empleados");
            Console.WriteLine("2 - Transporte");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("------------------------");
            Console.Write("---> ");
        }

        public static void MenuCRUD()
        {
            Console.WriteLine("Elige una opción: ");
            Console.WriteLine("1 - Crear");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("3 - Eliminar");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("------------------");
            Console.Write("---> ");
        }
    }
}
