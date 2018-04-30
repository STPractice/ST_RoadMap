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
        public string Index()
        {
            return "It works)";
        }
        [HttpGet]
        public ActionResult EmployeeList()
        {
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
        public ActionResult EmployeeProfile(string employeeId= "1f2dc159-0b55-48a1-afec-d8f0066ba569")
        {
            if(employeeId==null)
            {
                return HttpNotFound();
            }
            else
            {
                var user = MentorLogic.GetEmployeesProfile(employeeId);
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