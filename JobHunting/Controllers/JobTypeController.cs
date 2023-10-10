using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobTypeController
    {

        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_jobtype> GetAllJobType()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_jobtypes.ToList();
            }
        }

        public bool InsertJobType(tbl_jobtype jt)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobtypes.Where(jty => jty.JobTypeName == jt.JobTypeName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_jobtypes.InsertOnSubmit(jt);
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

        public bool UpdateJobType(tbl_jobtype jt)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobtypes.Where(jty => jty.JobTypeID == jt.JobTypeID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobTypeName = jt.JobTypeName;
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

        public bool DeleteJobType(tbl_jobtype jt)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobtypes.Where(jty => jty.JobTypeID == jt.JobTypeID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_jobtypes.DeleteOnSubmit(obj);
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
        public bool GetByJobTypeID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobtypes.Where(jty => jty.JobTypeID == id).FirstOrDefault();
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