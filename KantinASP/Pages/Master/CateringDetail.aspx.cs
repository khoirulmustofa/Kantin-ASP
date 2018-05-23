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
    public partial class CateringDetail : System.Web.UI.Page
    {

        private Catering oCatering = null;
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
                default:
                    break;
            }
        }

        private void PrecessEdit()
        {
            DataReadInReadOnlyState();
            PopulateControlValuesInEditState();
            AdjustControlInEditState();
        }

        private void DataReadInReadOnlyState()
        {
            oCatering = new CateringCrud().GetCateringByNik(DataID);
        }

        private void PopulateControlValuesInEditState()
        {
            if (oCatering != null)
            {
                txtIdCatering.Text = oCatering.IdCatering;
                txtNameCatering.Text = oCatering.NameCatering;
                txtTelpCatering.Text = oCatering.TelpCatering;
                txtAddressCatering.Text = oCatering.AddressCatering;
                txtEmailCatering.Text = oCatering.EmailCatering;
            }
        }

        private void AdjustControlInEditState()
        {
            txtIdCatering.ReadOnly = true;
        }

        private void ProcessNew()
        {
            DataReadInNewState();
            //PopulateControlInNewState();
            AdjustControlInNewState();
        }

        private void AdjustControlInNewState()
        {
            lblTitleForm.Text = "Add New Catering";
        }

        private void DataReadInNewState()
        {
            oCatering = new Catering();
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
                    Response.Redirect("CateringList.aspx");
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
                    oCatering.IdCatering = txtIdCatering.Text;
                    oCatering.NameCatering = txtNameCatering.Text;
                    oCatering.TelpCatering = txtTelpCatering.Text;
                    oCatering.AddressCatering = txtAddressCatering.Text;
                    oCatering.EmailCatering = txtEmailCatering.Text;
                    new CateringCrud().InsertCatering(oCatering);
                }
                else
                {
                    oCatering.IdCatering = txtIdCatering.Text;
                    oCatering.NameCatering = txtNameCatering.Text;
                    oCatering.TelpCatering = txtTelpCatering.Text;
                    oCatering.AddressCatering = txtAddressCatering.Text;
                    oCatering.EmailCatering = txtEmailCatering.Text;
                    new CateringCrud().UpdateCatering(oCatering);
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

            if (txtIdCatering.Text == "")
            {
                script.Append("Id Catering has to be filled!");
                txtIdCatering.Focus();
            }
            else if (txtNameCatering.Text == "")
            {
                script.Append("Name Catering has to be filled!");
                txtNameCatering.Focus();
            }
            else if (txtTelpCatering.Text == "")
            {
                script.Append("Telp Catering has to be filled!");
                txtTelpCatering.Focus();
            }
            else if (txtAddressCatering.Text == "")
            {
                script.Append("Address Catering has to be filled!");
                txtAddressCatering.Focus();
            }
            else if (txtEmailCatering.Text == "")
            {
                script.Append("Email Catering has to be filled!");
                txtEmailCatering.Focus();
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
    }
}