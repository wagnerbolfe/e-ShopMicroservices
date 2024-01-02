using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class SeedData
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<SeedData> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", nameof(OrderContext));
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "wag", 
                    FirstName = "Wagner", 
                    LastName = "Bolfe", 
                    EmailAddress = "wagnerbolfe@gmail.com", 
                    AddressLine = "Rio Branco", 
                    Country = "Brazil", 
                    TotalPrice = 350
                }
            };
        }
    }
}