using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using System;
using PizzaBox.Methods;
//using PizzaBox.Storing.Repositories;

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
      CYOPizza.DisplayXMLMenu(AllCrusts);
      Console.WriteLine("What kind of Crust would you like?");
      Crust = Common.SwitchChoice(1, 3, AllCrusts);
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddSize()
    {
      CYOPizza.DisplayXMLMenu(AllSizes);
      Console.WriteLine("What size would you like?");
      Size = Common.SwitchChoice(1, 3, AllSizes);
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddToppings()
    {
      Toppings = AllToppings.GetRange(0, 5);
    }
    public MeatPizza(int x)
    {
      AddCrust();
      AddSize();
      AddToppings();
      GetPrice();
    }
    public MeatPizza()
    {

    }
    public override string ToString()
    {
      return $"{Size.Name} MeatPizza";
    }
    public override string ToStringName()
    {
      return "MeatPizza";
    }
  }
}
