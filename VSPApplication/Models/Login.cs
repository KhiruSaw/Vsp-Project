using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VSPApplication.Models
{
    public class Login:IDisposable
    {
        [Required(ErrorMessage ="EmailID is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose();

        }
    }
}