using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDTO>();
            CreateMap<CustomerDTO,Customer>();
        }
    }
}