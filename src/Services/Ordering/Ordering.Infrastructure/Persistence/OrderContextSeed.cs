using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredData());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredData()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn", 
                    FirstName = "Koustav", 
                    LastName = "Mishra", 
                    EmailAddress = "mkk6160@gmail.com", 
                    AddressLine = "Contai", 
                    State = "West Bengal",
                    Country = "India",
                    ZipCode = "721401",
                    TotalPrice = 350, 
                    CardName="KM", 
                    CardNumber="democard", 
                    CVV = "935", 
                    Expiration="10/27" }
            };
        }
    }
}
