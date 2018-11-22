using System;
using Microsoft.EntityFrameworkCore;

namespace Paypont.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> people) : base(people)
        {
        }

        public DbSet<Customer> customers { get; set; }

    }
}
