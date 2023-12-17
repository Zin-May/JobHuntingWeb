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
            using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
            {
                return udb.tbl_users.ToList();
            }
        }

        public bool InsertUser(tbl_user u)
        {
            try
            {
                using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
                {
                    var obj = udb.tbl_users.Where(ur => ur.UserName == u.UserID).FirstOrDefault();
                    if (obj == null)
                    {
                        udb.tbl_users.InsertOnSubmit(u);
                        udb.SubmitChanges();
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
                using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
                {
                    var obj = udb.tbl_users.Where(ur => ur.UserID == u.UserID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserName = u.UserName;
                        obj.Email = u.Email;
                        obj.Password = u.Password;
                        obj.Phone = u.Phone;
                        obj.IsAdmin = u.IsAdmin;
                        obj.CreatedDate = u.CreatedDate;
                        obj.UpdatedDate = u.UpdatedDate;
                        udb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(string id)
        {
            try
            {
                using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
                {
                    var obj = udb.tbl_users.Where(ur => ur.UserID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        udb.tbl_users.DeleteOnSubmit(obj);
                        udb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_user GetByUserID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
                {
                    tbl_user user = udb.tbl_users.SingleOrDefault(ur => ur.UserID == id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public tbl_user GetLogin(string username, string password)
        {
            using (JobHuntingDBDataContext udb = new JobHuntingDBDataContext(con))
            {
                tbl_user user = udb.tbl_users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
        }
    }
}