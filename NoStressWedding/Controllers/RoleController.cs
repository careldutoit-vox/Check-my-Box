
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class RoleController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /Roles/

        public ViewResult Index()
        {
            return View(context.Roles.ToList());
        }

        //
        // GET: /Roles/Details/5

        public ViewResult Details(int id)
        {
			Role p = context.Roles.Single(x => x.RoleId == id);
            return View(p);
        }

        //
        // GET: /Roles/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Roles/Create

        [HttpPost]
        public ActionResult Create(Role d)
        {
            if (ModelState.IsValid)
            {
              context.Roles.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /Roles/Edit/5
 
        public ActionResult Edit(int id)
        {
          Role p = context.Roles.Single(x => x.RoleId == id);
             return View(p);
        }

        //
        // POST: /Roles/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          Role p = context.Roles.Single(x => x.RoleId == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Delete/5
 
        public ActionResult Delete(int id)
        {
          Role p = context.Roles.Single(x => x.RoleId == id);
            return View(p);
        }

        //
        // POST: /Roles/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          Role p = context.Roles.Single(x => x.RoleId == id);
            context.Roles.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
