using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public int OrderId { private set; get; }
    public List<APizza> Items { private set; get; }
    public decimal OrderTotal { private set; get; }

    public void AddPizza(APizza Pizza)
    {
      this.Items.Add(Pizza);
      this.OrderTotal = this.OrderTotal + Pizza.GetPrice();
    }
    private Order()
    {

    }


  }
}