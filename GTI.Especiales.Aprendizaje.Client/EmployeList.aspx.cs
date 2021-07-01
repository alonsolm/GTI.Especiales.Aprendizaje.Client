using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTI.Especiales.Aprendizaje.Client.Models;

namespace GTI.Especiales.Aprendizaje.Client
{
    public partial class EmployeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
        }

        public void addEmployeForm_InsertItem()
        {
        }

        public void addEmployeForm_ItemInserted()
        {
        }
        

        public List<Employe> GetEmployes()
        {
            var employe = new List<Employe> {
                new Employe
                {
                    EmployeID = 1,
                    EmployeName = "Alonso",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = true
               },
                new Employe
                {
                    EmployeID = 2,
                    EmployeName = "Jesus",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = true
               },
                new Employe
                {
                    EmployeID = 3,
                    EmployeName = "Tomas",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = false
               },
                new Employe
                {
                    EmployeID = 4,
                    EmployeName = "Betty",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = true
               },
                new Employe
                {
                    EmployeID = 5,
                    EmployeName = "Luis",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = false
               },
                new Employe
                {
                    EmployeID = 6,
                    EmployeName = "Ricardo",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = false
               }
            };
            return employe;
        }
    }
}