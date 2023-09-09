using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your id ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]

        public string Password { get; set; }
    }

}
