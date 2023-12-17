using JobHunting.Models;
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
            using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
            {
                return jldb.tbl_joblocations.ToList();
            }
        }

        public bool InsertJobLocation(tbl_joblocation jl)
        {
            try
            {
                using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
                {
                    var obj = jldb.tbl_joblocations.Where(jlo => jlo.JobStreetAddress == jl.JobStreetAddress).FirstOrDefault();
                    if (obj == null)
                    {
                        jldb.tbl_joblocations.InsertOnSubmit(jl);
                        jldb.SubmitChanges();
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
                using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
                {
                    var obj = jldb.tbl_joblocations.Where(jlo => jlo.JobLocationID == jl.JobLocationID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobStreetAddress = jl.JobStreetAddress;
                        obj.CityID = jl.CityID;
                        jldb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJobLocation(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
                {
                    var obj = jldb.tbl_joblocations.Where(jlo => jlo.JobLocationID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        jldb.tbl_joblocations.DeleteOnSubmit(obj);
                        jldb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tbl_joblocation GetByJobLocationID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
                {
                    tbl_joblocation jlocation = jldb.tbl_joblocations.FirstOrDefault(jl => jl.JobLocationID == id);
                    return jlocation;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public tbl_joblocation GetByCity(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jldb = new JobHuntingDBDataContext(con))
                {
                    tbl_joblocation job = jldb.tbl_joblocations.FirstOrDefault(jo => jo.CityID == id);
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