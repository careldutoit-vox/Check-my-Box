using System.Linq;
using System.Web.Mvc;
using Check_my_Box.Areas.DBManagement.Catalog;
using Check_my_Box.Areas.DBManagement.Models;

namespace Check_my_Box.Areas.DBManagement.Controllers {
	public class AccomidationModelController: Controller {
		private readonly MainDBCatalog context = new MainDBCatalog();

		//
		// GET: /AccomidationModels/

		public ViewResult Index() {
			return View(context.AccomidationModels.ToList());
		}

		//
		// GET: /AccomidationModels/Details/5

		public ViewResult Details(int id) {
			AccomidationModel p = context.AccomidationModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// GET: /AccomidationModels/Create

		public ActionResult Create() {
			return View();
		}

		//
		// POST: /AccomidationModels/Create

		[HttpPost]
		public ActionResult Create(AccomidationModel d) {
			if (ModelState.IsValid) {
				context.AccomidationModels.Add(d);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /AccomidationModels/Edit/5

		public ActionResult Edit(int id) {
			AccomidationModel p = context.AccomidationModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// POST: /AccomidationModels/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection form) {
			AccomidationModel p = context.AccomidationModels.Single(x => x.Id == id);
			if (TryUpdateModel(p)) {
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /AccomidationModels/Delete/5

		public ActionResult Delete(int id) {
			AccomidationModel p = context.AccomidationModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// POST: /AccomidationModels/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection) {
			AccomidationModel p = context.AccomidationModels.Single(x => x.Id == id);
			context.AccomidationModels.Remove(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}