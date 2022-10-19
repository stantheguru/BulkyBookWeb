using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Areas.Identity.Data;


namespace BulkyBookWeb.Controllers
{
	public class UserController : Controller


	{

        public readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Registration was successful";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
    }
}
