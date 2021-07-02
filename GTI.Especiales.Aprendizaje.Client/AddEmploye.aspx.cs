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
    public partial class AddEmploye : System.Web.UI.Page
    {
        protected EmployeRepository repository = new EmployeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddEmployeForm_InsertItem()
        {
            var employe = new Employe();
            TryUpdateModel(employe);
            repository.AddEmploye(employe);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeList");
        }

        protected void AddEmployeForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/EmployeList");
        }
    }
}