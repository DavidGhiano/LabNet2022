using Lab.TP7.Entities;
using Lab.TP7.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.UI
{
    public class Create
    {
        public static void CreateEmployees()
        {
            Employees employees = new Employees();
            Console.Write("Nombre: ");
            employees.FirstName = Console.ReadLine();
            Console.Write("Apellido: ");
            employees.LastName = Console.ReadLine();
            EmployeesLogic employeesLogic = new EmployeesLogic();
            employeesLogic.Add(employees);
        }



        public static void CreateShipper()
        {
            Shippers shippers = new Shippers();
            Console.Write("Nombre de la compañia: ");
            shippers.CompanyName = Console.ReadLine();
            ShippersLogic shippersLogic = new ShippersLogic();
            shippersLogic.Add(shippers); 
        }



    }
}
