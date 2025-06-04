using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo1
{
    
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        static List<Product> products = new List<Product>() {
        new Product(){ProductId=1,Name="Mouse",Quantity=2,Description="Wireless",Price=1300,Category="iball"},
         new Product(){ProductId=1,Name="Mouse",Quantity=2,Description="Wired",Price=1300,Category="ibox"},
         new Product(){ProductId=2,Name="Keyboard",Quantity=12,Description="Wireless",Price=3220,Category="iball"},
         new Product(){ProductId=3,Name="Laptop",Quantity=22,Description="HD and Touch",Price=87000,Category="Hp"},
         new Product(){ProductId=4,Name="Cooling Pad",Quantity=32,Description="test",Price=2000,Category="Gamerz"},
         new Product(){ProductId=5,Name="Monitor",Quantity=42,Description="LED",Price=6000,Category="Hp"},
              new Product(){ProductId=6,Name="projector",Quantity=12,Description="Wired",Price=1700,Category="Hp"},
         new Product(){ProductId=7,Name="Pencil",Quantity=62,Description="Color pencil",Price=170,Category="Stationary"},
              new Product(){ProductId=8,Name="Scale",Quantity=42,Description="long size",Price=100, Category = "Stationary"},
        };
        public List<Product> GetAllProducts()
        {
            return products;
        }
        public void Demo()
        {
            //var productsPriceMorethan5000 = products.Where(p => p.Price >= 5000);
            //foreach (var product in productsPriceMorethan5000)
            //{
            //    Console.WriteLine($"{product.ProductId} \t {product.Name}\t {product.Price}");
            //}

            ////Example for order by
            //var orderbyProductName = from p in products
            //                         orderby p.Name descending
            //                         select p;

            //var orderbyProductName1 = products.OrderByDescending(p => p.Name);

            //foreach (var product in orderbyProductName1)
            //{
            //    Console.WriteLine($"{product.Name}");
            //}

            //var ordebyPriceName = from p in products
            //                      orderby p.Name ascending, p.Price descending
            //                      select new { p.Name, p.Price };

            //var ordebyPriceName1 = products.OrderByDescending(p => p.Name)
            //                       .ThenBy(p => p.Price);

            //foreach (var product in ordebyPriceName1)
            //{
            //    Console.WriteLine($"{product.Name}\t {product.Price}");
            //}


            //Example for Group by

            //Query Syntax

           //var  groupedProducts = from p in products
           //                   group p by p.Category;

           // var groupedProducts2 =products.GroupBy(p => p.Category);
           // foreach(var categoryGroup in groupedProducts)
           // {
           //     Console.WriteLine("Category :"+categoryGroup.Key);
           //     foreach (var product in categoryGroup)
           //     {
           //         Console.WriteLine($"{product.Name}\t {product.Description}\t{product.Price}");
           //     }
           // }
        }
    }
}
