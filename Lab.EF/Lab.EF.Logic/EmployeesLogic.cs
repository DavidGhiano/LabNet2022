using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
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
            var employees = context.Employees.Find(id);
            context.Employees.Remove(employees);
            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
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
