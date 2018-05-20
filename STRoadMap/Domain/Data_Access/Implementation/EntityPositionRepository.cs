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
            List<SkillLevel> innerSkillLevels = new List<SkillLevel>();
            foreach (SkillLevel foreignSkillLevel in entity.SkillLevels)
            {
                SkillLevel innerSkillLevel = UoW.SkillLevels.Find(foreignSkillLevel.SkillLevelId);
                if (innerSkillLevel != null)
                {
                    innerSkillLevels.Add(innerSkillLevel);
                }
                else
                {
                    return 0;
                }
            }
            entity.SkillLevels = innerSkillLevels;

            Position currentPosition = Find(entity.PositionId);
            if (currentPosition == null) return 0;
            currentPosition.Name = entity.Name;
            currentPosition.PositionLevel = entity.PositionLevel;
            
            List<SkillLevel> OldSkillLevels = currentPosition.SkillLevels.ToList<SkillLevel>();
            List<SkillLevel> NewSkillLevels = entity.SkillLevels.ToList<SkillLevel>();

            foreach (SkillLevel oldSkillLevel in OldSkillLevels)
            {
                bool exist = false;

                foreach (SkillLevel newSkillLevel in NewSkillLevels)
                {
                    if (oldSkillLevel.SkillLevelId == newSkillLevel.SkillLevelId)
                    {
                        exist = true;
                    }
                }
                if (exist == false)
                {
                    currentPosition.SkillLevels.Remove(oldSkillLevel);
                }
            }
            foreach (SkillLevel newSkillLevel in NewSkillLevels)
            {
                bool exist = false;
                foreach (SkillLevel oldSkillLevel in OldSkillLevels)
                {
                    if (newSkillLevel.SkillLevelId == oldSkillLevel.SkillLevelId) exist = true;
                }
                if (exist == false)
                {
                    currentPosition.SkillLevels.Add(newSkillLevel);
                }
            }

            try
            {
                context.Entry(currentPosition).State = System.Data.Entity.EntityState.Modified;
                return currentPosition.SpecializationId;
            }

            catch (Exception)
            {
                return 0;
            }
        }
    }
}
