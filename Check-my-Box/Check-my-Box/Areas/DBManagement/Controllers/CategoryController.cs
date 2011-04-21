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
    public class CategoryController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /Category/

        public ViewResult Index()
        {
            return View(context.Categories.ToList());
        }

        //
        // GET: /Category/Details/5

        public ViewResult Details(int id)
        {
			Category category = context.Categories.Single(x => x.CategoryId == id);
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
				context.Categories.Add(category);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(category);
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
			Category category = context.Categories.Single(x => x.CategoryId == id);
			return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
				context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
			Category category = context.Categories.Single(x => x.CategoryId == id);
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = context.Categories.Single(x => x.CategoryId == id);
            context.Categories.Remove(category);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}