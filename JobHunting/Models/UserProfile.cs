using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class UserProfile
    {
        public string UserProfileID { get; set; }
        public Binary UserImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string SocialMediaLink { get; set; }
        public string UserID { get; set; }
    }
}