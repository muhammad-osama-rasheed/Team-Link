using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EmployeeManagementSystem.Controllers
{
    public class ApplicationController : Controller
    {

        ApplicationDbContexts db = new ApplicationDbContexts();
        // GET: Application
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
                var data = db.EmployeeApplications.ToList();
                return View(data);
            }
        }


        public ActionResult AddApplication()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddApplication(EmployeeApplication app)
        {
            if (ModelState.IsValid == true)
            {
                app.Name = Session["name"]?.ToString();
                app.Email = Session["email"]?.ToString();
                app.EmployeeId = Session["userId"]?.ToString();
                app.Status = "Pending";

                db.EmployeeApplications.Add(app);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["AddappMessage"] = "<script>alert('Application Sent.')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["AddappMessage"] = "<script>alert('Failed to sent application. Please try again later!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {

            var row = db.EmployeeApplications.Where(model => model.Id == id).FirstOrDefault();

            if (row == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(row);
        }


        [HttpPost]
        public ActionResult Delete(EmployeeApplication app)
        {

            db.Entry(app).State = EntityState.Deleted;
            int a = db.SaveChanges();

            if (a > 0)
            {
                TempData["DeleteEmpApplication"] = "<script>alert('Application Deleted.')</script>";

            }
            else
            {
                TempData["DeleteEmpApplication"] = "<script>alert('Failed to delete application.')</script>";
            }

            return RedirectToAction("Index", "Application");
        }


        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var row = db.EmployeeApplications.Where(model => model.Id == id).FirstOrDefault();

            if (row == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(row);
        }


        public ActionResult Edit(int id)
        {

            var row = db.EmployeeApplications.Where(model => model.Id == id).FirstOrDefault();

            if (row == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeApplication app)
        {
            if (ModelState.IsValid)
            {
                db.Entry(app).State = EntityState.Modified;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["UpdateEmpApplication"] = "<script>alert('Application Modified.')</script>";
                }
                else
                {
                    TempData["UpdateEmpApplication"] = "<script>alert('Failed to modify application.')</script>";
                }

                return RedirectToAction("Index");
            }

            return View(app);
        }










    }
}