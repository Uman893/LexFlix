using LexFlix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LexFlix.Data;
using System;
using System.Linq;

namespace LexFlix.Models
{
    public static class SeedCustomersData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Customers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Customers.AddRange(
                    new Customer
                    {
                       FirstName = "Todd",
                       LastName = "Michels",
                       BillingAddress = "Gullbergsgatan 3",
                       BillingZip ="57658",
                       BillingCity = "Linköping",
                       DeliveryAddress = "Industrialgatan 4",
                       DeliveryZip = "466768",
                       DeliveryCity = "Linköping",
                       Email = "tester1@gmail.com",
                       PhoneNo = "9368576595"
                    },

                    new Customer
                    {
                        FirstName = "Alexander",
                        LastName = "Stigberg",
                        BillingAddress = "Skolgatan 3",
                        BillingZip = "55312",
                        BillingCity = "Linköping",
                        DeliveryAddress = "Skolgatan 3",
                        DeliveryZip = "55312",
                        DeliveryCity = "Linköping",
                        Email = "testtest@gmail.com",
                        PhoneNo = "4839312354"
                    },

                    new Customer
                    {
                        FirstName = "Adam",
                        LastName = "Fågel",
                        BillingAddress = "Fiskvägen 18",
                        BillingZip = "083213",
                        BillingCity = "Stockholm",
                        DeliveryAddress = "Fiskvägen 18",
                        DeliveryZip = "083213",
                        DeliveryCity = "Stockholm",
                        Email = "yadayada@gmail.com",
                        PhoneNo = "0843325671"
                    },

                    new Customer
                    {
                        FirstName = "Erik",
                        LastName = "Halsström",
                        BillingAddress = "Gatanvägen 5",
                        BillingZip = "67532",
                        BillingCity = "Göteborg",
                        DeliveryAddress = "Gatanvägen 5",
                        DeliveryZip = "67532",
                        DeliveryCity = "Göteborg",
                        Email = "blablabal@gmail.com",
                        PhoneNo = "0983456781"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}