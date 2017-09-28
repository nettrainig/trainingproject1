using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using log4net;

namespace TestProject1
{
    class Program
    {
        private static void SortDistictAndShowProducts(TestContext tc)
        {
            var sortedProducts = tc.Products.ToList<Product>();

            sortedProducts.Sort();
            sortedProducts = sortedProducts.Distinct<Product>(new ProductComparer()).ToList<Product>();

            foreach (var product in sortedProducts)
                Console.WriteLine(product.Code);
        }

        private static void UpdatePrice(TestContext tc)
        {
            var products = tc.Products.ToList<Product>();

            Console.WriteLine("Enter ID to edit price:");
            int i = 0;
            int.TryParse(Console.ReadLine(), out i);

            var p = products.Find(pr => pr.ID == i);
            if (p == null)
                LogManager.GetLogger(typeof(Program)).Warn("can't find product with entered id.");
            else
            {
                Decimal d = 0;
                Console.WriteLine("Enter new price:");
                if (Decimal.TryParse(Console.ReadLine(), out d))
                    p.Price = d;
                else
                    LogManager.GetLogger(typeof(Program)).Warn("incorrect price for a product.");

                tc.Entry(p).State = EntityState.Modified;
                tc.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            TestContext tc = new TestContext();

            SortDistictAndShowProducts(tc);
            
            UpdatePrice(tc);

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
