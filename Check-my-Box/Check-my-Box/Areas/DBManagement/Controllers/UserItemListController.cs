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
    public class UserItemListController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /UserItemList/

        public ViewResult Index() {

            return View(context.UserItemLists.Include(useritemlist => useritemlist.UserItems).ToList());
        }


				public ViewResult Test(int id) {
					UserItemList useritemlist = context.UserItemLists.Single(x => x.UserItemListId == id);
					return View(useritemlist);
				}

				//
				// POST: /UserItemList/Test/5

				[HttpPost]
				public ActionResult Test(UserItemList useritemlist,
					[Bind(Prefix = "UserItemList.UserItems")] UserItem[] userItems)
 {
					if (ModelState.IsValid) {
						context.Entry(useritemlist).State = EntityState.Modified;
						context.SaveChanges();
						return RedirectToAction("Index");
					}
					ViewBag.PossibleUsers = context.Users;
					return View(useritemlist);
				}

        //
        // GET: /UserItemList/Details/5

        public ViewResult Details(int id)
        {
			UserItemList useritemlist = context.UserItemLists.Single(x => x.UserItemListId == id);
            return View(useritemlist);
        }

        //
        // GET: /UserItemList/Create

        public ActionResult Create()
        {
			ViewBag.PossibleUsers = context.Users;
            return View();
        } 

        //
        // POST: /UserItemList/Create

        [HttpPost]
        public ActionResult Create(UserItemList useritemlist)
        {
            if (ModelState.IsValid)
            {
				context.UserItemLists.Add(useritemlist);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

			ViewBag.PossibleUsers = context.Users;
            return View(useritemlist);
        }
        
        //
        // GET: /UserItemList/Edit/5
 
        public ActionResult Edit(int id)
        {
			UserItemList useritemlist = context.UserItemLists.Single(x => x.UserItemListId == id);
			ViewBag.PossibleUsers = context.Users;
			return View(useritemlist);
        }

        //
        // POST: /UserItemList/Edit/5

        [HttpPost]
        public ActionResult Edit(UserItemList useritemlist)
        {
            if (ModelState.IsValid)
            {
				context.Entry(useritemlist).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.PossibleUsers = context.Users;
            return View(useritemlist);
        }

        //
        // GET: /UserItemList/Delete/5
 
        public ActionResult Delete(int id)
        {
			UserItemList useritemlist = context.UserItemLists.Single(x => x.UserItemListId == id);
            return View(useritemlist);
        }

        //
        // POST: /UserItemList/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserItemList useritemlist = context.UserItemLists.Single(x => x.UserItemListId == id);
            context.UserItemLists.Remove(useritemlist);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}