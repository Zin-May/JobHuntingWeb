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
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_jobpositions.ToList();
            }
        }

        public bool InsertJobPosition(tbl_jobposition jp)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobpositions.Where(jpo => jpo.JobPositionName == jp.JobPositionName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_jobpositions.InsertOnSubmit(jp);
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

        public bool UpdateJobPosition(tbl_jobposition jp)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobpositions.Where(jpo => jpo.JobPositionID == jp.JobPositionID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobPositionName = jp.JobPositionName;
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

        public bool DeleteJobPosition(tbl_jobposition jp)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobpositions.Where(jpo => jpo.JobPositionID == jp.JobPositionID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_jobpositions.DeleteOnSubmit(obj);
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

        public bool GetByJobPositionID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_jobpositions.Where(jpo => jpo.JobPositionID == id).FirstOrDefault();
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