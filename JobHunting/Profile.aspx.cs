using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uinfo"] != null)
            {
                string user = Session["uinfo"].ToString();
                lblName.Text = user;
            }
            else
            {
                lblName.Text = "Blog Home";
            }

        }
    }
}