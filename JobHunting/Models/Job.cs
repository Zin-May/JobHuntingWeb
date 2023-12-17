using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class Job
    {
        public string JobID { get; set; }
        public string CompanyID { get; set; }
        public string JobRoleID { get; set; }
        public string JobTypeID { get; set; }
        public string CategoryID { get; set; }
        public string JobLocationID { get; set; }
        public string JobPositionID { get; set; }
        public string Allowence { get; set; }
        public string Salary { get; set; }
        public string JobDescription { get; set; }
        public string JobResponsibility { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; }
    }
}