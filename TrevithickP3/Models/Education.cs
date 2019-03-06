using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class Education
    {
        [Key]
       public int EducationID { get; set; }
       public string Degree { get; set; }
      public  DateTime End { get; set; }
       public string School { get; set; }
       public DateTime Start { get; set; }
    }
}
