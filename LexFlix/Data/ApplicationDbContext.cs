using LexFlix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexFlix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderRows> OrderRows { get; set; }

        public DbSet<Movies> Movies { get; set; }
    }
}