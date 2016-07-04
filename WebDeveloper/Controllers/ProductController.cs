using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Controllers
{
    public class ProductController : Controller
    {
        private ProductData _product = new ProductData();

        // GET: Product
        public ActionResult Index()
        {
            return View(_product.GetList());
        }

        public ActionResult Create()
        {
            //var categories = new CategorieData();
            //ViewBag.ProductCategories =  categories.GetList();
            return View(new Products());
        }
        [HttpPost]
        public ActionResult Create(Products product)
        {
            if (ModelState.IsValid)
            {
                _product.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id=0)
        {
            var product = _product.GetProductById(id);
            if (product == null)
                return RedirectToAction("Index");
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            if(ModelState.IsValid)
            {
                _product.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id=0)
        {
            var product = _product.GetProductById(id);
            if (product == null)
                return RedirectToAction("Index");
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _product.GetProductById(id);
            if (product == null)
                return View();
            if (_product.Delete(product)>0)
                return RedirectToAction("Index");
            return View();
        }
    }
}