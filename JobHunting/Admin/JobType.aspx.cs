using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class JobType : System.Web.UI.Page
    {
        JobTypeController controller = new JobTypeController();
        tbl_jobtype tbl = new tbl_jobtype();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<tbl_jobtype> GetAllJobType()
        {
            return controller.GetAllJobType().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByJobTypeName(txtJobTypeName.Value.Trim()) != true)
            {
                tbl.JobTypeID = Guid.NewGuid().ToString();
                tbl.JobTypeName = txtJobTypeName.Value.Trim();
                var obj = controller.InsertJobType(tbl);
                if (obj == true)
                {
                    txtJobTypeName.Value = string.Empty;
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
            string id = hfJTID.Value;
            tbl.JobTypeID = id;
            tbl.JobTypeName = txtJobTypeName.Value.Trim();
            var obj = controller.UpdateJobType(tbl);
            if (obj == true)
            {
                txtJobTypeName.Value = string.Empty;
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
            string id = hfJTID.Value;
            JobController jController = new JobController();
            if (jController.GetByJobType(id) != null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('You cannot delete this data!')", true);
            }
            else
            {
                var obj = controller.DeleteJobType(id);
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