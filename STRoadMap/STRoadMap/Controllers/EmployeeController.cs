using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Extensibility;

namespace STRoadMap.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic employeeLogic;

        public EmployeeController(IEmployeeLogic EmployeeLogic)
        {
            this.employeeLogic = EmployeeLogic;
        }
        // GET: Employee
        public string Index()
        {
            return "It works)";
        }

        [HttpGet]
        public ActionResult PerformanceReview(int? SpecializationId = 103)
        {
            if (SpecializationId == null)
            {
                return HttpNotFound();
            }
            else
            {
                Specialization spec = employeeLogic.GetSpecialization((int)SpecializationId);
                if (spec == null)
                {
                    return HttpNotFound();
                }
                else
                {

                    return View(spec);
                }
            }
        }

        [HttpPost]
        public ActionResult PerformanceReview(SkillMatrix position)
        {
            position.EmpolyeeId = 100;
            if (position == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (employeeLogic.CreateSkillMatrix(position))
                {
                    return View("Index");
                    //return RedirectToAction("PositionList", "HR", new { SpecializationId = position.SpecializationId });
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
    }
}