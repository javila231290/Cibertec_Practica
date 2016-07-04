
using System.Web.Mvc;
using WebDeveloper.Model;
using WebDeveloper.DataAccess;

namespace WebDeveloper.Controllers
{
    public class CategorieController : Controller
    {

        private CategorieData _categorie = new CategorieData();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(_categorie.GetList());
        }
        
        public ActionResult Create()
        {
            return View(new Categories());
        }
        [HttpPost]
        public ActionResult Create(Categories categorie)
        {
            if (ModelState.IsValid)
            {
                _categorie.Add(categorie);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id=0)
        {
            var categorie = _categorie.GetCategorytById(id);
            if (categorie == null)
                return RedirectToAction("Index");
            return View(categorie);
        }
        [HttpPost]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _categorie.Update(categories);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id=0)
        {
            var categorie = _categorie.GetCategorytById(id);
            if (categorie == null)
                return RedirectToAction("Index");
            return View(categorie);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var categorie = _categorie.GetCategorytById(id);
            if (categorie == null)
                return View();
            if (_categorie.Delete(categorie) > 0)
                return RedirectToAction("Index");
            return View();
        }

        //public FileContentResult GetImage(int id)
        //{
        //    var categorie = _categorie.GetCategorytById(id);
        //    if (categorie != null) return File(categorie.Picture, categorie.PictureMimeType);
        //    else return null;
        //}
    }
}