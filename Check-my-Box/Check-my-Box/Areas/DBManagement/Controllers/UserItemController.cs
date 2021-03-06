using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Check_my_Box.Areas.DBManagement.Models;
using Check_my_Box.Areas.DBManagement.Catalog;

namespace Check_my_Box.Areas.DBManagement.Controllers
{   
    public class UserItemController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /UserItem/

        public ViewResult Index()
        {
            return View(context.UserItems.Include(useritem => useritem.ItemValue).ToList());
        }

        //
        // GET: /UserItem/Details/5

        public ViewResult Details(int id)
        {
			UserItem useritem = context.UserItems.Single(x => x.UserItemId == id);
            return View(useritem);
        }

        //
        // GET: /UserItem/Create

        public ActionResult Create()
        {
			ViewBag.PossibleItemValues = context.ItemValues;
            return View();
        } 

        //
        // POST: /UserItem/Create

        [HttpPost]
        public ActionResult Create(UserItem useritem)
        {
            if (ModelState.IsValid)
            {
				context.UserItems.Add(useritem);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

			ViewBag.PossibleItemValues = context.ItemValues;
            return View(useritem);
        }
        
        //
        // GET: /UserItem/Edit/5
 
        public ActionResult Edit(int id)
        {
			UserItem useritem = context.UserItems.Single(x => x.UserItemId == id);
			ViewBag.PossibleItemValues = context.ItemValues;
			return View(useritem);
        }

        //
        // POST: /UserItem/Edit/5

        [HttpPost]
        public ActionResult Edit(UserItem useritem)
        {
            if (ModelState.IsValid)
            {
				context.Entry(useritem).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.PossibleItemValues = context.ItemValues;
            return View(useritem);
        }

        //
        // GET: /UserItem/Delete/5
 
        public ActionResult Delete(int id)
        {
			UserItem useritem = context.UserItems.Single(x => x.UserItemId == id);
            return View(useritem);
        }

        //
        // POST: /UserItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserItem useritem = context.UserItems.Single(x => x.UserItemId == id);
            context.UserItems.Remove(useritem);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}