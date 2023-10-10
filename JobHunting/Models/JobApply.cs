using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class JobApply
    {
        public string JobApplyID { get; set; }
        public string UserID { get; set; }
        public string JobID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}