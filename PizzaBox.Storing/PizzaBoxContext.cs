using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<Order> Orders { get; set; } //implicit serialization
    //above is order of what to save
    public PizzaBoxContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }//where to save
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Order>().HasKey(e => e.EntityID);

    }//how to save/retrieve them
  }
}