using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija.Dtos;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<CarDto, Car>();

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Rental, RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>();
        }
    }
}