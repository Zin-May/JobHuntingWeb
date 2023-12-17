using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class JobPositionController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_jobposition> GetAllJobPosition()
        {
            using (JobHuntingDBDataContext jpdb = new JobHuntingDBDataContext(con))
            {
                return jpdb.tbl_jobpositions.ToList();
            }
        }

        public bool InsertJobPosition(tbl_jobposition jp)
        {
            try
            {

                using (JobHuntingDBDataContext jpdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jpdb.tbl_jobpositions.Where(jpo => jpo.JobPositionName == jp.JobPositionName).FirstOrDefault();
                    if (obj == null)
                    {
                        jpdb.tbl_jobpositions.InsertOnSubmit(jp);
                        jpdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateJobPosition(tbl_jobposition jp)
        {
            try
            {
                using (JobHuntingDBDataContext jpdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jpdb.tbl_jobpositions.Where(jpo => jpo.JobPositionID == jp.JobPositionID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobPositionName = jp.JobPositionName;
                        jpdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJobPosition(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jpdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jpdb.tbl_jobpositions.Where(jpo => jpo.JobPositionID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        jpdb.tbl_jobpositions.DeleteOnSubmit(obj);
                        jpdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tbl_jobposition GetByJobPositionID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext jpdb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobposition jposition = jpdb.tbl_jobpositions.FirstOrDefault(jp => jp.JobPositionID == id);
                    return jposition;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool GetByJobPositionName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobposition cat = cdb.tbl_jobpositions.FirstOrDefault(c => c.JobPositionName == name);
                    if (cat != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}