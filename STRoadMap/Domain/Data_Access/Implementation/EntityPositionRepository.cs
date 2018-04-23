using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityPositionRepository : IPositionRepository
    {
        private readonly Entities1 context;
        private readonly IUnitOfWork UoW;

        public EntityPositionRepository(Entities1 context, IUnitOfWork UoW)
        {
            this.context = context;
            this.UoW = UoW;
        }

        public int Create(Position entity)
        {
            Specialization innerSpecialization = UoW.Specializations.Find(entity.SpecializationId);
            if (innerSpecialization == null)
            {
                return 0;
            }
            entity.Specialization = innerSpecialization;

            List<SkillLevel> innerSkillLevels = new List<SkillLevel>();
            foreach (SkillLevel skillLevel in entity.SkillLevels)
            {
                SkillLevel innerSkillLevel = UoW.SkillLevels.Find(skillLevel.SkillLevelId);
                innerSkillLevels.Add(innerSkillLevel);
                if (innerSkillLevel == null)
                {
                    return 0;
                }
            }
            entity.SkillLevels = innerSkillLevels;

            return context.Positions.Add(entity).PositionId;
        }

        public void Delete(Position entity)
        {
            context.Positions.Remove(entity);
        }

        public Position Find(params object[] keyValues)
        {
            return context.Positions.Find(keyValues);
        }

        public IEnumerable<Position> Get(Func<Position, bool> predicate)
        {
            return context.Positions.Where(predicate);
        }

        public IEnumerable<Position> GetAll()
        {
            return context.Positions.ToList();
        }

        public int Update(Position entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.PositionId;
        }
    }
}
