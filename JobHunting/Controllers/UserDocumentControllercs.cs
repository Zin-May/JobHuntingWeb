using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class UserDocumentControllercs
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_userdocument> GetAllUserDocument()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_userdocuments.ToList();
            }
        }

        public bool InsertUserDocument(tbl_userdocument ud)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userdocuments.Where(urd => urd.UserID == ud.UserID).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_userdocuments.InsertOnSubmit(ud);
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

        public bool UpdateUserDocument(tbl_userdocument ud)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userdocuments.Where(urd => urd.UserDocumentID == ud.UserDocumentID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserID = ud.UserID;
                        obj.DocumentName = ud.DocumentName;
                        obj.DocumentType = ud.DocumentType;
                        obj.DocumentURL = ud.DocumentURL;
                        obj.CreatedDate = ud.CreatedDate;
                        obj.Status = ud.Status;
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

        public bool DeleteUserDocument(tbl_userdocument ud)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userdocuments.Where(urd => urd.UserDocumentID == ud.UserDocumentID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_userdocuments.DeleteOnSubmit(obj);
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
        public bool GetByUserDocumentID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_userdocuments.Where(urd => urd.UserDocumentID == id).FirstOrDefault();
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