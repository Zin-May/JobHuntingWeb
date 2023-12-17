using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class JobRole : System.Web.UI.Page
    {
        JobRoleController controller = new JobRoleController();
        tbl_jobrole tbl = new tbl_jobrole();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<tbl_jobrole> GetAllJobRole()
        {
            return controller.GetAllJobRole().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByJobRoleName(txtJobRoleName.Value.Trim()) != true)
            {
                tbl.JobRoleID = Guid.NewGuid().ToString();
                tbl.JobRoleName = txtJobRoleName.Value.Trim();
                var obj = controller.InsertJobRole(tbl);
                if (obj == true)
                {
                    txtJobRoleName.Value = string.Empty;
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
            string id = hfJRID.Value;
            JobController jController = new JobController();
            if (jController.GetByJobRole(id)!=null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('You cannot delete this data!')", true);
            }
            else
            {
                var obj = controller.DeleteJobRole(id);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = hfJRID.Value;
            tbl.JobRoleID = id;
            tbl.JobRoleName = txtJobRoleName.Value.Trim();
            var obj = controller.UpdateJobRole(tbl);
            if (obj == true)
            {
                txtJobRoleName.Value = string.Empty;
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