using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing.Repositories;
using System.Reflection;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static FileRepository _fr = new FileRepository();
    static void Main()
    {
      /*  //var stores = new List<AStore>{new ChicagoStore(), new NewYorkStore() };


        for (int x = 0; x < _storeSingleton.Stores.Count; x += 1)
        {
            System.Console.WriteLine($"{x} {_storeSingleton.Stores[x]}");//string interpolation, {} represent variables, while the rest is added in as text for the string
        }

        var input = System.Console.ReadLine(); //could use string instead of var, because it always returns string anyways.
        int entry = int.Parse(input);

        sc.WriteLine(_storeSingleton.Stores[entry]); // sc can be used now instead of System.Console or Console
        */
      //this does not work above for some reason in printing the names.
      DoTheThing();
    }
    private static void DoTheThing()
    {
      PrintStoreList();
    }
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        ++index;
        //solution for iteration of properties in objects found by "https://stackoverflow.com/questions/36656177/loop-through-an-objects-properties-and-get-the-values-for-those-of-type-datetim/36656271"
        foreach (PropertyInfo prop in item.GetType().GetProperties())
        {

          Console.WriteLine($"{index} - {prop.Name} - {prop.GetValue(item)}");
        }
      }

    }
  }
}