using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class CompanyModel
    {
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public byte[] CompanyImage { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int EmployeeCount { get; set; }
    }
}