using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using Microsoft.EntityFrameworkCore.Design;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using System.Linq;

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
    public static T DataReadID<T>(long ID, DbSet<T> Table) where T : AModel
    {
      //https://stackoverflow.com/questions/23675187/linq-query-using-generics was a very helpful resource for figuring this out
      return Table.Where(x => x.EntityID == ID).FirstOrDefault() as T;
    }
    public static Customer CustomerReadString(string Search, DbSet<Customer> context)
    {
      return context
      .Where(x => x.Name == Search)
      .FirstOrDefault();
    }

    public static Order DataReadEager(long ID, DbSet<Order> Table)
    {

      return Table
      .Where(x => x.EntityID == ID)
      .Include(b => b.Customer)
      .Include(b => b.Store)
      .Include(b => b.Items)
      .FirstOrDefault();
    }
    public static void Save<T>(PizzaBoxContext context, T ThingToSave) where T : class
    {
      context.Add(ThingToSave);
      context.SaveChanges();
    }
    public static List<Order> StoreHistory(PizzaBoxContext context, int StoreID)
    {
      return context.Orders
      .Where(a => a.Store.EntityID == StoreID)
      .Include(b => b.Customer)
      .Include(b => b.Store)
      .ToList();

    }
    public static List<Order> CustomerHistory(PizzaBoxContext context, int CustID)
    {
      return context.Orders
      .Where(a => a.Customer.EntityID == CustID)
      .Include(b => b.Items)
      .Include(b => b.Store)
      .ToList();

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      {
        //key block
        builder.Entity<Order>()
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
        builder.Entity<CYOPizza>()
        .HasBaseType<APizza>();
        // builder.Entity<Order>()
        // .HasOne<Customer>()
        // .WithMany()
        // .HasForeignKey("CustomerEntityID")
        // ;
        // builder.Entity<APizza>()
        // .HasOne<Order>()
        // .WithMany(b => b.Items)
        // .HasForeignKey(b => b.OrderID);
        // builder.Entity<Order>()
        // .HasOne<AStore>()
        // .WithMany()
        // .HasForeignKey(b => b.StoreID);
      }
      // OnDataSeeding(builder);


    }//how to save/retrieve them
    private void OnDataSeeding(ModelBuilder builder)
    {
      builder.Entity<MeatPizza>().HasData(new MeatPizza[]
     {
                 new MeatPizza() {EntityID=1, Price=5.00m}
     });
      builder.Entity<Customer>().HasData(new Customer[]
      {
             new Customer("Johnny Test"){EntityID=1}
      });
      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
{
             new NewYorkStore(){EntityID =1}
});
      builder.Entity<Order>().HasData(new Order[]
      {
             new Order() {EntityID=1}
      });
    }
  }
}