using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Directory.Core.RepositoryDesign.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
    }
}
