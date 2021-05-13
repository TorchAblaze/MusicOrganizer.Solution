using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/artists/{artistId}/records/new")]
    public ActionResult New(int artistId)
    {
      Artists artist = Artists.Find(artistId);
      return View(artist);
    }
    [HttpGet("/artists/{artistId}/records/{recordId}")]
    public ActionResult Show(int artistId, int recordId)
    {
      Records records = Records.Find(recordId);
      Artists artist = Artists.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("records", records);
      model.Add("artists", artist);
      return View(model);
    }
    [HttpPost("artists/delete")]
    public ActionResult DeleteAll()
    {
      Artists.ClearAll();
      return View();
    }
  }
}