using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Kantin.Crud;
using System.IO;

namespace KantinASP.Pages.Master
{
    public partial class CateringList : System.Web.UI.Page
    {
        private int page, startPage, endPage;
        private string criteria, value, listPerPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                criteria = dllCriteria.SelectedValue;
                value = txtValue.Text;
                listPerPage = dllListPerPage.SelectedItem.Text;
                lblPage.Text = "1";
                page = Int32.Parse(lblPage.Text);
                startPage = 1;
                endPage = page * Int32.Parse(listPerPage);
                DisplayData(criteria = "IdCatering", value = null, startPage, endPage);
            }
        }

        private void ControlComponent()
        {
            if (Convert.ToInt32(lblPage.Text) <= 1)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if (endPage >= Convert.ToInt32(lblTotalRecord.Text))
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }

        }

        private void DisplayData(string criteria, string value, int startPage, int endPage)
        {
            DataTable dt = new CateringCrud().GetCateringAsTable(criteria, value, startPage, endPage);
            gvCatering.DataSource = dt;
            gvCatering.DataBind();

            GetTotalRecord(criteria, value);
            GetTotalPage(criteria, value, Int32.Parse(listPerPage));
            ControlComponent();
        }

        private void GetTotalPage(string criteria, string value, int listPerPage)
        {
            int totalPage = new CateringCrud().GetTotalPage(criteria, value, listPerPage);
            lblTotalPage.Text = totalPage.ToString();
        }

        protected void btnEditCatering_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;

            Response.Redirect("CateringDetail.aspx?DataID=" + button.CommandArgument + "&PageState=1");
        }

        protected void btnDeleteCatering_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            new CateringCrud().DeleteCateringByNik(button.CommandArgument);
            int startNo = Convert.ToInt32(gvCatering.Rows[0].Cells[1].Text);

            string script = string.Format("alert('{0}')", "NIK " + button.CommandArgument + " Deleted, Success");
            ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);

            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            lblPage.Text = "1";
            page = Int32.Parse(lblPage.Text);
            startPage = 1;
            endPage = page * Int32.Parse(listPerPage);
            DisplayData(criteria = "IdCatering", value = null, startPage, endPage);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            lblPage.Text = "1";
            page = Int32.Parse(lblPage.Text);
            startPage = 1;
            endPage = page * Int32.Parse(listPerPage);


            string msg = string.Empty;

            if (string.IsNullOrEmpty(criteria) && string.IsNullOrEmpty(value))
            {
                DisplayData(criteria = "IdCatering", value = null, startPage, endPage);
                return;
            }

            if (string.IsNullOrEmpty(criteria))
            {
                msg = "Please select criteria";
                string script = string.Format("alert('{0}')", msg);
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                dllCriteria.Focus();
                return;
            }

            if (string.IsNullOrEmpty(value))
            {
                msg = "Please input value";
                string script = string.Format("alert('{0}')", msg);
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                txtValue.Focus();
                return;
            }

            
            DisplayData(criteria, value, startPage, endPage);
        }


        private void GetTotalRecord(string criteria, string value)
        {
            int ttlRecord = new CateringCrud().GetTotalRecord(criteria, value);
            lblTotalRecord.Text = ttlRecord.ToString();
        }


        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            page = Int32.Parse(lblPage.Text);

            lblPage.Text = Convert.ToString(page - 1);
            startPage = ((page - 1) * Int32.Parse(listPerPage)) - (Int32.Parse(listPerPage) - 1);
            endPage = Int32.Parse(lblPage.Text) * Int32.Parse(listPerPage);

            string msg = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(criteria))
                {
                    msg = "Please select criteria and input value";
                    string script = string.Format("alert('{0}')", msg);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                    dllCriteria.Focus();
                    return;
                }
                DisplayData(criteria, value, startPage, endPage);
                return;
            }
            DisplayData(criteria = "IdCatering", value = null, startPage, endPage);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            page = Int32.Parse(lblPage.Text);
            startPage = (Int32.Parse(lblPage.Text) * Int32.Parse(listPerPage)) + 1;
            lblPage.Text = Convert.ToString(page + 1);
            endPage = Int32.Parse(lblPage.Text) * Int32.Parse(listPerPage);

            string msg = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(criteria))
                {
                    msg = "Please select criteria and input value";
                    string script = string.Format("alert('{0}')", msg);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                    dllCriteria.Focus();
                    return;
                }
                DisplayData(criteria, value, startPage, endPage);
                return;
            }
            DisplayData(criteria = "IdCatering", value = null, startPage, endPage);

        }

        protected void dllListPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {

            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            lblPage.Text = "1";
            page = Int32.Parse(lblPage.Text);
            startPage = 1;
            endPage = page * Int32.Parse(listPerPage);

            string msg = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (string.IsNullOrEmpty(criteria))
                {
                    msg = "Please select criteria and input value";
                    string script = string.Format("alert('{0}')", msg);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                    dllCriteria.Focus();
                    return;
                }
                DisplayData(criteria, value, startPage, endPage);
                return;
            }
            DisplayData(criteria = "IdCatering", value = null, startPage, endPage);
        }

        protected void btnAddCatering_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("CateringDetail.aspx?PageState=0"));
        }

    }
}