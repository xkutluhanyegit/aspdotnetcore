using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger,ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _customerService.GetAll();
            if (result.Success)
            {
                var resultMap = await _customerService.GetAllCustomerDto();
                if (resultMap.Success)
                {
                    return View(resultMap.Data);
                }

                
            }
            return View();
        }

        
    }
}