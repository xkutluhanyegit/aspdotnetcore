using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator,object entity)
        {   
            var result = validator.Validate(new ValidationContext<object>(entity));
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }   
        }
    }
}