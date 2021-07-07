using GTI.Especiales.Aprendizaje.Client.Data;
using GTI.Especiales.Aprendizaje.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        public void EmployeeGrid_DeleteItem(int employeeID)
        {
            _repository.DeleteEmployee(employeeID);
        }

        public List<Employee> GetEmployees()
        {
            /* return new List<Employee>
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
            return _repository.GetAllEmployees();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edituser")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the buttonfrom the Rows collection.
                GridViewRow row = employeeList.Rows[index];

                // Add code here now you have the specific row data
            }

        }
        

        protected void employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
