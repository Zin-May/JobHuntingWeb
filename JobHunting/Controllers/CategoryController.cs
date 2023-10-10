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
            using(JobHuntingDBDataContext jdb=new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_categories.ToList();
            }
        }

        public bool InsertCategory(tbl_category c)
        {
            try
            {

                using (JobHuntingDBDataContext jdb=new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_categories.Where(cat => cat.CategoryName == c.CategoryName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_categories.InsertOnSubmit(c);
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

        public bool UpdateCategory(tbl_category c)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_categories.Where(cat => cat.CategoryID == c.CategoryID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CategoryName = c.CategoryName;
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

        public bool DeleteCategory(tbl_category c)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_categories.Where(cat => cat.CategoryID == c.CategoryID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_categories.DeleteOnSubmit(obj);
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

        public bool GetByCategoryID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_categories.Where(cat => cat.CategoryID == id).FirstOrDefault();
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