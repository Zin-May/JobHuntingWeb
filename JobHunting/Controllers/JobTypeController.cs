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
            using (JobHuntingDBDataContext jtdb = new JobHuntingDBDataContext(con))
            {
                return jtdb.tbl_jobtypes.ToList();
            }
        }

        public bool InsertJobType(tbl_jobtype jt)
        {
            try
            {
                using (JobHuntingDBDataContext jtdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jtdb.tbl_jobtypes.Where(jty => jty.JobTypeName == jt.JobTypeID).FirstOrDefault();
                    if (obj == null)
                    {
                        jtdb.tbl_jobtypes.InsertOnSubmit(jt);
                        jtdb.SubmitChanges();
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
                using (JobHuntingDBDataContext jtdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jtdb.tbl_jobtypes.Where(jty => jty.JobTypeID == jt.JobTypeID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.JobTypeName = jt.JobTypeName;
                        jtdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJobType(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jtdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jtdb.tbl_jobtypes.Where(jty => jty.JobTypeID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        jtdb.tbl_jobtypes.DeleteOnSubmit(obj);
                        jtdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_jobtype GetByJobTypeID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jtdb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobtype jtype = jtdb.tbl_jobtypes.FirstOrDefault(jt => jt.JobTypeID == id);
                    return jtype;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool GetByJobTypeName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_jobtype jtype = cdb.tbl_jobtypes.FirstOrDefault(jt => jt.JobTypeName == name);
                    if (jtype != null)
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