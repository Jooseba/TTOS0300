using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCashMachine
{
    public static class Products
    {
        public static List<Product> GetAllProducts()
        {
            //Create some products for sample
            Product Kahvi = new Product() { Name = "Kahvi", Price = 1.5F };
            Product Tee = new Product() { Name = "Tee", Price = 1.1F };
            Product Pulla = new Product() { Name = "Pulla", Price = 1.6F };
            Product Sämpylä = new Product() { Name = "Sämpylä", Price = 2.5F };
            Product Suklaa = new Product() { Name = "Suklaa", Price = 1.3F };

            //return products
            List<Product> products = new List<Product>();
            products.Add(Kahvi);
            products.Add(Tee);
            products.Add(Pulla);
            products.Add(Sämpylä);
            products.Add(Suklaa);
            products.Add(new Product() { Name = "Laku", Price = 0.8F });
            return products;
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public override string ToString()
        {
            return $"{Name} {Price.ToString("C")}";
        }
    }
}
