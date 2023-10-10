using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobLocationController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_joblocation> GetAllJobLocation()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_joblocations.ToList();
            }
        }

        public bool InsertJobLocation(tbl_joblocation jl)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_joblocations.Where(jlo => jlo.JobStreetAddress == jl.JobStreetAddress).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_joblocations.InsertOnSubmit(jl);
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

        public bool UpdateJobLocation(tbl_joblocation jl)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_joblocations.Where(jlo => jlo.JobLocationID == jl.JobLocationID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobStreetAddress = jl.JobStreetAddress;
                        obj.CityID = jl.CityID;
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

        public bool DeleteJobLocation(tbl_joblocation jl)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_joblocations.Where(jlo => jlo.JobLocationID == jl.JobLocationID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_joblocations.DeleteOnSubmit(obj);
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

        public bool GetByJobLocationID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_joblocations.Where(jlo => jlo.JobLocationID == id).FirstOrDefault();
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