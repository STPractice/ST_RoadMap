using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        public readonly Entities1 context = new Entities1();

        public EntityUnitOfWork()
        {

        }

        IAspNetRoleRepository aspNetRoles = null;
        public IAspNetRoleRepository AspNetRoles
        {
            get
            {
                if (aspNetRoles == null)
                    aspNetRoles = new EntityAspNetRoleRepository(context);
                return aspNetRoles;
            }
        }

        IAspNetUserClaimRepository aspNetUserClaims = null;
        public IAspNetUserClaimRepository AspNetUserClaims
        {
            get
            {
                if (aspNetUserClaims == null)
                    aspNetUserClaims = new EntityAspNetUserClaimRepository(context);
                return aspNetUserClaims;
            }
        }

        IAspNetUserLoginRepository aspNetUserLogins = null;
        public IAspNetUserLoginRepository AspNetUserLogins
        {
            get
            {
                if (aspNetUserLogins == null)
                    aspNetUserLogins = new EntityAspNetUserLoginRepository(context);
                return aspNetUserLogins;
            }
        }

        IAspNetUserRepository aspNetUsers = null;
        public IAspNetUserRepository AspNetUsers
        {
            get
            {
                if (aspNetUsers == null)
                    aspNetUsers = new EntityAspNetUserRepository(context);
                return aspNetUsers;
            }
        }

        ICheckpointsSkillRepository checkpointsSkills = null;
        public ICheckpointsSkillRepository CheckpointsSkills
        {
            get
            {
                if (checkpointsSkills == null)
                    checkpointsSkills = new EntityCheckpointsSkillRepository(context);
                return checkpointsSkills;
            }
        }

        IEmployeeRepository employees = null;
        public IEmployeeRepository Employees
        {
            get
            {
                if (employees == null)
                    employees = new EntityEmployeeRepository(context);
                return employees;
            }
        }

        IMentorCheckpointCommentRepository mentorCheckpointComments = null;
        public IMentorCheckpointCommentRepository MentorCheckpointComments
        {
            get
            {
                if (mentorCheckpointComments == null)
                    mentorCheckpointComments = new EntityMentorCheckpointCommentRepository(context);
                return mentorCheckpointComments;
            }
        }

        IMentorRepository mentors = null;
        public IMentorRepository Mentors
        {
            get
            {
                if (mentors == null)
                    mentors = new EntityMentorRepository(context);
                return mentors;
            }
        }

        IMentorRMCommentRepository mentorRMComments = null;
        public IMentorRMCommentRepository MentorRMComments
        {
            get
            {
                if (mentorRMComments == null)
                    mentorRMComments = new EntityMentorRMCommentRepository(context);
                return mentorRMComments;
            }
        }

        INotificationRepository notifications = null;
        public INotificationRepository Notifications
        {
            get
            {
                if (notifications == null)
                    notifications = new EntityNotificationRepository(context);
                return notifications;
            }
        }

        IPositionRepository positions = null;
        public IPositionRepository Positions
        {
            get
            {
                if (positions == null)
                    positions = new EntityPositionRepository(context, this);
                return positions;
            }
        }

        IRegistrationKeyRepository registrationKeys = null;
        public IRegistrationKeyRepository RegistrationKeys
        {
            get
            {
                if (registrationKeys == null)
                    registrationKeys = new EntityRegistrationKeyRepository(context);
                return registrationKeys;
            }
        }

        IRMCheckpointRepository rMCheckpoints = null;
        public IRMCheckpointRepository RMCheckpoints
        {
            get
            {
                if (rMCheckpoints == null)
                    rMCheckpoints = new EntityRMCheckpointRepository(context);
                return rMCheckpoints;
            }
        }

        IRoadMapRepository roadMaps = null;
        public IRoadMapRepository RoadMaps
        {
            get
            {
                if (roadMaps == null)
                    roadMaps = new EntityRoadMapRepository(context);
                return roadMaps;
            }
        }

        ISkillLevelRepository skillLevels = null;
        public ISkillLevelRepository SkillLevels
        {
            get
            {
                if (skillLevels == null)
                    skillLevels = new EntitySkillLevelRepository(context);
                return skillLevels;
            }
        }

        ISkillMatrixRepository skillMatrices = null;
        public ISkillMatrixRepository SkillMatrices
        {
            get
            {
                if (skillMatrices == null)
                    skillMatrices = new EntitySkillMatrixRepository(context);
                return skillMatrices;
            }
        }

        ISkillRepository skills = null;
        public ISkillRepository Skills
        {
            get
            {
                if (skills == null)
                    skills = new EntitySkillRepository(context);
                return skills;
            }
        }

        ISpecializationRepository specializations = null;
        public ISpecializationRepository Specializations
        {
            get
            {
                if (specializations == null)
                    specializations = new EntitySpecializationRepository(context, this);
                return specializations;
            }
        }

        IUserCheckpointCommentRepository userCheckpointComments = null;
        public IUserCheckpointCommentRepository UserCheckpointComments
        {
            get
            {
                if (userCheckpointComments == null)
                    userCheckpointComments = new EntityUserCheckpointCommentRepository(context);
                return userCheckpointComments;
            }
        }

        public bool Commit()
        {
            try
            {
                return context.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
