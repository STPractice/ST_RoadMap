using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    public interface IEmployeeLogic
    {
        Specialization GetSpecialization(int SpecializationId);
        bool CreateSkillMatrix(SkillMatrix matrix, string userName);
        IEnumerable<Specialization> GetSpecializations();
        SkillMatrix GetSkillMatrix(string userId);
        Employee GetProfile(string UserId);
        bool IsPerformanceReviewPassed(string employeeId);
        bool IsRoadMapExists(string employeeId);
        RoadMap getRoadMap(string employeeId);
        bool PassCheckpoint(int RMCheckpointId);
        bool ChangeSkillCondition(int RMCheckpointId, int SkillLevelId);
        IEnumerable<Notification> GetAllUsersNotifications(string userId);
        bool DeleteNotification(int? notificationId);
    }
}
