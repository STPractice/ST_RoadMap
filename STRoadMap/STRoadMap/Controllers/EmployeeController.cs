using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extensibility;

namespace STRoadMap.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic EmployeeLogic;

        public EmployeeController(IEmployeeLogic EmployeeLogic)
        {
            this.EmployeeLogic = EmployeeLogic;
        }
        // GET: Employee
        public string Index()
        {
            return "It works)";
        }
    }
}