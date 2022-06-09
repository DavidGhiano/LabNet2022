using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class Listar
    {
        public static void ListarEmployees()
        {
            var employees = new EmployeesLogic();
            Console.WriteLine("ID | APELLIDO, Nombre");
            Console.WriteLine("---------------------");
            foreach (var item in employees.GetAll())
            {
                Console.WriteLine($"{item.EmployeeID} | {item.LastName.ToUpper()}, {item.FirstName}");
            }
            Console.WriteLine("---------------------");
        }

        public static void ListarShippers()
        {
            var shippers = new ShippersLogic();
            Console.WriteLine("ID | Nombre de Compañia");
            Console.WriteLine("-----------------------");
            foreach(var item in shippers.GetAll())
            {
                Console.WriteLine($"{item.ShipperID} | {item.CompanyName}");
            }
            Console.WriteLine("-----------------------");
        }
    }
}
