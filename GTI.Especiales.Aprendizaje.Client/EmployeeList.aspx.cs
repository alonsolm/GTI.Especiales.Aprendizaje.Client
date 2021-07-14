using GTI.Especiales.Aprendizaje.Client.Data;
using GTI.Especiales.Aprendizaje.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        private EmployeeRepository _repository;
        public int Total =1;
        public int Activos=1;
        public int Inactivos=1;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(_connectionString);
            this.Total = _repository.GetAllEmployees().AsQueryable().Count();
            this.Activos = _repository.GetAllEmployees().AsQueryable().Where(p => p.Active == true).Count();
            this.Inactivos = _repository.GetAllEmployees().AsQueryable().Where(p => p.Active == false).Count();
            var widtgh = this.employeeList.Width;
            var h = this.employeeList.Rows.Count;

        }
       
        protected override void OnSaveStateComplete(EventArgs e)
        {
            var Rows = this.employeeList.Rows.Count;
            Control CounterSection = FindControl("CounterSection");
            double  RowsHeightDouble = ((Rows * 78.34) + 516)/16;
            String RowsHeightString = RowsHeightDouble.ToString() + "em";
            this.CounterSection.Style.Add("top", RowsHeightString);
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
            this.Activos = _repository.GetAllEmployees().AsQueryable().Where(p => p.Active == true).Count();
            this.Inactivos = _repository.GetAllEmployees().AsQueryable().Where(p => p.Active == false).Count();
        }

        public IQueryable<Employee> GetEmployees([Control] String dysplayActive, [Control] String txtSearch)
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
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                },
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Alonso Lares",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22,
                    Active = true
                }
        }.AsQueryable();*/

            if (!String.IsNullOrEmpty(txtSearch))
            {
                return _repository.GetAllEmployees().AsQueryable().Where(e => e.EmployeeName.ToUpper().Contains(txtSearch.ToUpper()));
            }
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
