using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class SignUpAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.Value != txtConfirmPassword.Value)
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblResult.Text = "Please Enter Same Password!";
            }
            else
            {
                tbl_user user = new tbl_user();
                user.UserID = Guid.NewGuid().ToString();
                user.UserName = txtUserName.Value.Trim();
                user.Email = txtEmail.Value.Trim();
                user.Password = txtPassword.Value;
                user.IsAdmin = true;
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;

                UserController user_controller = new UserController();

                if (user_controller.InsertUser(user))
                {
                    Response.Redirect("../login.aspx");

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