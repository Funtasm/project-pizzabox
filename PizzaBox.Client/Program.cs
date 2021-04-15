using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
namespace PizzaBox.Client
{
    public class Program
    {
        static void Main()
        {
            var stores = new List<AStore>{new ChicagoStore(), new NewYorkStore() };

            for (int x = 0; x < stores.Count; x += 1)
            {
                System.Console.WriteLine($"{x} {stores[x]}");//string interpolation, {} represent variables, while the rest is added in as text for the string
            }

            var input = System.Console.ReadLine(); //could use string instead of var, because it always returns string anyways.
            int entry = int.Parse(input);

            sc.WriteLine(stores[entry]); // sc can be used now instead of System.Console or Console
            
        }
    }
}