using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace opentrek.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Invalid First Name Length")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Invalid Last Name Length")]
        public string LastName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Invalid Username Length")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Invalid Password Format")]
        public string Password { get; set; }
    }
}
