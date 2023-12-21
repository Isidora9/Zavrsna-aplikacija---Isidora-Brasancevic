using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ZavrsnaAplikacija.Models;

namespace ZavrsnaAplikacija.Dtos
{
    public class RentalDto
    {
        public int RentalId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> CarId { get; set; }
        //[Required]
        [Display(Name = "Date Rented")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateRented { get; set; }
        //[Required]
        [Display(Name = "Date Returned")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateReturned { get; set; }

        public CarDto Car { get; set; }
        public CustomerDto Customer { get; set; }

    }
}