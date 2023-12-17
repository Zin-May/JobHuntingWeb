using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class Job : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        JobController controller = new JobController();
        tbl_job tbl = new tbl_job();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDLCategory();
                bindDDLCompany();
                bindDDLJobLocation();
                bindDDLJobRole();
                bindDDLJobType();
                bindDDLJobPosition();
            }
        }
        void bindDDLCompany()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlCompany.DataSource = db.tbl_companies.ToList();
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyID";
                ddlCompany.DataBind();

                ddlCompany.Items.Insert(0, "-- Choose Company --");
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

                ddlJobRole.Items.Insert(0, "-- Choose Job Role --");
            }
        }
        void bindDDLJobType()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlJobType.DataSource = db.tbl_jobtypes.ToList();
                ddlJobType.DataTextField = "JobTypeName";
                ddlJobType.DataValueField = "JobTypeID";
                ddlJobType.DataBind();

                ddlJobType.Items.Insert(0, "-- Choose Job Type --");
            }
        }
        void bindDDLCategory()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlCategory.DataSource = db.tbl_categories.ToList();
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                ddlCategory.Items.Insert(0, "-- Choose Category --");
            }
        }

        void bindDDLJobLocation()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                var query= from jl in db.tbl_joblocations
                           join c in db.tbl_cities on jl.CityID equals c.CityID
                           join co in db.tbl_countries on c.CountryID equals co.CountryID
                           select new
                           {
                               JobLocationID = jl.JobLocationID,
                               CityID = c.CityID,
                               name = jl.JobStreetAddress+" , " + c.CityName + " , " + co.CountryName,
                               CountryID = co.CountryID,
                           };
                ddlJobLocation.DataSource = query.ToList();
                ddlJobLocation.DataTextField = "name";
                ddlJobLocation.DataValueField = "JobLocationID";
                ddlJobLocation.DataBind();

                ddlJobLocation.Items.Insert(0, "-- Choose Job Location --");
            }
        }

        void bindDDLJobPosition()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                ddlJobPosition.DataSource = db.tbl_jobpositions.ToList();
                ddlJobPosition.DataTextField = "JobPositionName";
                ddlJobPosition.DataValueField = "JobPositionID";
                ddlJobPosition.DataBind();

                ddlJobPosition.Items.Insert(0, "-- Choose Job Position --");
            }
        }

        public List<JobView> GetAllJob()
        {
            return controller.GetAllJobView().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl.JobID = Guid.NewGuid().ToString();
            tbl.CompanyID = ddlCompany.SelectedValue;
            tbl.JobRoleID = ddlJobRole.SelectedValue;
            tbl.JobTypeID = ddlJobType.SelectedValue;
            tbl.CategoryID = ddlCategory.SelectedValue;
            tbl.JobLocationID = ddlJobLocation.SelectedValue;
            tbl.JobPositionID = ddlJobPosition.SelectedValue;
            tbl.Allowence = txtAllowence.Value.Trim();
            tbl.Salary=txtSalary.Value.Trim();
            tbl.JobDescription=txtDescription.Value.Trim();
            tbl.JobResponsibility=txtResponibility.Value.Trim();
            tbl.Status = txtStatus.Value.Trim();
            tbl.CreatedDate = DateTime.Now;
            tbl.UpdatedDate = DateTime.Now;
            var obj = controller.InsertJob(tbl);
            if (obj == true)
            {
                txtAllowence.Value = string.Empty;
                txtSalary.Value = string.Empty;
                txtDescription.Value = string.Empty;
                txtResponibility.Value = string.Empty;
                txtStatus.Value = string.Empty;
                bindDDLCompany();
                bindDDLJobRole();
                bindDDLJobType();
                bindDDLCategory();
                bindDDLJobLocation();
                bindDDLJobPosition();
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Insert!";

            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = hfJID.Value;
            tbl.JobID = id;
            tbl.CompanyID = ddlCompany.SelectedValue;
            tbl.JobRoleID = ddlJobRole.SelectedValue;
            tbl.JobTypeID = ddlJobType.SelectedValue;
            tbl.CategoryID = ddlCategory.SelectedValue;
            tbl.JobLocationID = ddlJobLocation.SelectedValue;
            tbl.JobPositionID = ddlJobPosition.SelectedValue;
            tbl.Allowence = txtAllowence.Value.Trim();
            tbl.Salary = txtSalary.Value.Trim();
            tbl.JobDescription = txtDescription.Value.Trim();
            tbl.JobResponsibility = txtResponibility.Value.Trim();
            tbl.Status = txtStatus.Value.Trim();
            tbl.CreatedDate = DateTime.Parse(hfCreateddate.Value);
            tbl.UpdatedDate = DateTime.Now;
            var obj = controller.UpdateJob(tbl);
            if (obj == true)
            {
                txtAllowence.Value = string.Empty;
                txtSalary.Value = string.Empty;
                txtDescription.Value = string.Empty;
                txtResponibility.Value = string.Empty;
                txtStatus.Value = string.Empty;
                bindDDLCompany();
                bindDDLJobRole();
                bindDDLJobType();
                bindDDLCategory();
                bindDDLJobLocation();
                bindDDLJobPosition();
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Insert!";

            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string id = hfJID.Value;
            var obj = controller.DeleteJob(id);
            if (obj == true)
            {
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Delete!";

            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }
    }
}