using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityRoadMapRepository : IRoadMapRepository
    {
        private readonly Entities1 context;

        public EntityRoadMapRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(RoadMap entity)
        {
            return context.RoadMaps.Add(entity).RoadMapId;
        }

        public void Delete(RoadMap entity)
        {
            context.RoadMaps.Remove(entity);
        }

        public RoadMap Find(params object[] keyValues)
        {
            return context.RoadMaps.Find(keyValues);
        }

        public IEnumerable<RoadMap> Get(Func<RoadMap, bool> predicate)
        {
            return context.RoadMaps.Where(predicate);
        }

        public IEnumerable<RoadMap> GetAll()
        {
            return context.RoadMaps.ToList();
        }

        public int Update(RoadMap entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.RoadMapId;
        }
    }
}
