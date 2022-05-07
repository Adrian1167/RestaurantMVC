using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> objCustomerList = _db.Customers;
            return View(objCustomerList);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(obj);
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

            var customerFromDb = _db.Customers.Find(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }

            return View(customerFromDb);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
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

            var customerFromDb = _db.Customers.Find(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }

            return View(customerFromDb);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? CustomerId)
        {

            var obj = _db.Customers.Find(CustomerId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(obj);
        }
    }
}



