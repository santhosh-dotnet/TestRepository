using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDonMVC.Models;

namespace CRUDonMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult LoginCheck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                LoginRepository lr = new LoginRepository();
                if (lr.CheckUser(lm.Username, lm.Password))
                {
                    return RedirectToAction("GetAllEmpDetails");
                }
                else
                    ViewBag.message = "User credentials Mismatch";
                return View();
            }
            else
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel lm)
        {
            if (ModelState.IsValid)
            {
                LoginRepository lr = new LoginRepository();
                lr.RegisterUser(lm);
                ViewBag.message = " Registration Successfully Completed ";
                return View();
            }
            else
            return View();
        }
        public ActionResult InsertEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertEmp(EmpModel em)
        {
            if (ModelState.IsValid)
            {
                LoginRepository lr = new LoginRepository();
                lr.InsertEmployee(em);
                return View("GetAllEmpDetails");
            }
            return View();
        }
        public ActionResult GetAllEmpDetails(EmpModel em)
        {
            LoginRepository lr = new LoginRepository();
            return View (lr.DisplayEmployee());
        }
        public ActionResult UpdateEmp( int id)
        {
            LoginRepository lr = new LoginRepository();
            return View(lr.DisplayEmployee().Find(obj=>obj.Eid==id));
        }
        [HttpPost]
        public ActionResult UpdateEmp(EmpModel em)
        {
            if (ModelState.IsValid)
            {
                LoginRepository lr = new LoginRepository();
                lr.UpdateEmployee(em);
                return View("GetAllEmpDetails");
            }
            return View();
        }
        public ActionResult DeleteEmp(int id)
        {
            if (ModelState.IsValid)
            {
                LoginRepository lr = new LoginRepository();
                lr.DeleteEmployee(id);
                return View("GetallEmpDetails");
            }
            return View();
        }
    }
}