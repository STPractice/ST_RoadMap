using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityRegistrationKeyRepository : IRegistrationKeyRepository
    {
        private readonly Entities1 context;

        public EntityRegistrationKeyRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(RegistrationKey entity)
        {
            context.RegistrationKeys.Add(entity);
            return 0;
        }

        public void Delete(RegistrationKey entity)
        {
            context.RegistrationKeys.Remove(entity);
        }

        public RegistrationKey Find(params object[] keyValues)
        {
            return context.RegistrationKeys.Find(keyValues);
        }

        public IEnumerable<RegistrationKey> Get(Func<RegistrationKey, bool> predicate)
        {
            return context.RegistrationKeys.Where(predicate);
        }

        public IEnumerable<RegistrationKey> GetAll()
        {
            return context.RegistrationKeys.ToList();
        }

        public int Update(RegistrationKey entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return 0;
        }
    }
}
