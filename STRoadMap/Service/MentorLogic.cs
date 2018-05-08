using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class MentorLogic:IMentorLogic
    {
        private readonly IUnitOfWork UoW;

        public MentorLogic(IUnitOfWork uoW)
        {
            UoW = uoW;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return UoW.Employees.GetAll();
        }

        public Employee GetEmployeesProfile(int employeeId)
        {
            return UoW.Employees.Find(employeeId);
        }

        public RoadMap GetEmployeesRoadMap(int employeeId)
        {
            return UoW.RoadMaps.GetAll().GetEnumerator().Current;
        }
    }
}