using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class WorkExperience
    {
        public string WorkExperienceID { get; set; }
        public string CompanyID { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string UserProfileID { get; set; }
    }
}