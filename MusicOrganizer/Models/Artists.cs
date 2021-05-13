using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artists
  {
    private static List<Artists> _instances = new List<Artists> { };
    public string ArtistName { get; set; }
    public int Id { get; }
    public List<Records> Records { get; set; }

    public Artists(string artistName)
    {
      ArtistName = artistName;
      _instances.Add(this);
      Id = _instances.Count;
      Records = new List<Records> { };
    }

    public static List<Artists> GetAll()
    {
      return _instances;
    }

    public static Artists Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public void AddRecord(Records record)
    {
      Records.Add(record);
    }
  }
}