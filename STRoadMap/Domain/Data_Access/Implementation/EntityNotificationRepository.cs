using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntityNotificationRepository : INotificationRepository
    {
        private readonly Entities1 context;

        public EntityNotificationRepository(Entities1 context)
        {
            this.context = context;
        }

        public int Create(Notification entity)
        {
            return context.Notifications.Add(entity).NotificationId;
        }

        public void Delete(Notification entity)
        {
            context.Notifications.Remove(entity);
        }

        public Notification Find(params object[] keyValues)
        {
            return context.Notifications.Find(keyValues);
        }

        public IEnumerable<Notification> Get(Func<Notification, bool> predicate)
        {
            return context.Notifications.Where(predicate);
        }

        public IEnumerable<Notification> GetAll()
        {
            return context.Notifications.ToList();
        }

        public int Update(Notification entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity.NotificationId;
        }
    }
}
