using JobHunting.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting
{
    public partial class jobsingle : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        UserController uController = new UserController();
        JobController controller = new JobController();
        public List<JobView> jList = new List<JobView>();
        public List<JobView> relatedList = new List<JobView>();
        tbl_jobapply tbl = new tbl_jobapply();
        JobApplyController jaCcontroller = new JobApplyController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["key"] != null)
            {
                string jid = Request.QueryString["key"];
                Session["JobID"] = jid;
                if (jid != null)
                {
                    GetJobSingle(jid);
                   // Response.Redirect("jobsingle.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('This is empty!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('This is empty!')", true);
            }
        }
        public void GetJobSingle(string jobId)
        {
            var query = controller.GetByJobSingle(jobId);
            if (query != null)
            {
                jList.Add(query);
                GetRelatedJob(query.JobPositionName, jobId);
            }
        }

        public int CountData()
        {
            return controller.GetAllJobView().ToList().Count;
        }

        public void GetRelatedJob(string jpName, string id)
        {
            using (JobHuntingDBDataContext jdb = new JobHuntingDBDataContext(con))
            {
                var query = jdb.JobViews.FirstOrDefault(jv => jv.JobPositionName == jpName && jv.JobID != id);
                if (query != null)
                {
                    relatedList.Add(query);
                }
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Session["uinfoid"] != null)
            {
                tbl.JobApplyID = Guid.NewGuid().ToString();
                tbl.UserID = Session["uinfoid"].ToString();
                tbl.JobID = Session["JobID"].ToString();
                tbl.CreatedDate = DateTime.Now;
                jaCcontroller.InsertJobApply(tbl);
            }
            else
            {
                Response.Redirect("signUp.aspx");
            }
        }
    }
}