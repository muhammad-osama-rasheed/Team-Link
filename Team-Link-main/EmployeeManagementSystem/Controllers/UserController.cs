using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContexts db = new ApplicationDbContexts();

        // GET: User
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"] != null && Session["role"].ToString().ToLower() != "user" && Session["role"].ToString().ToLower() == "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var employee = db.Employees.FirstOrDefault(e => e.Id == userId);
                if (employee == null)
                {
                    TempData["LoginSuccess"] = "<script>alert('Employee not found.')</script>";
                    return RedirectToAction("Logout", "Home");
                }
                return View(employee);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var employee = db.Employees.Find(id);
            if (employee == null)
                return RedirectToAction("Index");
            return View(employee);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = db.Employees.Find(model.Id);
                if (employee == null)
                    return RedirectToAction("Index");

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Address = model.Address;
                employee.Gender = model.Gender;
                employee.Age = model.Age;

                // Only update password if provided and confirmed
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        employee.Password = model.Password;
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                        return View(model);
                    }
                }

                db.SaveChanges();
                TempData["UpdateEmpMessage"] = "<script>alert('Profile updated!')</script>";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}