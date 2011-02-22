using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoStressWedding.Areas.Services.Controllers {
  public class MainController : Controller {
    //
    // GET: /Services/Main/

    public ActionResult CheckList() {
      MainCatalog mainCatalog = new MainCatalog();

      return View(mainCatalog);
    }

    public ActionResult ListView() {
      MainCatalog mainCatalog = new MainCatalog();

      return View(mainCatalog);
    }
    //
    // GET: /Services/Main/Details/5

    public ActionResult Details(int id) {
      return View();
    }

    //
    // GET: /Services/Main/Create

    public ActionResult Create() {
      return View();
    }

    //
    // POST: /Services/Main/Create

    [HttpPost]
    public ActionResult Create(FormCollection collection) {
      try {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    //
    // GET: /Services/Main/Edit/5

    public ActionResult Edit(int id) {
      return View();
    }

    //
    // POST: /Services/Main/Edit/5

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) {
      try {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }

    //
    // GET: /Services/Main/Delete/5

    public ActionResult Delete(int id) {
      return View();
    }

    //
    // POST: /Services/Main/Delete/5

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection) {
      try {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      } catch {
        return View();
      }
    }
  }
}
