using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Extensibility
{
    public interface IMentorLogic
    {
        IEnumerable<Employee> GetEmployeeList();

        Employee GetEmployeesProfile(int employeeId);

        RoadMap GetEmployeesRoadMap(int employeeId);
    }
}
