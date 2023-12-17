using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class indexadmin : System.Web.UI.Page
    {
        JobRoleController roleController=new JobRoleController();
        JobTypeController typeController = new JobTypeController();
        CategoryController categoryController = new CategoryController();
        JobController jobController = new JobController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<tbl_jobrole> GetAllJobRole()
        {
            return roleController.GetAllJobRole().ToList();
        }
        public List<tbl_jobtype> GetAllJobType()
        {
            return typeController.GetAllJobType().ToList();
        }
        public List<tbl_category> GetAllCategory()
        {
            return categoryController.GetAllCategory().ToList();
        }
        public List<JobView> GetAllJob()
        {
            return jobController.GetAllJobView().ToList();
        }
    }
}