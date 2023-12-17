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
            using (JobHuntingDBDataContext sdb = new JobHuntingDBDataContext(con))
            {
                return sdb.tbl_skills.ToList();
            }
        }

        public bool InsertSkill(tbl_skill s)
        {
            try
            {
                using (JobHuntingDBDataContext sdb = new JobHuntingDBDataContext(con))
                {
                    var obj = sdb.tbl_skills.Where(sk => sk.SkillName == s.SkillName).FirstOrDefault();
                    if (obj == null)
                    {
                        sdb.tbl_skills.InsertOnSubmit(s);
                        sdb.SubmitChanges();
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
                using (JobHuntingDBDataContext sdb = new JobHuntingDBDataContext(con))
                {
                    var obj = sdb.tbl_skills.Where(sk => sk.SkillID == s.SkillID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.SkillName = s.SkillName;
                        obj.UserProfileID = s.UserProfileID;
                        sdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSkill(string id)
        {
            try
            {
                using (JobHuntingDBDataContext sdb = new JobHuntingDBDataContext(con))
                {
                    var obj = sdb.tbl_skills.Where(sk => sk.SkillID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        sdb.tbl_skills.DeleteOnSubmit(obj);
                        sdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_skill GetBySkillID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext sdb = new JobHuntingDBDataContext(con))
                {
                    tbl_skill skill = sdb.tbl_skills.FirstOrDefault(sk => sk.SkillID == id);
                    return skill;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}