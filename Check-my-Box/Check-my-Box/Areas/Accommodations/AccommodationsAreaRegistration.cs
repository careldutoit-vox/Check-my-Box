using System.Web.Mvc;

namespace Check_my_Box.Areas.Accommodations {
	public class AccommodationsAreaRegistration: AreaRegistration {
		public override string AreaName {
			get { return "Accommodations"; }
		}

		public override void RegisterArea(AreaRegistrationContext context) {
			context.MapRoute(
				"Accommodations_default",
				"Accommodations/{controller}/{action}/{id}",
				new {
					action = "Index",
					id = UrlParameter.Optional
				}
				);
		}
	}
}