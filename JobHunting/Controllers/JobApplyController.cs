using JobHunting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobApplyController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        public List<tbl_jobapply> GetAllJobApply()
        {
            using (JobHuntingDBDataContext jadb = new JobHuntingDBDataContext(con))
            {
                return jadb.tbl_jobapplies.ToList();
            }
        }

        public bool InsertJobApply(tbl_jobapply ja)
        {
            try
            {
                using (JobHuntingDBDataContext jadb = new JobHuntingDBDataContext(con))
                {
                    var obj = jadb.tbl_jobapplies.Where(jap => jap.JobApplyID == ja.JobApplyID).FirstOrDefault();
                    if (obj == null)
                    {
                        jadb.tbl_jobapplies.InsertOnSubmit(ja);
                        jadb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateJobApply(tbl_jobapply ja)
        {
            try
            {
                using (JobHuntingDBDataContext jadb = new JobHuntingDBDataContext(con))
                {
                    var obj = jadb.tbl_jobapplies.Where(jap => jap.JobApplyID == ja.JobApplyID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserID = ja.UserID;
                        obj.JobID = ja.JobID;
                        obj.CreatedDate = ja.CreatedDate;
                        jadb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJobApply(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jadb = new JobHuntingDBDataContext(con))
                {
                    var obj = jadb.tbl_jobapplies.Where(jap => jap.JobApplyID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        jadb.tbl_jobapplies.DeleteOnSubmit(obj);
                        jadb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_jobapply GetByJobApplyID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jadb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobapply japply = jadb.tbl_jobapplies.FirstOrDefault(jap => jap.JobApplyID == id);
                    return japply;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}