using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeData _employee = new EmployeeData();

        // GET: Employee
        public ActionResult Index()
        {
            return View(_employee.GetList());
        }

        public ActionResult Create()
        {
            return View(new Employees());
        }
        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Add(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id=0)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
                return RedirectToAction("Index");
            return View(employee);

        }
        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id = 0)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
                return RedirectToAction("Index");
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
                return View();
            if (_employee.Delete(employee) > 0)
                return RedirectToAction("Index");
            return View();
        }
    }
}