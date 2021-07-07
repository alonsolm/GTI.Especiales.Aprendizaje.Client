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

            context.SaveChanges();

        }
    }
}
