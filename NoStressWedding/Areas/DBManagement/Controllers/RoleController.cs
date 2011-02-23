using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Areas.DBManagement.Catalog;
using NoStressWedding.Areas.DBManagement.Models;

namespace NoStressWedding.Areas.DBManagement.Controllers
{   
    public class RoleController : Controller
    {
			private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /Role/

        public ViewResult Index()
        {
            return View(context.Roles.ToList());
        }

        //
        // GET: /Role/Details/5

        public ViewResult Details(int id)
        {
			Role role = context.Roles.Single(x => x.RoleId == id);
            return View(role);
        }

        //
        // GET: /Role/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
				context.Roles.Add(role);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(role);
        }
        
        //
        // GET: /Role/Edit/5
 
        public ActionResult Edit(int id)
        {
			Role role = context.Roles.Single(x => x.RoleId == id);
			return View(role);
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
				//context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        //
        // GET: /Role/Delete/5
 
        public ActionResult Delete(int id)
        {
			Role role = context.Roles.Single(x => x.RoleId == id);
            return View(role);
        }

        //
        // POST: /Role/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = context.Roles.Single(x => x.RoleId == id);
            context.Roles.Remove(role);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}