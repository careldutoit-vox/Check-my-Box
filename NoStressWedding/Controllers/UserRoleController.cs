
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class UserRoleController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /UserRoles/

        public ViewResult Index()
        {
            return View(context.UserRoles.ToList());
        }

        //
        // GET: /UserRoles/Details/5

        public ViewResult Details(int id)
        {
			UserRole p = context.UserRoles.Single(x => x.UserRoleID == id);
            return View(p);
        }

        //
        // GET: /UserRoles/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserRoles/Create

        [HttpPost]
        public ActionResult Create(UserRole d)
        {
            if (ModelState.IsValid)
            {
              context.UserRoles.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /UserRoles/Edit/5
 
        public ActionResult Edit(int id)
        {
          UserRole p = context.UserRoles.Single(x => x.UserRoleID == id);
             return View(p);
        }

        //
        // POST: /UserRoles/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          UserRole p = context.UserRoles.Single(x => x.UserRoleID == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /UserRoles/Delete/5
 
        public ActionResult Delete(int id)
        {
          UserRole p = context.UserRoles.Single(x => x.UserRoleID == id);
            return View(p);
        }

        //
        // POST: /UserRoles/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          UserRole p = context.UserRoles.Single(x => x.UserRoleID == id);
            context.UserRoles.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
