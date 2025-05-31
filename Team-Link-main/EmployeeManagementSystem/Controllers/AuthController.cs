using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        ApplicationDbContexts db = new ApplicationDbContexts();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(User u)
        {

            var user = db.Users.FirstOrDefault(model => model.Email == u.Email && model.Password == u.Password);

            if (user != null)
            {
                Session["userId"] = user.Id.ToString();
                Session["email"] = user.Email;
                Session["name"] = user.LastName;
                Session["role"] = user.Role;

                TempData["LoginSuccess"] = "<script>alert('Login Successfully!')</script>";

                if (user.Role.ToLower() == "admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {

                var employee = db.Employees.FirstOrDefault(emp => emp.Email == u.Email && emp.Password == u.Password);

                if (employee != null)
                {
                    Session["userId"] = employee.Id.ToString();
                    Session["email"] = employee.Email;
                    Session["name"] = employee.Name;
                    Session["role"] = employee.Role;

                    TempData["LoginSuccess"] = "<script>alert('Login Successfully!')</script>";

                    if (employee.Role.ToLower() == "user")
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }


            ViewBag.ErrorMessage = "<script>alert('Email or Password is Incorrect.')</script>";
            return View();
        }





    

        public ActionResult Signup()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Signup(User u)
        {

            if (ModelState.IsValid == true)
            {
                u.Role = "admin";

                db.Users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Signup Successfully!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Failed to create account!')</script>";
                }
            }
            return View();
        }
    }
}