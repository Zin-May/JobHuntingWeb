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
        public List<JobView> GetAllJobView()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.JobViews.ToList();
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
                        obj.JobPositionID = j.JobPositionID;
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

        public bool DeleteJob(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobs.Where(job => job.JobID == id).FirstOrDefault();
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
        public tbl_job GetByJobID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.JobID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_job GetByCompany(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.CompanyID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_job GetByJobRole(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.JobRoleID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_job GetByJobType(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.JobTypeID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_job GetByCategory(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.CategoryID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_job GetByJobLocation(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.JobLocationID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public tbl_job GetByJobPosition(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    tbl_job job = jdb.tbl_jobs.FirstOrDefault(jo => jo.JobPositionID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<sp_searchjobResult> SearchByJobViewWithCountry(string company, string jobrole, string country)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    return jdb.sp_searchjob(company, jobrole, country).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JobView GetByJobSingle(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    JobView job = jdb.JobViews.FirstOrDefault(jv => jv.JobID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}