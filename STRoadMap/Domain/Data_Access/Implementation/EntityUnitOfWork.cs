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

        public IEmployeeRepository Employees => throw new NotImplementedException();

        public IMentorCheckpointCommentRepository MentorCheckpointComments => throw new NotImplementedException();

        public IMentorRepository Mentors => throw new NotImplementedException();

        public IMentorRMCommentRepository MentorRMComments => throw new NotImplementedException();

        public INotificationRepository Notifications => throw new NotImplementedException();

        public IPositionRepository Positions => throw new NotImplementedException();

        public IRegistrationKeyRepository RegistrationKeys => throw new NotImplementedException();

        public IRMCheckpointRepository RMCheckpoints => throw new NotImplementedException();

        public IRoadMapRepository RoadMaps => throw new NotImplementedException();

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

        public ISkillMatrixRepository SkillMatrices => throw new NotImplementedException();

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

        public ISpecializationRepository Specializations => throw new NotImplementedException();

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
