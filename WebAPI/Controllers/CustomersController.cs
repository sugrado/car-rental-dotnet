using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcustomerdetail")]
        public IActionResult GetDetailsById(int customerId)
        {
            var result = _customerService.GetCustomerDetail(customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcustomersdetail")]
        public IActionResult GetDetails()
        {
            var result = _customerService.GetCustomersDetail();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.DeleteCustomer(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("updatefindex")]
        public IActionResult UpdateCustomerFindexScore(Customer customer)
        {
            var result = _customerService.UpdateCustomerFindexScore(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
