using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.Value != txtRePassword.Value)
            {
                lblMessage.Text = "Please Enter Same Password";
                messagealert.Visible = true;
            }
            else
            {
                tbl_user user = new tbl_user();
                user.UserID = Guid.NewGuid().ToString();
                user.UserName = txtUserName.Value.Trim();
                user.Email = txtEmail.Value.Trim();
                user.Password = txtPassword.Value;
                user.IsAdmin = false;
                user.CreatedDate = DateTime.Now;
                user.UpdatedDate = DateTime.Now;

                UserController user_controller = new UserController();

                if (user_controller.InsertUser(user))
                {
                    Response.Redirect("login.aspx");

                }
                else
                {
                    lblMessage.Text = "Try Again";
                    messagealert.Visible = true;
                }
            }
        }
    }
}