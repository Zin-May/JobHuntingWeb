using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoryController controller = new CategoryController();
            gvCategoryList.DataSource = controller.GetAllCategory();
            gvCategoryList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_category tbl=new tbl_category();
            tbl.CategoryID = Guid.NewGuid().ToString();
            tbl.CategoryName = txtcategoryname.Value.Trim();
            CategoryController controller = new CategoryController();
            controller.InsertCategory(tbl);
            if(controller.InsertCategory(tbl))
            {
                txtcategoryname.Value = string.Empty;
            }
            else
            {
                lblResult.Text = "Failed";
            }

        }
    }
}