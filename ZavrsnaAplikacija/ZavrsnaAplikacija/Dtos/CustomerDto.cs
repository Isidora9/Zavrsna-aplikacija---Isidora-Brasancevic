using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public Nullable<int> DriverLicNo { get; set; }
    }
}