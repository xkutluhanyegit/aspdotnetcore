using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public string Message {get;}

        public bool Success {get;}

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
    }
}