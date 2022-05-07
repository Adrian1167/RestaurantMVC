using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Reservation> objReservationList = _db.Reservations;
            return View(objReservationList);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Reservations.Add(obj);
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

            var reservationFromDb = _db.Reservations.Find(id);

            if (reservationFromDb == null)
            {
                return NotFound();
            }

            return View(reservationFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation obj)
        {
            if (ModelState.IsValid)
            {
                _db.Reservations.Update(obj);
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

            var reservationFromDb = _db.Reservations.Find(id);

            if (reservationFromDb == null)
            {
                return NotFound();
            }

            return View(reservationFromDb);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? ReservationId)
        {

            var obj = _db.Reservations.Find(ReservationId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Reservations.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);
        }
    }
}