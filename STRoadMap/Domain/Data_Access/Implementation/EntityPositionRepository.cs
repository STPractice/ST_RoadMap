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

        public EntityPositionRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(Position entity)
        {
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
