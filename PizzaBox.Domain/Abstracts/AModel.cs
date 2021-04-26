using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AModel
  {
    public long EntityID { get; set; }
  }
}