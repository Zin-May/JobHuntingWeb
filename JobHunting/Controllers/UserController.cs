using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class UserController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_user> GetAllUser()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_users.ToList();
            }
        }

        public bool InsertUser(tbl_user u)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_users.Where(ur => ur.UserName == u.UserName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_users.InsertOnSubmit(u);
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

        public bool UpdateUser(tbl_user u)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_users.Where(ur => ur.UserID == u.UserID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserName = u.UserName;
                        obj.Email = u.Email;
                        obj.Password = u.Password;
                        obj.Phone = u.Phone;
                        obj.IsAdmin = u.IsAdmin;
                        obj.CreatedDate = u.CreatedDate;
                        obj.UpdatedDate = u.UpdatedDate;
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

        public bool DeleteUser(tbl_user u)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_users.Where(ur => ur.UserID == u.UserID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_users.DeleteOnSubmit(obj);
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
        public bool GetByUserID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_users.Where(ur => ur.UserID == id).FirstOrDefault();
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