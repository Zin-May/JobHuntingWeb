using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserController user_controller = new UserController();
            var obj = user_controller.GetLogin(txtUserName.Value, txtPassword.Value);
            if (obj != null)
            {
                Session["uinfo"] = obj.UserName;
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMessage.Text = "Try Again";
            }
        }
    }
}