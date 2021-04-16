using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    private static FileRepository _fr = new FileRepository();
    private static StoreSingleton _instance;
    public List<AStore> Stores { get; }
    private StoreSingleton()
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
      // _fr.WriteToFile(@"store.xml", new List<AStore>()
      //   {
      //     new ChicagoStore(),
      //     new NewYorkStore()
      //   }); //There is no need to now write to file, unless for debugging purposes.

      Stores = _fr.ReadFromFile(@"store.xml");

    }


    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new StoreSingleton();
        }
        return _instance;
      }


    }

  }
}