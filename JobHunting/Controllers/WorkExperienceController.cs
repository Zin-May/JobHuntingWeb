using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class WorkExperienceController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_workexperience> GetAllWorkExperience()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_workexperiences.ToList();
            }
        }

        public bool InsertWorkExperience(tbl_workexperience w)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == w.WorkExperienceID).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_workexperiences.InsertOnSubmit(w);
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

        public bool UpdateWorkExperience(tbl_workexperience w)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == w.WorkExperienceID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CompanyID = w.CompanyID;
                        obj.Position = w.Position;
                        obj.StartDate = w.StartDate;
                        obj.EndDate = w.EndDate;
                        obj.IsCurrentJob = w.IsCurrentJob;
                        obj.UserProfileID = w.UserProfileID;
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

        public bool DeleteWorkExperience(tbl_workexperience w)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == w.WorkExperienceID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_workexperiences.DeleteOnSubmit(obj);
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
        public bool GetByWorkExperienceID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == id).FirstOrDefault();
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