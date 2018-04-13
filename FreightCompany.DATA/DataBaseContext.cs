using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using FreightCompany.Domain;

namespace FreightCompany.Data
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        public static readonly LoggerFactory FreightLoggerFactory  
         = new LoggerFactory(new[] {
            new ConsoleLoggerProvider((category,level)
                => category == DbLoggerCategory.Database.Command.Name && 
                level == LogLevel.Information, true) 
         });



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new { p.OrderId, p.ProductId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
              .EnableSensitiveDataLogging()
              .UseLoggerFactory(FreightLoggerFactory)
               .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = FreightCompany; Trusted_Connection = True;");
        }
    }
}

