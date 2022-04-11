using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCTest.Model
{
   public class EmployeeModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Enter First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage ="Enter Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public int? AddressId { get; set; }

        [Required]
        [DisplayName("Emp Code")]
        public string Code { get; set; }

        public AddressModel Address { get; set; }
    }
}
