using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHunger.EF.Models;

namespace ZeroHunger.EF
{
    public class ZHContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restuarant1> Restuarants { get; set; }

        public DbSet<CollectRequest> CollectRequests { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<AssignRequest> AssignRequests { get; set; }

    }
}