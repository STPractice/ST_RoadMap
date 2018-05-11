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

        public RoadMap getRoadMap(string userId)
        {
            RoadMap rm = UoW.Employees.FindByUserId(userId).RoadMaps.FirstOrDefault();
            return rm;
        }

        public Employee GetProfile(string UserId)
        {
            return UoW.Employees.FindByUserId(UserId);
        }

        public bool PassCheckpoint(int RMCheckpointId)
        {
            RMCheckpoint rmc = UoW.RMCheckpoints.Find(RMCheckpointId);
            if (rmc != null)
            {
                if (rmc.Achieved == 0)
                {
                    rmc.Achieved = 1;
                }
                else
                {
                    rmc.Achieved = 0;
                }
                UoW.RMCheckpoints.Update(rmc);
                UoW.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeSkillCondition(int RMCheckpointId, int SkillLevelId)
        {
            foreach(CheckpointsSkill skill in UoW.CheckpointsSkills.GetAll())
            {
                if (skill.RMCheckpointId == RMCheckpointId && skill.SkillLevelId == SkillLevelId)
                {
                    skill.Achieved = Math.Abs(1 - skill.Achieved);
                    UoW.CheckpointsSkills.Update(skill);                    
                    return UoW.Commit();
                }
            }
            return false;
        }
    }
}