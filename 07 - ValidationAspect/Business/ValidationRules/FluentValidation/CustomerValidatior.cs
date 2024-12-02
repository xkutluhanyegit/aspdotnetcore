using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidatior:AbstractValidator<Customer>
    {
        public CustomerValidatior()
        {   
            RuleFor(p=>p.CompanyName).NotEmpty().MinimumLength(2).WithMessage("*Minimum 2 karakter olmalıdır!");
        }
    }
}