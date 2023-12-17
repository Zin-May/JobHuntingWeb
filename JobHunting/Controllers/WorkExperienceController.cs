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
            using (JobHuntingDBDataContext wedb = new JobHuntingDBDataContext(con))
            {
                return wedb.tbl_workexperiences.ToList();
            }
        }

        public bool InsertWorkExperience(tbl_workexperience w)
        {
            try
            {
                using (JobHuntingDBDataContext wedb = new JobHuntingDBDataContext(con))
                {
                    var obj = wedb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == w.WorkExperienceID).FirstOrDefault();
                    if (obj == null)
                    {
                        wedb.tbl_workexperiences.InsertOnSubmit(w);
                        wedb.SubmitChanges();
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
                using (JobHuntingDBDataContext wedb = new JobHuntingDBDataContext(con))
                {
                    var obj = wedb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == w.WorkExperienceID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CompanyID = w.CompanyID;
                        obj.Position = w.Position;
                        obj.StartDate = w.StartDate;
                        obj.EndDate = w.EndDate;
                        obj.IsCurrentJob = w.IsCurrentJob;
                        obj.UserProfileID = w.UserProfileID;
                        wedb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteWorkExperience(string id)
        {
            try
            {
                using (JobHuntingDBDataContext wedb = new JobHuntingDBDataContext(con))
                {
                    var obj = wedb.tbl_workexperiences.Where(wex => wex.WorkExperienceID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        wedb.tbl_workexperiences.DeleteOnSubmit(obj);
                        wedb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_workexperience GetByWorkExperienceID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext wedb = new JobHuntingDBDataContext(con))
                {
                    tbl_workexperience wexp = wedb.tbl_workexperiences.FirstOrDefault(we => we.WorkExperienceID == id);
                    return wexp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}