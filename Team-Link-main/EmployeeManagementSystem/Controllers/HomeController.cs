using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContexts db = new ApplicationDbContexts();


        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"] != null && Session["role"].ToString().ToLower() == "user")
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                var data = db.Employees.ToList();
                return View(data);
            }
        }


        public ActionResult AddEmployee()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"] != null && Session["role"].ToString().ToLower() == "user")
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            if (ModelState.IsValid == true)
            {

                e.IsActive = true;
                e.CreatedAt = DateTime.Now;
                e.Role = "user";


                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.AddEmployeeMessage = "<script>alert('Employee created successfully.')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.AddEmployeeMessage = "<script>alert('Failed to create employee. Please try again later!')</script>";
                }
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var EmployeeIdRow = db.Employees.Where(model => model.Id == id).FirstOrDefault();

            if (EmployeeIdRow == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(EmployeeIdRow);
        }


        [HttpPost]
        public ActionResult Delete(Employee e)
        {

            db.Entry(e).State = EntityState.Deleted;
            int a = db.SaveChanges();

            if (a > 0)
            {
                TempData["DeleteEmpMessage"] = "<script>alert('Employee Deleted.')</script>";

            }
            else
            {
                TempData["DeleteEmpMessage"] = "<script>alert('Failed to delete employee.')</script>";
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var EmployeeIdRow = db.Employees.Where(model => model.Id == id).FirstOrDefault();

            if (EmployeeIdRow == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(EmployeeIdRow);
        }

        // --- EDIT EMPLOYEE SECTION STARTS HERE ---

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var employee = db.Employees.Where(model => model.Id == id).FirstOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(employee);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                TempData["EditEmpMessage"] = "<script>alert('Employee details updated successfully.')</script>";
                return RedirectToAction("Index");
            }
            return View(e);
        }
        // --- EDIT EMPLOYEE SECTION ENDS HERE ---

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Auth");
        }
    }
}