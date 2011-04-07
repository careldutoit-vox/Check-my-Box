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
    public class UserController : Controller
    {
			private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(context.Users.Include(user => user.UserItemLists).ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
			User user = context.Users.Single(x => x.UserId == id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
				context.Users.Add(user);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
			User user = context.Users.Single(x => x.UserId == id);
			return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
				//context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
			User user = context.Users.Single(x => x.UserId == id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.Users.Single(x => x.UserId == id);
            context.Users.Remove(user);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}