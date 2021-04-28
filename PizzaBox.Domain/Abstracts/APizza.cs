using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
//using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Abstracts
{


  public abstract class APizza : AModel
  {
    protected string _SizePath = @"Data/pizzasize.xml";
    protected string _CrustPath = @"Data/pizzacrust.xml";
    protected string _ToppingsPath = @"Data/pizzatoppings.xml";
    protected static List<Crust> AllCrusts { get; private set; }
    protected static List<Size> AllSizes { get; private set; }
    protected static List<Toppings> AllToppings { get; private set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }

    public List<Toppings> Toppings { get; set; } = new List<Toppings>();
    public decimal Price { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public APizza()
    {
      ReadMenu();
    }
    protected APizza(int CrustChoice, int SizeChoice, List<int> Toppings)
    {

    }
    /// <summary>
    /// Simple price calculator, useable by any instance of APizza.
    /// </summary>
    /// <returns>decimal</returns>
    public void GetPrice()
    {
      decimal Total;
      Total = Crust.Price + Size.Price;
      for (int i = 0; i < Toppings.Count; i++)
      {
        Total = Total + Toppings[i].Price;
      }
      Price = Total;
    }


    /// <summary>
    /// 
    /// </summary>


    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddCrust();


    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddSize();

    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddToppings();
    private void ReadMenu()
    {
      AllCrusts = MenuReader<Crust>(_CrustPath);
      AllSizes = MenuReader<Size>(_SizePath);
      AllToppings = MenuReader<Toppings>(_ToppingsPath);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<T> MenuReader<T>(string path) where T : PizzaComponent
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<T>));
      return xml.Deserialize(reader) as List<T>;
    }
    protected static void DisplayXMLMenu<T>(List<T> MenuList) where T : PizzaComponent
    {
      {
        var index = 0;

        foreach (var item in MenuList)
        {
          ++index;
          Console.Write("\n" + index);
          Console.Write($" - {item.ToString()}");
        }

        Console.Write("\n");
      }
    }
    public virtual string ToString()
    {
      string Return1 = $"{Size.Name} - {Crust.Name} with:";
      foreach (var item in Toppings)
        Return1 += $" ({item.Name})";
      return Return1;
    }
    public virtual string ToStringName()
    {
      return "A Pizza";
    }
    public string ToStringALL()
    {
      if (Size is null)
        return "not all properties are not found!";
      string Return1 = $"{Size.Name} - {Crust.Name} with:";
      foreach (var item in Toppings)
        Return1 += $" ({item.Name})";
      return Return1;
    }
  }
}
