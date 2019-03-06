using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public bool Quote { get; set; }
        public bool Generalmessage { get; set; }
        public bool Webapp { get; set; }
        public bool Windowsapp { get; set; }
        public bool Phoneapp { get; set; }

    }
}
