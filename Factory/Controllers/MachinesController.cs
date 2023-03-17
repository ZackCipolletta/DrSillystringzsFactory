using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {

    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      // List<Machine> model = null;
      // if (sortBy ==null)
      // {
      //   model = _db.Machines.Include(machine => machine.Engineer).ToList();
      // } 
      // else if (sortBy.Equals("date"))
      // {
      //   model = _db.Machines.OrderBy(machine => machine.DueDate).Include(machine => machine.Category).ToList();
      // }
      return View();
    }

    public ActionResult Create()
    {
      // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create (Machine machine)
    {
      // if (machine.CategoryId == 0)
      // {
      //   return RedirectToAction("Create");
      // }
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Engineer)          
          .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

        public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Title");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId });
    }  
    
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("MarkComplete")]
    public ActionResult MarkComplete(Boolean Completed, int Id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == Id);
      thisMachine.Completed = Completed;
      _db.Machines.Update(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}