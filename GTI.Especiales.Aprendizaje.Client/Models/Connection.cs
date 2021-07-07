using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using GTI.Especiales.Aprendizaje.Client.Data;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public class Connection
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        private EmployeeRepository _repository;
    }
}