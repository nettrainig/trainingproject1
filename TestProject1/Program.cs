using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Threading.Tasks;

namespace TestProject1
{
    class Program
    {        
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            List<Product> products = new List<Product>() { new Product { ID = 1, Code = "B" }, new Product { ID = 2, Code = "A"}, new Product { ID = 3, Code = "C"}, new Product { ID = 4, Code = "B"} };

            products.Sort();
            products = products.Distinct<Product>(new ProductComparer()).ToList<Product>();

            foreach (var product in products)
                Console.WriteLine(product.Code);
                        
            LogManager.GetLogger(typeof(Program)).Info("test log message");

            Console.ReadLine();
        }
    }
}
