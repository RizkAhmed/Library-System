using MVC_DEMO_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DEMO_1.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> emps = new List<Employee>() 
        {
            new Employee{ ID=1,Name="rizk"},
            new Employee{ ID=2,Name="ahmed"},
            new Employee{ ID=3,Name="mohamed"},
            new Employee{ ID=4,Name="hany"},
            new Employee{ ID=5,Name="ramy"},
            new Employee{ ID=6,Name="hasssan"},
        };

        public ActionResult Delete(int id)
        {
            var emp = (Employee)emps.FirstOrDefault(e => e.ID == id);
            emps.Remove(emp);
            return RedirectToAction("GettAll");
        }
        public ActionResult Creation(int id,string name)
        {
            emps.Add(new Employee{ ID = id, Name = name });
            return RedirectToAction("GettAll");
        }
        public ActionResult Create()
        {
            return View();

        }
        public ActionResult EditSave(string name ,int id)
        {
            var emp = (Employee)emps.FirstOrDefault(e=>e.ID==id);
            emp.Name = name;
            return RedirectToAction("GettAll");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.emp = emps.FirstOrDefault(e => e.ID == id);
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.emp = emps.FirstOrDefault(e=>e.ID==id);
            return View();
        }
        public ActionResult GettAll()
        {
            ViewBag.emplist = emps;
            return View();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}