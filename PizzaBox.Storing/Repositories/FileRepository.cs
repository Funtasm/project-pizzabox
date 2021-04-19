using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class FileRepository
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public T ReadFromFile<T>(string path) where T : class
    {

      var reader = new StreamReader(path);
      var xml = new XmlSerializer(typeof(T));

      return xml.Deserialize(reader) as T;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static void WriteToFile<T>(string path, T items)
    {

      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(T));

      xml.Serialize(writer, items);

    }
  }
}