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
        protected EmployeRepository repository = new EmployeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void EmployeGrid_UpdateItem(int employeID)
        {
            //Response.Redirect("~/EmployeUpdate?id=" + employeID);

             var employe = new Employe();
             TryUpdateModel(employe);
             repository.UpdateEmploye(employe);
        }

        public void EmployeGrid_DeleteItem(int employeID)
        {

        }

        public List<Employe> GetEmployes()
        {
            Employe employe = repository.GetEmployeById(1);

            return repository.GetEmployes();
        }
    }
}
