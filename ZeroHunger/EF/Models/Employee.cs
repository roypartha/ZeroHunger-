using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Employee
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public DateTime Dob { get ; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Type { get; set; }

    }
}