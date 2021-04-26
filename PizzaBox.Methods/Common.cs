using System;
using System.Collections.Generic;

namespace PizzaBox.Methods
{
  public class Common
  {
    public static int Answer()
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
    public static int Answer(int lowerBound, int upperBound)
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
    public static T SwitchChoice<T>(int x, int y, List<T> Items) where T : class
    {
      int Temp = Answer(x, y);
      if (Temp == 0)
        return null;
      for (int i = x; i <= y; i++)
      {
        if (Temp == i)
          return Items[i - 1] as T;
      }
      return null; // should never be reached
    }
  }

}
