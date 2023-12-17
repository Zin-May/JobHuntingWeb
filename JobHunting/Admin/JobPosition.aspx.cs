using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class JobPosition : System.Web.UI.Page
    {
        JobPositionController controller = new JobPositionController();
        tbl_jobposition tbl = new tbl_jobposition();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<tbl_jobposition> GetAllJobPosition()
        {
            return controller.GetAllJobPosition().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByJobPositionName(txtJobPositionName.Value.Trim()) != true)
            {
                tbl.JobPositionID = Guid.NewGuid().ToString();
                tbl.JobPositionName = txtJobPositionName.Value.Trim();
                var obj = controller.InsertJobPosition(tbl);
                if (obj == true)
                {
                    txtJobPositionName.Value = string.Empty;
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
            string id = hfJPID.Value;
            tbl.JobPositionID = id;
            tbl.JobPositionName = txtJobPositionName.Value.Trim();
            var obj = controller.UpdateJobPosition(tbl);
            if (obj == true)
            {
                txtJobPositionName.Value = string.Empty;
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
            string id = hfJPID.Value;
            JobController jController = new JobController();
            if (jController.GetByJobLocation(id) != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('You cannot delete this data!')", true);
            }
            else
            {
                var obj = controller.DeleteJobPosition(id);
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