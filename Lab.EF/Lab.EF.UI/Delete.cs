using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class Delete
    {

        public static void DeleteEmployees()
        {
            try
            {
                Console.Write("ID del registro a eliminar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                EmployeesLogic employeesLogic = new EmployeesLogic();
                employeesLogic.Delete(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void DeleteShipper()
        {
            try
            {
                Console.Write("ID del registro a eliminar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                ShippersLogic shippersLogic = new ShippersLogic();
                shippersLogic.Delete(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

    }

}
