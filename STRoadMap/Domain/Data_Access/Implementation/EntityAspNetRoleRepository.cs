using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityAspNetRoleRepository : IAspNetRoleRepository
    {
        private readonly Entities1 context;

        public EntityAspNetRoleRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(AspNetRole entity)
        {
            context.AspNetRoles.Add(entity);
            return 0;
        }

        public void Delete(AspNetRole entity)
        {
            context.AspNetRoles.Remove(entity);
        }

        public AspNetRole Find(params object[] keyValues)
        {
            return context.AspNetRoles.Find(keyValues);
        }

        public IEnumerable<AspNetRole> Get(Func<AspNetRole, bool> predicate)
        {
            return context.AspNetRoles.Where(predicate);
        }

        public IEnumerable<AspNetRole> GetAll()
        {
            return context.AspNetRoles.ToList();
        }

        public int Update(AspNetRole entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return 0;
        }
    }
}
