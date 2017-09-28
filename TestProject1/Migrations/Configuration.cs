namespace TestProject1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestProject1.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestProject1.TestContext context)
        {
            var products = new List<Product>()
            {
                new Product { ID = 1, Code = "B", Name = "Milk", Price = 1.3M },
                new Product { ID = 2, Code = "A", Name = "Water", Price = 0.2M },
                new Product { ID = 3, Code = "C", Name = "Meet", Price = 5M },
                new Product { ID = 4, Code = "B", Name = "Other water", Price = 0.25M },
                new Product { ID = 5, Code = "C", Name = "Other milk", Price = 1.2M },
                new Product { ID = 6, Code = "D", Name = "Pepper", Price = 1.5M},
                new Product { ID = 7, Code = "E", Name = "Tomato", Price = 0.8M},
                new Product { ID = 8, Code = "F", Name = "Tequila", Price = 13.7M}
           };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }
    }
}
