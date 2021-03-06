﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Check_my_Box.Areas.DBManagement.Catalog;

namespace Check_my_Box {
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
					"Default", // Route name
					"{controller}/{action}/{id}", // URL with parameters
					new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

			#region Area Routing
			// Routing config for the Retentions area
			//routes.CreateArea("HelpDesk", "ProjectName.Areas.HelpDesk.Controllers",
			//DB Area
			routes.MapRoute("DBManagement", "DBManagement/{controller}/{action}",
				new {
					controller = "",
					action = ""
				}
				);

			routes.MapRoute("Authentication", "Authentication/{controller}/{action}",
				new {
					controller = "",
					action = ""
				}
				);
			#endregion
		}

		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			System.Data.Entity.Database.SetInitializer(new MainDBContextInitializer());
		}
	}
}