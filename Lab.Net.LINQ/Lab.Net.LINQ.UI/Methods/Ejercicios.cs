using Lab.Net.LINQ.Entities;
using Lab.Net.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.UI.Methods
{
    public static class Ejercicios
    {
        private static CustomersLogic customersLogic = new CustomersLogic();
        private static ProductsLogic productsLogic = new ProductsLogic();
        /// <summary>
        /// 1. Query para devolver objeto customer
        /// </summary>
        public static void EjercicioUno()
        {
            Customers customer = customersLogic.GetFirstByCountry("Mexico");
            ImprimirDatos("Nombre de la compañia: ", customer.CompanyName);
            ImprimirDatos("Ubicada en: ", customer.Country);
            Console.WriteLine("------------------------");
        }

        /// <summary>
        ///2. Query para devolver todos los productos sin stock 
        /// </summary>
        public static void EjercicioDos()
        {
            List<Products> products = productsLogic.GetNotStock();
            Console.WriteLine("PRODUCTOS SIN STOCK");
            Console.WriteLine("-------------------");
            foreach (Products product in products)
            {
                Console.WriteLine($"- {product.ProductName}");
            }
        }
        //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad
        public static void EjercicioTres()
        {
            List<Products> products = productsLogic.GetStockThreeByUnit();
            foreach (var item in products)
            {
                ImprimirDatos("Producto: ", item.ProductName);
                ImprimirDatos("Stock: ", item.UnitsInStock.ToString());
                ImprimirDatos("Precio Unitario: ", item.UnitPrice.ToString());
                Console.WriteLine("-----------------------");
            }
        }
        //4. Query para devolver todos los customers de la Región WA
        public static void EjercicioCuatro()
        {
            List<Customers> customers = customersLogic.GetAllRegionWA();
            foreach (var item in customers)
            {
                Console.WriteLine($"- {item.CompanyName}");
            }
        }
        //5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
        public static void EjercicioCinco()
        {
            Products product = productsLogic.GetFirstByID();
            if (product != null)
            {
                Console.WriteLine($"- {product.ProductName}");
            }
            else
            {
                Console.WriteLine("No se encontró el número del producto con ID 789");
            }
        }
        //6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.
        public static void EjercicioSeis()
        {
            List<string> companyName= customersLogic.GetAllCompanyName();
            Console.WriteLine("-------Nombres-------");
            foreach (var item in companyName)
            {
                Console.WriteLine("---------------------");
                ImprimirDatos("+ ", item.ToUpper());
                ImprimirDatos("- ", item.ToLower());
            }
            Console.WriteLine("---------------------");
        }
        //7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.
        public static void EjercicioSiete()
        {
            List<Customers_Orders> customerOrders = customersLogic.GetCustomerByOrder();

            foreach (var item in customerOrders)
            {
                ImprimirDatos("- Nombre de compañia: ", item.CompanyName);
                ImprimirDatos("- Region: ", item.Region);
                ImprimirDatos("- Numero de Orden: ", item.OrderID.ToString());
                ImprimirDatos("- Fecha: ", item.OrderDate.ToString());
                Console.WriteLine("---------------------");
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
