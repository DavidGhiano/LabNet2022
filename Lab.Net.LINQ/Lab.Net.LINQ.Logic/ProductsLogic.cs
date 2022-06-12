using Lab.Net.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.LINQ.Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products>
    {
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public List<Products> GetNotStock()
        {
            var query = context.Products.Where(p => p.UnitsInStock == 0);

            //var query = from product in context.Products
            //            where product.UnitsInStock == 0
            //            select product;

            return query.ToList();
        }

        public List<Products> GetStockThreeByUnit()
        {
            //var query = context.Products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3);

            var query = from product in context.Products
                        where product.UnitsInStock > 0 && product.UnitPrice > 3
                        select product;

            return query.ToList();
        }

        public Products GetFirstByID()
        {
            var query = context.Products.Where(p => p.ProductID == 789);

            //var query = from product in context.Products
            //            where product.ProductID == 789
            //            select product;

            return query.FirstOrDefault();
        }

        public List<Products> GetStockOrderDesc()
        {
            //var query = context.Products.OrderByDescending(p => p.UnitsInStock);

            var query = from product in context.Products
                        orderby product.UnitsInStock descending
                        select product;

            return query.ToList();
        }

        public List<Products_Categories> GetProductWithCategorie()
        {
            var query = context.Products.Join(context.Categories,
                                                p => p.CategoryID,
                                                c => c.CategoryID,
                                                (p, c) => new Products_Categories
                                                {
                                                    ProductName = p.ProductName,
                                                    CategoryName = c.CategoryName
                                                });

            //var query = from product in context.Products
            //            join category in context.Categories
            //            on product.CategoryID equals category.CategoryID
            //            select new Products_Categories
            //            {
            //                ProductName = product.ProductName,
            //                CategoryName = category.CategoryName
            //            };

            return query.ToList();
        }

        public Products GetFirst()
        {
            //var query = context.Products.ToList();

            var query = from product in context.Products
                        select product;


            return query.First();
        }
    }
}
