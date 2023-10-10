using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class UserProfileController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_userprofile> GetAllUserProfile()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_userprofiles.ToList();
            }
        }

        public bool InsertUserProfile(tbl_userprofile up)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userprofiles.Where(urp => urp.UserID == up.UserID).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_userprofiles.InsertOnSubmit(up);
                        jdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUserProfile(tbl_userprofile up)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userprofiles.Where(urp => urp.UserProfileID == up.UserProfileID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserImage = up.UserImage;
                        obj.DateOfBirth = up.DateOfBirth;
                        obj.Address = up.Address;
                        obj.Education = up.Education;
                        obj.SocialMediaLink = up.SocialMediaLink;
                        obj.UserID = up.UserID;
                        jdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUserProfile(tbl_userprofile up)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userprofiles.Where(urp => urp.UserProfileID == up.UserProfileID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_userprofiles.DeleteOnSubmit(obj);
                        jdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool GetByUserProfileID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userprofiles.Where(urp => urp.UserProfileID == id).FirstOrDefault();
                    if (obj != null)
                    {
                       obj.ToString();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}