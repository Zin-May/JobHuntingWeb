﻿using System;
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

        public bool DeleteCountry(string id)
        {
            try
            {
                using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
                {
                    var obj = jdb.tbl_countries.Where(co => co.CountryID == id).FirstOrDefault();
                    if (obj != null)
                    {
                        var checkCountry = jdb.tbl_cities.Where(ci => ci.CountryID == id).FirstOrDefault();
                        if (checkCountry != null)
                        {
                            return false;
                        }
                        else
                        {
                            jdb.tbl_countries.DeleteOnSubmit(obj);
                            jdb.SubmitChanges();
                        }
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
        public bool GetByCountryName(string name)
        {
            try
            {
                using (JobHuntingDBDataContext cdb = new JobHuntingDBDataContext(con))
                {
                    tbl_country country = cdb.tbl_countries.FirstOrDefault(cou => cou.CountryName == name);
                    if (country != null)
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