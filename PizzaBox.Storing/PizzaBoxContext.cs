using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore.Design;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {

    private readonly IConfiguration _configuration;
    public DbSet<Customer> Customers { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<AStore> Stores { get; set; }
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
      { //key block
        builder.Entity<Order>()
        .HasKey(e => e.EntityID);
        builder.Entity<PizzaComponent>()
        .HasKey(e => e.EntityID);
        builder.Entity<AStore>()
        .HasKey(e => e.EntityID);
        builder.Entity<ChicagoStore>()
        .HasBaseType<AStore>();
        builder.Entity<NewYorkStore>()
        .HasBaseType<AStore>();
        builder.Entity<Customer>()
        .HasKey(e => e.EntityID);
        builder.Entity<APizza>()
        .HasKey(e => e.EntityID);
      }
      {//relationship block
        builder.Entity<MeatPizza>()
        .HasBaseType<APizza>();
        builder.Entity<Order>()
        .HasOne<Customer>()
        .WithMany()
        .HasForeignKey(b => b.CustomerID);
        builder.Entity<APizza>()
        .HasOne<Order>()
        .WithMany(b => b.Items)
        .HasForeignKey(b => b.OrderID);
        builder.Entity<Order>()
        .HasOne<AStore>()
        .WithMany()
        .HasForeignKey(b => b.StoreID);
      }
      // OnDataSeeding(builder);


    }//how to save/retrieve them
     //     private void OnDataSeeding(ModelBuilder builder)
     //     {
     //       builder.Entity<MeatPizza>().HasData(new MeatPizza[]
     //      {
     //             new MeatPizza() {OrderID=1}
     //      });
     //       builder.Entity<Customer>().HasData(new Customer[]
     //       {
     //         new Customer("Johnny Test")
     //       });
     //       builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
     // {
     //         new NewYorkStore()
     // });
     //       builder.Entity<Order>().HasData(new Order[]
     //       {
     //         new Order() {StoreID =1, CustomerID=1}
     //       });
     //     }
  }
}