using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZavrsnaAplikacija.Dtos;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private DbCarRentalEntities _context;
        public CustomersController()
        {
            _context = new DbCarRentalEntities();
        }

        // GET/api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }
        // GET/api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        // POST/api/Customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.CustomerId = customer.CustomerId;
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);
        }
        // PUT/api/Customers/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.CustomerId = customer.CustomerId;
            //customerInDb.Name = customer.Name;
            //customerInDb.DriverLicNo = customer.DriverLicNo;
            _context.SaveChanges();
            return Ok();
        }
        // DELETE/api/Customers/1

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
