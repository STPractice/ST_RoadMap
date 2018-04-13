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

        public IAspNetRoleRepository AspNetRoles => throw new NotImplementedException();

        public IAspNetUserClaimRepository AspNetUserClaims => throw new NotImplementedException();

        public IAspNetUserLoginRepository AspNetUserLogins => throw new NotImplementedException();

        public IAspNetUserRepository AspNetUsers => throw new NotImplementedException();

        public ICheckpointSkillRepository CheckpointSkills => throw new NotImplementedException();

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

        public IMentorCheckpointCommentRepository MentorCheckpointComments => throw new NotImplementedException();

        public IMentorRepository Mentors => throw new NotImplementedException();

        public IMentorRMCommentRepository MentorRMComments => throw new NotImplementedException();

        public INotificationRepository Notifications => throw new NotImplementedException();

        IPositionRepository positions = null;
        public IPositionRepository Positions
        {
            get
            {
                if (positions == null)
                    positions = new EntityPositionRepository(context);
                return positions;
            }
        }

        public IRegistrationKeyRepository RegistrationKeys => throw new NotImplementedException();

        public IRMCheckpointRepository RMCheckpoints => throw new NotImplementedException();

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
                    specializations = new EntitySpecializationRepository(context);
                return specializations;
            }
        }

        public IUserCheckpointCommentRepository UserCheckpointComments => throw new NotImplementedException();

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
