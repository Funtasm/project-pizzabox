using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private const string _path = @"pizza.xml";
    private static FileRepository _fr = new FileRepository();
    private static PizzaSingleton _instance;
    public List<APizza> Pizzas { get; }
    private PizzaSingleton()
    {
      // Stores = new List<AStore>()
      //     {
      //        new ChicagoStore(),
      //        new NewYorkStore()
      //     };
      // if (Stores == null)
      // {
      //   Stores = _fr.ReadFromFile(@"store.xml");
      // }

      // if (Stores == null)
      // {
      // _fr.WriteToFile(@"pizza.xml", new List<APizza>());
      //   {
      //     new ChicagoStore(),
      //     new NewYorkStore()
      //   }); //There is no need to now write to file, unless for debugging purposes.

      Pizzas = _fr.ReadFromFile<List<APizza>>(_path);

    }

    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new PizzaSingleton();
        }
        return _instance;
      }


    }

  }
}