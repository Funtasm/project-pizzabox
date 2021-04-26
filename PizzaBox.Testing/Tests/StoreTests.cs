using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    [Fact]
    public void Test_ChicagoStore()
    {
      //arrange (sut = subject under test)
      var sut = new ChicagoStore();

      //act 
      var actual = sut.name;

      // assert
      Assert.True(actual == "ChicagoStore");
    }
    [Fact]
    public void Test_NYStore()
    {
      //arrange (sut = subject under test)
      var sut = new NewYorkStore();

      //act 
      var actual = sut.name;

      // assert
      Assert.True(actual == "NewYorkStore");
    }

  }
}