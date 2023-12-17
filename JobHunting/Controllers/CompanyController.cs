using JobHunting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        public List<CompanyModel> GetCompany()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                return (from co in db.tbl_companies
                        select new CompanyModel()
                        {
                            CompanyID = co.CompanyID,
                            CompanyName = co.CompanyName,
                            CompanyImage = (byte[])co.CompanyImage.ToArray(),
                            Description = co.Description,
                            Address = co.Address,
                            Phone = co.Phone,
                            Email = co.Email,
                            EmployeeCount = Convert.ToInt32(co.EmployeeCount)
                        }).ToList();
            }
        }

        //public string GetImage(object img)
        //{
        //    return "data:image/png;base64," + Convert.ToBase64String((byte[id])img);
        //}

        public bool InsertCompany(tbl_company co)
        {
            try
            {
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    var obj = codb.tbl_companies.Where(com => com.CompanyName == co.CompanyName).FirstOrDefault();
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
                        obj.Description = co.Description;
                        obj.Address = co.Address;
                        obj.Phone = co.Phone;
                        obj.Email = co.Email;
                        obj.EmployeeCount = co.EmployeeCount;
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

        public bool DeleteCompany(string id)
        {
            try
            {
                using (JobHuntingDBDataContext codb = new JobHuntingDBDataContext(con))
                {
                    var obj = codb.tbl_companies.Where(com => com.CompanyID == id).FirstOrDefault();
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
        public bool GetByCompanyName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_company com = cdb.tbl_companies.FirstOrDefault(co => co.CompanyName == name);
                    if (com != null)
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