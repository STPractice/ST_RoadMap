using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace STRoadMap.Controllers
{
    public class MentorController : Controller
    {
        private readonly IMentorLogic MentorLogic;

        public MentorController(IMentorLogic MentorLogic)
        {
            this.MentorLogic = MentorLogic;
        }
        // GET: Mentor
        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR")|| HttpContext.User.IsInRole("Mentor");
        }
        public string Index()
        {
            return "It works)";
        }
        [HttpGet]
        public ActionResult EmployeeList()
        {
            if (!IsAuthorized())
            {
                Response.StatusCode = 404;
                return HttpNotFound();
            }
            IEnumerable<Employee> spec = MentorLogic.GetEmployeeList();
            if (spec == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(spec);
            }
        }

        [HttpGet]
        public ActionResult EmployeeProfile(int? EmployeeId=100)
        {
            if(EmployeeId==null)
            {
                return HttpNotFound();
            }
            else
            {
                var user = MentorLogic.GetEmployeesProfile((int) EmployeeId);
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