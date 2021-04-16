using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public class FileRepository
  {

    public List<AStore> ReadFromFile(string path)
    {
      {

        var reader = new StreamReader(path);

        var xml = new XmlSerializer(typeof(List<AStore>));

        // return xml.Deserialize(reader) as List<AStore>; // if casting fails, ==> null POCOs, plain old csharp objects
        return (List<AStore>)xml.Deserialize(reader); // if casting fails ==> exception
      }

    }

    public void WriteToFile(string path, List<AStore> stores)
    {

      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<AStore>));

      xml.Serialize(writer, stores);



    }
  }
}
