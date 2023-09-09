using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Models
{
    public class AssignFoodViewModel
    {
        public AssignRequest AssignRequest { get; set; }
        public SelectList Employees { get; set; }
    }
}