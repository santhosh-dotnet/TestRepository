using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDonMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Enter User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Select Your Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone")]
        public long Phone { get; set; }
    }
    public class EmpModel
    {
        [Required(ErrorMessage = "Enter Employee Id")]
        public int Eid { get; set; }
        [Required(ErrorMessage = "Enter Employee Name ")]
        public string Ename { get; set; }
        [Required(ErrorMessage = "Please choose Employee City ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Address")]
        public string Address { get; set; }
    }
}