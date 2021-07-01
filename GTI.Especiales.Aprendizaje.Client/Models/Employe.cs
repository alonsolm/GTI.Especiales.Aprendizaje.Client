using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }
        public string EmployeName { get; set; }
        public string RFC { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }


    }
}