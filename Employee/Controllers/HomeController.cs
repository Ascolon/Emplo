using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        
        DataContext Structure = new DataContext();
        public ActionResult Index()
        {
            return View(Structure.Workers);
        }

        [HttpPost]
        public PartialViewResult add(string FirstName, string SecondName, string Patronymic, string Position, string DivisionName)
        {
            Structure.Workers.Add(new Worker
            {
                FirstName = FirstName,
                SecondName = SecondName,
                Patronymic = Patronymic,
                Position = Position,
                DivisionName = DivisionName,
            });
            Structure.SaveChanges();
            return PartialView("newTable", Structure.Workers);
        }

        [HttpPost]
        public PartialViewResult delete(int RecId)
        {
            Structure.Workers.Remove(Structure.Workers.Where(g => g.WorkerId == RecId).Single());
            Structure.SaveChanges();
            return PartialView("newTable", Structure.Workers);
        }

        [HttpPost]
        public ActionResult edit(int EditId, string NewFirstName, string NewSecondName, string NewPatronymic, string NewPosition, string NewDivision)
        {
            var oldREecord = Structure.Workers.Where(g => g.WorkerId == EditId).Single();
            if (oldREecord != null)
            {
                oldREecord.FirstName = NewFirstName;
                oldREecord.SecondName = NewSecondName;
                oldREecord.Patronymic = NewPatronymic;
                oldREecord.Position = NewPosition;
                oldREecord.DivisionName = NewDivision;
            }
            Structure.SaveChanges();
            return PartialView("newTable", Structure.Workers);
        }

        [HttpGet]
        public JsonResult CurentDivision(string Type)
        {
            var T = Structure.Divisions.Where(g => g.DivisionType == Type).Select(g => g);
            
            return Json(T,JsonRequestBehavior.AllowGet);
        }
    }
}