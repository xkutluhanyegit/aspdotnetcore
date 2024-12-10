using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Get(Expression<Func<T,bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T,bool>> filter = null);
    }

    
 
}


