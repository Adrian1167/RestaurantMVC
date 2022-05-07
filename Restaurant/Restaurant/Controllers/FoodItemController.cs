using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FoodItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<FoodItem> objFoodItemList = _db.FoodItems;
            return View(objFoodItemList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FoodItem obj)
        {
            if (ModelState.IsValid)
            {
                _db.FoodItems.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var fooditemFromDb = _db.FoodItems.Find(id);

            if (fooditemFromDb == null)
            {
                return NotFound();
            }

            return View(fooditemFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItem obj)
        {
            if (ModelState.IsValid)
            {
                _db.FoodItems.Update(obj);
                _db.SaveChanges();
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

            var fooditemFromDb = _db.FoodItems.Find(id);

            if (fooditemFromDb == null)
            {
                return NotFound();
            }

            return View(fooditemFromDb);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? FoodItemId)
        {

            var obj = _db.FoodItems.Find(FoodItemId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.FoodItems.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);
        }
    }
}