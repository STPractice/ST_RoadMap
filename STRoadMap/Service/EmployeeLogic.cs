using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Service
{
    public class EmployeeLogic:IEmployeeLogic
    {
        private readonly IUnitOfWork UoW;
        

        public EmployeeLogic(IUnitOfWork uoW)
        {
            UoW = uoW;
            
            
        }

        public bool CreateSkillMatrix(SkillMatrix matrix, string userId)
        {
            Employee employee = UoW.Employees.FindByUserId(userId);
            matrix.EmpolyeeId = employee.EmpolyeeId;
            try
            {
                if (employee.SkillMatrices.Count != 0)
                {
                    UoW.SkillMatrices.Delete(employee.SkillMatrices.First());
                }
                UoW.SkillMatrices.Create(matrix);
                return UoW.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Specialization GetSpecialization(int SpecializationId)
        {
            return UoW.Specializations.Find(SpecializationId);
        }
        public IEnumerable<Specialization> GetSpecializations()
        {
            return UoW.Specializations.GetAll();
        }

        public bool IsPerformanceReviewPassed(string employeeId)
        {
            if (UoW.Employees.FindByUserId(employeeId).SkillMatrices.Count < 1)
            {
                return false;
            }
            return true;
        }

        public bool IsRoadMapExists(string employeeId)
        {
            if (UoW.Employees.FindByUserId(employeeId).RoadMaps.Count < 1)
            {
                return false;
            }
            return true;
        }

        public RoadMap getRoadMap(string employeeId)
        {
            var Roadmaps = UoW.RoadMaps.GetAll();
           return Roadmaps.GetEnumerator().Current;
        }

        public Employee GetProfile(string UserId)
        {
            return UoW.Employees.FindByUserId(UserId);
        }
    }
}