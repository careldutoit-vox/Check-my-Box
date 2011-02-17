
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class ItemController : Controller
    {
        private MainCatalog context = new MainCatalog();
        UserItemList itemList = new UserItemList();
  
        //
        // GET: /Items/

        public ViewResult Index()
        {


            return View(context.Items.ToList());
        }

        //
        // GET: /Items/Details/5

        public ViewResult Details(int id)
        {
          Item p = context.Items.Single(x => x.Id == id);
            return View(p);
        }

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Items/Create

        [HttpPost]
        public ActionResult Create(Item d)
        {
            if (ModelState.IsValid)
            {
              context.Items.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /Items/Edit/5
 
        public ActionResult Edit(int id)
        {
          Item p = context.Items.Single(x => x.Id == id);
             return View(p);
        }

        //
        // POST: /Items/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          Item p = context.Items.Single(x => x.Id == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Items/Delete/5
 
        public ActionResult Delete(int id)
        {
          Item p = context.Items.Single(x => x.Id == id);
            return View(p);
        }

        //
        // POST: /Items/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          Item p = context.Items.Single(x => x.Id == id);
            context.Items.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
