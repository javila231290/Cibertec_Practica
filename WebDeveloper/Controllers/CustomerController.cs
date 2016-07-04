using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerData _customer = new CustomerData();

        // GET: Customer
        public ActionResult Index()
        {
            return View(_customer.GetList());
        }

        public ActionResult Create()
        {
            return View(new Customers());
        }
        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id = 0)
        {
            var customer = _customer.GetCustomerById(id);
            if (customer == null)
                return RedirectToAction("Index");
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Update(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id = 0)
        {
            var customer = _customer.GetCustomerById(id);
            if (customer == null)
                return RedirectToAction("Index");
            return View(customer);
        }
        [HttpPost]
        public ActionResult Delete(int id=0)
        {
            var customer = _customer.GetCustomerById(id);
            if (customer == null)
                return View();
            if (_customer.Delete(customer)>0)
                return RedirectToAction("Index");
            return View();
        }
    }
}