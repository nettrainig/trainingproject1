using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() { new Product { ID = 1, Code = "B" }, new Product { ID = 2, Code = "A"}, new Product { ID = 3, Code = "C"} };
            products.Sort();
            foreach (var product in products)
                Console.WriteLine(product.Code);            
            Console.ReadLine();
        }
    }
}
