using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ZHContext db = new ZHContext();
                    collectRequest.AssigneDate = DateTime.Now;
                    collectRequest.RestaurantId =  (int)Session["Id"];

                    db.CollectRequests.Add(collectRequest);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (SqlException ex)
                {
                    // Handle foreign key constraint violation
                    if (ex.Number == 547)
                    {
                        ModelState.AddModelError("", "Invalid Restaurant ID. Please select a valid Restaurant ID.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while processing the request.");
                    }
                }
            }

            return View(collectRequest);
        }


    }
}