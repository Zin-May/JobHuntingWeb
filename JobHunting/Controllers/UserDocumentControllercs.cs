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
            using (JobHuntingDBDataContext uddb = new JobHuntingDBDataContext(con))
            {
                return uddb.tbl_userdocuments.ToList();
            }
        }

        public bool InsertUserDocument(tbl_userdocument ud)
        {
            try
            {
                using (JobHuntingDBDataContext uddb = new JobHuntingDBDataContext(con))
                {
                    var obj = uddb.tbl_userdocuments.Where(urd => urd.UserID == ud.UserID).FirstOrDefault();
                    if (obj == null)
                    {
                        uddb.tbl_userdocuments.InsertOnSubmit(ud);
                        uddb.SubmitChanges();
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
                using (JobHuntingDBDataContext uddb = new JobHuntingDBDataContext(con))
                {
                    var obj = uddb.tbl_userdocuments.Where(urd => urd.UserDocumentID == ud.UserDocumentID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.UserID = ud.UserID;
                        obj.DocumentName = ud.DocumentName;
                        obj.DocumentType = ud.DocumentType;
                        obj.DocumentURL = ud.DocumentURL;
                        obj.CreatedDate = ud.CreatedDate;
                        obj.Status = ud.Status;
                        uddb.SubmitChanges();
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
                using (JobHuntingDBDataContext uddb = new JobHuntingDBDataContext(con))
                {
                    var obj = uddb.tbl_userdocuments.Where(urd => urd.UserDocumentID == ud.UserDocumentID).FirstOrDefault();
                    if (obj != null)
                    {
                        uddb.tbl_userdocuments.DeleteOnSubmit(obj);
                        uddb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_userdocument GetByUserDocumentID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext uddb = new JobHuntingDBDataContext(con))
                {
                    tbl_userdocument udocument = uddb.tbl_userdocuments.FirstOrDefault(ud => ud.UserDocumentID == id);
                    return udocument;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}