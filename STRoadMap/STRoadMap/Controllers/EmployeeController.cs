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
        private bool IsAuthorized()
        {
            return HttpContext.User.IsInRole("HR") || HttpContext.User.IsInRole("Mentor") || HttpContext.User.IsInRole("Employee");
        }
        // GET: Employee
        public string Index()
        {
            return "It works)";
        }
    }
}