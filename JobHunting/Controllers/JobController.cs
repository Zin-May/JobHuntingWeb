using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        public List<tbl_job> GetAllJob()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_jobs.ToList();
            }
        }

        public bool InsertJob(tbl_job j)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobs.Where(job => job.JobID == j.JobID).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_jobs.InsertOnSubmit(j);
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

        public bool UpdateJob(tbl_job j)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobs.Where(job => job.JobID == j.JobID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CompanyID = j.CompanyID;
                        obj.JobRoleID = j.JobRoleID;
                        obj.JobTypeID = j.JobTypeID;
                        obj.CategoryID = j.CategoryID;
                        obj.JobLocationID = j.JobLocationID;
                        obj.Allowence = j.Allowence;
                        obj.Salary = j.Salary;
                        obj.JobDescription = j.JobDescription;
                        obj.JobResponsibility = j.JobResponsibility;
                        obj.CreatedDate = j.CreatedDate;
                        obj.UpdatedDate = j.UpdatedDate;
                        obj.Status = j.Status;
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

        public bool DeleteJob(tbl_job j)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobs.Where(job => job.JobID == j.JobID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_jobs.DeleteOnSubmit(obj);
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
        public bool GetByJobID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobs.Where(job => job.JobID == id).FirstOrDefault();
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