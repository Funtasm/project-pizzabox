using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public long StoreID { get; set; }

    public long CustomerID { get; set; }
    // public Customer Customer { get; set; }

    public List<APizza> Items { set; get; } //= new List<APizza>();
    public decimal OrderTotal { set; get; }

    public void AddPizza(APizza Pizza)
    {
      Items.Add(Pizza);
      OrderTotal = OrderTotal + Pizza.Price;
      Pizza.OrderID = EntityID;
    }
    public Order()
    {

    }
    public Order(long tStoreID, long tCustomerID)
    {
      StoreID = tStoreID;
      CustomerID = tCustomerID;
      Items = new List<APizza>();
    }


  }
}