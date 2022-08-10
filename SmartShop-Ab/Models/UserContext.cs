using Microsoft.EntityFrameworkCore;

namespace SmartShop_Ab.Models
{
    public class UserContext:DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Connect"));
        }
        public DbSet<UserMaster>UserMasters { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<AddProduct> AddProducts { get; set; }
        public DbSet<StockManagement> StockManagements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


    }
    
}
