
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class UserItemListController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /UserItemLists/

        public ViewResult Index()
        {
            return View(context.UserItemLists.ToList());
        }

        //
        // GET: /UserItemLists/Details/5

        public ViewResult Details(int id)
        {
			UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            return View(p);
        }

        //
        // GET: /UserItemLists/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserItemLists/Create

        [HttpPost]
        public ActionResult Create(UserItemList d)
        {
            if (ModelState.IsValid)
            {
              context.UserItemLists.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /UserItemLists/Edit/5
 
        public ActionResult Edit(int id)
        {
          UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
             return View(p);
        }

        //
        // POST: /UserItemLists/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /UserItemLists/Delete/5
 
        public ActionResult Delete(int id)
        {
          UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            return View(p);
        }

        //
        // POST: /UserItemLists/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            context.UserItemLists.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // POST: /UserItemLists/Delete/5

        [HttpPost]
        public ActionResult Test(int id, FormCollection collection)
        {
            UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            context.UserItemLists.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public ActionResult Test(int id)
        {
          // UserItemList p = context.UserItemLists.Single(x => x.UserItemListId == id);
            return View();
        }

    }
}
