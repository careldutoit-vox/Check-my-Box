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
    public class ItemTextValueController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemTextValue/

        public ViewResult Index()
        {
            return View(context.ItemTextValues.Include(itemtextvalue => itemtextvalue.ItemText).ToList());
        }

        //
        // GET: /ItemTextValue/Details/5

        public ViewResult Details(int id)
        {
			ItemTextValue itemtextvalue = context.ItemTextValues.Single(x => x.ItemValueId == id);
            return View(itemtextvalue);
        }

        //
        // GET: /ItemTextValue/Create

        public ActionResult Create()
        {
			ViewBag.PossibleItemTexts = context.ItemTexts;
            return View();
        } 

        //
        // POST: /ItemTextValue/Create

        [HttpPost]
        public ActionResult Create(ItemTextValue itemtextvalue)
        {
            if (ModelState.IsValid)
            {
				context.ItemTextValues.Add(itemtextvalue);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

			ViewBag.PossibleItemTexts = context.ItemTexts;
            return View(itemtextvalue);
        }
        
        //
        // GET: /ItemTextValue/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemTextValue itemtextvalue = context.ItemTextValues.Single(x => x.ItemValueId == id);
			ViewBag.PossibleItemTexts = context.ItemTexts;
			return View(itemtextvalue);
        }

        //
        // POST: /ItemTextValue/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemTextValue itemtextvalue)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemtextvalue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.PossibleItemTexts = context.ItemTexts;
            return View(itemtextvalue);
        }

        //
        // GET: /ItemTextValue/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemTextValue itemtextvalue = context.ItemTextValues.Single(x => x.ItemValueId == id);
            return View(itemtextvalue);
        }

        //
        // POST: /ItemTextValue/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemTextValue itemtextvalue = context.ItemTextValues.Single(x => x.ItemValueId == id);
            context.ItemTextValues.Remove(itemtextvalue);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}