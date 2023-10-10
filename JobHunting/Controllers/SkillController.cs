using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class SkillController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_skill> GetAllSkill()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_skills.ToList();
            }
        }

        public bool InsertSkill(tbl_skill s)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_skills.Where(sk => sk.SkillName == s.SkillName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_skills.InsertOnSubmit(s);
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

        public bool UpdateSkill(tbl_skill s)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_skills.Where(sk => sk.SkillID == s.SkillID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.SkillName = s.SkillName;
                        obj.UserProfileID = s.UserProfileID;
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

        public bool DeleteSkill(tbl_skill s)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_skills.Where(sk => sk.SkillID == s.SkillID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_skills.DeleteOnSubmit(obj);
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
        public bool GetBySkillID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_skills.Where(sk => sk.SkillID == id).FirstOrDefault();
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