using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VSPApplication.Models
{
    public class User_Master:IDisposable
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is Required !")]
        [MaxLength(15), MinLength(1)]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required !")]
        [MaxLength(15), MinLength(1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required !")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        [Remote("CheckExistingEmail", "Account", ErrorMessage = "Email Already exits !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required !")]
        [DataType(DataType.Password)]
        [MaxLength(15), MinLength(8)]       
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required !")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsActivated { get; set; }

      
      
        [Required(ErrorMessage = "Email is Required !")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        [Remote("CheckExistingEmailForChagePassword", "Account", ErrorMessage = "Email Already exits !")]
        public string PasswordChangEmialId { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose();

        }
    }
}