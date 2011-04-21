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
    public class ItemSearchableValueController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemSearchableValue/

        public ViewResult Index()
        {
            return View(context.ItemSearchableValues.Include(itemsearchablevalue => itemsearchablevalue.ItemSearchable).Include(itemsearchablevalue => itemsearchablevalue.SearchableElement).ToList());
        }

        //
        // GET: /ItemSearchableValue/Details/5

        public ViewResult Details(int id)
        {
			ItemSearchableValue itemsearchablevalue = context.ItemSearchableValues.Single(x => x.ItemValueId == id);
            return View(itemsearchablevalue);
        }

        //
        // GET: /ItemSearchableValue/Create

        public ActionResult Create()
        {
			ViewBag.PossibleItemSearchables = context.ItemSearchables;
			ViewBag.PossibleSearchableElements = context.SearchableElements;
            return View();
        } 

        //
        // POST: /ItemSearchableValue/Create

        [HttpPost]
        public ActionResult Create(ItemSearchableValue itemsearchablevalue)
        {
            if (ModelState.IsValid)
            {
				context.ItemSearchableValues.Add(itemsearchablevalue);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

			ViewBag.PossibleItemSearchables = context.ItemSearchables;
			ViewBag.PossibleSearchableElements = context.SearchableElements;
            return View(itemsearchablevalue);
        }
        
        //
        // GET: /ItemSearchableValue/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemSearchableValue itemsearchablevalue = context.ItemSearchableValues.Single(x => x.ItemValueId == id);
			ViewBag.PossibleItemSearchables = context.ItemSearchables;
			ViewBag.PossibleSearchableElements = context.SearchableElements;
			return View(itemsearchablevalue);
        }

        //
        // POST: /ItemSearchableValue/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemSearchableValue itemsearchablevalue)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemsearchablevalue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.PossibleItemSearchables = context.ItemSearchables;
			ViewBag.PossibleSearchableElements = context.SearchableElements;
            return View(itemsearchablevalue);
        }

        //
        // GET: /ItemSearchableValue/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemSearchableValue itemsearchablevalue = context.ItemSearchableValues.Single(x => x.ItemValueId == id);
            return View(itemsearchablevalue);
        }

        //
        // POST: /ItemSearchableValue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSearchableValue itemsearchablevalue = context.ItemSearchableValues.Single(x => x.ItemValueId == id);
            context.ItemSearchableValues.Remove(itemsearchablevalue);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}