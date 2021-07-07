using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class EmployeeCommand
    {
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salario { get; set; }
        public bool Activo { get; set; }

        public Employee merge()
        {
            Employee employee = new Employee();

            employee.EmployeeID = this.EmployeeID;
            employee.EmployeeName = this.Nombre;
            employee.RFC = this.RFC;
            employee.Salary = this.Salario;
            employee.Active = this.Activo;

            return employee;
        }


    }
}