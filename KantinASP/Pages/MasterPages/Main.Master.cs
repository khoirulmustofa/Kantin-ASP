using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;
using Kantin.Crud;
using Kantin.Common;
using System.IO;

namespace KantinASP.Pages.MasterPages
{
    public partial class Main1 : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblUserName.Text = Session["UserName"].ToString();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "";
            if (!Page.IsPostBack)
            {
                CultureInfo ci = new CultureInfo("id-ID", false);



            }
            SetMenuAuthorization();
        }
        


        private void SetMenuAuthorization()
        {
            string[] uri = Request.Url.AbsoluteUri.Split(new string[] { "/" }, 0);
            string baseUrl = uri[0] + "//" + uri[2] + "/";
            StringBuilder lm = new StringBuilder();
            MenuCrud oMenuCrud = new MenuCrud();
            DataTable dtmenu = oMenuCrud.GetListMenuByUserIDAsDataTable(Commons.GetCurrentLoginUser());
            //DataTable dtMenuCp = dtmenu.Copy();
            //DataRow[] root = dtmenu.Select("MenuParent = 0","MenuSeqtNo"); 
            DataTable dtRoot = oMenuCrud.GetRootMenuByUserID(Commons.GetCurrentLoginUser());
            foreach (DataRow r in dtRoot.Rows)
            {
                DataRow[] flm = dtmenu.Select(string.Format("MenuParent = {0}", r["MenuID"]));
                if (flm.Length > 0)
                {
                    lm.Append(string.Format("<li class='{4}'><a class='dropmenu' href='{0}'><i class='{1}'></i><span class='hidden-tablet'> {2}</span></a>", r["MenuPath"], r["MenuIconString"], r["MenuName"], baseUrl, r["MenuID"]));
                    lm.Append("<ul>");
                    foreach (DataRow rfl in flm)
                    {
                        DataRow[] slc = dtmenu.Select(string.Format("MenuParent = {0}", rfl["MenuID"]));
                        if (slc.Length > 0)
                        { // ini jika ada tambahan lagi
                            lm.Append(string.Format("<li class='{4}'> <a class='dropmenu' href='#'><i class='icon-folder-close-alt'></i><span class='hidden-tablet'> Dropdown</span><span class='label label-important'> 3 </span></a>", rfl["MenuPath"], rfl["MenuIconString"], rfl["MenuName"], baseUrl, rfl["MenuID"]));
                            lm.Append("<ul>");
                            foreach (DataRow rsl in slc)
                            {
                                lm.Append(string.Format("<li><a class='submenu' href='{0}'><i class='icon-file-alt'></i><span class='hidden-tablet'> {1}</span></a></li>", rsl["MenuPath"], rsl["MenuName"], rsl["MenuIconString"], rsl["MenuName"], baseUrl, rsl["MenuID"]));
                            }
                            lm.Append("</ul>");
                            lm.Append("</li>");
                        }
                        else
                        {
                            lm.Append(string.Format("<li class='{4}'><a href='{0}'><i class='{1}'></i><span class='hidden-tablet'> {2}</span></a></li>", rfl["MenuPath"], rfl["MenuIconString"], rfl["MenuName"], baseUrl, rfl["MenuID"]));
                        }

                    }
                    lm.Append("</ul>");
                    lm.Append("</li>");
                }
                else
                {
                    lm.Append(string.Format("<li><a href='{3}{0}'><span class='{1}'></span><span class='text'>{2}</span></a></li>", r["MenuPath"], r["MenuIconString"], r["MenuName"], baseUrl));
                }
            }
            string script = string.Format("<script type='text/javascript'>$('#mainmenu').append(\"{0}\");</script>", lm);
            ScriptManager.RegisterStartupScript(this, typeof(string), "onload", script, false);
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}