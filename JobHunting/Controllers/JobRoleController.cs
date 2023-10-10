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
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_jobroles.ToList();
            }
        }

        public bool InsertJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobroles.Where(jro => jro.JobRoleName == jr.JobRoleName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_jobroles.InsertOnSubmit(jr);
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

        public bool UpdateJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobroles.Where(jro => jro.JobRoleID == jr.JobRoleID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobRoleName = jr.JobRoleName;
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

        public bool DeleteJobRole(tbl_jobrole jr)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobroles.Where(jro => jro.JobRoleID == jr.JobRoleID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_jobroles.DeleteOnSubmit(obj);
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

        public bool GetByJobRoleID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobroles.Where(jro => jro.JobRoleID == id).FirstOrDefault();
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