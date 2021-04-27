using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using System;
using PizzaBox.Methods;
//using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Models
{


  public class CYOPizza : APizza
  {
    public CYOPizza(int x)
    {
      AddCrust();
      AddSize();
      AddToppings();
      GetPrice();
    }
    public CYOPizza()
    {

    }

    protected override void AddCrust()
    {
      CYOPizza.DisplayXMLMenu(AllCrusts);
      Console.WriteLine("What kind of Crust would you like?");
      Crust = Common.SwitchChoice(1, 3, AllCrusts);
    }
    protected override void AddSize()
    {
      CYOPizza.DisplayXMLMenu(AllSizes);
      Console.WriteLine("What size would you like?");
      Size = Common.SwitchChoice(1, 3, AllSizes);
    }
    protected override void AddToppings()
    {
      int MaxToppings = 3;
      CYOPizza.DisplayXMLMenu(AllToppings);
      Console.WriteLine("What Toppings would you like on your pizza? Pick up to three, and choose 0 to skip!");
      while (MaxToppings > 0)
      {
        Toppings Temp = Common.SwitchChoice(0, 8, AllToppings);
        if (Temp is null)
        { }
        else
        {
          Toppings.Add(Temp);
        }
        MaxToppings--;
      }
    }
    public override string ToString()
    {
      return $"{Size.Name} CYO Pizza";
    }
    public override string ToStringName()
    {
      return "Create Your Own Pizza";
    }
  }
}