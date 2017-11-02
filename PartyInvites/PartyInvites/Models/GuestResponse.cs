using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models {
    public class GuestResponse {

        // MVC automatically detects the attributes and uses them to validate data during the model-binding
        // process.
        // EX: - WillAttend - The browser sends a null value if the user has not selected a
        // value, and this causes the Required attribute to report a validation error.This is a nice example of how MVC
        // elegantly blends C# features with HTML and HTTP.

        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; } // COISAS EM QUE PRECISA FAZER CONTAS OU COMPARAR usamos INT !!

        /*
         [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
             
         */

        [Required(ErrorMessage = "Please specify whether you will attend the party")]
        public bool? WillAttend { get; set; } // true, false ou nulo > neste exemplo com validação não faz sentido nulo
    }
}
