using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Interfaces.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll ();
        bool Create(T entity);
        bool Delete(int id);
        T GetById(int id);
        bool Update(T modifiedEntity);
    }
}
