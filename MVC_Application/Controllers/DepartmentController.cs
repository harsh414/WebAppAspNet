using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Entities;
using Application.DataAccess;

namespace MVC_Application.Controllers
{
    public class DepartmentController : Controller
    {
        IDataAccess<Department, int> deptDbAccess;
        public DepartmentController(IDataAccess<Department, int> d)
        {
            deptDbAccess = d;
        }

        public ActionResult Index()
        {
            var department = deptDbAccess.Get();

            return View(department);
        }

        public ActionResult Create()
        {
            var dept= new Department();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(Department d)
        {
            deptDbAccess.Create(d);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dept = deptDbAccess.Get(id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, Department dept)
        {
            deptDbAccess.Update(id, dept);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var dept = deptDbAccess.Get(id);
            return View(dept);
        }


        public ActionResult Delete(int id)
        {
            deptDbAccess.Delete(id);
            return RedirectToAction("Index");
        }

    }
}