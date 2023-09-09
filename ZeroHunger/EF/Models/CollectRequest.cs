using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class CollectRequest
    {
        [Required,Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime AssigneDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int EmployeeId { get; set; }

        [Required, ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restuarant1 Restaurant { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }

        public CollectRequest()
        {
            FoodItems = new List<FoodItem>();
        }
        


    }
}