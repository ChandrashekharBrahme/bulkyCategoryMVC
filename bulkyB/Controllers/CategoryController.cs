using bulkyB.Data;
using bulkyB.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkyB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoriesList = _db.Categories.ToList();
            return View(objCategoriesList);
        }
        //GEt
        public IActionResult Create()
        {

            return View();
        }

        // POSt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder and name can't be exactly same ");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category Created sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GEt
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }

        // POSt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder and name can't be exactly same ");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category Updated sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }

        // POSt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id); 
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["sucess"] = "Category Deleted sucessfully";
            return RedirectToAction("Index");
          
            
        }
    }
}
