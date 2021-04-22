using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AModel
  {
    [Key]
    public long EntityID { get; set; }
  }
}