using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Extensibility;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using STRoadMap.Models;

namespace STRoadMap.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic employeeLogic;

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public EmployeeController(IEmployeeLogic EmployeeLogic)
        {
            this.employeeLogic = EmployeeLogic;
        }
        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR") || HttpContext.User.IsInRole("Mentor") || HttpContext.User.IsInRole("Employee");
        }
        // GET: Employee
        public string Index()
        {
            return "It works)";
        }

        [HttpGet]
        public ActionResult PerformanceReview()
        {
            IEnumerable<Specialization> specs = employeeLogic.GetSpecializations();
            return View(specs);
        }

        [HttpPost]
        public ActionResult PerformanceReview(SkillMatrix position)
        {
            if (position == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                if (employeeLogic.CreateSkillMatrix(position, UserManager.FindByName(HttpContext.User.Identity.Name).Id))
                {
                    return View("Employee", "Employee");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult ProfileEmployee(int? EmployeeId = 100)
        {
            if (EmployeeId == null)
            {
                return HttpNotFound();
            }
            else
            {
                var user = employeeLogic.GetProfile((int)EmployeeId);
                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }
    }
}