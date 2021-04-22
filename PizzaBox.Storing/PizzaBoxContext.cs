using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore.Design;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {

    private readonly IConfiguration _configuration;
    public DbSet<Order> Orders { get; set; } //implicit serialization
    //above is order of what to save


    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }//where to save
    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<Order>()
      .HasKey(e => e.EntityID)
      .HasName("PK_OrderId");
      builder.Entity<APizza>()
      .HasKey(e => e.EntityID);
      builder.Entity<MeatPizza>().HasBaseType<APizza>();


    }//how to save/retrieve them
  }
}