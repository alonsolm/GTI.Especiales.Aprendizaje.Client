﻿using System;
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

        private static List<Employe> GetProducts()
        {
            var employe = new List<Employe> {
                new Employe
                {
                    EmployeID = 1,
                    EmployeName = "name",
                    RFC = "rfc",
                    Salary = 22.50m,
               }
            };

            return employe;
        }

    }
}