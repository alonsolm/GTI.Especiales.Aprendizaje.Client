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
        private EmployeeRepository _repository;

        #region QueryString properties
        public int Id
        {
            get
            {
                Int32.TryParse(Request.QueryString[nameof(Id).ToLower()], out int id);
                return id;
            }
        }
        public bool IsEditMode => (Id > 0);
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(Globals.ConnectionString);

            if (Page.IsPostBack)
                return;

            if (IsEditMode)
            {
                Employee employee = _repository.GetEmployeeById(Id);
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
        }

        protected void AddUpdateEmployeeForm_InsertItem(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeName = this.Name.Text;
            employee.RFC = this.RFC.Text;
            employee.Salary = Convert.ToDecimal(this.Salary.Text);
            employee.Active = true;

            if (IsEditMode)
            {
                employee.EmployeeID = Id;
                employee.Active = this.Active.Checked;
                _repository.UpdateEmployee(employee);
            }
            else
            {
                _repository.AddEmployee(employee);
            }

            Response.Redirect("~/EmployeeList");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeeList");
        }
    }
}