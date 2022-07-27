using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Entities;
using Application.DataAccess;

namespace MVC_Application.Controllers
{
    public class EmployeeController : Controller
    {
        IDataAccess<Employee, int> EmpDbAccess;
        public EmployeeController(IDataAccess<Employee, int> e)
        {
            EmpDbAccess = e;
        }

        public ActionResult Index()
        {
            var emps = EmpDbAccess.Get();
            return View(emps);
        }

        public ActionResult Create()
        {
            var emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            EmpDbAccess.Create(e);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var emp = EmpDbAccess.Get(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            EmpDbAccess.Update(id, emp);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var emp = EmpDbAccess.Get(id);
            return View(emp);
        }


        public ActionResult Delete(int id)
        {
            EmpDbAccess.Delete(id);
            return RedirectToAction("Index");
        }
    }
}