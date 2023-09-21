using Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;

namespace EvoMarket.Infrastructures.DbContexts;

public class ShopDataContext:DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public ShopDataContext(DbContextOptions<ShopDataContext>options):base(options)
    {
        
    }
}