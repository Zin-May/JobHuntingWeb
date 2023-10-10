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
        protected void Page_Load(object sender, EventArgs e)
        {
            JobTypeController controller = new JobTypeController();
            gvJobTypeList.DataSource = controller.GetAllJobType();
            gvJobTypeList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_jobtype tbl = new tbl_jobtype();
            tbl.JobTypeID = Guid.NewGuid().ToString();
            tbl.JobTypeName = txtjobtypename.Value.Trim();
            JobTypeController controller = new JobTypeController();
            controller.InsertJobType(tbl);
            if (controller.InsertJobType(tbl))
            {
                txtjobtypename.Value = string.Empty;
            }
            else
            {
                lblResult.Text = "Failed";
            }
        }
    }
}