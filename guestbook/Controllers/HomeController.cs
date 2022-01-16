using guestbook.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace guestbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly guestbookContext db;
        public HomeController(guestbookContext db)
        {
            this.db=db;
        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(User s)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(s);
                db.SaveChanges();
                return RedirectToAction("login");
            }
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(User user)
        {
            var u = db.Users.Where(a=>a.email== user.email && a.password==user.password).FirstOrDefault();
            if (u != null)
            {
                HttpContext.Session.SetInt32("Id", u.id);
                return RedirectToAction("Index", "Users");
            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction("login");
        }
    }
}