using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
       //public DataContext(){}
        public readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Households>().HasKey(h => h.Hshd_Num);
            modelBuilder.Entity<Products>().HasKey(p => p.Product_num);
            modelBuilder.Entity<Transactions>().HasOne(t => t.Households)
            .WithMany(h => h.Transactions)
            .HasForeignKey(t => t.Hshd_Num);
            modelBuilder.Entity<Transactions>().HasOne(t => t.Products)
            .WithMany(p => p.Transactions)
            .HasForeignKey(t => t.Product_num);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            //options.UseSqlServer("Data Source=LocalDatabase.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Households> Households { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}