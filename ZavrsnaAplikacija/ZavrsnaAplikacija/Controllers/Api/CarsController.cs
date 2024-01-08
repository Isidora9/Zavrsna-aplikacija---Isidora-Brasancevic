using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using ZavrsnaAplikacija.Dtos;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.Controllers.Api
{
    public class CarsController : ApiController
    {
        private DbCarRentalEntities _context;
        public CarsController()
        {
            _context = new DbCarRentalEntities();
        }

        // GET/api/Cars
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        }

        // GET/api/Cars/5
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        // POST/api/Cars
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var car = Mapper.Map<CarDto, Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();
            carDto.CarId = car.CarId;
            return Created(new Uri(Request.RequestUri + "/" + car.CarId), carDto);
        }

        // PUT/api/Cars/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var carInDb = _context.Cars.SingleOrDefault(c => c.CarId == id);
            if (carInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(carDto, carInDb);
            //carInDb.CarId = car.CarId;
            //carInDb.Manufacturer = car.Manufacturer;
            //carInDb.Model = car.Model;
            //carInDb.LicensePlate = car.LicensePlate;
            //carInDb.Year = car.Year;
            //carInDb.Available = car.Available;
            _context.SaveChanges();
            return Ok();
        }
        // DELETE/api/Cars/1

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCar(int id) 
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.CarId == id);
            if (carInDb == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(carInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
