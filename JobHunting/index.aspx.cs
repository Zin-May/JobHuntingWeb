using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace JobHunting
{
    public partial class index : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        JobController jcontroller = new JobController();
        public JobView obj;
        public List<sp_searchjobResult> jobAllList= new List<sp_searchjobResult>();
        public string companyname,jobrolename,countryname = " ";
        public string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDLJobRole();
                bindDDLCountry();
            }
            GetAllJob();
        }

        public void GetAllJob()
        {

            if (countryname == " " && jobrolename == " " && companyname == " ")
            {
                jobAllList = jcontroller.SearchByJobViewWithCountry(companyname, jobrolename, countryname).ToList();
            }
            else
            {
                jobAllList = jcontroller.SearchByJobViewWithCountry(companyname, jobrolename, countryname).ToList();
            }
        }

        void bindDDLJobRole()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlJobRole.DataSource = db.tbl_jobroles.ToList();
                ddlJobRole.DataTextField = "JobRoleName";
                ddlJobRole.DataValueField = "JobRoleID";
                ddlJobRole.DataBind();

                ddlJobRole.Items.Insert(0, "Select Job Role");
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {

            countryname = ddlCountry.SelectedItem.ToString();
            jobrolename = ddlJobRole.SelectedItem.ToString();
            companyname = txtcompanyname.ToString();
            GetAllJob();
            bindDDLJobRole();
            bindDDLCountry();
        }

        protected void btnJobSingle_Click(object sender, EventArgs e)
        {
            Session["JOBID"] = hfJID.Value;
            if (Session["JOBID"] != null)
            {
                Response.Redirect("jobsingle.aspx");
            }
        }

        void bindDDLCountry()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlCountry.DataSource = db.tbl_countries.ToList();
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();

                ddlCountry.Items.Insert(0, "Select Region");
            }
        }

        public int CountData()
        {
           return jcontroller.GetAllJobView().ToList().Count;
        }
    }
}