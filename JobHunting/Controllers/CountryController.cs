using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class CountryController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_country> GetAllCountry()
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                return jdb.tbl_countries.ToList();
            }
        }

        public bool InsertCountry(tbl_country c)
        {
            try
            {

                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_countries.Where(co => co.CountryName == c.CountryName).FirstOrDefault();
                    if (obj == null)
                    {
                        jdb.tbl_countries.InsertOnSubmit(c);
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

        public bool UpdateCountry(tbl_country c)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_countries.Where(co => co.CountryID == c.CountryID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CountryName = c.CountryName;
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

        public bool DeleteCountry(tbl_country c)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_countries.Where(co => co.CountryID == c.CountryID).FirstOrDefault();
                    if (obj != null)
                    {
                        jdb.tbl_countries.DeleteOnSubmit(obj);
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

        public tbl_country GetByCountryID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext coudb = new JobHuntingDBDataContext(con))
                {
                    tbl_country country = coudb.tbl_countries.FirstOrDefault(co => co.CountryID == id);
                    return country;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}