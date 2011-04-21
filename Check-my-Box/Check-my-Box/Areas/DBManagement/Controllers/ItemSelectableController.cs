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
    public class ItemSelectableController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /ItemSelectable/

        public ViewResult Index()
        {
            return View(context.ItemSelectables.ToList());
        }

        //
        // GET: /ItemSelectable/Details/5

        public ViewResult Details(int id)
        {
			ItemSelectable itemselectable = context.ItemSelectables.Single(x => x.Id == id);
            return View(itemselectable);
        }

        //
        // GET: /ItemSelectable/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ItemSelectable/Create

        [HttpPost]
        public ActionResult Create(ItemSelectable itemselectable)
        {
            if (ModelState.IsValid)
            {
				context.ItemSelectables.Add(itemselectable);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(itemselectable);
        }
        
        //
        // GET: /ItemSelectable/Edit/5
 
        public ActionResult Edit(int id)
        {
			ItemSelectable itemselectable = context.ItemSelectables.Single(x => x.Id == id);
			return View(itemselectable);
        }

        //
        // POST: /ItemSelectable/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemSelectable itemselectable)
        {
            if (ModelState.IsValid)
            {
				context.Entry(itemselectable).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemselectable);
        }

        //
        // GET: /ItemSelectable/Delete/5
 
        public ActionResult Delete(int id)
        {
			ItemSelectable itemselectable = context.ItemSelectables.Single(x => x.Id == id);
            return View(itemselectable);
        }

        //
        // POST: /ItemSelectable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSelectable itemselectable = context.ItemSelectables.Single(x => x.Id == id);
            context.ItemSelectables.Remove(itemselectable);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}