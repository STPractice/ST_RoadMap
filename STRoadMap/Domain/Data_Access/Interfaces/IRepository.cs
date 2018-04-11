using System;
using System.Collections.Generic;

namespace Domain
{
	public interface IRepository<T> where T : IEntity
    {
		IEnumerable<T> GetAll();

        int Create(T entity);

        IEnumerable<T> Get(Func<T,bool> predicate);

        T Find(params object[] keyValues);

		int Update(T entity);

		void Delete(T entity);
	}
}
