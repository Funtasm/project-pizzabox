using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using System;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Models
{

  /// <summary>
  /// 
  /// </summary>
  public class MeatPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    protected override void AddCrust()
    {
      Crust = AllCrusts[0];
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddSize()
    {
      Size = AllSizes[0];
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddToppings()
    {
      Toppings = AllToppings.GetRange(0, 3);
    }
    public MeatPizza()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }
  }
}
