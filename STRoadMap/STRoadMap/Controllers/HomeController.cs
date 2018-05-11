using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STRoadMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("EmployeeProfile", "Employee");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }
    }
}