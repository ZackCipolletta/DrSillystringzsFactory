using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;


namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Category[] cats = _db.Categories.ToArray();
      Machine[] machines = _db.Machines.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("categories", cats);
      model.Add("machines", machines);
      return View(model);
      return View();
    }

  }
}