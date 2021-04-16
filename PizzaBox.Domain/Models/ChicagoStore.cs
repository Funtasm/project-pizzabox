using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class ChicagoStore : AStore
  {
    public ChicagoStore()
    {
      name = "ChicagoStore";
      address = "1111 Codeview ln.";
    }
  }
}