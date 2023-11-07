using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml.Linq;

namespace JobHunting.Controllers
{
    public class CompanyController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_company> GetAllCompany()
        {
            using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
            {
                return codb.tbl_companies.ToList();
            }
        }

        public bool InsertCompany(tbl_company co)
        {
            try
            {
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    var obj = codb.tbl_companies.Where(com => com.CompanyName==co.CompanyName).FirstOrDefault();
                    if (obj == null)
                    {
                        codb.tbl_companies.InsertOnSubmit(co);
                        codb.SubmitChanges();
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
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    var obj = codb.tbl_companies.Where(com => com.CompanyID == co.CompanyID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CompanyName = co.CompanyName;
                        obj.CompanyImage = co.CompanyImage;
                        codb.SubmitChanges();
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
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    var obj = codb.tbl_companies.Where(com => com.CompanyID == co.CompanyID).FirstOrDefault();
                    if (obj != null)
                    {
                        codb.tbl_companies.DeleteOnSubmit(obj);
                        codb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_company GetByCompanyID(string id)
        {
            try
            {
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    tbl_company company = codb.tbl_companies.FirstOrDefault(com => com.CompanyID == id);
                    return company;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}