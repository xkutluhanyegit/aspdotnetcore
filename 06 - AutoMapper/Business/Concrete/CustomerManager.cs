using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal,IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }
        public async Task<IResult> Add(Customer customer)
        {
            await _customerDal.Add(customer);
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Customer customer)
        {
            await _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            var result = await _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public async Task<IDataResult<List<CustomerDTO>>> GetAllCustomerDto()
        {
            var result = await _customerDal.GetAll();
            var data =  _mapper.Map<List<CustomerDTO>>(result);

            return new SuccessDataResult<List<CustomerDTO>>(data);
        }

        public async Task<IDataResult<Customer>> GetById(int id)
        {
            var result = await _customerDal.Get(l=>l.CustomerId == id.ToString());
            return new SuccessDataResult<Customer>(result);
        }

        public async Task<IResult> Update(Customer customer)
        {
            await _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}