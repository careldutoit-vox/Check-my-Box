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
    public class ItemValueController : Controller
    {
			private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemValue/

        public ViewResult Index()
        {
            return View(context.ItemValues.ToList());
        }

        //
        // GET: /ItemValue/Details/5

        public ViewResult Details(int id)
        {
			ItemValue itemvalue = context.ItemValues.Single(x => x.ItemValueId == id);
            return View(itemvalue);
        }

        //
        // GET: /ItemValue/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ItemValue/Create

        [HttpPost]
        public ActionResult Create(ItemValue itemvalue)
        {
            if (ModelState.IsValid)
            {
				context.ItemValues.Add(itemvalue);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(itemvalue);
        }
        
        //
        // GET: /ItemValue/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemValue itemvalue = context.ItemValues.Single(x => x.ItemValueId == id);
			return View(itemvalue);
        }

        //
        // POST: /ItemValue/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemValue itemvalue)
        {
            if (ModelState.IsValid)
            {
				//context.Entry(itemvalue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemvalue);
        }

        //
        // GET: /ItemValue/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemValue itemvalue = context.ItemValues.Single(x => x.ItemValueId == id);
            return View(itemvalue);
        }

        //
        // POST: /ItemValue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemValue itemvalue = context.ItemValues.Single(x => x.ItemValueId == id);
            context.ItemValues.Remove(itemvalue);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}