using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CollectRequest()
        {
            ZHContext db = new ZHContext();

            int sessionId = (int)Session["Id"];

            var collectRequests = db.CollectRequests
                .Where(cr => cr.EmployeeId == sessionId && cr.Status == "processing")
                .ToList();

            var restaurantIds = collectRequests.Select(cr => cr.RestaurantId).ToList();
            var restaurants = db.Restuarants
                .Where(r => restaurantIds.Contains(r.Id))
                .ToList();

            ViewBag.CollectRequests = collectRequests;
            ViewBag.Restaurants = restaurants;

            return View();
        }
        public ActionResult AddFood(int id)
        {
            ZHContext db = new ZHContext();
            var collectRequest = db.CollectRequests.FirstOrDefault(cr => cr.Id == id);

            if (collectRequest == null)
            {
                // Handle the case when the collect request is not found
                return HttpNotFound();
            }
            var foodItem = new FoodItem
            {
                CollectRequestId = collectRequest.Id,

                Name = collectRequest.Name,
                Quantity = collectRequest.Quantity

            };

            db.FoodItems.Add(foodItem);

            collectRequest.Status = "complete"; // Update the status

            db.SaveChanges();
            return RedirectToAction("AssignRequest", "Employee");

        }
    }
}