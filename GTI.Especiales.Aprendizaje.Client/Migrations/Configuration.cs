namespace GTI.Especiales.Aprendizaje.Client.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GTI.Especiales.Aprendizaje.Client.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GTI.Especiales.Aprendizaje.Client.Models.EmployeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GTI.Especiales.Aprendizaje.Client.Models.EmployeContext context)
        {
            context.Employe.AddOrUpdate(
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
                    EmployeName = "Raul",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = false
                },
                new Employe
                {
                    EmployeID = 7,
                    EmployeName = "Emilce",
                    RFC = "LAMA940810HBCRJL00",
                    Salary = 22.50m,
                    Active = false
                });

            context.SaveChanges();

        }
    }
}
