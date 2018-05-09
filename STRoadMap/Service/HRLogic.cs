using Extensibility;
using System;
using System.Collections.Generic;
using Domain;
using System.IO;
using System.Linq;
using System.Text;

namespace Service
{

    public class HRLogic : IHRLogic
    {
        IUnitOfWork UoW;

        public HRLogic(IUnitOfWork uoW)
        {
            this.UoW = uoW;
        }

        public IEnumerable<Specialization> GetSpecializationList()
        {            
            return UoW.Specializations.GetAll();            
        }

        public bool DeleteSpecialization (int id)
        {
            if (UoW.Specializations.Find(id) != null)
            {
                UoW.Specializations.Delete(UoW.Specializations.Find(id));
                return UoW.Commit();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Skill> GetSkillList()
        {
            return UoW.Skills.GetAll();

        }

        public bool DeleteSkill(int SkillId)
        {
            UoW.Skills.Delete(UoW.Skills.Find(SkillId));
            var isOk = UoW.Commit();
            if (isOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        public bool CreateSkill(Skill skill)
        {
            try
            {
                UoW.Skills.Create(skill);                
                return UoW.Commit();                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Skill GetSkill(int id)
        {
            return UoW.Skills.Find(id);
        }

        public bool EditSkill(Skill skill)
        {

            UoW.Skills.Update(skill.SkillId, skill.Name);

            List<SkillLevel> OldSkillLevels = UoW.Skills.Find(skill.SkillId).SkillLevels.ToList<SkillLevel>();
            List<SkillLevel> NewSkillLevels = skill.SkillLevels.ToList<SkillLevel>();

            foreach (SkillLevel OldSkillLevel in OldSkillLevels)
            {
                bool exist = false;

                foreach (SkillLevel newSkillLevel in NewSkillLevels)
                {
                    if (OldSkillLevel.SkillLevelId == newSkillLevel.SkillLevelId)
                    {
                        UoW.SkillLevels.Update(newSkillLevel.SkillLevelId, newSkillLevel.Name, newSkillLevel.Description, newSkillLevel.SkillId, newSkillLevel.Level);
                        exist = true;
                    }
                }

                if (exist == false)
                {
                    UoW.SkillLevels.Delete(OldSkillLevel);
                }
            }
            foreach (SkillLevel newSkillLevel in NewSkillLevels)
            {
                if (newSkillLevel.SkillLevelId == 0)
                {
                    newSkillLevel.SkillId = skill.SkillId;
                    UoW.SkillLevels.Create(newSkillLevel);
                }
            }
            
            return UoW.Commit();
        }

        public IEnumerable<Position> GetPositionList(int SpecializationId)
        {
            if (UoW.Specializations.Find(SpecializationId) == null)
            {
                return null;
            }
            else
            {
                IEnumerable<Position> positions = UoW.Positions.Get(new Func<Position, bool>((Position a) => { return a.SpecializationId == SpecializationId; }));
                return positions;
            }
        }

        public bool DeletePosition(int id)
        {
            UoW.Positions.Delete(UoW.Positions.Find(id));
            return UoW.Commit();
        }

        public Position GetPosition(int PositionId)
        {
            return UoW.Positions.Find(PositionId);
        }

        public bool EditPosition(Position position)
        {
            int success = UoW.Positions.Update(position);
            return UoW.Commit() && (success != 0);
        }

        public Specialization GetSpecialization(int SpecializationId)
        {
            return UoW.Specializations.Find(SpecializationId);
        }

        public bool CreatePosition(Position position)
        {
            UoW.Positions.Create(position);
            return UoW.Commit();
        }

        public bool CreateSpecialization(Specialization specialization)
        {
            try
            {
                UoW.Specializations.Create(specialization);
                return UoW.Commit();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditSpecialization(Specialization spec)
        {
            bool success = UoW.Specializations.Update(spec)!= 0;
            return success && UoW.Commit();
        }


        public RoadMap GetRoadMap(int EmployeeId)
        {
            int RoadMapId = 0;
            if (UoW.Employees.Find(EmployeeId) != null && UoW.Employees.Find(EmployeeId).RoadMaps.FirstOrDefault() != null) RoadMapId = UoW.Employees.Find(EmployeeId).RoadMaps.FirstOrDefault().RoadMapId;
            return UoW.RoadMaps.Find(RoadMapId);
        }

        public bool DeleteRoadMap(int RoadMapId)
        {
            UoW.RoadMaps.Delete(UoW.RoadMaps.Find(RoadMapId));
            return UoW.Commit();
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
           return UoW.Employees.GetAll();
        }
        public bool AcceptCheckpoint(int RMCheckpointId)
        {
            RMCheckpoint checkpoint = UoW.RMCheckpoints.Find(RMCheckpointId);
            checkpoint.Achieved = 2;
            UoW.RMCheckpoints.Update(checkpoint);
            return UoW.Commit();
        }
        public bool RefuseCheckpoint(int RMCheckpointId)
        {
            RMCheckpoint checkpoint = UoW.RMCheckpoints.Find(RMCheckpointId);
            checkpoint.Achieved = 0;
            UoW.RMCheckpoints.Update(checkpoint);
            return UoW.Commit();
        }

        public Employee GetEmployeesProfile(int employeeId)
        {
            return UoW.Employees.Find(employeeId);
        }
    }
}