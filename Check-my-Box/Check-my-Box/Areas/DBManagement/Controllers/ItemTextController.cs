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
    public class ItemTextController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemText/

        public ViewResult Index()
        {
            return View(context.ItemTexts.ToList());
        }

        //
        // GET: /ItemText/Details/5

        public ViewResult Details(int id)
        {
			ItemText itemtext = context.ItemTexts.Single(x => x.Id == id);
            return View(itemtext);
        }

        //
        // GET: /ItemText/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ItemText/Create

        [HttpPost]
        public ActionResult Create(ItemText itemtext)
        {
            if (ModelState.IsValid)
            {
				context.ItemTexts.Add(itemtext);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(itemtext);
        }
        
        //
        // GET: /ItemText/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemText itemtext = context.ItemTexts.Single(x => x.Id == id);
			return View(itemtext);
        }

        //
        // POST: /ItemText/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemText itemtext)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemtext).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemtext);
        }

        //
        // GET: /ItemText/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemText itemtext = context.ItemTexts.Single(x => x.Id == id);
            return View(itemtext);
        }

        //
        // POST: /ItemText/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemText itemtext = context.ItemTexts.Single(x => x.Id == id);
            context.ItemTexts.Remove(itemtext);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}