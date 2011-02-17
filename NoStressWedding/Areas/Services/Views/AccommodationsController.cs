using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoStressWedding.Areas.Accommodations.Controllers {
  public class AccommodationsController : Controller {
    public ActionResult Accommodation() {

      return View();
    }
    //
    // GET: /Accommodations/Accommodations/

    public ActionResult Index() {
      return View();
    }

    //
    // GET: /Accommodations/Accommodations/Details/5

    public ActionResult Details(int id) {
      return View();
    }

    //
    // GET: /Accommodations/Accommodations/Create

    public ActionResult Create() {
      return View();
    }

    //
    // POST: /Accommodations/Accommodations/Create

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
    // GET: /Accommodations/Accommodations/Edit/5

    public ActionResult Edit(int id) {
      return View();
    }

    //
    // POST: /Accommodations/Accommodations/Edit/5

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
    // GET: /Accommodations/Accommodations/Delete/5

    public ActionResult Delete(int id) {
      return View();
    }

    //
    // POST: /Accommodations/Accommodations/Delete/5

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
