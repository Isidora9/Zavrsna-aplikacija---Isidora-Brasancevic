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
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CustomerDto()
        //{
        //    this.Rentals = new HashSet<Rental>();
        //}
        public int CustomerId { get; set; }
        //[Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please.")]
        [Display(Name = "Customer’s Name")]
        public string Name { get; set; }
        //[Required]
        [Display(Name = "Driver's license number")]
        public Nullable<int> DriverLicNo { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Rental> Rentals { get; set; }

    }
}