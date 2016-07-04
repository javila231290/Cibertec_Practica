
using System.Web.Mvc;
using WebDeveloper.Model;
using WebDeveloper.DataAccess;
using System.Web;

namespace WebDeveloper.Controllers
{
    public class CategorieController : Controller
    {

        private CategorieData _categorie = new CategorieData();


        public FileContentResult GetImage(int id)
        {
            //var categorie = _categorie.GetCategorytById(id);
            //if (categorie != null) return File(categorie.Picture, categorie.PictureContentType);
            //else return null;
            return (_categorie.GetCategorytById(id) != null) ? File(_categorie.GetCategorytById(id).Picture, _categorie.GetCategorytById(id).PictureContentType) : null;
        }

        private bool SaveChanges(Categories categorie, HttpPostedFileBase image, int state)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    categorie.PictureContentType = image.ContentType;
                    categorie.PictureFileName = image.FileName;
                    categorie.Picture = new byte[image.ContentLength];
                    image.InputStream.Read(categorie.Picture, 0, image.ContentLength);
                }
                if (state == 0)
                    _categorie.Add(categorie);
                else
                    _categorie.Update(categorie);
                return true;
            }
            return false;
        }

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
        public ActionResult Create(Categories categorie, HttpPostedFileBase image)
        {
            if (SaveChanges(categorie, image, 0))
                return RedirectToAction("Index");
            else
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
        public ActionResult Edit(Categories categorie, HttpPostedFileBase image)
        {
            if (SaveChanges(categorie, image, 1))
                return RedirectToAction("Index");
            else
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


    }
}