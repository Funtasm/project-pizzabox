using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client;
using PizzaBox.Client.Singletons;
using PizzaBox.Methods;
using System.Collections.Generic;
using PizzaBox.Storing;
using System.IO;
using System;
namespace PizzaBox.Testing.Tests
{
  public class CommonTesting
  {
    [Fact]
    public void Test_MenuReader()
    {
      //cannot find file so it fails
      //arrange (sut = subject under test)
      var sut = new MeatPizza();
      List<PizzaComponent> act = sut.MenuReader<PizzaComponent>("/home/seth/revature/project_pizzabox/PizzaBox.Client/Data/pizzacrust.xml");
      //act 
      // assert
      Assert.True(act[0].Name == "Thin");
    }
    [Fact]
    public void Test_DataBaseValues()
    {
      //cannot find file so it fails.
      var sut = new PizzaBoxContext();
      var Customer = PizzaBoxContext.DataReadID(1, sut.Customers);
      Assert.True(Customer.Name == "Johnny Test");
    }
    [Theory]
    [InlineData("Johnny")]
    [InlineData("MapleLeaf")]
    [InlineData("5892njfds02")]
    public void Test_Customer(string Name)
    {
      var sut = new Customer(Name);
      var actual = sut.Name;
      Assert.True(actual == Name);
    }
    [Fact]
    public void Test_MeatPizza()
    {
      //cannot find file so it fails.
      var Test1 = new MeatPizza();
      Assert.True(Test1.Size.Name == "Small");
      Assert.True(Test1.Crust.Name == "Thin");
      Assert.True(Test1.Toppings.Count == 3);
    }
    [Fact]
    public void Test_StoreSingleton()
    {
      //cannot find file so it fails.
      var TestInstance = StoreSingleton.Instance;
      var TestInstance2 = StoreSingleton.Instance;
      Assert.True(TestInstance == TestInstance2);
    }
    [Fact]
    public void ToString_test()
    {
      var Store = new NewYorkStore();
      Assert.True(Store.ToString() == Store.name);
    }
    [Fact]
    public void PizzaComponentInheritance_Test1()
    {
      var Component = new PizzaComponent();
      Assert.True(Component.EntityID == 0);

    }
    [Fact]
    public void OrderEmptyTest()
    {
      var sut = new Order() { Customer = new Customer() };
      Assert.True(sut.Customer.Name == "Default");

    }
    [Fact]
    public void CYOPizza_Test()
    {
      var sut = new CYOPizza();
      Assert.True(sut is null);
      // this fails because it tries to reach the xml as well
    }
  }
}