using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data {get;}
    }
}