using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;

namespace EvoMarket.Auth.Infrastructure.Context;

public class AuthDataContext:DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Device?> Devices { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string connectionString = "Host=localhost; Port=5432; Database=EvoMarket.Auth; username=postgres; password=3214";

        optionsBuilder
            .UseNpgsql(connectionString);
        
        base.OnConfiguring(optionsBuilder);
        
    }
}