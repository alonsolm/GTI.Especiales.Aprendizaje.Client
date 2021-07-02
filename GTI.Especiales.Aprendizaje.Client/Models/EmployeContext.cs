using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class EmployeContext : DbContext
    {
        public EmployeContext() : base("GTI.Especiales.Aprendizaje.Client")
        {
        }
        public DbSet<Employee> Employe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(k => k.EmployeID);
        }
    }
}