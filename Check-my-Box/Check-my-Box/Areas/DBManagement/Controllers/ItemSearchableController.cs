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
    public class ItemSearchableController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemSearchable/

        public ViewResult Index()
        {
            return View(context.ItemSearchables.Include(itemsearchable => itemsearchable.Category).ToList());
        }

        //
        // GET: /ItemSearchable/Details/5

        public ViewResult Details(int id)
        {
			ItemSearchable itemsearchable = context.ItemSearchables.Single(x => x.Id == id);
            return View(itemsearchable);
        }

        //
        // GET: /ItemSearchable/Create

        public ActionResult Create()
        {
			ViewBag.PossibleCategories = context.Categories;
            return View();
        } 

        //
        // POST: /ItemSearchable/Create

        [HttpPost]
        public ActionResult Create(ItemSearchable itemsearchable)
        {
            if (ModelState.IsValid)
            {
				context.ItemSearchables.Add(itemsearchable);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

						ViewBag.PossibleCategories = context.Categories;
            return View(itemsearchable);
        }
        
        //
        // GET: /ItemSearchable/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemSearchable itemsearchable = context.ItemSearchables.Single(x => x.Id == id);
			ViewBag.PossibleCategories = context.Categories;
			return View(itemsearchable);
        }

        //
        // POST: /ItemSearchable/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemSearchable itemsearchable)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemsearchable).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
						ViewBag.PossibleCategories = context.Categories;
            return View(itemsearchable);
        }

        //
        // GET: /ItemSearchable/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemSearchable itemsearchable = context.ItemSearchables.Single(x => x.Id == id);
            return View(itemsearchable);
        }

        //
        // POST: /ItemSearchable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSearchable itemsearchable = context.ItemSearchables.Single(x => x.Id == id);
            context.ItemSearchables.Remove(itemsearchable);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}