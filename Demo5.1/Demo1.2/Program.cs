using Demo1._2.Context;
using System;
using System.Linq;

namespace Demo1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BikestoresDbContext())
            {

                var filter = from e in context.Products
                             select new { e.ProductName, e.Brand.BrandName, e.Category.CategoryName, e.ListPrice };
                  foreach(var product in filter)
                    {
                        Console.WriteLine(
                            $"{product.ProductName}, {product.BrandName}, {product.CategoryName} ({product.ListPrice})");
                    }
            }
        }
    }
}
