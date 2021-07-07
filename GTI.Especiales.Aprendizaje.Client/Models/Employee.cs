using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string RFC { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salary { get; set; }
        public bool Active { get; set; }


    }
}