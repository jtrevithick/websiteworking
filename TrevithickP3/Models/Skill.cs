﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class Skill
    {
        [Key]
       public int SkillID { get; set; }
       public string Description { get; set; }
       public string Title { get; set; }
    }
}
