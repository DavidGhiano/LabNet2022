using Lab.TP7.Data;
using Lab.TP7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TP7.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public void Add(Employees newObject)
        {
            context.Employees.Add(newObject);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                var employees = context.Employees.Find(id);
                context.Employees.Remove(employees);
                context.SaveChanges();

            }
            catch (Exception Ex)
            {

                throw;
            }
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employees GetOne(int id)
        {
            return context.Employees.First(e => e.EmployeeID == id);
        }

        public void Update(Employees objectUpdate)
        {
            var employee = context.Employees.Find(objectUpdate.EmployeeID);

            employee.FirstName = objectUpdate.FirstName;
            employee.LastName = objectUpdate.LastName;

            context.SaveChanges();
        }
    }
}
