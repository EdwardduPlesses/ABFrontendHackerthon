using Microsoft.EntityFrameworkCore;
using StoreService.Database.Models;

namespace StoreService.Database;

public class StoreDb(DbContextOptions options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<ProductTags> ProductTags { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Tags> Tags { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<UserPurchase> UserPurchases { get; set; }
    public DbSet<FixedPriceProduct> FixedPriceProducts { get; set; }
    

    public void Seed()
    {
        
        Models.Users.Seed(this);
        Models.Tags.Seed(this);
        Models.Products.Seed(this);
    }
}