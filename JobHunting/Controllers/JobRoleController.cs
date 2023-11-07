using JobHunting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobRoleController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_jobrole> GetAllJobRole()
        {
            using (JobHuntingDBDataContext jrdb = new JobHuntingDBDataContext(con))
            {
                return jrdb.tbl_jobroles.ToList();
            }
        }

        public bool InsertJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jrdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jrdb.tbl_jobroles.Where(jro => jro.JobRoleName == jr.JobRoleName).FirstOrDefault();
                    if (obj == null)
                    {
                        jrdb.tbl_jobroles.InsertOnSubmit(jr);
                        jrdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jrdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jrdb.tbl_jobroles.Where(jro => jro.JobRoleID == jr.JobRoleID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobRoleName = jr.JobRoleName;
                        jrdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jrdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jrdb.tbl_jobroles.Where(jro => jro.JobRoleID == jr.JobRoleID).FirstOrDefault();
                    if (obj != null)
                    {
                        jrdb.tbl_jobroles.DeleteOnSubmit(obj);
                        jrdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tbl_jobrole GetByJobRoleID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jrdb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobrole jrole = jrdb.tbl_jobroles.FirstOrDefault(jr => jr.JobRoleID == id);
                    return jrole;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}