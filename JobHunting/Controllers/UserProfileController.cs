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
            using (JobHuntingDBDataContext updb = new JobHuntingDBDataContext(con))
            {
                return updb.tbl_userprofiles.ToList();
            }
        }

        public bool InsertUserProfile(tbl_userprofile up)
        {
            try
            {
                using (JobHuntingDBDataContext updb = new JobHuntingDBDataContext(con))
                {
                    var obj = updb.tbl_userprofiles.Where(urp => urp.UserID == up.UserID).FirstOrDefault();
                    if (obj == null)
                    {
                        updb.tbl_userprofiles.InsertOnSubmit(up);
                        updb.SubmitChanges();
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
                using (JobHuntingDBDataContext updb = new JobHuntingDBDataContext(con))
                {
                    var obj = updb.tbl_userprofiles.Where(urp => urp.UserProfileID == up.UserProfileID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserImage = up.UserImage;
                        obj.DateOfBirth = up.DateOfBirth;
                        obj.Address = up.Address;
                        obj.Education = up.Education;
                        obj.SocialMediaLink = up.SocialMediaLink;
                        obj.UserID = up.UserID;
                        updb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUserProfile(string id)
        {
            try
            {
                using (JobHuntingDBDataContext updb = new JobHuntingDBDataContext(con))
                {
                    var obj = updb.tbl_userprofiles.Where(urp => urp.UserProfileID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        updb.tbl_userprofiles.DeleteOnSubmit(obj);
                        updb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_userprofile GetByUserProfileID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext updb = new JobHuntingDBDataContext(con))
                {
                    tbl_userprofile uprofile = updb.tbl_userprofiles.FirstOrDefault(up => up.UserProfileID == id);
                    return uprofile;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}