using EShoppingApp.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Data
{
    public class EShoppingDbContext:IdentityDbContext<AppUser>
    {
        public EShoppingDbContext(DbContextOptions<EShoppingDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductDocument> ProductDocuments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
