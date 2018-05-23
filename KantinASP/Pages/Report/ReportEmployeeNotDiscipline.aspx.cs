using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Kantin.Crud;

namespace KantinASP.Pages.Report
{
    public partial class ReportEmployeeNotDiscipline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string startDate = txtStartDate.Text.Trim();
            string endDate = txtEndDate.Text.Trim();

            ReportDataSource rds = new ReportDataSource("DataSet1", GetReportEmpleyeeNotDiscipline(startDate,endDate));
            rvEmpleyeeNotDiscipline.LocalReport.ReportPath = Server.MapPath("ReportNotDiscipline.rdlc");

            ReportParameter p1 = new ReportParameter("StartDate", startDate);
            ReportParameter p2 = new ReportParameter("EndDate", endDate);
           

            rvEmpleyeeNotDiscipline.LocalReport.SetParameters(new ReportParameter[]{p1,p2});
            rvEmpleyeeNotDiscipline.LocalReport.DataSources.Add(rds);
            rvEmpleyeeNotDiscipline.LocalReport.DisplayName = "Report Employe Not Discipline " + DateTime.Now.ToString("yyyyMMdd_hhmmss");

            rvEmpleyeeNotDiscipline.LocalReport.Refresh();
        }

        private DataTable GetReportEmpleyeeNotDiscipline(string StartDate,string EndDate)
        {
            return new EmployeeCrud().GetEmpleyeeNotDiscipline(StartDate, EndDate);
        }
    }
}