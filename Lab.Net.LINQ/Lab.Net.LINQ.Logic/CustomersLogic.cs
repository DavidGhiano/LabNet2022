using Lab.Net.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customers GetFirstByCountry(string country)
        {

            var query = context.Customers.Where(c => c.Country == country);
            
            //var query = from customer in context.Customers
            //            where customer.Country == country
            //            select customer;

            return query.FirstOrDefault();
        }

        public List<Customers> GetAllRegionWA()
        {
            //var query = context.Customers.Where(c => c.Region == "WA");

            var query = from customer in context.Customers
                        where customer.Region == "WA"
                        select customer;

            return query.ToList();
        }

        public List<string> GetAllCompanyName()
        {
            var query = context.Customers.Select(c => c.CompanyName);

            //var query = from customer in context.Customers
            //            select customer.CompanyName;

            return query.ToList();
        }

        public List<Customers_Orders> GetCustomerByOrder()
        {
            DateTime fecha = Convert.ToDateTime("1/1/1997");
            var query = from customer in context.Customers
                        join order in context.Orders
                        on new { customer.CustomerID } equals new { order.CustomerID }
                        where customer.Region == "WA" && order.OrderDate > fecha
                        select new Customers_Orders
                        {
                            CompanyName = customer.CompanyName,
                            Region = customer.Region,
                            OrderID = order.OrderID,
                            OrderDate = order.OrderDate
                        };

            return query.ToList();
        }

        public IEnumerable<Customers> GetFirstThreeElements()
        {
            var query = context.Customers.Where(c => c.Region == "WA").Take(3);

            //var query = from customer in context.Customers
            //            where customer.Region == "WA"
            //            select customer;

            return query.ToList();
        }
        
        public List<Customers> GetCompanyNameOrder()
        {
            //var query = context.Customers.OrderBy(c => c.CompanyName);

            var query = from customer in context.Customers
                        orderby customer.CompanyName
                        select customer;

            return query.ToList();
        }

        public List<Customers_Orders> GetCustomersByOrders()
        {

            var query = (from customer in context.Customers
                         join order in context.Orders
                         on customer.CustomerID equals order.CustomerID
                         group customer by customer.CompanyName into c
                         select new Customers_Orders
                         {
                             Cantidad = c.Count(),
                             CompanyName = c.Key
                         });

            return query.ToList();
        }


    }
}
