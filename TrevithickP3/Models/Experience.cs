using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class Experience
    {
        [Key]
       public int ExperienceID { get; set; }

       public   string Description { get; set; }

       public  DateTime End { get; set; }

       public DateTime Start { get; set; }

       public string Title { get; set; }
    }
}
