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
    public class ItemSelectableValueController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemSelectableValue/

        public ViewResult Index()
        {
            return View(context.ItemSelectableValues.Include(itemselectablevalue => itemselectablevalue.ItemSelectable).ToList());
        }

        //
        // GET: /ItemSelectableValue/Details/5

        public ViewResult Details(int id)
        {
			ItemSelectableValue itemselectablevalue = context.ItemSelectableValues.Single(x => x.ItemValueId == id);
            return View(itemselectablevalue);
        }

        //
        // GET: /ItemSelectableValue/Create

        public ActionResult Create()
        {
			ViewBag.PossibleItemSelectables = context.ItemSelectables;
            return View();
        } 

        //
        // POST: /ItemSelectableValue/Create

        [HttpPost]
        public ActionResult Create(ItemSelectableValue itemselectablevalue)
        {
            if (ModelState.IsValid)
            {
				context.ItemSelectableValues.Add(itemselectablevalue);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

			ViewBag.PossibleItemSelectables = context.ItemSelectables;
            return View(itemselectablevalue);
        }
        
        //
        // GET: /ItemSelectableValue/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemSelectableValue itemselectablevalue = context.ItemSelectableValues.Single(x => x.ItemValueId == id);
			ViewBag.PossibleItemSelectables = context.ItemSelectables;
			return View(itemselectablevalue);
        }

        //
        // POST: /ItemSelectableValue/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemSelectableValue itemselectablevalue)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemselectablevalue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.PossibleItemSelectables = context.ItemSelectables;
            return View(itemselectablevalue);
        }

        //
        // GET: /ItemSelectableValue/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemSelectableValue itemselectablevalue = context.ItemSelectableValues.Single(x => x.ItemValueId == id);
            return View(itemselectablevalue);
        }

        //
        // POST: /ItemSelectableValue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSelectableValue itemselectablevalue = context.ItemSelectableValues.Single(x => x.ItemValueId == id);
            context.ItemSelectableValues.Remove(itemselectablevalue);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}