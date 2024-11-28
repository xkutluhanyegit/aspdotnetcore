using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IResult> Add(Customer customer);
        Task<IResult> Delete(Customer customer);
        Task<IResult> Update(Customer customer);
        Task<IDataResult<Customer>> GetById(int id);
        Task<IDataResult<List<Customer>>> GetAllCustomers();
    }
}