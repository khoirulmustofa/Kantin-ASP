using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kantin.Entity;
using System.Text;
using System.IO;
using System.Configuration;
using Kantin.Crud;

namespace KantinASP.Pages.Master
{
    public partial class EmployeDetail : System.Web.UI.Page
    {

        private Employee oEmployee = null;
        private int PageState
        {
            get
            {
                return Convert.ToInt16(Request.QueryString["PageState"]);
            }
        }

        private string DataID
        {
            get
            {
                return Request.QueryString["DataID"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProcessBegin();

            }

        }

        private void ProcessBegin()
        {
            switch (PageState)
            {
                case 0:
                    ProcessNew();
                    break;
                case 1:
                    PrecessEdit();                    
                    break;
                case 2:
                    PrecessRead();
                    break;
                default:
                    break;
            }
        }

        private void PrecessRead()
        {
            DataReadInReadOnlyState();
            PopulateControlValuesInReadState();
            AdjustControlInReadState();
        }

        private void PopulateControlValuesInReadState()
        {
            if (oEmployee != null)
            {
                txtNik.Text = oEmployee.Nik;
                txtNameEmployee.Text = oEmployee.NameEmployee;
                txtDepartmentEmployee.Text = oEmployee.DepartmentEmployee;
                lblNamePhoto.Text = oEmployee.PhotoEmployee;
                imgPhotoEmployee.ImageUrl = "~/Images/" + oEmployee.PhotoEmployee;
            }
        }

        private void AdjustControlInReadState()
        {
            txtNik.ReadOnly = true;
            txtNameEmployee.ReadOnly = true;
            txtDepartmentEmployee.ReadOnly = true;
            FileUpload_Photo.Visible = false;
            btnPreview.Visible = false;
            btnSave.Visible = false;
            imgPhotoEmployee.ImageUrl = "~/Images/" + oEmployee.PhotoEmployee;
            lblTitleForm.Text = "Read Employee";
        }

        private void PrecessEdit()
        {
            DataReadInReadOnlyState();
            PopulateControlValuesInEditState();
            AdjustControlInEditState();
        }

        private void DataReadInReadOnlyState()
        {
            oEmployee = new EmployeeCrud().GetEmployeeByNik(DataID);
        }

        private void PopulateControlValuesInEditState()
        {
            if (oEmployee != null)
            {
                txtNik.Text = oEmployee.Nik;
                txtNameEmployee.Text = oEmployee.NameEmployee;
                txtDepartmentEmployee.Text = oEmployee.DepartmentEmployee;
                lblNamePhoto.Text = oEmployee.PhotoEmployee;
                imgPhotoEmployee.ImageUrl = "~/Images/" + oEmployee.PhotoEmployee;
            }
        }

        private void AdjustControlInEditState()
        {
            txtNik.ReadOnly = true;
            lblTitleForm.Text = "Edit Employee";
        }

        private void ProcessNew()
        {
            DataReadInNewState();
            //PopulateControlInNewState();
            AdjustControlInNewState();
        }

        private void AdjustControlInNewState()
        {
            lblTitleForm.Text = "Add New Employee";
        }

        private void DataReadInNewState()
        {
            oEmployee = new Employee();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsDataValidOnSave())
            {
                ProcessSave();

            }
        }

        private void ProcessSave()
        {
            string errorMsg = "";
            if (IsDataValidOnSave())
            {
                if (PageState == 0)
                {
                    DataReadInNewState();
                    DataSave(out errorMsg);
                }
                else
                {
                    DataReadInReadOnlyState();
                    DataSave(out errorMsg);
                }
                if (string.IsNullOrEmpty(errorMsg))
                {
                    string script = "alert('Save data success!'); history.back();";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", script, true);
                    Response.Redirect("EmployeList.aspx");
                }
            }
        }



        private void DataSave(out string errorMsg)
        {
            errorMsg = string.Empty;
            try
            {
                if (this.PageState == 0)
                {
                    oEmployee.Nik = txtNik.Text;
                    oEmployee.NameEmployee = txtNameEmployee.Text;
                    oEmployee.DepartmentEmployee = txtDepartmentEmployee.Text;
                    oEmployee.PhotoEmployee = lblNamePhoto.Text;
                    new EmployeeCrud().InsertEmployee(oEmployee);
                }
                else
                {
                    oEmployee.Nik = txtNik.Text;
                    oEmployee.NameEmployee = txtNameEmployee.Text;
                    oEmployee.DepartmentEmployee = txtDepartmentEmployee.Text;
                    oEmployee.PhotoEmployee = lblNamePhoto.Text;
                    new EmployeeCrud().UpdateEmployee(oEmployee);
                }
            }
            catch (Exception ex)
            {

                errorMsg = ex.ToString();
            }
        }

        private bool IsDataValidOnSave()
        {
            bool isValid = true;
            bool isSessionLive = true;
            StringBuilder script = new StringBuilder();

            //if (Commons.GetCurrentLoginUser() == null)
            //{
            //    script.Append("Session is expired!");
            //    isSessionLive = false;
            //}

            if (txtNik.Text == "")
            {
                script.Append("NIK has to be filled!");
                txtNik.Focus();
            }
            else if (txtNameEmployee.Text == "")
            {
                script.Append("NameEmployee has to be filled!");
                txtNameEmployee.Focus();
            }
            else if (lblNamePhoto.Text == "")
            {
                script.Append("Upload Photo has to be filled!");
                FileUpload_Photo.Focus();
            }

            if (script.Length > 0)
            {
                isValid = false;

                if (isSessionLive)
                    ScriptManager.RegisterStartupScript(this.Page, typeof(String), "Validation", "alert('" + script.ToString() + "');", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, typeof(String), "Validation", "alert('" + script.ToString() + "');window.close();", true);
            }

            script = null;
            return isValid;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (FileUpload_Photo.HasFile)
            {
                string fileName = FileUpload_Photo.FileName.ToUpper();
                string fl=Server.MapPath("/Images/" + lblNamePhoto.Text.ToUpper());
                if (File.Exists(fl))
                {
                    File.Delete(Server.MapPath("/Images/" + lblNamePhoto.Text.ToUpper()));
                }
                FileUpload_Photo.SaveAs(Server.MapPath("/Images/" + fileName));
                imgPhotoEmployee.ImageUrl = "~/Images/" + fileName;
                lblNamePhoto.Text = fileName;

            }
        }

    }
}