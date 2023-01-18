using MVC_DEMO_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DEMO_1.Controllers
{
    public class NewEmployeeController : Controller
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
        // GET: NewEmployee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id,string name)
        {
            emps.Add(new Employee { ID = id, Name = name });
            return RedirectToAction("GetAll");
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            var emp = emps.FirstOrDefault(e => e.ID == id);
            emps.Remove(emp);
            return RedirectToAction("GetAll");
        }
        public ActionResult Edit(int id)
        {
            var emp = emps.FirstOrDefault(e => e.ID == id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(string name,int id)
        {
            var emp = emps.FirstOrDefault(e => e.ID == id);
            emp.Name = name;
            return RedirectToAction("GetAll");
        }
        public ActionResult Details(int id)
        {
            var emp = emps.FirstOrDefault(e => e.ID == id);
            return View(emp);
        }
        public ActionResult GetAll()
        {
            return View(emps); ;
        }
    }
}