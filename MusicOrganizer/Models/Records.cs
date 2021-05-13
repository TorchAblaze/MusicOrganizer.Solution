using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Records
  {
    public string RecordName { get; set; }
    public int Id { get; }
    private static List<Records> _instances = new List<Records> { };

    public Records(string recordName)
    {
      RecordName = recordName;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Records> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Records Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}