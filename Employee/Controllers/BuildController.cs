using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class BuildController : Controller
    {
        DataContext Structure = new DataContext();
        // GET: Build
        public ActionResult Index()
        {
            ViewBag.list = new SelectList(Structure.Divisions
                .Where(g => g.DivisionType == "Управление"), "DivisionName", "DivisionName")
                .ToList();
            return View();
        }

        public ActionResult Build(string createThis)
        {
            ViewBag.header = createThis;
  
            return PartialView("Buildin");

        }
    }
}