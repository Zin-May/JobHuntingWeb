using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace JobHunting
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnSignUp_ServerClick(object sender, EventArgs e)
        {
            lblMessage.Text = "Click Start";
            tbl_user user = new tbl_user();
            user.UserID = Guid.NewGuid().ToString();
            user.UserName = txtUserName.Value;
            user.Email = txtEmail.Value;
            if (txtPassword != txtRePassword)
            {
                lblMessage.Text = "Please Enter Same Password";
            }
            else
            {
                user.Password = txtPassword.Value;
            }
            user.IsAdmin = chkAdmin.Checked;
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;

            UserController user_controller = new UserController();
            if (user_controller.InsertUser(user) == true)
            {
                if (user.IsAdmin == true)
                {
                    Response.Redirect("Admin/indexadmin.aspx");
                }
                else
                {
                    Session["uinfo"] = txtUserName.Value;
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Try Again";
            }
        }
    }
}