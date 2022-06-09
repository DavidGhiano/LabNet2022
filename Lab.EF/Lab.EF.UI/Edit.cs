using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class Edit
    {
        public static void EditEmployees()
        {
            Employees employees = new Employees();
            try
            {
                Console.Write("ID: ");
                employees.EmployeeID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nombre: ");
                employees.FirstName = Console.ReadLine();
                Console.Write("Apellido: ");
                employees.LastName = Console.ReadLine();

                EmployeesLogic employeesLogic = new EmployeesLogic();
                employeesLogic.Update(employees);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void EditShipper()
        {
            Shippers shippers = new Shippers();
            try
            {
                Console.Write("ID: ");
                shippers.ShipperID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nombre de la compañia: ");
                shippers.CompanyName = Console.ReadLine();
                ShippersLogic shippersLogic = new ShippersLogic();
                shippersLogic.Update(shippers);
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message);
                Console.ReadLine();
            }
        }
    }
}
