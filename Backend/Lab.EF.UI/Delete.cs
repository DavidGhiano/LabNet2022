using Lab.TP7.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.UI
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
            catch (DbUpdateException ex)
            {
                Console.WriteLine("El registro no se puede eliminar porque está ligado a una Compra.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
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
            catch(DbUpdateException ex)
            {
                Console.WriteLine("El registro no se puede eliminar porque está ligado a una Compra.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

    }

}
