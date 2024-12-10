using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Concrete.Entityframwork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        public ICustomerDal _customerRepository {get;private set;}
        private IDbContextTransaction _transaction;
        public UnitOfWork(NorthwindContext context,ICustomerDal customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                // Değişiklikleri kaydet
                await  _context.SaveChangesAsync();

                // Transaction'ı commit et
                await _transaction.CommitAsync();
            }
            catch (System.Exception)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }
    }
}