using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uinfo"] != null)
            {
                string user = Session["uinfo"].ToString();
                lblAdminName.Text = "Welcome! " + user;
            }
        }
    }
}