using Lab.Net.LINQ.Entities;
using Lab.Net.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.UI.Methods
{
    public static class OtrosEjercicios
    {
        private static CustomersLogic customersLogic = new CustomersLogic();
        private static ProductsLogic productsLogic = new ProductsLogic();
        //8. Query para devolver los primeros 3 Customers de la  Región WA
        public static void EjercicioOcho()
        {
            IEnumerable<Customers> customers = customersLogic.GetFirstThreeElements();
            foreach (Customers customer in customers)
            {
                ImprimirDatos("Nombre de companía: ", customer.CompanyName);
            }

        }
        //9. Query para devolver lista de productos ordenados por nombre
        public static void EjercicioNueve()
        {
            var customers = customersLogic.GetCompanyNameOrder();
            foreach(var item in customers)
            {
                ImprimirDatos("- ", item.CompanyName);
            }
        }
        //10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.
        public static void EjercicioDiez()
        {
            List<Products> products = productsLogic.GetStockOrderDesc();
            Console.WriteLine("-----------------");
            foreach(var item in products)
            {
                ImprimirDatos("-Nombre del producto: ", item.ProductName);
                ImprimirDatos("-Unidades: ", item.UnitsInStock.ToString());
                Console.WriteLine("-----------------");
            }
        }
        //11. Query para devolver las distintas categorías asociadas a los productos
        public static void EjercicioOnce()
        {
            List<Products_Categories> productsCategories = productsLogic.GetProductWithCategorie();
            Console.WriteLine("-----------------");
            foreach(var item in productsCategories)
            {
                ImprimirDatos("-Producto: ", item.ProductName);
                ImprimirDatos("-Categoria ", item.CategoryName);
                Console.WriteLine("-----------------");
            }
        }
        //12. Query para devolver el primer elemento de una lista de productos
        public static void EjercicioDoce()
        {
            Products product = productsLogic.GetFirst();
        }
        //13. Query para devolver los customer con la cantidad de ordenes asociadas
        public static void EjercicioTrece()
        {
            List<Customers_Orders> customersOrders = customersLogic.GetCustomersByOrders();
            foreach(var item in customersOrders)
            {
                ImprimirDatos("Nombre de compañía: ", item.CompanyName);
                ImprimirDatos("Cantidad: ", item.Cantidad.ToString());
                Console.WriteLine("-----------------");
            }
        }

        private static void ImprimirDatos(string campo, string valor)
        {
            Console.Write(campo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(valor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
