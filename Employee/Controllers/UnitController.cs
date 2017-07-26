using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class UnitController : Controller
    {
        DataContext Structure = new DataContext();

        public ActionResult Index()
        {
            return View(Structure.Divisions);
        }


        // Добавление  группы
        [HttpPost]
        public ActionResult AddDivision(string DivisionType, string DivisionParent, string DivisionName)
        {
            if (Structure.Divisions.Where(g => g.DivisionName == DivisionName).Count() >= 1)
            {
                return PartialView("Error");
            }
            else
            {
                Structure.Divisions.Add(new Division
                {
                    DivisionName = DivisionName,
                    DivisionType = DivisionType,
                    DivisionParent = DivisionParent,
                });
                Structure.SaveChanges();
                return PartialView("UpdateDivision", Structure.Divisions);
            }
        }
        [HttpPost]
        public ActionResult DeleteDivision(int RecId)
        {
            Structure.Divisions.Remove(Structure.Divisions.Where(g => g.DivisionId == RecId).Single());
            Structure.SaveChanges();
            return PartialView("UpdateDivision", Structure.Divisions);
        }
        [HttpGet]
        public JsonResult Avilable(string Type)
        {
            IEnumerable<Division> T = null;
            if (Type == "Группа")
                T = Structure.Divisions.Where(g => g.DivisionType == "Отдел").Select(g => g);
            if (Type == "Отдел")
                T = Structure.Divisions.Where(g => g.DivisionType == "Управление").Select(g => g);


            return Json(T,JsonRequestBehavior.AllowGet);
        }
    }
}