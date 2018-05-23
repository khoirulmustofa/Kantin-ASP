using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kantin.Entity;
using Kantin.Crud;

namespace KantinASP.Pages.Kantin
{
    public partial class ScanBarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Image1.ImageUrl = "~/Images/profile-pic.jpg";
            }
            //txtNik.Attributes.Add("onKeyPress", "doClick('" + btnSearchNik.ClientID + "',event)");
        }

        protected void btnSearchNik_Click(object sender, EventArgs e)
        {
            string nik = txtNik.Text;


            Employee oEmploye = new Employee();

            oEmploye = new EmployeeCrud().GetEmployeeByNik(nik);
            if (oEmploye == null)
            {
                string script = string.Format("alert('{0}')", "NIK " + nik + " Not found!!");
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                txtNik.Text = "";
                txtNik.Focus();
                ClearControl();
                return;

            }
            SaveEmployeToMeal(oEmploye);



        }

        private void PopulateEmploye(Employee oEmploye, string Status)
        {
            lblNik.Text = oEmploye.Nik;
            lblNameEmployee.Text = oEmploye.NameEmployee;
            lblDepartmentEmployee.Text = oEmploye.DepartmentEmployee;
            lblScan.Text = DateTime.Now.ToString();
            Image1.ImageUrl = "~/Images/" + oEmploye.PhotoEmployee;
            lblStatus.Text = Status;
            txtNik.Text = "";
            txtNik.Focus();
        }

        /// <summary>
        /// Untuk simpan ke meal
        /// </summary>
        /// <param name="oEmploye"></param>
        private void SaveEmployeToMeal(Employee oEmploye)
        {
            try
            {
                // simpan reguler   
                int jmlR = new MealCrud().GetCountMealBy(oEmploye.Nik, "R");
                if (jmlR == 0)
                {
                    Meal oMeal = new Meal();
                    oMeal.Nik = oEmploye.Nik;
                    oMeal.IdCatering = "K0001";
                    oMeal.Status = "R";
                    new MealCrud().InsertMeal(oMeal);
                    PopulateEmploye(oEmploye, "Regular");
                    return;
                }

                // simpan lembur
                int jmlL = new MealCrud().GetCountMealBy(oEmploye.Nik, "O");
                if (jmlL == 0)
                {
                    Meal oMeal = new Meal();
                    oMeal.Nik = oEmploye.Nik;
                    oMeal.IdCatering = "K0001";
                    oMeal.Status = "O";
                    new MealCrud().InsertMeal(oMeal);
                    PopulateEmploye(oEmploye, "Overtime");
                    return;
                }

                // jika reguler dan lembur sudah terpakai
                string script = string.Format("alert('{0}')", "NIK " + oEmploye.Nik + " , quota meal for today used up !!!");
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                txtNik.Text = "";
                txtNik.Focus();
                ClearControl();
                return;
            }
            catch (Exception ex)
            {

                string script = string.Format("alert('{0}')", ex.ToString());
                ScriptManager.RegisterStartupScript(this, typeof(string), "onClick", script, true);
                txtNik.Text = "";
                txtNik.Focus();
            }
        }

        private void ClearControl()
        {
            lblNik.Text = "";
            lblNameEmployee.Text = "";
            lblDepartmentEmployee.Text = "";
            lblScan.Text = "";
            lblStatus.Text = "";
            Image1.ImageUrl = null;
        }


    }
}