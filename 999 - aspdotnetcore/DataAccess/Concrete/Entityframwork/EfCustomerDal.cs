using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Entityframwork
{
    public class EfCustomerDal:EfEntityRepositoryBase<NorthwindContext,Customer>,ICustomerDal
    {
        
    }
}