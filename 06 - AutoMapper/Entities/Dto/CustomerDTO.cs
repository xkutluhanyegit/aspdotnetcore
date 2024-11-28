using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dto
{
    public class CustomerDTO:IDto
    {
        public string CompanyName { get; set; } 

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }
    }
}