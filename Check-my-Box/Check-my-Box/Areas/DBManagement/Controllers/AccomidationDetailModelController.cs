using System.Linq;
using System.Web.Mvc;
using Check_my_Box.Areas.DBManagement.Catalog;
using Check_my_Box.Areas.DBManagement.Models;

namespace Check_my_Box.Areas.DBManagement.Controllers {
	public class AccomidationDetailModelController: Controller {
		private readonly MainDBCatalog context = new MainDBCatalog();

		//
		// GET: /AccomidationDetailModels/

		public ViewResult Index() {
			return View(context.AccomidationDetailModels.ToList());
		}

		//
		// GET: /AccomidationDetailModels/Details/5

		public ViewResult Details(int id) {
			AccomidationDetailModel p = context.AccomidationDetailModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// GET: /AccomidationDetailModels/Create

		public ActionResult Create() {
			return View();
		}

		//
		// POST: /AccomidationDetailModels/Create

		[HttpPost]
		public ActionResult Create(AccomidationDetailModel d) {
			if (ModelState.IsValid) {
				context.AccomidationDetailModels.Add(d);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /AccomidationDetailModels/Edit/5

		public ActionResult Edit(int id) {
			AccomidationDetailModel p = context.AccomidationDetailModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// POST: /AccomidationDetailModels/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection form) {
			AccomidationDetailModel p = context.AccomidationDetailModels.Single(x => x.Id == id);
			if (TryUpdateModel(p)) {
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		//
		// GET: /AccomidationDetailModels/Delete/5

		public ActionResult Delete(int id) {
			AccomidationDetailModel p = context.AccomidationDetailModels.Single(x => x.Id == id);
			return View(p);
		}

		//
		// POST: /AccomidationDetailModels/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection) {
			AccomidationDetailModel p = context.AccomidationDetailModels.Single(x => x.Id == id);
			context.AccomidationDetailModels.Remove(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}