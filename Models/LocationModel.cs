using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace opentrek.Models
{
    public class LocationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Invalid Country Format")]
        public string Country { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Invalid Recommendation Format")]
        public string Recommendation { get; set; }
    }
}
