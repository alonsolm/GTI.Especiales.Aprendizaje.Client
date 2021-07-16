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
        private EmployeeRepository _repository;

        #region ViewState properties
        public int TotalEmployees
        {
            get
            {
                return (int)ViewState[nameof(TotalEmployees)];
            }
            set
            {
                ViewState[nameof(TotalEmployees)] = value;
            }
        }
        public int ActiveEmployees
        {
            get
            {
                return (int)ViewState[nameof(ActiveEmployees)];
            }
            set
            {
                ViewState[nameof(ActiveEmployees)] = value;
            }
        }
        public int DisabledEmployees
        {
            get
            {
                return (int)ViewState[nameof(DisabledEmployees)];
            }
            set
            {
                ViewState[nameof(DisabledEmployees)] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(Globals.ConnectionString);
            IEnumerable<Employee> employees = _repository.GetAllEmployees();
            this.TotalEmployees = employees.Count();
            this.ActiveEmployees = employees.Count(p => p.Active == true);
            this.DisabledEmployees = (this.TotalEmployees - this.ActiveEmployees);
        }
        public void EmployeeGrid_UpdateItem(int employeeID)
        {
            Response.Redirect($"~/AddEmployee?id={employeeID}");
        }

        public void EmployeeGrid_DeleteItem()
        {
            var employee = new Employee();
            TryUpdateModel(employee);
            Result result = _repository.DeleteEmployee(employee.EmployeeID);
            if (result.IsSuccess)
            {
                this.ActiveEmployees--;
                this.DisabledEmployees++;
            }
        }

        public IQueryable<Employee> GetEmployees([Control] String displayActive, [Control] String txtSearch)
        {
            IQueryable<Employee> employees = _repository.GetAllEmployees().AsQueryable();

            if (displayActive == "Activos")
            {
                return employees.Where(e => e.Active == true);
            }
            else if (displayActive == "Inactivos")
            {
                return employees.Where(e => e.Active == false);
            }

            return employees;
        }
    }
}
