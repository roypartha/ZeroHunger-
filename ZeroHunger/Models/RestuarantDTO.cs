using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace ZeroHunger.Models
{
    public class RestuarantDTO
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }
        [Required, StringLength(11)]
        public string Contact { get; set; }
    }
}