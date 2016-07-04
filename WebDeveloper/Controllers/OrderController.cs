using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class OrderController : Controller
    {
        private OrderData _order = new OrderData();

        // GET: Order
        public ActionResult Index()
        {
            return View(_order.GetList());
        }

        public ActionResult Create()
        {
            return View(new Orders());
        }
        [HttpPost]
        public ActionResult Create(Orders order)
        {
            if (ModelState.IsValid)
            {
                _order.Add(order);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id = 0)
        {
            var order = _order.GetOrderById(id);
            if (order == null)
                return RedirectToAction("ndex");
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Orders order)
        {
            if (ModelState.IsValid)
            {
                _order.Update(order);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id = 0)
        {
            var order = _order.GetOrderById(id);
            if (order == null)
                return RedirectToAction("Index");
            return View(order);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var order = _order.GetOrderById(id);
            if (order == null)
                return View();
            if (_order.Delete(order) > 0)
                return RedirectToAction("Index");
            return View();
        }
    }
}