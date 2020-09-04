using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginWithCrudOperation.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        
        public string Designation { get; set; }
        [Range(15,30,ErrorMessage ="Age should be 15 to 30 only.")]
        public string Age { get; set; }
        [RegularExpression(@"\+91[0-9]{10}",ErrorMessage ="Invalid Mobile")]
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public string ImageName { get; set; }
        ////[NotMapped]
        ////public List<City> Cities { get; set; }
    }
}