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
    public partial class Country : System.Web.UI.Page
    {
        CountryController controller = new CountryController();
        tbl_country tbl = new tbl_country();
        protected void Page_Load(object sender, EventArgs e)
        {
            messagealert.Style.Add("display", "none");
        }

        public List<tbl_country> GetAllCountry()
        {
            return controller.GetAllCountry().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByCountryName(txtCountryName.Value.Trim()) != true)
            {
                tbl.CountryID = Guid.NewGuid().ToString();
                tbl.CountryName = txtCountryName.Value.Trim();
                var obj = controller.InsertCountry(tbl);
                if (obj == true)
                {
                    txtCountryName.Value = string.Empty;
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

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string id = hfCOID.Value;
            CityController cController = new CityController();
            if (cController.GetByCountry(id) != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('You cannot delete this data!')", true);
            }
            else
            {
                var obj = controller.DeleteCountry(id);
                if (obj == true)
                {
                    messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                    lblResult.Text = "Successfully Delete!";

                }
                else
                {
                    messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                    lblResult.Text = "This Data Cannot be delete!";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string id = hfCOID.Value;
            tbl.CountryID = id;
            tbl.CountryName = txtCountryName.Value.Trim();
            var obj = controller.UpdateCountry(tbl);
            if (obj == true)
            {
                txtCountryName.Value = string.Empty;
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Update!";

            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }
    }
}