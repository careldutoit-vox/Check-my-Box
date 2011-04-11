using System.Web.Mvc;

namespace Check_my_Box.Areas.DBManagement {
	public class DBManagementAreaRegistration: AreaRegistration {
		public override string AreaName {
			get { return "DBManagement"; }
		}

		public override void RegisterArea(AreaRegistrationContext context) {
			context.MapRoute(
				"DBManagement_default",
				"DBManagement/{controller}/{action}/{id}",
				new {
					action = "Index",
					id = UrlParameter.Optional
				}
				);
		}
	}
}