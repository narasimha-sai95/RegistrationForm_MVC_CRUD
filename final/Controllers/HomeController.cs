using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final.Models;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Details e)
        {
            if (ModelState.IsValid)
            {
                RegistrationEntities1 db=new RegistrationEntities1();
                db.Details.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }
    }
}