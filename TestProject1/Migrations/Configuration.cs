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
            //products
            var products = new List<Product>()
            {
                new Product { ID = 1, Code = "B", Name = "Milk", Price = 1.3M },
                new Product { ID = 2, Code = "A", Name = "Water", Price = 0.2M },
                new Product { ID = 3, Code = "C", Name = "Meet", Price = 5M },
                new Product { ID = 4, Code = "B", Name = "Other water", Price = 0.25M },
                new Product { ID = 5, Code = "C", Name = "Other milk", Price = 1.2M },
                new Product { ID = 6, Code = "D", Name = "Pepper", Price = 1.5M},
                new Product { ID = 7, Code = "E", Name = "Tomato", Price = 0.8M},
                new Product { ID = 8, Code = "F", Name = "Tequila", Price = 13.7M},
                new Product { ID = 9, Code = "G", Name = "Rum", Price = 11.2M},
                new Product { ID = 10, Code = "H", Name = "Gun", Price = 140M}
           };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var clients = new List<Client>()
            {
                new Client { ID = 1, Name = "John Doe"},
                new Client { ID = 2, Name = "(Captain) Jack Sparrow"},
                new Client { ID = 3, Name = "Han Solo"},
                new Client { ID = 4, Name = "Vito Corleone"},
                new Client { ID = 5, Name = "Django"}
            };

            clients.ForEach(s => context.Clients.AddOrUpdate(c => c.ID, s));
            context.SaveChanges();

            var orders = new List<Order>()
            {
                new Order { ID = 1, ClientID = 1, DateCreated = new DateTime(2017, 3, 25)},
                new Order { ID = 2, ClientID = 2, DateCreated = new DateTime(2017, 5, 4)},
                new Order { ID = 3, ClientID = 2, DateCreated = new DateTime(2017, 5, 5)},
                new Order { ID = 4, ClientID = 4, DateCreated = new DateTime(2017, 8, 14)},
                new Order { ID = 5, ClientID = 4, DateCreated = new DateTime(2017, 8, 14)},
                new Order { ID = 6, ClientID = 5, DateCreated = new DateTime(2017, 9, 1)},
                new Order { ID = 7, ClientID = 2, DateCreated = new DateTime(2017, 5, 9)}
            };

            orders.ForEach(s => context.Orders.AddOrUpdate(o => o.ID, s));
            context.SaveChanges();

            var orderDetails = new List<OrderDetails>()
            {
                new OrderDetails { ID = 1, OrderID = 1, ProductID = 1, ProductQuantity = 2},
                new OrderDetails { ID = 2, OrderID = 1, ProductID = 2, ProductQuantity = 3},
                new OrderDetails { ID = 3, OrderID = 1, ProductID = 3, ProductQuantity = 1},
                new OrderDetails { ID = 4, OrderID = 2, ProductID = 9, ProductQuantity = 10},
                new OrderDetails { ID = 5, OrderID = 2, ProductID = 9, ProductQuantity = 10},
                new OrderDetails { ID = 6, OrderID = 3, ProductID = 8, ProductQuantity = 5},
                new OrderDetails { ID = 7, OrderID = 4, ProductID = 10, ProductQuantity = 8},
                new OrderDetails { ID = 8, OrderID = 5, ProductID = 8, ProductQuantity = 1},
                new OrderDetails { ID = 9, OrderID = 6, ProductID = 10, ProductQuantity = 4},
                new OrderDetails { ID = 10, OrderID = 7, ProductID = 9, ProductQuantity = 8}
            };

            orderDetails.ForEach(s => context.OrderDetails.AddOrUpdate(od => od.ID, s));
            context.SaveChanges();
        }
    }
}
