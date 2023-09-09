using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeDTO emp)
        {
            if (ModelState.IsValid)
            {
                ZHContext db= new ZHContext();
               
                // Convert the EmployeeDTO to Employee
                var employee = Convert(emp);

                // Add the employee to the DbSet
                db.Employees.Add(employee);

                // Save the changes to the database
                db.SaveChanges();
                return RedirectToAction("CreateEmployee");

            }
            return View(emp);
        }

        public ActionResult CollectRequest()
        {
            ZHContext db = new ZHContext();

            // Retrieve CollectRequest data from the database
            List<CollectRequest> collectRequests = db.CollectRequests
                .Where(cr => cr.Status == "open")
                .ToList();

            return View(collectRequests);
        }
        [HttpGet]
        public ActionResult AssignRequest(int id)
        {
            ZHContext db = new ZHContext();
            // get the list of Employee id and show it in form to select 
            var employeeIds = db.Employees.Select(e => e.Id).ToList();

            ViewBag.EmployeeIds = new SelectList(employeeIds);

            return View();
        }
        [HttpPost]
        public ActionResult AssignRequest(int id, int employeeId)
        {
            ZHContext db = new ZHContext();
            var collectRequest = db.CollectRequests.Find(id);
            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            // Update the EmployeeId property with the selected employeeId
            collectRequest.EmployeeId = employeeId;
            collectRequest.Status = "processing";
            db.SaveChanges();

            // Redirect to some other action or view after assigning the request
            return RedirectToAction("CollectRequest", "Admin");
        }

        public ActionResult FoodItems()
        {

            ZHContext db = new ZHContext();
            var foodItems = db.FoodItems.ToList();
            return View(foodItems);

        }

        public ActionResult AssignForm(int id)
        {
            ZHContext db = new ZHContext();

            // Get the FoodItem by its Id
            var foodItem = db.FoodItems.Find(id);

            if (foodItem == null)
            {
                // Handle the case when the FoodItem is not found
                return HttpNotFound();
            }

            var assignRequest = new AssignRequest
            {
                Id = foodItem.Id,
                Name = foodItem.Name,
                Quantity = foodItem.Quantity,
                Address = "",
                EmployeeId = 0, // Set default EmployeeId to 0, or any other default value
                Status = "" // Set default Status to an appropriate value
            };



            // Get the list of Employees to populate the dropdown list
            var employees = db.Employees.ToList();

            var viewModel = new AssignFoodViewModel
            {
                AssignRequest = assignRequest,
                Employees = new SelectList(employees, "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignForm(AssignRequest assign)
        {
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();

                assign.Status = "processing"; // You can set the Status as required
              

                db.AssignRequests.Add(assign);

                db.SaveChanges();

            
                return RedirectToAction("Index", "Admin");
            }

            return View("Index");
        }


        EmployeeDTO Convert(Employee employee)
        {
            var em = new EmployeeDTO();
            em.Name = employee.Name;
            em.Email = employee.Email;
            em.Mobile = employee.Mobile;
            em.Dob = employee.Dob;
            em.Password = employee.Password;
            em.Type = employee.Type;

            return em;
        }

        Employee Convert(EmployeeDTO employee)
        {
            var em = new Employee();
            em.Name = employee.Name;
            em.Email = employee.Email;
            em.Mobile = employee.Mobile;
            em.Dob = employee.Dob;
            em.Password = employee.Password;
            em.Type = employee.Type;

            return em;
        }

        List<EmployeeDTO> Convert(List<Employee> us)
        {
            var employees = new List<EmployeeDTO>();
            foreach (var item in us)
            {
                employees.Add(Convert(item));
            }
            return employees;
        }

    }
}