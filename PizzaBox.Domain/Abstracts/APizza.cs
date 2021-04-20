using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
//using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Abstracts
{
  public struct PizzaComponent
  {
    public string Name;
    public decimal Price;
    /// <summary>
    /// Allows for the adding of PizzaComponents to a <List>PizzaComponents without saving them prior.
    /// </summary>

    public static PizzaComponent MakeComponent(string x, decimal y)
    {
      PizzaComponent abc = new PizzaComponent();
      abc.Price = y;
      abc.Name = x;
      return abc;
    }
  }


  public abstract class APizza : AModel
  {
    private string _SizePath = @"Data/pizzasize.xml";
    private string _CrustPath = @"Data/pizzacrust.xml";
    private string _ToppingsPath = @"Data/pizzatoppings.xml";
    protected static List<PizzaComponent> AllCrusts { get; private set; }
    protected static List<PizzaComponent> AllSizes { get; private set; }
    protected static List<PizzaComponent> AllToppings { get; private set; }
    protected PizzaComponent Crust;
    protected PizzaComponent Size;
    protected List<PizzaComponent> Toppings;


    /// <summary>
    /// 
    /// </summary>
    protected APizza()
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
    public decimal GetPrice()
    {
      decimal Total;
      Total = this.Crust.Price + this.Size.Price;
      for (int i = 0; i < Toppings.Count; i++)
      {
        Total = Total + Toppings[i].Price;
      }
      return Total;
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
    // private void CreateMenu()
    // {
    // PizzaComponent Crust1 = PizzaComponent.MakeComponent("Thin", 0.00m);
    // PizzaComponent Size1 = PizzaComponent.MakeComponent("Small", 1.00m);
    // PizzaComponent Topping1 = PizzaComponent.MakeComponent("Mozzerella", 1.00m);
    // AllCrusts.Add(Crust1);
    // AllSizes.Add(Size1);
    // AllToppings.Add(Topping1);
    // FileRepository.WriteToFile(_CrustPath, AllCrusts);
    // FileRepository.WriteToFile(_SizePath, AllSizes);
    // FileRepository.WriteToFile(_ToppingsPath, AllToppings);

    // }
    //above requires a circular dependency, must create a private write to file in APizza to continue.

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private List<PizzaComponent> MenuReader(string path)
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
