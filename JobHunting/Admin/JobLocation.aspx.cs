using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class JobLocation : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        JobLocationController controller = new JobLocationController();
        tbl_joblocation tbl = new tbl_joblocation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDLCityCountry();
            }
        }

        public List<tbl_joblocation> GetAllJobLocation()
        {
            return controller.GetAllJobLocation().ToList();
        }

        void bindDDLCityCountry()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                var query = db.tbl_cities.Join(db.tbl_countries, ci => ci.CountryID, co => co.CountryID,
                      (ci, co) => new
                      {
                          CityID = ci.CityID,
                          name = ci.CityName + " - " + co.CountryName,
                          CountryID = co.CountryID,
                      });
                ddlCityCountry.DataSource = query.ToList();
                ddlCityCountry.DataTextField = "name";
                ddlCityCountry.DataValueField = "CityID";
                ddlCityCountry.DataBind();

                ddlCityCountry.Items.Insert(0, "-- Choose City & Country --");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl.JobLocationID = Guid.NewGuid().ToString();
            tbl.JobStreetAddress = txtJobStreetAddress.Value;
            tbl.CityID = ddlCityCountry.SelectedValue;
            var obj = controller.InsertJobLocation(tbl);
            if (obj == true)
            {
                txtJobStreetAddress.Value = string.Empty;
                bindDDLCityCountry();
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

            string id = hfJLlID.Value;
            tbl.JobLocationID = id;
            tbl.JobStreetAddress = txtJobStreetAddress.Value;
            tbl.CityID = ddlCityCountry.SelectedValue;
            var obj = controller.UpdateJobLocation(tbl);
            if (obj == true)
            {
                txtJobStreetAddress.Value = string.Empty;
                bindDDLCityCountry();
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Update!";

            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string id = hfJLlID.Value;
            JobLocationController jlController = new JobLocationController();
            if (jlController.GetByCity(id) != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('You cannot delete this data!')", true);
            }
            else
            {
                var obj = controller.DeleteJobLocation(id);
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
}