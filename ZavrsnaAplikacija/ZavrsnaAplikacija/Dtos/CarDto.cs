using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.Dtos
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<bool> Available { get; set; }
    }
}