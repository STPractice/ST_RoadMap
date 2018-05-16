using Extensibility;
using System;
using System.Collections.Generic;
using Domain;
using System.IO;
using System.Linq;
using System.Security.Principal;
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

        public Employee GetEmployee(int EmployeeId)
        {
            return UoW.Employees.Find(EmployeeId);
        }

        public int CreateRoadMap(RoadMap roadMap)
        {
            roadMap.Deadline = roadMap.RMCheckpoints.Last().Deadline;
            roadMap.Employee = UoW.Employees.Find(roadMap.EmpolyeeId);
            if (UoW.Employees.Find(roadMap.EmpolyeeId).RoadMaps.Count != 0)
            {
                UoW.RoadMaps.Delete(UoW.RoadMaps.Find(UoW.Employees.Find(roadMap.EmpolyeeId).RoadMaps.First().RoadMapId));
            }
            UoW.RoadMaps.Create(roadMap);
            if (UoW.Commit())
            { 
                return UoW.Employees.Find(roadMap.EmpolyeeId).RoadMaps.First().RoadMapId;
            }
            else
            {
                return 0;
            }
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

        public List<Skill> GetEmployeesAvailableSkills(int EmployeeId)
        {
            Employee employee = UoW.Employees.Find(EmployeeId);
            if (employee != null&& employee.SkillMatrices.FirstOrDefault()!= null)
            {
                return employee.SkillMatrices.FirstOrDefault().Specialization.Skills.ToList();
            }
            else
            {
                return null;
            }
        }

        public Employee GetEmployeesProfile(int employeeId)
        {
            return UoW.Employees.Find(employeeId);
        }

        public bool DecreaseEmployee(int employeeId)
        {
            var user = GetEmployeesProfile((int)employeeId);
            if (user == null)
            {
                return false;
            }

            var role = user.AspNetUser.AspNetRoles.FirstOrDefault(r => r.Name == "HR");
            if (role != null)
            {
                user.AspNetUser.AspNetRoles.Remove(role);
                UoW.Commit();
                return true;
            }
            role = user.AspNetUser.AspNetRoles.FirstOrDefault(r => r.Name == "Mentor");
            if (role != null)
            {
                user.AspNetUser.AspNetRoles.Remove(role);
                UoW.Commit();
                return true;
            }

            return false;
        }

        public bool IncreaseEmployee(int employeeId)
        {
            var user = GetEmployeesProfile((int)employeeId);
            if (user == null)
            {
                return false;
            }

            var role = user.AspNetUser.AspNetRoles.FirstOrDefault(r => r.Name == "HR");
            if (role != null)
            {
                return false;
            }
            role = user.AspNetUser.AspNetRoles.FirstOrDefault(r => r.Name == "Mentor");
            if (role != null)
            {
                user.AspNetUser.AspNetRoles.Add(UoW.AspNetRoles.Find("ed5466fa-bb11-4ce0-a4d0-0d9e35b9607b"));
                UoW.Commit();
                return true;
            }
            user.AspNetUser.AspNetRoles.Add(UoW.AspNetRoles.Find("4066c225-7328-49ac-b0a0-77ca4d8782ee"));
            UoW.Commit();
            return true;
        }

        public void NotifyUsersSpecializationEdited(Specialization specialization)
        {
            foreach (Employee employee in UoW.Employees.GetAll())
            {
                if (employee.SkillMatrices.ToArray()[0].Specialization.SpecializationId.Equals(specialization.SpecializationId))
                {
                    Notification notification =
                        new Notification
                        {
                            Content = "You specialization was edited, check for updates",
                            UserId = employee.UserId,
                            url = "Employee/specialization"
                        };
                    UoW.Notifications.Create(notification);
                    UoW.Commit();
                }
                
            }
           
        }

        public void NotifyCheckPointAccepted(int? employeeId, int? rmCheckpointId)
        {
            var employee = UoW.Employees.Find(employeeId);
            Notification notification = new Notification
            {
                Content = "Your checkpoint was accepted",
                UserId = employee.UserId,
                url = "Employee/RoadMap"
            };
            UoW.Notifications.Create(notification);
            UoW.Commit();
        }

        public void NotifyCheckPointRefused(int? employeeId, int? rmCheckpointId)
        {
            var employee = UoW.Employees.Find(employeeId);
            Notification notification = new Notification
            {
                Content = "Your checkpoint was accepted",
                UserId = employee.UserId,
                url = "Employee/RoadMap"
            };
            UoW.Notifications.Create(notification);
            UoW.Commit();
        }
        public void NotifyRoadMapCreated(int? employeeId)
        {
            var employee = UoW.Employees.Find(employeeId);
            Notification notification = new Notification
            {
                Content = "Your roadmap was created, check for updates",
                UserId = employee.UserId,
                url = "Employee/RoadMap"
            };
            UoW.Notifications.Create(notification);
            UoW.Commit();
        }
    }
}