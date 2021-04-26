using System.Collections.Generic;
using System;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing.Repositories;
using System.Reflection;
using PizzaBox.Storing;


namespace PizzaBox.Client
{
  public class Program
  {
    private static bool Restart = true;
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();

    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    // private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

    private static FileRepository _fr = new FileRepository();
    static void Main()
    {
      DoTheThing();
    }
    private static void DoTheThing()
    {

      while (Restart)
      {
        Console.WriteLine(
  @"Welcome to PizzaBox!
Would you like to make an order, check a store's order history, or check your own order history?
1: Start an Order.
2: Check a stores Order History
3: Check your Order History.
0: Quit.
      ");

        switch (Answer(0, 3))
        {
          case 1:
            {
              Restart = false;
              StartOrder();
              break;
            }
          case 2:
            {

              Restart = false;
              break;
            }
          case 3:
            {

              Restart = false;
              break;
            }
          case 0:
            {

              Restart = false;
              break;
            }
          default:
            {
              Console.WriteLine("You did not input a valid choice. Please input 1, 2, 3, or 0.");

              break;
            }
        }
      }
      // using (var context = new PizzaBoxContext())
      // {
      //   context.Orders.Add(Test);
      //   context.SaveChanges();
      // }

    }

    private static int Answer()
    {
      string UncheckedChoice = Console.ReadLine();
      if (Int32.TryParse(UncheckedChoice, out int Choice))
      {
        return Choice;
      }
      else
      {
        Console.WriteLine($"You did not input a valid choice. Please input only a single digit to select a choice.");
        Choice = Answer();
      }
      return Choice;
    }
    private static int Answer(int lowerBound, int upperBound)
    {
      int choice = Answer();
      if ((choice < lowerBound) || (choice > upperBound))
      {
        Console.WriteLine($"You did not input a valid choice. Please input only a digit in range of {lowerBound} to {upperBound}, inclusive.");
        choice = Answer(lowerBound, upperBound);
        return choice;
      }
      return choice;
    }
    private static void StartOrder()
    {
      Console.WriteLine(@"Are you a returning customer, or are you a new customer?
1: Returning Customer
2: New Customer
0: Go Back");

      switch (Answer(0, 2))
      {
        case 1:
          {
            ReturningCustomer();
            break;
          }
        case 2:
          {
            NewCustomer();
            break;
          }
        case 0:
          {
            Restart = true;
            break;
          }
        default:
          {
            Console.WriteLine(@"You shouldn't be here.");
            break;
          }
      }
    }
    private static void NewCustomer()
    {
      Console.WriteLine("Please input your name, or what you would like to be called by!");
      Customer nCust = new Customer(Console.ReadLine());
      PizzaBoxContext.Save<Customer>(_context, nCust);


    }

    private static void ReturningCustomer()
    {
      Console.WriteLine("Please input your ID number!");
      int choice = Answer();
      Customer Customer = PizzaBoxContext.DataReadID<Customer>(choice, _context.Customers);
      Console.WriteLine($"{Customer.Name}");
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