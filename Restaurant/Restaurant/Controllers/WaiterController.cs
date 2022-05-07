using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class WaiterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WaiterController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Waiter> objWaiterList = _db.Waiters;
            return View(objWaiterList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Waiter obj)
        {
            if (ModelState.IsValid)
            {
                _db.Waiters.Add(obj);
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

            var waiterFromDb = _db.Waiters.Find(id);

            if (waiterFromDb == null)
            {
                return NotFound();
            }

            return View(waiterFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Waiter obj)
        {
            if (ModelState.IsValid)
            {
                _db.Waiters.Update(obj);
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

            var waiterFromDb = _db.Waiters.Find(id);

            if (waiterFromDb == null)
            {
                return NotFound();
            }

            return View(waiterFromDb);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? WaiterId)
        {

            var obj = _db.Waiters.Find(WaiterId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Waiters.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            //return View(obj);
        }
    }
}