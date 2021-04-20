using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public abstract class AStore : AModel
  {
    public string name { get; set; }
    public string address { get; set; }
    public AStore()
    {
      name = "Yet to be Named";
      address = "Coming Soon!";
    }
    public override string ToString()
    {
      return name;
    }
  }
}