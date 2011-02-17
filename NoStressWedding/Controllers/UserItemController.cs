
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class UserItemController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /UserItems/

        public ViewResult Index()
        {
            return View(context.UserItems.ToList());
        }

        //
        // GET: /UserItems/Details/5

        public ViewResult Details(int id)
        {
			UserItem p = context.UserItems.Single(x => x.UserItemID == id);
            return View(p);
        }

        //
        // GET: /UserItems/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserItems/Create

        [HttpPost]
        public ActionResult Create(UserItem d)
        {
            if (ModelState.IsValid)
            {
              context.UserItems.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /UserItems/Edit/5
 
        public ActionResult Edit(int id)
        {
          UserItem p = context.UserItems.Single(x => x.UserItemID == id);
             return View(p);
        }

        //
        // POST: /UserItems/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          UserItem p = context.UserItems.Single(x => x.UserItemID == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /UserItems/Delete/5
 
        public ActionResult Delete(int id)
        {
          UserItem p = context.UserItems.Single(x => x.UserItemID == id);
            return View(p);
        }

        //
        // POST: /UserItems/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          UserItem p = context.UserItems.Single(x => x.UserItemID == id);
            context.UserItems.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
