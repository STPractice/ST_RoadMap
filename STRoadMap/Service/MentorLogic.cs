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
                int RoadMapId = 0;
                if (UoW.Employees.Find(employeeId) != null && UoW.Employees.Find(employeeId).RoadMaps.FirstOrDefault() != null)
            {
                RoadMapId = UoW.Employees.Find(employeeId).RoadMaps.FirstOrDefault().RoadMapId;
            }

            return UoW.RoadMaps.Find(RoadMapId);
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
    }
}