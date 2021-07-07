using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class EmployeDatabaseInitializer : DropCreateDatabaseIfModelChanges<EmployeContext>
    {

        protected override void Seed(EmployeContext context)
        {
            GetProducts().ForEach(p => context.Employe.Add(p));
        }

        private static List<Employee> GetProducts()
        {
            var employe = new List<Employee> {
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "name",
                    RFC = "rfc",
                    Salary = 22.50m,
               }
            };

            return employe;
        }

    }
}