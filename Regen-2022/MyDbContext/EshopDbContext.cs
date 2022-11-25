using Microsoft.EntityFrameworkCore;
using Regen_2022.Models;

namespace Regen_2022.MyDbContext
{
    public class EshopDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(local);Initial Catalog=Eshop-Regen-2022;Integrated Security = true";
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
