using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace TestProject1
{
    class TestDataGenerator
    {        
        private readonly string OrderDetailsName = "OrderDetails";

        private readonly string SelectOrderDetailsSQL = 
            "SELECT TOP {0} ID, {1}, ProductID, ProductQuantity " +
            "FROM OrderDetails";
        
        private const string formatMessage = "using AutoDetectChangesEnabled = {0} inserting {1} {2} takes {3} ms. ";  //expl: using AutoDetectChangesEnabled = false inserting 500 orders takes 109 ms.

        private void GenerateData(int count, bool usingChangeTracking, Func<TestContext, int> DoAction, string message)
        {
            using (var context = new TestContext())
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();

                    context.Configuration.AutoDetectChangesEnabled = usingChangeTracking;
                    int rescount = DoAction(context);

                    sw.Stop();
                    
                    Console.WriteLine(string.Format(formatMessage, usingChangeTracking, rescount, message, sw.ElapsedMilliseconds));
                }
                finally
                {
                    if (!usingChangeTracking)
                        context.Configuration.AutoDetectChangesEnabled = true;
                }
            }
        }

        public void GenerateOrders(int count, bool usingChangeTracking)
        {
            GenerateData(count, 
                usingChangeTracking, 
                ct => 
                {
                    Random r = new Random();                    
                    int lastOrderID = ct.Orders.Max<Order>(o => o.ID);
                    for (int i = 1; i <= count; i++)
                        ct.Orders.Add(new Order() { ID = lastOrderID + i, ClientID = r.Next(4) + 1, DateCreated = DateTime.Now});
                    ct.SaveChanges();
                    return count;
                },
                "Order values");
        }

        public void GenerateOrderDetails(int count, bool usingChangeTracking)
        {            
            GenerateData(count,
                usingChangeTracking,
                ct =>
                {
                    string connectionString = ct.Database.Connection.ConnectionString;
                    SqlConnection sourceConnection = new SqlConnection(connectionString);
                    sourceConnection.Open();
                    var orders = ct.Orders.ToList<Order>();
                    orders.ForEach(o =>
                    {
                        SqlCommand commandSourceData = new SqlCommand(string.Format(SelectOrderDetailsSQL, count, o.ID), sourceConnection);

                        SqlDataReader reader = commandSourceData.ExecuteReader();
                        try
                        {

                            using (var bulkCopy = new SqlBulkCopy(connectionString))
                            {
                                bulkCopy.DestinationTableName = OrderDetailsName;
                                bulkCopy.WriteToServer(reader);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    });                   
                    return orders.Count * count;
                },
                "Order Details values");
        }
    }
}
