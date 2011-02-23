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
    public class UserRoleController : Controller
    {
			private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /UserRole/

        public ViewResult Index()
        {
            return View(context.UserRoles.ToList());
        }

        //
        // GET: /UserRole/Details/5

        public ViewResult Details(int id)
        {
			UserRole userrole = context.UserRoles.Single(x => x.UserRoleId == id);
            return View(userrole);
        }

        //
        // GET: /UserRole/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserRole/Create

        [HttpPost]
        public ActionResult Create(UserRole userrole)
        {
            if (ModelState.IsValid)
            {
				context.UserRoles.Add(userrole);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(userrole);
        }
        
        //
        // GET: /UserRole/Edit/5
 
        public ActionResult Edit(int id)
        {
			UserRole userrole = context.UserRoles.Single(x => x.UserRoleId == id);
			return View(userrole);
        }

        //
        // POST: /UserRole/Edit/5

        [HttpPost]
        public ActionResult Edit(UserRole userrole)
        {
            if (ModelState.IsValid)
            {
				//context.Entry(userrole).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userrole);
        }

        //
        // GET: /UserRole/Delete/5
 
        public ActionResult Delete(int id)
        {
			UserRole userrole = context.UserRoles.Single(x => x.UserRoleId == id);
            return View(userrole);
        }

        //
        // POST: /UserRole/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userrole = context.UserRoles.Single(x => x.UserRoleId == id);
            context.UserRoles.Remove(userrole);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}