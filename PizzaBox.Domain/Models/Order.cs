using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customer { get; set; }
    public AStore Store { get; set; }

    public List<APizza> Items { set; get; } = new List<APizza>();
    public decimal OrderTotal { set; get; }

    public void AddPizza(APizza Pizza)
    {
      Items.Add(Pizza);
      OrderTotal = OrderTotal + Pizza.Price;
    }
    public Order()
    {

    }


  }
}