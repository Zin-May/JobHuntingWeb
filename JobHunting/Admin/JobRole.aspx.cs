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
        protected void Page_Load(object sender, EventArgs e)
        {
            JobRoleController controller = new JobRoleController();
            gvJobRoleList.DataSource = controller.GetAllJobRole();
            gvJobRoleList.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_jobrole tbl = new tbl_jobrole();
            tbl.JobRoleID = Guid.NewGuid().ToString();
            tbl.JobRoleName = txtjobrolename.Value.Trim();
            JobRoleController controller = new JobRoleController();
            controller.InsertJobRole(tbl);
            if (controller.InsertJobRole(tbl))
            {
                txtjobrolename.Value = string.Empty;
            }
            else
            {
                lblResult.Text = "Failed";
            }
        }
    }
}