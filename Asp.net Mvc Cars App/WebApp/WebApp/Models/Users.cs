using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApp.Models
{
    public class Users
    {
        [Required(ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Compare("Password",ErrorMessageResourceName ="ConfirmPasswordMatch", ErrorMessageResourceType =typeof(Resources.Resource))]
        [Display(Name ="ConfirmPassword", ResourceType =typeof(Resources.Resource))]
        //ErrorMessage = "Confirm password doesn't match, Type again !")
        public string ConfirmPassword { get; set; }
    }
}