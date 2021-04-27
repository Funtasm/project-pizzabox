using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing.Repositories;
using System.Reflection;
using PizzaBox.Storing;
using PizzaBox.Methods;

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

        switch (Common.Answer(0, 3))
        {
          case 1:
            {
              Restart = false;
              StartOrder();
              break;
            }
          case 2:
            {
              StoreHistory();
              Restart = false;
              break;
            }
          case 3:
            {
              CustomerHistory();
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


    private static void StartOrder()
    {
      Console.WriteLine(@"Are you a returning customer, or are you a new customer?
1: Returning Customer
2: New Customer
0: Go Back");

      switch (Common.Answer(0, 2))
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
    private static void OrderCreation(Customer Customer)
    {
      Order MyOrder = new Order();
      MyOrder.Customer = Customer;
      bool localrestart = false;
      Console.WriteLine("Which store will you be purchasing from?");
      PrintStoreList();
      switch (Common.Answer(1, 3))
      {
        case 1:
          {
            MyOrder.Store = PizzaBoxContext.DataReadID(1, _context.Stores);

            break;
          }
        case 2:
          {
            MyOrder.Store = PizzaBoxContext.DataReadID(2, _context.Stores);

            break;
          }
        case 3:
          {
            MyOrder.Store = PizzaBoxContext.DataReadID(3, _context.Stores);

            break;
          }

      }
      do
      {
        MyOrder.AddPizza(PizzaCreator());
        Console.WriteLine(@"Would you like to add another pizza?
1: Yes
2: No
");
        if (Common.Answer(1, 2) == 1)
          localrestart = true;
        else
          localrestart = false;
      } while (localrestart);
      ConfirmOrder(MyOrder);

    }
    private static void ConfirmOrder(Order MyOrder)
    {
      Console.WriteLine($"Your order for {MyOrder.Customer.Name} at the {MyOrder.Store.name} contains:");
      for (int i = 0; i < MyOrder.Items.Count; i++)
      {
        Console.WriteLine($"{i + 1}: {MyOrder.Items[i].ToString()} - {MyOrder.Items[i].Price}");
      }
      Console.WriteLine($"For a total of: {MyOrder.OrderTotal}");
      PizzaBoxContext.Save(_context, MyOrder);
    }
    private static APizza PizzaCreator()
    {
      Console.WriteLine(@"Would you like a MeatPizza, or to create your own Pizza?
1: MeatPizza
2: Create my own!
");
      switch (Common.Answer(1, 2))
      {
        case 1:
          {
            MeatPizza Pizza = new MeatPizza(1);
            return Pizza;
            break;
          }
        case 2:
          {
            CYOPizza Pizza = new CYOPizza(1);
            return Pizza;
            break;
          }

      }
      //this shouldnt ever be reached.
      return null;
    }
    private static void NewCustomer()
    {
      bool localrestart = true;
      while (localrestart)
      {
        Console.WriteLine("Please input your name, or what you would like to be called by!");
        Customer nCust = new Customer(Console.ReadLine());
        Console.WriteLine($"You put {nCust.Name}, is that right? 1 to continue, or 2 to re-assign your name.");
        switch (Common.Answer(1, 2))
        {
          case 1:
            {
              PizzaBoxContext.Save<Customer>(_context, nCust);
              nCust = PizzaBoxContext.CustomerReadString(nCust.Name, _context.Customers);
              localrestart = false;
              Console.WriteLine($"Your name, {nCust.Name}, has been saved! Your ID is: {nCust.EntityID}");
              OrderCreation(nCust);
              break;
            }
          case 2:
            {

              break;
            }
          default:
            {
              Console.WriteLine("You shouldn't be here, again.");
              break;
            }
        }
      }//end while loop

    }
    private static void StoreHistory()
    {
      Console.WriteLine("Which store history would you like to check?");
      PrintStoreList();
      List<Order> Read;
      Read = PizzaBoxContext.StoreHistory(_context, (Common.Answer(1, 3)));
      foreach (var item in Read)
      {
        Console.WriteLine(item.ToString());
      }
    }
    private static void CustomerHistory()
    {
      bool localrestart = false;
      Console.WriteLine("Whose order history would you like to check?");
      int choice = Common.Answer();
      do
      {
        List<Order> History = PizzaBoxContext.CustomerHistory(_context, choice);
        if (History is null)
        {
          Console.WriteLine("We couldnt find a customer with that ID! :( Try another, or enter 0 to return!");
          choice = Common.Answer();
          if (choice == 0)
          {
            localrestart = false;
            DoTheThing();
          }
          else
          {
            localrestart = true;
          }
        }
        else
        {
          foreach (var item in History)
          {
            Console.WriteLine($"Order ID:{item.EntityID} - {item.Store.name} - {item.OrderTotal} containing:");
            for (int i = 0; i < item.Items.Count; i++)
              Console.WriteLine($"{item.Items[i].ToStringName()} {item.Items[i].ToStringALL()}");
          }
        }
      } while (localrestart);
    }
    private static void ReturningCustomer()
    {
      bool localrestart = false;
      Console.WriteLine("Please input your CustomerID!");
      int choice = Common.Answer();
      do
      {
        Customer Customer = PizzaBoxContext.DataReadID<Customer>(choice, _context.Customers);
        if (Customer is null)
        {
          Console.WriteLine("We couldnt find a customer with that ID! :( Try another, or enter 0 to return!");
          choice = Common.Answer();
          if (choice == 0)
          {
            localrestart = false;
            StartOrder();
          }
          else
          {
            localrestart = true;
          }
        }
        else
        {
          Console.WriteLine($"{Customer.Name}, welcome back!");
          OrderCreation(Customer);
        }
      } while (localrestart);

    }
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        ++index;
        Console.Write("\n" + index);
        //solution for iteration of properties in objects found by "https://stackoverflow.com/questions/36656177/loop-through-an-objects-properties-and-get-the-values-for-those-of-type-datetim/36656271"
        foreach (PropertyInfo prop in item.GetType().GetProperties())
        {
          if (prop.PropertyType == typeof(string))
            Console.Write($" - {prop.GetValue(item)}");
        }
      }
      Console.Write("\n");
    }
  }
}