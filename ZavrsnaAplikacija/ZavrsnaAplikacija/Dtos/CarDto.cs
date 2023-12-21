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
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CarDto()
        //{
        //    this.Rentals = new HashSet<Rental>();
        //}
        public int CarId { get; set; }
        //[Required]
        [Display(Name = "Car Manufacturer")]
        public string Manufacturer { get; set; }
        //[Required]
        public string Model { get; set; }
        //[Required]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        //[Required]
        public Nullable<int> Year { get; set; }
        //[Required]
        public Nullable<bool> Available { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Rental> Rentals { get; set; }

    }
}