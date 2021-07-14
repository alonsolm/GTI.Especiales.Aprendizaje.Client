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
                this.Active.Checked = employee.Active;
                this.BtnAddUpdate.Text = "Modificar";
                this.BtnAddUpdate.Style.Add("padding", ".85em 1.802em");
            }
            else
            {
                Control ActiveSection = FindControl("ActiveSection");
                this.ActiveSection.Style.Add("display", "none");
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
                employee.Active = true;
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
            Response.Redirect("~/EmployeeList");
        }

        protected void AddEmployeeForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/EmployeeList");
        }
    }
}