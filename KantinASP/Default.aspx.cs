using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Kantin.Entity;
using Kantin.Crud;
using System.Configuration;
using System.Data;
using Kantin.Common;

namespace KantinASP
{
    public partial class Default : System.Web.UI.Page
    {
        private string OwnerApp
        {
            get
            {
                return ConfigurationManager.AppSettings["OwnerApp"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string userName = txtUserName.Text.Trim();
                //string password = txtPassword.Text.Trim();
                string userName = "123";
                string password = "123";

                IsNullOrEmpty(userName, password);

                if (VerifyUser(userName, password))
                {
                    Response.Redirect("Dashboard.aspx");
                }

            }
            catch (Exception ex)
            {

                string script = string.Format("alert('{0}')", ex.ToString());
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);

            }
        }

        private bool VerifyUser(string userName, string password)
        {
            string error = string.Empty;
            bool result = false;
            Users oUsers = new UsersCrud().GetUserBy(OwnerApp+"/"+userName);
            if (oUsers == null)
            {
                error = "User name is wrong !!, Please corect";
                txtUserName.Text = "";
                txtUserName.Focus();
                result = false;
            }
            else
            {
                string pass = new UsersCrud().GetUserVerifyPassword(password);
                //kesamaan password
                if (oUsers.Passwords.Equals(pass))
                {
                    DataTable dtRole = new RoleUserCrud().GetRoleUserBy(OwnerApp + "/" + userName);
                    Session[Constants.USERID] = dtRole.Rows[0]["USERID"].ToString();
                    Session[Constants.USERNAME] = dtRole.Rows[0]["USERNAME"].ToString();
                    Session[Constants.ROLEID] = dtRole.Rows[0]["ROLEID"].ToString();
                    Session[Constants.ROLENAME] = dtRole.Rows[0]["ROLENAME"].ToString();
                    result = true;
                }
                else
                {
                    error = "Password is wrong !!, Please corect";
                    txtPassword.Text = "";
                    txtPassword.Focus();
                    result = false;
                }                
            }
            string script = string.Format("alert('{0}')", error);
            ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
            return result;
        }

        //private object GetRoleName()
        //{
        //    SMBCRole role = SMBCRoleFacade.GetRoleByUserID(DomainName + "/" + Login1.UserName);
        //    return role == null ? string.Empty : role.RoleName;
        //}

        private void IsNullOrEmpty(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                lblMessege.Text = "Plaese complete Usename !!";
                lblMessege.ForeColor = Color.Red;
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblMessege.Text = "Plaese complete password !!";
                txtPassword.ForeColor = Color.Red;
                txtPassword.Focus();
                return;
            }
        }
    }
}