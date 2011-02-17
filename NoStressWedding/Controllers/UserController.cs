
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class UserController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /Users/

        public ViewResult Index()
        {
            return View(context.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ViewResult Details(int id)
        {
			User p = context.Users.Single(x => x.ID == id);
            return View(p);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User d)
        {
            if (ModelState.IsValid)
            {
              context.Users.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
		     User p = context.Users.Single(x => x.ID == id);
             return View(p);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            User p = context.Users.Single(x => x.ID == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
			User p = context.Users.Single(x => x.ID == id);
            return View(p);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            User p = context.Users.Single(x => x.ID == id);
            context.Users.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
