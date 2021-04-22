using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public AStore Store;
    public Customer Customer;
    //public int OrderId { private set; get; }
    public List<APizza> Items { private set; get; }
    public decimal OrderTotal { private set; get; }

    public void AddPizza(APizza Pizza)
    {
      this.Items.Add(Pizza);
      this.OrderTotal = this.OrderTotal + Pizza.GetPrice();
    }
    private Order()
    {
      Store = new NewYorkStore();
      Customer = new Customer();
      Customer.Name = "Johnny Test";
      this.AddPizza(new MeatPizza());
      //test for database
    }


  }
}