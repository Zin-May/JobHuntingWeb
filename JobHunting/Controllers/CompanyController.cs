using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace JobHunting.Controllers
{
    public class CompanyController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_company> GetAllCompany()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_companies.ToList();
            }
        }

        public bool InsertCompany(tbl_company co)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_companies.Where(com => com.CompanyName==co.CompanyName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_companies.InsertOnSubmit(co);
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

        public bool UpdateCompany(tbl_company co)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_companies.Where(com => com.CompanyID == co.CompanyID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CompanyName = co.CompanyName;
                        obj.CompanyImage = co.CompanyImage;
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

        public bool DeleteCompany(tbl_company co)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_companies.Where(com => com.CompanyID == co.CompanyID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_companies.DeleteOnSubmit(obj);
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
        public bool GetByCompanyID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_companies.Where(com => com.CompanyID == id).FirstOrDefault();
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