using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class EmployeeLogic:IEmployeeLogic
    {
        private readonly IUnitOfWork UoW;
        private readonly Employee employee;

        public EmployeeLogic(IUnitOfWork uoW)
        {
            UoW = uoW;
            employee = UoW.Employees.Find(100);
        }

        public bool CreateSkillMatrix(SkillMatrix matrix)
        {
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
    }
}