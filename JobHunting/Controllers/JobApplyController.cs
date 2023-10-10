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
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_jobapplies.ToList();
            }
        }

        public bool InsertJobApply(tbl_jobapply ja)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobapplies.Where(jap => jap.JobApplyID == ja.JobApplyID).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_jobapplies.InsertOnSubmit(ja);
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

        public bool UpdateJobApply(tbl_jobapply ja)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobapplies.Where(jap => jap.JobApplyID == ja.JobApplyID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserID = ja.UserID;
                        obj.JobID = ja.JobID;
                        obj.CreatedDate = ja.CreatedDate;
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

        public bool DeleteJobApply(tbl_jobapply ja)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobapplies.Where(jap => jap.JobApplyID == ja.JobApplyID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_jobapplies.DeleteOnSubmit(obj);
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
        public bool GetByJobApplyID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobapplies.Where(jap => jap.JobApplyID == id).FirstOrDefault();
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