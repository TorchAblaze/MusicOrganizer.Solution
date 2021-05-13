using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    //Homepage for all of our added artists.
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artists> allArtists = Artists.GetAll();
      return View(allArtists);
    }
    //Landing page where our form is kept for adding new artist.
    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }
    //Creates the new artist from the previous pathway and sends you back to the homepage of all artists.
    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artists newArtist = new Artists(artistName);
      return RedirectToAction("Index");
    }
    //Shows you the artists' details when clicked on post creation.
    [HttpGet("/artists/{artistId}")]
    public ActionResult Show(int artistId)
    {
      Artists artists = Artists.Find(artistId);
      Dictionary<string, object> artistRecords = new Dictionary<string, object>();
      List<Records> records = artists.Records;
      artistRecords.Add("artists", artists);
      artistRecords.Add("records", records);
      return View(artistRecords);
    }
    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create(int artistId, string recordName)
    {
      Dictionary<string, object> artistRecords = new Dictionary<string, object>();
      Artists foundArtist = Artists.Find(artistId);
      Records newRecord = new Records(recordName);
      foundArtist.AddRecord(newRecord);
      List<Records> discography = foundArtist.Records;
      artistRecords.Add("records", discography);
      artistRecords.Add("artists", foundArtist);
      return View("Show", artistRecords);
    }
  }
}