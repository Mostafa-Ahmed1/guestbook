using guestbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace guestbook.Controllers
{
    public class UsersController : Controller
    {
        private readonly guestbookContext db;

        public UsersController(guestbookContext db)
        {
            this.db=db;
        }

        public ActionResult Index()
        {
            var msgs = db.messages.Include(a=>a.User).ToList();
            return View(msgs);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(message m)
        {
            try
            {
                var i = HttpContext.Session.GetInt32("Id");
                m.userId=(int)i;
                m.time=DateTime.Now;
                db.messages.Add(m);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
           var mess= db.messages.Where(a => a.id==id).Select(x => x).FirstOrDefault();
            return View(mess);
        }

        [HttpPost]
        public ActionResult Edit(int id, message m)
        {
            try
            {
                var mess = db.messages.Where(a => a.id==id).FirstOrDefault();
                mess.time=DateTime.Now;
                mess.msg = m.msg;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            { 
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var msg = db.messages.Where(a => a.id ==id).FirstOrDefault();
                db.Remove(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //----------------------------------------------------------------
        public IActionResult List(int id)
        {
            HttpContext.Session.SetInt32("ChtId", id);
            ViewBag.x = db.messages.Where(a => a.chatId==id).Include(a => a.User).ToList();
            return View(ViewBag.x);
        }

        public IActionResult Reply()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Reply(message m)
        {
                var i = HttpContext.Session.GetInt32("Id");
                ViewData["C"] = HttpContext.Session.GetInt32("ChtId");
                m.userId=(int)i;
                m.chatId=(int)ViewData["C"];
                m.time=DateTime.Now;
                db.messages.Add(m);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("List", (int)ViewData["C"]);
        }

    }
}
