using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Kantin.Crud;
using System.IO;
using Kantin.Common;

namespace KantinASP.Pages.Master
{
    public partial class EmployeList : System.Web.UI.Page
    {
        private int page, startPage, endPage;
        private string criteria, value, listPerPage;
        private DataTable dtLevel;
        private bool readAcces, createAcces, editAcces, deleteAcces;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] uri = Request.Url.AbsoluteUri.Split(new string[] { "/" }, 0);
            string RoleId = Session[Constants.ROLEID].ToString();
            string FormName = uri[5];

            dtLevel = new RoleUserCrud().GetMenuAccesBy(RoleId, FormName);
            readAcces = bool.Parse(dtLevel.Rows[0][Constants.READACCES].ToString());
            createAcces = bool.Parse(dtLevel.Rows[0][Constants.CREATEACCES].ToString());
            editAcces = bool.Parse(dtLevel.Rows[0][Constants.EDITACCES].ToString());
            deleteAcces = bool.Parse(dtLevel.Rows[0][Constants.DELETEACCES].ToString());
            ControlComponentByLevel(readAcces, createAcces, editAcces, deleteAcces);

            if (!Page.IsPostBack)
            {
                criteria = dllCriteria.SelectedValue;
                value = txtValue.Text;
                listPerPage = dllListPerPage.SelectedItem.Text;
                lblPage.Text = "1";
                page = Int32.Parse(lblPage.Text);
                startPage = 1;
                endPage = page * Int32.Parse(listPerPage);
                DisplayData(criteria = "Nik", value = null, startPage, endPage);
            }
        }

        private void ControlComponentByLevel(bool readAcces, bool createAcces, bool editAcces, bool deleteAcces)
        {
            if (createAcces == true)
            {
                btnAddEmployee.Visible = true;
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
            DataTable dt = new EmployeeCrud().GetEmployeeAsTable(criteria, value, startPage, endPage);
            gvEmploye.DataSource = dt;
            gvEmploye.DataBind();

            GetTotalRecord(criteria, value);
            GetTotalPage(criteria, value, Int32.Parse(listPerPage));
            ControlComponent();
        }

        private void GetTotalPage(string criteria, string value, int listPerPage)
        {
            int totalPage = new EmployeeCrud().GetTotalPage(criteria, value, listPerPage);
            lblTotalPage.Text = totalPage.ToString();
        }

        protected void btnReadEmployee_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (readAcces != true)
            {
                string script = string.Format("alert('{0}')", "You haven't acces this event !!");
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                return;
            }
            Response.Redirect("EmployeDetail.aspx?DataID=" + button.CommandArgument + "&PageState=2");
        }

        protected void btnEditEmployee_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (editAcces != true)
            {
                string script = string.Format("alert('{0}')", "You haven't acces this event !!");
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                return;
            }
            Response.Redirect("EmployeDetail.aspx?DataID=" + button.CommandArgument + "&PageState=1");
        }

        protected void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (editAcces != true)
            {
                string script = string.Format("alert('{0}')", "You haven't acces this event !!");
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                return;
            }
            new EmployeeCrud().DeleteEmployeeByNik(button.CommandArgument);
            int startNo = Convert.ToInt32(gvEmploye.Rows[0].Cells[1].Text);

            string pesan = string.Format("alert('{0}')", "NIK " + button.CommandArgument + " Deleted, Success");
            ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", pesan, true);

            if (File.Exists(Server.MapPath("/images/" + button.CommandName)))
            {
                File.Delete(Server.MapPath("/images/" + button.CommandName));
            }

            criteria = dllCriteria.SelectedValue;
            value = txtValue.Text;
            listPerPage = dllListPerPage.SelectedItem.Text;
            lblPage.Text = "1";
            page = Int32.Parse(lblPage.Text);
            startPage = 1;
            endPage = page * Int32.Parse(listPerPage);
            DisplayData(criteria = "Nik", value = null, startPage, endPage);
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
                DisplayData(criteria = "Nik", value = null, startPage, endPage);
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
            int ttlRecord = new EmployeeCrud().GetTotalRecord(criteria, value);
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
            DisplayData(criteria = "Nik", value = null, startPage, endPage);
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
            DisplayData(criteria = "Nik", value = null, startPage, endPage);

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
            DisplayData(criteria = "Nik", value = null, startPage, endPage);
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("EmployeDetail.aspx?PageState=0"));
        }

        protected void gvEmploye_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnRead = (LinkButton)e.Row.FindControl("btnReadEmployee");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEditEmployee");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDeleteEmployee");
                if (readAcces == true)
                {
                    btnRead.Visible = true;
                }
                if (editAcces == true)
                {
                    btnEdit.Visible = true;
                }
                if (deleteAcces == true)
                {
                    btnDelete.Visible = true;
                }
            }

        }

    }
}