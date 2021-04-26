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
    protected static List<PizzaComponent> AllCrusts { get; private set; }
    protected static List<PizzaComponent> AllSizes { get; private set; }
    protected static List<PizzaComponent> AllToppings { get; private set; }
    public PizzaComponent Crust;
    public PizzaComponent Size;

    public List<PizzaComponent> Toppings = new List<PizzaComponent>();
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
      AllCrusts = MenuReader(_CrustPath);
      AllSizes = MenuReader(_SizePath);
      AllToppings = MenuReader(_ToppingsPath);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<PizzaComponent> MenuReader(string path)
    {
      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<PizzaComponent>));
      return xml.Deserialize(reader) as List<PizzaComponent>;
    }
    // public override string ToString()
    // {
    //   var stringBuilder = new StringBuilder();
    //   var separator = ", ";

    //   foreach (var item in Toppings)
    //   {
    //     stringBuilder.Append($"{item}{separator}");
    //   }

    //   return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    // }
  }
}
