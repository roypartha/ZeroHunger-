using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();

                if (login.Id <= 1000)
                {
                    // Restaurant
                    var user = (from u in db.Restuarants
                                where u.Id == login.Id &&
                                      u.Password == login.Password
                                select u).SingleOrDefault();

                    if (user != null)
                    {
                       
                        Session["Id"] = user.Id;
                        return RedirectToAction("Index", "Restaurant");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid ID or Password");
                    }
                }
                else
                {
                    // Employee or Admin
                    var user = (from u in db.Employees
                                where u.Id == login.Id &&
                                      u.Password == login.Password
                                select u).SingleOrDefault();

                    if (user != null)
                    {
                        if (user.Type == 1)
                        {
                            Session["Id"] = user.Id;
                            Session["Type"] = user.Type;
                            return RedirectToAction("Index", "Admin");

                           

                        }
                        else if (user.Type == 2)
                        {

                            Session["Id"] = user.Id;
                            Session["Type"] = user.Type;
                            return RedirectToAction("Index", "Employee");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid ID or Password");
                    }
                }
            }

            return View(login);
        }

        public ActionResult Logout()
        {
          

           
            Session.Clear();

         
            return RedirectToAction("Login", "Home"); 
        }



        [HttpGet]
        public ActionResult CreateRestaurant()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateRestaurant(Restuarant1 res)
        {
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();

                // Convert the EmployeeDTO to Employee
               // var rest = Convert(res);

                // Add the employee to the DbSet
                db.Restuarants.Add(res);

                // Save the changes to the database
                db.SaveChanges();
                return RedirectToAction("CreateRestaurant");

            }

            return View(res);
        }
       /* RestuarantDTO Convert(Restuarant1 restuarant)
        {
            var re = new RestuarantDTO();
            re.Name = restuarant.Name;
            re.Email = restuarant.Email;
            re.Contact = restuarant.Contact;
            re.Address = restuarant.Address;
            re.Password = restuarant.Password;
        
            return re;
        }

        Restuarant1 Convert(RestuarantDTO restuarant)
        {
            var re = new Restuarant1();
            re.Name = restuarant.Name;
            re.Email = restuarant.Email;
            re.Contact = restuarant.Contact;
            re.Address = restuarant.Address;
            re.Password = restuarant.Password;

            return re;
        }

        List<RestuarantDTO> Convert(List<Restuarant1> us)
        {
            var restuarants = new List<RestuarantDTO>();
            foreach (var item in us)
            {
                restuarants.Add(Convert(item));
            }
            return restuarants;
        }*/
    }
}