
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoStressWedding.Models;
using NoStressWedding.Catalog;

namespace NoStressWedding.Controllers
{       public class ItemListController : Controller
    {
        private MainCatalog context = new MainCatalog();

        //
        // GET: /ItemLists/

        public ViewResult Index()
        {
            return View(context.ItemLists.ToList());
        }

        //
        // GET: /ItemLists/Details/5

        public ViewResult Details(int id)
        {
			ItemList p = context.ItemLists.Single(x => x.ItemListId == id);
            return View(p);
        }

        //
        // GET: /ItemLists/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ItemLists/Create

        [HttpPost]
        public ActionResult Create(ItemList d)
        {
            if (ModelState.IsValid)
            {
              context.ItemLists.Add(d);
              context.SaveChanges();
              return RedirectToAction("Index");  
            }
            return View();
        }
        
        //
        // GET: /ItemLists/Edit/5
 
        public ActionResult Edit(int id)
        {
          ItemList p = context.ItemLists.Single(x => x.ItemListId == id);
             return View(p);
        }

        //
        // POST: /ItemLists/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
          ItemList p = context.ItemLists.Single(x => x.ItemListId == id);
            if (TryUpdateModel(p))
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /ItemLists/Delete/5
 
        public ActionResult Delete(int id)
        {
          ItemList p = context.ItemLists.Single(x => x.ItemListId == id);
            return View(p);
        }

        //
        // POST: /ItemLists/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
          ItemList p = context.ItemLists.Single(x => x.ItemListId == id);
            context.ItemLists.Remove(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
