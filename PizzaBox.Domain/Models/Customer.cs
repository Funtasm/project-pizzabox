using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Customer : AModel
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }


    public Customer()
    {
      Name = "Default";
    }

    public Customer(string n)
    {
      Name = n;
    }
    public override string ToString()
    {
      return Name;
    }
  }
}