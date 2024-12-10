using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;


        public CustomerManager(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [ValidationAspect(typeof(CustomerValidatior))]
        public async Task<IResult> Add(Customer customer)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                await _unitOfWork._customerRepository.Add(customer);
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (System.Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
            return new SuccessResult();
        }

        public async Task<IResult> Delete(Customer customer)
        {
            await _unitOfWork._customerRepository.Delete(customer);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            var result = await _unitOfWork._customerRepository.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public async Task<IDataResult<List<CustomerDTO>>> GetAllCustomerDto()
        {
            var result = await _unitOfWork._customerRepository.GetAll();
            var data =  _mapper.Map<List<CustomerDTO>>(result);

            return new SuccessDataResult<List<CustomerDTO>>(data);
        }

        public async Task<IDataResult<Customer>> GetById(int id)
        {
            var result = await _unitOfWork._customerRepository.Get(l=>l.CustomerId == id.ToString());
            return new SuccessDataResult<Customer>(result);
        }

        public async Task<IResult> Update(Customer customer)
        {
            await _unitOfWork._customerRepository.Update(customer);
            return new SuccessResult();
        }
    }
}