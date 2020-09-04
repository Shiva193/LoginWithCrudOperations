using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginWithCrudOperation.Models
{
    public class UserReg
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Please enter user name")]
        public string UserName { get; set; }
        [Display(Name ="Email Id")]
        [Required(ErrorMessage ="Please enter email id")]
        public string EmailId { get; set; }
        [Display(Name ="Mobile No.")]
        [Required(ErrorMessage ="Please enter Mobile no.")]
        public string MobileNo { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}