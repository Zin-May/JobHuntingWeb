using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobHunting.Controllers
{
    public class CityController
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;

        public List<tbl_city> GetAllCity()
        {
            using (JobHuntingDBDataContext cidb = new JobHuntingDBDataContext(con))
            {
                return cidb.tbl_cities.ToList();
            }
        }

        public bool InsertCity(tbl_city c)
        {
            try
            {

                using (JobHuntingDBDataContext cidb = new JobHuntingDBDataContext(con))
                {
                    var obj = cidb.tbl_cities.Where(ci => ci.CityName == c.CityName).FirstOrDefault();
                    if (obj == null)
                    {
                        cidb.tbl_cities.InsertOnSubmit(c);
                        cidb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCity(tbl_city c)
        {
            try
            {
                using (JobHuntingDBDataContext cidb = new JobHuntingDBDataContext(con))
                {
                    var obj = cidb.tbl_cities.Where(ci => ci.CityID == c.CityID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.CityName = c.CityName;
                        obj.CountryID = c.CountryID;
                        cidb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCity(string id)
        {
            try
            {
                using (JobHuntingDBDataContext cidb = new JobHuntingDBDataContext(con))
                {
                    var obj = cidb.tbl_cities.Where(ci => ci.CityID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        cidb.tbl_cities.DeleteOnSubmit(obj);
                        cidb.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tbl_city GetByCityID(string id)
        {
            try
            {

                using (JobHuntingDBDataContext cidb = new JobHuntingDBDataContext(con))
                {
                    tbl_city city = cidb.tbl_cities.FirstOrDefault(ci => ci.CityID == id);
                    return city;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool GetByCityName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_city city = cdb.tbl_cities.FirstOrDefault(c => c.CityName == name);
                    if (city != null)
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
        public tbl_city GetByCountry(string id)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_city job = cdb.tbl_cities.FirstOrDefault(jo => jo.CountryID == id);
                    return job;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}