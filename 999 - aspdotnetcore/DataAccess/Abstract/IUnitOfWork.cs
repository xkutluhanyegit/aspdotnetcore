using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerDal _customerRepository{get;}
        Task<int> CompleteAsync(); 
        void BeginTransaction(); 
        Task CommitTransactionAsync();  
        Task RollbackTransactionAsync(); 
    }
}