using JobHunting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace JobHunting.Controllers
{
    public class CategoryController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_category> GetAllCategory()
        {
            using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
            {
                return cdb.tbl_categories.ToList();
            }
        }

        public bool InsertCategory(tbl_category c)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    var obj = cdb.tbl_categories.Where(cat => cat.CategoryName == c.CategoryName).FirstOrDefault();
                    if (obj == null)
                    {
                        cdb.tbl_categories.InsertOnSubmit(c);
                        cdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCategory(tbl_category c)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    var obj = cdb.tbl_categories.Where(cat => cat.CategoryID == c.CategoryID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CategoryName = c.CategoryName;
                        cdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCategory(string id)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    var obj = cdb.tbl_categories.Where(cat => cat.CategoryID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        cdb.tbl_categories.DeleteOnSubmit(obj);
                        cdb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tbl_category GetByCategoryID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_category cat = cdb.tbl_categories.FirstOrDefault(c => c.CategoryID == id);
                    return cat;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool GetByCategoryName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_category cat = cdb.tbl_categories.FirstOrDefault(c => c.CategoryName == name);
                    if (cat != null)
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