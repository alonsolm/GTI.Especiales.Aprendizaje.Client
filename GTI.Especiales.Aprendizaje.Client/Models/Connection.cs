using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using GTI.Especiales.Aprendizaje.Client.Data;
namespace GTI.Especiales.Aprendizaje.Client.Models
{
    public static class Globals
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
    }
}