using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZavrsnaAplikacija.Dtos;
using ZavrsnaAplikacija.Models;
using System.Data.Entity;


namespace ZavrsnaAplikacija.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private DbCarRentalEntities _context;
        public RentalsController() 
        {
            _context = new DbCarRentalEntities();
        }
        // GET/api/Rentals
        public IEnumerable<RentalDto> GetRentals()
        {
            var rentalQuery = _context.Rentals.Include(c => c.Car).Include(r => r.Customer);
            return rentalQuery.ToList().Select(Mapper.Map<Rental, RentalDto>);
        }
        // GET/api/Rentals/5
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(c => c.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }
        // POST/api/Rentals
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            rentalDto.RentalId = rental.RentalId;
            return Created(new Uri(Request.RequestUri + "/" + rental.RentalId), rentalDto);
        }
        // PUT/api/Rentals/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);
            if (rentalInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(rentalDto, rentalInDb);
            _context.SaveChanges();
            return Ok();
        }
        // DELETE/api/Rentals/1

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.RentalId == id);
            if (rentalInDb == null)
            {
                return NotFound();
            }
            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
