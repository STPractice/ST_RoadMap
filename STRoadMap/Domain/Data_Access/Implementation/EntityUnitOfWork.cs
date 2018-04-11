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
            Skills = new EntitySkillRepository(this);
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

        public ISkillLevelRepository SkillLevels { get; }

        public ISkillMatrixRepository SkillMatrices => throw new NotImplementedException();

        public ISkillRepository Skills { get; }

        public ISpecializationRepository Specializations => throw new NotImplementedException();

        public IUserCheckpointCommentRepository UserCheckpointComments => throw new NotImplementedException();

        public bool Commit()
        {
            try
            {
                return context.SaveChanges()>=0;
            }
            catch
            {
                return false;
            }
        }
    }
}
