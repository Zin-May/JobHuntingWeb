using JobHunting.Controllers;
using JobHunting.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobHunting.Admin
{
    public partial class Company : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["JobHuntingConnectionString"].ConnectionString;
        CompanyController controller = new CompanyController();
        tbl_company tbl = new tbl_company();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDDLAddress();
            }
        }

        public List<tbl_company> GetAllCompany()
        {
            return controller.GetAllCompany().ToList();
        }

        public List<CompanyModel> GetCompany()
        {
            return controller.GetCompany().ToList();
        }
        void bindDDLAddress()
        {
            using (JobHuntingDBDataContext db = new JobHuntingDBDataContext(con))
            {
                var query = from jl in db.tbl_joblocations
                            join c in db.tbl_cities on jl.CityID equals c.CityID
                            join co in db.tbl_countries on c.CountryID equals co.CountryID
                            select new
                            {
                                JobLocationID = jl.JobLocationID,
                                CityID = c.CityID,
                                name = jl.JobStreetAddress + " , " + c.CityName + " , " + co.CountryName,
                                CountryID = co.CountryID,
                            };
                ddlAddress.DataSource = query.ToList();
                ddlAddress.DataTextField = "name";
                ddlAddress.DataValueField = "JobLocationID";
                ddlAddress.DataBind();

                ddlAddress.Items.Insert(0, "-- Choose Address --");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {           
            HttpPostedFile postedfile = imgCompanyFile.PostedFile;
            //string filename = Path.GetFileName(postedfile.FileName);
            string fileExtension = Path.GetExtension(postedfile.FileName);
            if (fileExtension == "")
            {

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('Phease Choose Image File!')", true);
            }
            else
            {
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpeg")
                {
                    Stream stream = postedfile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    tbl.CompanyImage = bytes;
                }
                tbl.CompanyID = Guid.NewGuid().ToString();
                tbl.CompanyName = txtCompanyName.Value.Trim();
                tbl.Description = txtDescription.Value.Trim();
                tbl.Address = ddlAddress.SelectedItem.ToString();
                tbl.Phone = txtPhoneNumber.Value.Trim();
                tbl.Email = txtEmail.Value.Trim();
                tbl.EmployeeCount = Convert.ToInt32(txtEmployeeCount.Value.Trim());

                var obj = controller.InsertCompany(tbl);
                if (obj == true)
                {
                    txtCompanyName.Value = string.Empty;
                    txtDescription.Value = string.Empty;
                    txtPhoneNumber.Value = string.Empty;
                    txtEmail.Value = string.Empty;
                    txtEmployeeCount.Value = string.Empty;
                    bindDDLAddress();
                    messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                    lblResult.Text = "Successfully Insert!";

                }
                else
                {
                    messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                    lblResult.Text = "Try Again!";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = hfCOMID.Value;
            byte[] imgURL = System.Convert.FromBase64String(hfIMGURL.Value);
           // string imgURL = hfIMGURL.Value;
            tbl.CompanyID = id;
            tbl.CompanyName = txtCompanyName.Value.Trim();
            tbl.Description = txtDescription.Value.Trim();
            tbl.Address = ddlAddress.SelectedItem.ToString();
            tbl.Phone = txtPhoneNumber.Value.Trim();
            tbl.Email = txtEmail.Value.Trim();
            tbl.EmployeeCount = Convert.ToInt32(txtEmployeeCount.Value.Trim());
            if (imgURL!=null)
            {
               tbl.CompanyImage = imgURL;
                controller.UpdateCompany(tbl);
            }
            else
            {

                HttpPostedFile postedfile = imgCompanyFile.PostedFile;
                string fileExtension = Path.GetExtension(postedfile.FileName);
                if (fileExtension == "")
                {

                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('Phease Choose Image File!')", true);
                }
                else
                {
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpeg")
                    {
                        Stream stream = postedfile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        tbl.CompanyImage = bytes;
                    }
                }
            }
            if(controller.UpdateCompany(tbl))
            {
                txtCompanyName.Value = string.Empty;
                txtDescription.Value = string.Empty;
                txtPhoneNumber.Value = string.Empty;
                txtEmail.Value = string.Empty;
                txtEmployeeCount.Value = string.Empty;
                bindDDLAddress();
                messagealert.Attributes.Add("class", "alert alert-success alert-dismissible fade show");
                lblResult.Text = "Successfully Insert!";
            }
            else
            {
                messagealert.Attributes.Add("class", "alert alert-danger alert-dismissible fade show");
                lblResult.Text = "Try Again!";
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            string id = hfCOMID.Value;
            
            var obj = controller.DeleteCompany(id);
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