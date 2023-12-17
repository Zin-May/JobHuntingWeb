using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static JobHunting.Admin.admin;

namespace JobHunting.Admin
{
    public partial class City : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        CityController controller = new CityController();
        tbl_city tbl = new tbl_city();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDLCountry();
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

                ddlCountry.Items.Insert(0, "--Choose Country--");
            }
        }

        public List<tbl_city> GetAllCity()
        {
            return controller.GetAllCity().ToList();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByCityName(txtCityName.Value.Trim()) != true)
            {
                tbl.CityID = Guid.NewGuid().ToString();
                tbl.CityName = txtCityName.Value.Trim();
                tbl.CountryID = ddlCountry.SelectedValue;
                var obj = controller.InsertCity(tbl);
                if (obj == true)
                {
                    txtCityName.Value = string.Empty;
                    bindDDLCountry();
                    messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                    lblResult.Text = "Successfully Insert!";

                }
                else
                {
                    messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                    lblResult.Text = "Try Again!";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('Phease Check Your Data!')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = hfCID.Value;
            tbl.CityID = id;
            tbl.CountryID = ddlCountry.SelectedValue;
            tbl.CityName = txtCityName.Value.Trim();
            var obj = controller.UpdateCity(tbl);
            if (obj == true)
            {
                txtCityName.Value = string.Empty;
                bindDDLCountry();
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
            string id = hfCID.Value;
            var obj = controller.DeleteCity(id);
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