using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityRMCheckpointRepository : IRMCheckpointRepository
    {
        private readonly Entities1 context;

        public EntityRMCheckpointRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(RMCheckpoint entity)
        {
            return context.RMCheckpoints.Add(entity).RMCheckpointId;
        }

        public void Delete(RMCheckpoint entity)
        {
            context.RMCheckpoints.Remove(entity);
        }

        public RMCheckpoint Find(params object[] keyValues)
        {
            return context.RMCheckpoints.Find(keyValues);
        }

        public IEnumerable<RMCheckpoint> Get(Func<RMCheckpoint, bool> predicate)
        {
            return context.RMCheckpoints.Where(predicate);
        }

        public IEnumerable<RMCheckpoint> GetAll()
        {
            return context.RMCheckpoints.ToList();
        }

        public int Update(RMCheckpoint entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.RMCheckpointId;
        }
    }
}
