using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTI.Especiales.Aprendizaje.Client.Models;
using GTI.Especiales.Aprendizaje.Client.Data;
namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        public EmployeeRepository _repository;
        protected Employee employee = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]) && _repository != null && this.BtnAddUpdate.Text != "Modificar")
            {
                employee = _repository.GetEmployeeById(Int32.Parse(Request.QueryString["id"]));
                this.Name.Text = employee.EmployeeName;
                this.RFC.Text = employee.RFC;
                this.Salary.Text = employee.Salary.ToString();
                if(employee.Active){ this.Active.Enabled = false;  }
                this.Active.Checked = employee.Active;
                this.BtnAddUpdate.Text = "Modificar";
                if (employee.Active) {
                    this.BtnDeleteCancel.Text = "Eliminar";
                    this.BtnDeleteCancel.Attributes.CssStyle.Add("background-color", "#dc3545");
                    this.BtnDeleteCancel.Attributes["onClick"] = "return confirm('Seguro quiere eliminar este empleado?');";
                }
                
                
                
            }
            _repository = new EmployeeRepository(_connectionString);
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(_connectionString);
        }
       


        protected void AddUpdateEmployeeForm_InsertItem(object sender, EventArgs e)
        {
            if (this.BtnAddUpdate.Text == "Crear")
            {
                var employee = new Employee();
                employee.EmployeeName = this.Name.Text;
                employee.RFC = this.RFC.Text;
                employee.Salary = Convert.ToDecimal(this.Salary.Text);
                employee.Active = this.Active.Checked;
                _repository.AddEmployee(employee);
            }
            else {
                employee.EmployeeID = Int32.Parse(Request.QueryString["id"]);
                employee.EmployeeName = this.Name.Text;
                employee.RFC = this.RFC.Text;
                employee.Salary = Convert.ToDecimal(this.Salary.Text);
                employee.Active = this.Active.Checked;
                _repository.UpdateEmployee(employee);
            }

            Response.Redirect("~/EmployeeList");
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            if (this.BtnDeleteCancel.Text == "Eliminar")
            {
                _repository.DeleteEmployee(Int32.Parse(Request.QueryString["id"]));
                Response.Redirect("~/EmployeeList");
            }
            else
            {
                Response.Redirect("~/EmployeeList");
            }
        }

        protected void AddEmployeeForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/EmployeeList");
        }
        
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
            }
        }
        public void imgValidAdd_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // Some Code
                    // Open Confirm dialog
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "openconfirmjs", "<script>openconfirmdialog();</script>");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        public void btnConfirmed_Clicked(object sender, EventArgs e)
        {
            // Proceed
        }
    }
}