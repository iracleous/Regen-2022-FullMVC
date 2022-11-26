using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Regen_2022.Models;

namespace Regen_2022.MyDbContext
{
    public class EshopDbContext:DbContext
    {
        public DbSet<Customer> Customers   => Set<Customer>();
        public DbSet<CustomerCategory> CustomerCategories => Set<CustomerCategory>();


        public EshopDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Data Source=(local);Initial Catalog=Eshop-Regen-2022;Integrated Security = true; TrustServerCertificate=True;";
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

    }
}
