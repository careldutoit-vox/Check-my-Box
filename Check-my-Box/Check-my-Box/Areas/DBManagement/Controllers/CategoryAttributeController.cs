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
    public class CategoryAttributeController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /CategoryAttribute/

        public ViewResult Index()
        {
            return View(context.CategoryAttributes.ToList());
        }

        //
        // GET: /CategoryAttribute/Details/5

        public ViewResult Details(int id)
        {
			CategoryAttribute categoryattribute = context.CategoryAttributes.Single(x => x.CategoryAttributeId == id);
            return View(categoryattribute);
        }

        //
        // GET: /CategoryAttribute/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CategoryAttribute/Create

        [HttpPost]
        public ActionResult Create(CategoryAttribute categoryattribute)
        {
            if (ModelState.IsValid)
            {
				context.CategoryAttributes.Add(categoryattribute);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(categoryattribute);
        }
        
        //
        // GET: /CategoryAttribute/Edit/5
 
        public ActionResult Edit(int id)
        {
			CategoryAttribute categoryattribute = context.CategoryAttributes.Single(x => x.CategoryAttributeId == id);
			return View(categoryattribute);
        }

        //
        // POST: /CategoryAttribute/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoryAttribute categoryattribute)
        {
            if (ModelState.IsValid)
            {
				context.Entry(categoryattribute).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryattribute);
        }

        //
        // GET: /CategoryAttribute/Delete/5
 
        public ActionResult Delete(int id)
        {
			CategoryAttribute categoryattribute = context.CategoryAttributes.Single(x => x.CategoryAttributeId == id);
            return View(categoryattribute);
        }

        //
        // POST: /CategoryAttribute/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryAttribute categoryattribute = context.CategoryAttributes.Single(x => x.CategoryAttributeId == id);
            context.CategoryAttributes.Remove(categoryattribute);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}