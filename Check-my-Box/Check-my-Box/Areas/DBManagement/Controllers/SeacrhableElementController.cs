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
    public class SeacrhableElementController : Controller
    {
        private MainDBCatalog context = new MainDBCatalog();

        //
        // GET: /SeacrhableElement/

        public ViewResult Index()
        {
            return View(context.SearchableElements.Include(searchableelement => searchableelement.Categorys).Include(searchableelement => searchableelement.CategoryAttributeValues).ToList());
        }

        //
        // GET: /SeacrhableElement/Details/5

        public ViewResult Details(int id)
        {
			SearchableElement searchableelement = context.SearchableElements.Single(x => x.SearchableElementId == id);
            return View(searchableelement);
        }

        //
        // GET: /SeacrhableElement/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SeacrhableElement/Create

        [HttpPost]
        public ActionResult Create(SearchableElement searchableelement)
        {
            if (ModelState.IsValid)
            {
				context.SearchableElements.Add(searchableelement);
				context.SaveChanges();
				return RedirectToAction("Index");  
            }

            return View(searchableelement);
        }
        
        //
        // GET: /SeacrhableElement/Edit/5
 
        public ActionResult Edit(int id)
        {
			SearchableElement searchableelement = context.SearchableElements.Single(x => x.SearchableElementId == id);
			return View(searchableelement);
        }

        //
        // POST: /SeacrhableElement/Edit/5

        [HttpPost]
        public ActionResult Edit(SearchableElement searchableelement)
        {
            if (ModelState.IsValid)
            {
				context.Entry(searchableelement).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchableelement);
        }

        //
        // GET: /SeacrhableElement/Delete/5
 
        public ActionResult Delete(int id)
        {
			SearchableElement searchableelement = context.SearchableElements.Single(x => x.SearchableElementId == id);
            return View(searchableelement);
        }

        //
        // POST: /SeacrhableElement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SearchableElement searchableelement = context.SearchableElements.Single(x => x.SearchableElementId == id);
            context.SearchableElements.Remove(searchableelement);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}