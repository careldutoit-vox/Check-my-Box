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
    public class ItemController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /Item/

        public ViewResult Index()
        {
            return View(context.Items.ToList());
        }

        //
        // GET: /Item/Details/5

        public ViewResult Details(int id)
        {
			Item item = context.Items.Single(x => x.Id == id);
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
				context.Items.Add(item);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(item);
        }
        
        //
        // GET: /Item/Edit/5
 
        public ActionResult Edit(int id)
        {
			Item item = context.Items.Single(x => x.Id == id);
			return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
				context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //
        // GET: /Item/Delete/5
 
        public ActionResult Delete(int id)
        {
			Item item = context.Items.Single(x => x.Id == id);
            return View(item);
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = context.Items.Single(x => x.Id == id);
            context.Items.Remove(item);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}