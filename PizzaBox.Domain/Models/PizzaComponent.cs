
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class PizzaComponent : AModel
  {
    public string Name { get; set; }

    public decimal Price { get; set; }

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
    public override string ToString()
    {
      return $"{Name} - ${Price}";
    }
  }
}
