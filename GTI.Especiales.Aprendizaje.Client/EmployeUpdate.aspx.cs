using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTI.Especiales.Aprendizaje.Client.Data;
using GTI.Especiales.Aprendizaje.Client.Models;
namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class EmployeUpdate : System.Web.UI.Page
    {
        private EmployeRepository repository = new EmployeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Employe employe = repository.GetEmployeById(Int32.Parse(Request.QueryString["id"]));
            }
        }

        public void UpdateEmployeForm_InsertItem()
        {
            var employe = new Employe();
            TryUpdateModel(employe);
            repository.AddEmploye(employe);
        }

        protected void CancelUpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeList");
        }

        protected void UpdateEmployeForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/EmployeList");
        }
    }
}