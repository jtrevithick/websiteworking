
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using TrevithickP3.Data;

namespace TrevithickP3.Models
{
    
    public class ResumeViewModel
    {
        private readonly ApplicationDbContext dbContext;

        [Key]
        public int ResumeId { get; set; }
        public List<Education> EducationItems { get; set; }

        public List<Experience> ExperienceItems { get; set; }

        public string Preamble { get; set; }

        public List<Skill> SkillItems { get; set; }

       public ResumeViewModel()
        {

            Preamble = "Motivated entry level programmer with.net experience looking for challenging and rewarding job.";
            
    }
    }
}
