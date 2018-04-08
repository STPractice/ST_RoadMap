using System;
using System.Collections.Generic;

namespace Domain
{
	public interface IRepository<T> where T : IEntity
    {
		IEnumerable<T> GetAll();

        int Create(T entity);

        T GetById(Guid id);

		int Update(T entity);

		void Delete(Guid id);
	}
}
