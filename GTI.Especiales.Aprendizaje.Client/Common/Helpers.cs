using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using GTI.Especiales.Aprendizaje.Client.Models;

namespace GTI.Especiales.Aprendizaje.Client.Common
{
    public static class Helpers
    {
        public static Result Success = new Result
        {
            IsSuccess = true,
            Message = "Ok"
        };

        public static Result OnError(string error)
        {
            return new Result
            {
                IsSuccess = false,
                Message = error
            };
        }
    }
}