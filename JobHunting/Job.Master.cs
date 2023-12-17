using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting
{
    public partial class Job : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uinfo"] != null)
            {
                string user = Session["uinfo"].ToString();
                lblLoginStatus.Text = "Welcome! " + user;
                divHomePage.Visible = false;
                divLoginPage.Visible = true;
            }
            else
            {
                divHomePage.Visible = true;
                divLoginPage.Visible = false;
            }
        }
    }
}