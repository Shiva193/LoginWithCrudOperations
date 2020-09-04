using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginWithCrudOperation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please enter user name")]
        [Display(Name ="Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please enter Password")]
        [Display(Name ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}