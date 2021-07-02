using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTI.Especiales.Aprendizaje.Client.Models;
using GTI.Especiales.Aprendizaje.Client.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class EmployeList : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        private EmployeeRepository _repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repository = new EmployeeRepository(_connectionString);
        }

        public void EmployeGrid_UpdateItem(int employeID)
        {
            var employe = new Employee();
            TryUpdateModel(employe);
            _repository.UpdateEmployee(employe);
        }

        public void EmployeGrid_DeleteItem(int employeID)
        {

        }

        public List<Employee> GetEmployes()
        {
            return _repository.GetAllEmployees();
        }
    }
}
