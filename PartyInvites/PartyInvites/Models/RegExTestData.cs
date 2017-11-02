using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class RegExTestData
    {
        //[Required(ErrorMessage ="Please enter the postal code")]
        //[RegularExpression(@"\d\d\d\d-\d\d\d", ErrorMessage ="Invalid Postal Code")] // @:trata como string normal: resolve problema /d
        //public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Invalid Postal Code")] // @:trata como string normal: resolve problema /d
        public string PostalCode { get; set; }

        // Portuguese License Plate
        [RegularExpression(@"[A-Z0-9]{2}-[A-Z0-9]{2}-[A-Z0-9]{2}", ErrorMessage = "Invalid License Plate")]
        public string LicensePlate { get; set; }

        //// Portuguese phone
        //[RegularExpression(@"(2\d{8})|9[1236])\d{7}", ErrorMessage = "Invalid phone number")]
        //public string Phone { get; set; }

        // Portuguese phone
        [RegularExpression(@"(2\d{8})|9([1236]\d{7})", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
    }
}
