using System;

namespace Domain
{
    public interface IUnitOfWork
    {        
        IAspNetRoleRepository AspNetRoles { get; }
        IAspNetUserClaimRepository AspNetUserClaims { get; }
        IAspNetUserLoginRepository AspNetUserLogins { get; }
        IAspNetUserRepository AspNetUsers { get; }
        ICheckpointSkillRepository CheckpointSkills { get; }
        IEmployeeRepository Employees { get; }
        IMentorCheckpointCommentRepository MentorCheckpointComments { get; }
        IMentorRepository Mentors { get; }
        IMentorRMCommentRepository MentorRMComments { get; }
        INotificationRepository Notifications { get; }
        IPositionRepository Positions { get; }
        IRegistrationKeyRepository RegistrationKeys { get; }
        IRMCheckpointRepository RMCheckpoints { get; }
        IRoadMapRepository RoadMaps { get; }
        ISkillLevelRepository SkillLevels { get; }
        ISkillMatrixRepository SkillMatrices { get; }
        ISkillRepository Skills { get; }
        ISpecializationRepository Specializations { get; }
        IUserCheckpointCommentRepository UserCheckpointComments { get; }

        bool Commit();
    }    
}