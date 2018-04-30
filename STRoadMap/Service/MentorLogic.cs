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

        public AspNetUser GetEmployeesProfile(string employeeId)
        {
            return UoW.AspNetUsers.Find(employeeId);
        }
    }
}