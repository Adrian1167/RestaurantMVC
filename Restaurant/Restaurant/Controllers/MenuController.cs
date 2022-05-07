using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Menu> objMenuList = _db.Menu;
            return View(objMenuList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu obj)
        {
            if (ModelState.IsValid)
            {
                _db.Menu.Add(obj);
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

            var menuFromDb = _db.Menu.Find(id);

            if (menuFromDb == null)
            {
                return NotFound();
            }

            return View(menuFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu obj)
        {
            if (ModelState.IsValid)
            {
                _db.Menu.Update(obj);
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

            var menuFromDb = _db.Menu.Find(id);

            if (menuFromDb == null)
            {
                return NotFound();
            }

            return View(menuFromDb);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? MenuId)
        {

            var obj = _db.Menu.Find(MenuId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Menu.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);
        }
    }
}