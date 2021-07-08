using GTI.Especiales.Aprendizaje.Client.Data;
using GTI.Especiales.Aprendizaje.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        private EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(_connectionString);
        }

        public void EmployeeGrid_UpdateItem(int employeeID)
        {
            var employee = new Employee();
            TryUpdateModel(employee);
            Response.Redirect("~/AddEmployee?id=" + employee.EmployeeID);
        }

        public void EmployeeGrid_DeleteItem()
        {
            var employee = new Employee();
            TryUpdateModel(employee);
            _repository.DeleteEmployee(employee.EmployeeID);
        }

        public IQueryable<Employee> GetEmployees([Control] String dysplayActive)
        {
            /*return new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                }
            };*/
            switch (dysplayActive)
            {
                case "Activos":
                    return _repository.GetAllEmployees().AsQueryable().Where(e => e.Active == true);
                case "Inactivos":
                    return _repository.GetAllEmployees().AsQueryable().Where(e => e.Active == false);
                case "Todos":
                    return _repository.GetAllEmployees().AsQueryable();
            }
            return _repository.GetAllEmployees().AsQueryable();
        }
        
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string employeeId = btn.CommandArgument;
            _repository.DeleteEmployee(Int32.Parse(employeeId));

        }

        protected void GoToUpdateView(object sender, ImageClickEventArgs e)
        {
            var employee = new Employee();
            TryUpdateModel(employee);
            Response.Redirect("~/AddEmployee?id=" + employee.EmployeeID);
        }
    }
}
