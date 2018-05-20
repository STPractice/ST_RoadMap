using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntitySkillMatrixRepository : ISkillMatrixRepository
    {
        private readonly Entities1 context;
        private readonly IUnitOfWork UoW;

        public EntitySkillMatrixRepository(Entities1 context, IUnitOfWork UoW)
        {
            this.context = context;
            this.UoW = UoW;
        }

        public int Create(SkillMatrix entity)
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
            return context.SkillMatrices.Add(entity).SkillMatrixId;
        }

        public void Delete(SkillMatrix entity)
        {
            context.SkillMatrices.Remove(entity);
        }

        public SkillMatrix Find(params object[] keyValues)
        {
            return context.SkillMatrices.Find(keyValues);
        }

        public IEnumerable<SkillMatrix> Get(Func<SkillMatrix, bool> predicate)
        {
            return context.SkillMatrices.Where(predicate);
        }

        public IEnumerable<SkillMatrix> GetAll()
        {
            return context.SkillMatrices.ToList();
        }

        public int Update(SkillMatrix entity)
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

            SkillMatrix currentMatrix = Find(entity.SkillMatrixId);
            if (currentMatrix == null) return 0;
            currentMatrix.SpecializationId = entity.SpecializationId;
            currentMatrix.EmpolyeeId = entity.EmpolyeeId;

            List<SkillLevel> OldSkillLevels = currentMatrix.SkillLevels.ToList<SkillLevel>();
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
                    currentMatrix.SkillLevels.Remove(oldSkillLevel);
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
                    currentMatrix.SkillLevels.Add(newSkillLevel);
                }
            }

            try
            {
                context.Entry(currentMatrix).State = System.Data.Entity.EntityState.Modified;
                return currentMatrix.SpecializationId;
            }

            catch (Exception)
            {
                return 0;
            }
        }
    }
}
