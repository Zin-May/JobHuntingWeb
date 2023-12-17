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
        CategoryController controller = new CategoryController();
        tbl_category tbl = new tbl_category();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<tbl_category> GetAllCategory()
        {
            return controller.GetAllCategory().ToList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (controller.GetByCategoryName(txtCategoryName.Value.Trim()) != true)
            {
                tbl.CategoryID = Guid.NewGuid().ToString();
                tbl.CategoryName = txtCategoryName.Value.Trim();
                var obj = controller.InsertCategory(tbl);
                if (obj == true)
                {
                    txtCategoryName.Value = string.Empty;
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
            tbl.CategoryID = id;
            tbl.CategoryName = txtCategoryName.Value.Trim();
            var obj = controller.UpdateCategory(tbl);
            if (obj == true)
            {
                txtCategoryName.Value = string.Empty;
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
           // lbtnDelete.Attributes.Add("onclick", "return ConfirmDelete();");
            string id = hfCID.Value;
            var obj = controller.DeleteCategory(id);
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